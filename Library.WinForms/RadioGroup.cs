#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class RadioGroup : UserControl, IDataEntryControl
    {
        public RadioGroup()
        {
            InitializeComponent();
            GetInitialOffSets();
        }

        private List<RadioButton> _buttons = new List<RadioButton>();
        private RadioButton _selectedButton = null;
        private bool _surpressResize = false;
        private Size _borderPanelOffset = Size.Empty;
        private Size _buttonPanelOffset = Size.Empty;
        private bool _isMandatory = false;
        private bool _showIndicator = true;

        [Description("Indicates whether the RadioGroup should have a border.")]
        public BorderStyle GroupBorderStyle
        {
            get { return panelGroup.BorderStyle; }

            set { panelGroup.BorderStyle = value; }
        }

        [Description("The radio buttons in the group.")]
        public RadioButton[] Buttons
        {
            get { return _buttons.ToArray(); }

            set
            {
                ResetButtons();
                AddButtonRange(value);
            }
        }

        [Description("The total number of buttons in the group.")]
        public int ButtonCount
        {
            get { return _buttons.Count; }

            set
            {
                if (value >= 0)
                {
                    if (value > _buttons.Count)
                    {
                        AddNewButtons(value - _buttons.Count);
                    }
                    else if (value < _buttons.Count)
                    {
                        RemoveOldButtons(value);
                    }
                }
            }
        }

        [Description("The text assigned to the button that the user checked.")]
        public string SelectedText
        {
            get { return (_selectedButton != null ? _selectedButton.Text : ""); }

            set
            {
                if (value != "")
                {
                    foreach (RadioButton currButton in _buttons)
                    {
                        if (currButton.Text.ToLower() == value.Trim().ToLower())
                        {
                            currButton.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        [Description("Set this to true to show an asterisk by the description when a field is mandatory.")]
        public bool ShowIndicator
        {
            get { return _showIndicator; }

            set
            {
                _showIndicator = value;
                labelIndicator.Visible = (_isMandatory && _showIndicator);
            }
        }

        #region IDataEntryControl Members

        [Description("Text describing the RadioGroup.")]
        public string Descriptor
        {
            get { return labelHeader.Text.Trim(); }

            set
            {
                if (value != null)
                {
                    labelHeader.Text = " " + value.Trim() + " ";
                    MoveIndicatorLabel();
                }
            }
        }

        [Description("True if this field must have some input.")]
        public bool IsMandatory
        {
            get { return _isMandatory; }

            set
            {
                _isMandatory = value;
                labelIndicator.Visible = (_isMandatory && _showIndicator);
            }
        }

        [Description("True if one of the buttons has been selected.")]
        public bool HasValue
        {
            get { return SelectedText != ""; }
        }

        /// <summary>
        /// Returns true if this control's value is not mandatory or true when 
        /// the user has selected a button when the value is mandatory.
        /// </summary>
        /// 
        /// <returns>
        /// False indicating the user still needs to select a button or true otherwise.
        /// </returns>
        /// 
        public bool HasRequiredInput()
        {
            bool hasInput = true;

            if (IsMandatory)
            {
                hasInput = HasValue;
            }

            pictureBoxErrorIndicator.Visible = !hasInput;

            return hasInput;
        }

        public void SetDataBinding(BindingSource DataBinder, string SourceName)
        {
            DataBindings.Add("SelectedText", DataBinder, SourceName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion

        [Description("Occurs when the user selects a radio button.")]
        public event ButtonSelectedEventHandler ButtonSelected;

        public void AddButton(string ButtonText)
        {
            AddButton(ButtonText, true);
        }

        public void RemoveButton(RadioButton ButtonToRemove)
        {
            RemoveButton(ButtonToRemove, true);
        }

        private void GetInitialOffSets()
        {
            _borderPanelOffset = new Size(Width - panelGroup.Width, Height - panelGroup.Height);
            _buttonPanelOffset = new Size(panelGroup.Width - flowLayoutPanelHolder.Width,
                                          panelGroup.Height - flowLayoutPanelHolder.Height);
        }

        private void MoveIndicatorLabel()
        {
            labelIndicator.Location = new Point(labelHeader.Left + labelHeader.Width, labelIndicator.Location.Y);
        }

        private void ResizeControl()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(ResizeControl
                           ));
            }
            else
            {
                //  Determine the total height of all buttons and the width of
                //    the widest button.

                int greatestWidth = 0;
                int totalHeight = 0;

                foreach (RadioButton currButton in Buttons)
                {
                    totalHeight += currButton.Height + currButton.Margin.Top + currButton.Margin.Bottom;

                    int tempWidth = currButton.Width + currButton.Margin.Left + currButton.Margin.Right;
                    if (tempWidth > greatestWidth)
                    {
                        greatestWidth = tempWidth;
                    }
                }

                //  Determine the new height and width of this control.

                Height = totalHeight +
                         flowLayoutPanelHolder.Padding.Top +
                         flowLayoutPanelHolder.Padding.Bottom +
                         _buttonPanelOffset.Height +
                         _borderPanelOffset.Height;
                Width = greatestWidth +
                        flowLayoutPanelHolder.Padding.Left +
                        flowLayoutPanelHolder.Padding.Right +
                        _buttonPanelOffset.Width +
                        _borderPanelOffset.Width;

                _surpressResize = false;
            }
        }

        private void AddButton(string ButtonText, bool ResizeControl)
        {
            var newButton = new RadioButton {Text = ButtonText};

            AddButton(newButton, ResizeControl);
        }

        private void AddButton(RadioButton NewButton, bool ResizeControl)
        {
            NewButton.CheckedChanged += new EventHandler(AllButtonsCheckedChanged);
            NewButton.Resize += new EventHandler(AllButtonsResize);
            NewButton.AutoSize = true;

            flowLayoutPanelHolder.Controls.Add(NewButton);
            _buttons.Add(NewButton);

            if (ResizeControl)
            {
                this.ResizeControl();
            }
        }

        private void RemoveButton(RadioButton ButtonToRemove, bool ResizeControl)
        {
            ButtonToRemove.CheckedChanged -= AllButtonsCheckedChanged;
            ButtonToRemove.Resize -= AllButtonsResize;

            flowLayoutPanelHolder.Controls.Remove(ButtonToRemove);
            _buttons.Remove(ButtonToRemove);

            if (ResizeControl)
            {
                this.ResizeControl();
            }
        }

        private void AddButtonRange(IEnumerable<RadioButton> ButtonRange)
        {
            _surpressResize = true;

            foreach (RadioButton currButton in ButtonRange)
            {
                AddButton(currButton, false);
            }

            ResizeControl();
        }

        private void AddNewButtons(int ButtonCount)
        {
            _surpressResize = true;

            for (int currCount = 1; currCount <= ButtonCount; currCount++)
            {
                AddButton("New Button", false);
            }

            ResizeControl();
        }

        private void RemoveOldButtons(int NewButtonCount)
        {
            _surpressResize = true;

            int currCount = _buttons.Count - 1;
            for (; currCount > NewButtonCount - 1; currCount--)
            {
                RemoveButton(_buttons[currCount] as RadioButton, false);
            }

            ResizeControl();
        }

        private void ResetButtons()
        {
            RemoveOldButtons(0);
            _buttons.Clear();
        }

        private void OnButtonSelected(RadioButton SelectedButton)
        {
            if (ButtonSelected != null)
            {
                ButtonSelected(this, new ButtonSelectedEventArgs(SelectedButton));
            }
        }

        private void AllButtonsCheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                var button = sender as RadioButton;

                if (button.Checked)
                {
                    _selectedButton = button;
                    OnButtonSelected(button);
                }
            }
        }

        private void AllButtonsResize(object sender, EventArgs e)
        {
            if (!_surpressResize)
            {
                ResizeControl();
            }
        }
    }
}