#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    /// <summary>
    /// Use this form for basic data entry tasks.  This form works closely with
    /// an input panel to perform its tasks.  Create the input panel for the 
    /// data first and then add it to a derived version of this form.
    /// </summary>
    /// 
    /// <remarks>
    /// To use this form, follow these steps:
    /// 
    /// 1. Create the input panel for the data.
    ///     - use the BaseDataPanel object as the base object for the panel
    ///     - if you do not use the BaseDataPanel object, the panel with the 
    ///       editing controls must implement IInputPanel
    ///     - this form can handle the basic editing functions (add, edit and
    ///       delete) through the IInputPanel interface
    /// 2. Drop the data input panel onto the panelInputPanelHolder object.
    ///     - it will automatically resize the holder panel and the form
    ///     - you may need to move the input panel to the top left corner of
    ///       the holder panel
    /// 3. When using this form (or its derived children) ensure the DataEntryType
    ///    property is set up correctly and use the EntryPanel's SourceInfo 
    ///    property to set the data entry panel up.
    /// 
    /// Notes:
    /// 
    /// - If you add controls to a form inherited from this one, it is recommended
    ///   you call the SetOffsetSizes() method in the inherited form's constructor.
    /// - If you need to do something with the base add, edit or delete actions,
    ///   override the appropriate methods in your input panel
    /// </remarks>
    /// 
    public partial class BaseDataEntryForm : Form, IBaseDataEntryForm
    {
        public BaseDataEntryForm()
        {
            InitializeComponent();
            SetOffsetSizes();
        }

        public BaseDataEntryForm(EntryType DataEntryType) : this()
        {
            this.DataEntryType = DataEntryType;
        }

        private EntryType _dataEntryType = EntryType.Add;
        private Size _offSetSize = Size.Empty;

        [Description("A panel control containing the objects to input data.")]
        public IInputPanel EntryPanel { get; set; }

        [Description("Specifies the entry type of the form.")]
        public EntryType DataEntryType
        {
            get { return _dataEntryType; }

            set
            {
                _dataEntryType = value;
                SetActionButtonIcon();
                EntryPanel.DataEntryType = value;
            }
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
            _offSetSize = new Size(Width - panelInputPanelHolder.Width, Height - panelInputPanelHolder.Height);
        }

        /// <summary>
        /// Sets the icon of the action button based on the current data 
        /// entry type.
        /// </summary>
        /// 
        private void SetActionButtonIcon()
        {
            imageButtonAction.Visible = true;
            switch (DataEntryType)
            {
                case EntryType.Add:
                    imageButtonAction.ButtonImage = Properties.Resources.add;
                    imageButtonAction.DisabledImage = Properties.Resources.add_disabled;
                    imageButtonAction.TooltipText = "Add";
                    break;

                case EntryType.Delete:
                    imageButtonAction.ButtonImage = Properties.Resources.delete;
                    imageButtonAction.DisabledImage = Properties.Resources.delete_disabled;
                    imageButtonAction.TooltipText = "Delete";
                    break;

                case EntryType.Edit:
                    imageButtonAction.ButtonImage = Properties.Resources.save_as;
                    imageButtonAction.DisabledImage = Properties.Resources.save_as_disabled;
                    imageButtonAction.TooltipText = "Save";
                    break;

                case EntryType.None:
                    imageButtonAction.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Resizes the form based on the newly added IInputPanel.
        /// </summary>
        /// 
        /// <param name="NewPanel">
        /// The recently added IInputPanel object.
        /// </param>
        /// 
        private void AddInputPanel(Control NewPanel)
        {
            EntryPanel = NewPanel as IInputPanel;
            Width = NewPanel.Width + _offSetSize.Width;
            Height = NewPanel.Height + _offSetSize.Height;
            NewPanel.Location = new Point(0, 0); //  Does not work!!!  Why?
        }

        /// <summary>
        /// Performs the add, save and delete actions for the current data based
        /// on the data entry type.
        /// </summary>
        /// 
        /// <remarks>
        /// If the current action is successful, a DialogResult of OK is returned
        /// from the ShowDialog method.  If not, the Cancel value is returned.
        /// </remarks>
        /// 
        private void DoCurrentAction()
        {
            if (DataEntryType == EntryType.Delete)
            {
                if (MessageBox.Show(this,
                                    "Are you sure you want to delete this information?",
                                    "Confirmation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (EntryPanel.DeleteData())
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        ShowError(EntryPanel.ActionError);
                    }
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else if (EntryPanel.VerifyInput())
            {
                if (EntryPanel.SaveData())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowError(EntryPanel.ActionError);
                }
            }
            else
            {
                ShowError(EntryPanel.EntryError);
            }
        }

        /// <summary>
        /// Calls the method to perform the add, modify or delete on the information.
        /// </summary>
        /// 
        private void imageButtonAction_Click(object sender, EventArgs e)
        {
            Debug.Assert(EntryPanel != null, "Entry panel object is null.");

            DoCurrentAction();
        }

        /// <summary>
        /// Ensures only IInputPanel controls are added to the input panel
        /// holder control.  Resizes the form based on the size of the added
        /// input panel.
        /// </summary>
        /// 
        private void panelInputPanelHolder_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is IInputPanel)
            {
                AddInputPanel(e.Control);
            }
            else
            {
                //  Prevent any other kind of controls being added to the panel.

                panelInputPanelHolder.Controls.Remove(e.Control);
            }
        }

        /// <summary>
        /// Closes the form and returns a dialog result of Cancel.
        /// </summary>
        /// 
        private void imageButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}