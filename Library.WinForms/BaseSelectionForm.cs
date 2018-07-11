#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Library;

#endregion

namespace Library.WinForms
{
    public partial class BaseSelectionForm : Form, IBaseSelectionForm
    {
        private const int ScrollBarWidth = 15;

        public BaseSelectionForm()
        {
            InitializeComponent();
            SetOffsetSizes();
        }

        private Size _offSetSize = Size.Empty;
        private ISelectionPanel _selectionPanel = null;
        private bool _addScrollBarWidth = true;

        [Description("A panel containing the list of objects to be selected.")]
        public ISelectionPanel SelectionPanel
        {
            get { return _selectionPanel; }

            protected set { _selectionPanel = value; }
        }

        [Description("The item selected by the user.")]
        public ISelectableDataEntry ItemSelected
        {
            get { return _selectionPanel.SelectedItem; }
        }

        [Description("True to add a scroll bar width when resizing this control.")]
        public bool AddScrollBarWidth
        {
            get { return _addScrollBarWidth; }

            set { _addScrollBarWidth = value; }
        }

        /// <summary>
        /// Sets the offset size between the form and the input panel.
        /// </summary>
        /// 
        /// <remarks>
        /// This method should be run from the constructor to determine the correct
        /// offset.  The offset size is used after a new panel has been added to
        /// the form.
        /// </remarks>
        /// 
        protected void SetOffsetSizes()
        {
            _offSetSize = new Size(Width - panelSelectionPanelHolder.Width, Height - panelSelectionPanelHolder.Height);
        }

        /// <summary>
        /// Displays an error message to the user in a dialog box.
        /// </summary>
        /// 
        /// <param name="Message">
        /// The message to display to the user.
        /// </param>
        /// 
        protected virtual void ShowError(string Message)
        {
            MessageBox.Show(this, Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Called after a selection panel is dropped onto the form.  Adjusts the
        /// size of the form to fit the dropped selection panel.
        /// </summary>
        /// 
        /// <remarks>
        /// Assumes the NewPanel has already been verified to be an ISelectionPanel
        /// object.
        /// </remarks>
        /// 
        /// <param name="NewPanel">
        /// The panel dropped on the form.  Must implement the ISelectionPanel 
        /// interface.
        /// </param>
        /// 
        private void AddSelectionPanel(Control NewPanel)
        {
            Debug.Assert(NewPanel is ISelectionPanel, "The parameter to AddSelectionPanel must be an ISelectionPanel.");

            SelectionPanel = NewPanel as ISelectionPanel;
            Width = NewPanel.Width + _offSetSize.Width + (AddScrollBarWidth ? ScrollBarWidth : 0);
            Height = NewPanel.Height + _offSetSize.Height;
            SelectionPanel.ItemDoubleClicked += SelectionPanel_ItemDoubleClicked;
            (SelectionPanel as Control).Width = panelSelectionPanelHolder.Width;
            (SelectionPanel as Control).Location = new Point(0, 0); //  Does not work!!!  Why?
        }

        /// <summary>
        /// Called when the user has selected an item either by double clicking 
        /// it or selecting it then clicking the Select button.  This method
        /// merely sets the result value and closes the form.
        /// </summary>
        /// 
        private void UserSelectedItem()
        {
            if (SelectionPanel.SelectedItem == null)
            {
                ShowError("Please select an item from the list.");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void panelSelectionPanelHolder_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is ISelectionPanel)
            {
                AddSelectionPanel(e.Control);
            }
            else
            {
                //  Prevent any other kind of controls being added to the panel.

                panelSelectionPanelHolder.Controls.Remove(e.Control);
            }
        }

        private void SelectionPanel_ItemDoubleClicked(object sender, ControlSelectedEventArgs e)
        {
            UserSelectedItem();
        }

        private void imageButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imageButtonSelect_Click(object sender, EventArgs e)
        {
            UserSelectedItem();
        }
    }
}