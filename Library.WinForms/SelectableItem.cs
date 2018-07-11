#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    /// <summary>
    /// A class to be used in lists where items need to be selected by the user.
    /// </summary>
    /// 
    public partial class SelectableItem : UserControl, ISelectable
    {
        public SelectableItem()
        {
            InitializeComponent();
            Init();
        }

        private Color _origBackColor;
        private Color _origForeColor;
        private Color _selectedBackColour = SystemColors.Highlight;
        private Color _selectedForeColour = SystemColors.HighlightText;

        private List<Control> _excludedControls = new List<Control>();

        private bool _isSelected = false;

        /// <summary>
        /// Gets/sets the selected status of the job item.
        /// </summary>
        /// 
        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                _isSelected = value;
                SetHighlight();
                if (_isSelected)
                {
                    OnControlSelected();
                }
                else
                {
                    OnControlUnSelected();
                }
            }
        }

        /// <summary>
        /// The background colour of the controls when this control is selected.
        /// </summary>
        /// 
        [Description("The background colour of the controls when this control is selected.")]
        public Color SelectedBackColour
        {
            get { return _selectedBackColour; }

            set { _selectedBackColour = value; }
        }

        /// <summary>
        /// The foreground colour for the text of the control when it is selected.
        /// </summary>
        /// 
        [Description("The foreground colour for the text of the control when it is selected.")]
        public Color SelectedForeColour
        {
            get { return _selectedForeColour; }

            set { _selectedForeColour = value; }
        }

        /// <summary>
        /// Fired when the user selects this control.
        /// </summary>
        /// 
        [Description("Fired when the user selects this control.")]
        public event ControlSelectedEventHandler ControlSelected;

        /// <summary>
        /// Fired when the user unselects this control.
        /// </summary>
        /// 
        [Description("Fired when the user unselects this control.")]
        public event ControlSelectedEventHandler ControlUnSelected;

        /// <summary>
        /// Fired when the user double clicks this control.
        /// </summary>
        /// 
        [Description("Fired when the user double clicks this control.")]
        public event ControlSelectedEventHandler ControlDoubleClicked;

        /// <summary>
        /// Stores the original colours for the control and the time labels
        /// for later restoration.  Sets up a handler for every control 
        /// contained in this custom control.
        /// </summary>
        /// 
        private void Init()
        {
            _origBackColor = BackColor;
            _origForeColor = ForeColor;

            //  Set the click handler for the base object in case the user
            //    clicks an area that has no control on it.

            MouseClick += new MouseEventHandler(AllControls_MouseClick);
            SetClickHandler(Controls);
        }

        /// <summary>
        /// Displays an error message to the user in a dialog box.
        /// </summary>
        /// 
        /// <param name="Message">
        /// The message to display to the user.
        /// </param>
        /// 
        protected void ShowError(string Message)
        {
            MessageBox.Show(FindForm(), Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Adds a control to a list for controls that should not have a click 
        /// handler for selecting this object.
        /// </summary>
        /// 
        /// <param name="ControlToExclude">
        /// The control to not add a click handler for.
        /// </param>
        /// 
        protected void AddToExcludedList(Control ControlToExclude)
        {
            _excludedControls.Add(ControlToExclude);
        }

        /// <summary>
        /// Sets up a handler to change the selection status of this control
        /// when the user clicks on it.  Every control gets the same handler
        /// so that it works regardless of the area clicked.
        /// </summary>
        /// 
        /// <remarks>
        /// This method should be called in every derived class' constructor
        /// after the derived class' call to InitializeComponent.
        /// </remarks>
        /// 
        /// <param name="ControlsToHandle">
        /// A collection of the controls to add the click handler.
        /// </param>
        /// 
        protected void SetClickHandler(ControlCollection ControlsToHandle)
        {
            foreach (Control currControl in ControlsToHandle)
            {
                if (!_excludedControls.Contains(currControl))
                {
                    currControl.MouseClick += new MouseEventHandler(AllControls_MouseClick);
                    currControl.MouseDoubleClick += new MouseEventHandler(AllControls_MouseDoubleClick);

                    if (currControl.Controls.Count > 0)
                    {
                        SetClickHandler(currControl.Controls);
                    }
                }
            }
        }

        /// <summary>
        /// Fires the ControlSelected event only when the control is selected.
        /// </summary>
        /// 
        private void OnControlSelected()
        {
            if (ControlSelected != null)
            {
                ControlSelected(this, new ControlSelectedEventArgs(this));
            }
        }

        /// <summary>
        /// Fires the ControlUnSelected event when the user unselects the control.
        /// </summary>
        /// 
        private void OnControlUnSelected()
        {
            if (ControlUnSelected != null)
            {
                ControlUnSelected(this, new ControlSelectedEventArgs(this));
            }
        }

        /// <summary>
        /// Fires the ControlDoubleClicked event when the user double clicks the
        /// control with the mouse.
        /// </summary>
        /// 
        private void OnControlDoubleClicked()
        {
            if (ControlDoubleClicked != null)
            {
                ControlDoubleClicked(this, new ControlSelectedEventArgs(this));
            }
        }

        /// <summary>
        /// Changes the colours of this control to match the value in the 
        /// IsSelected property.
        /// </summary>
        /// 
        protected virtual void SetHighlight()
        {
            BackColor = IsSelected ? SelectedBackColour : _origBackColor;
            ForeColor = IsSelected ? SelectedForeColour : _origForeColor;
        }

        /// <summary>
        /// Changes the colours of this control to their original colours.
        /// </summary>
        /// 
        protected void TurnOffHighlight()
        {
            BackColor = _origBackColor;
            ForeColor = _origForeColor;
        }

        /// <summary>
        /// Flips the IsSelected status when any control is clicked by the 
        /// left mouse button.
        /// </summary>
        /// 
        private void AllControls_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsSelected = !IsSelected;
            }
        }

        /// <summary>
        /// Selects this control then fires the double click event.
        /// </summary>
        /// 
        private void AllControls_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsSelected = true;
                OnControlDoubleClicked();
            }
        }
    }
}