#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class TextInput : LabelledInput, IDataEntryControl, ITextInput
    {
        public TextInput()
        {
            InitializeComponent();
        }

        private bool _isMultiline = false;

        [Description("Set this to true to allow multiline input in the textbox.")]
        public bool IsMultiline
        {
            get { return _isMultiline; }

            set
            {
                _isMultiline = value;

                //  Reset the size of the text box when changing to multiline textboxes.
                 
                Size origSize = textBoxInput.Size;
                textBoxInput.Multiline = _isMultiline;

                if (_isMultiline)
                {
                    textBoxInput.Size = origSize;
                }
            }
        }

        [Description("Returns true if the textbox contains some text.")]
        public bool HasValue
        {
            get { return textBoxInput.Text != ""; }
        }

        [Description("The string entered by the user.")]
        public string Value
        {
            get { return textBoxInput.Text; }

            set
            {
                if (value != null)
                {
                    textBoxInput.Text = value;
                }
            }
        }

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
            textBoxInput.DataBindings.Add("Text", DataBinder, SourceName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void TextInput_Leave(object sender, EventArgs e)
        {
            HasRequiredInput();
        }

        private void TextInput_EnabledChanged(object sender, EventArgs e)
        {
            textBoxInput.Enabled = Enabled;
        }
    }
}