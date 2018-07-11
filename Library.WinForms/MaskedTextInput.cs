#region

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class MaskedTextInput : LabelledInput, IDataEntryControl, IMaskedTextInput
    {
        public MaskedTextInput()
        {
            InitializeComponent();
        }

        [Description("The character to use in the absense of user input.")]
        public char PromptChar
        {
            get { return maskedTextBoxInput.PromptChar; }

            set { maskedTextBoxInput.PromptChar = value; }
        }

        [Description("The input mask to use at run time.")]
        public string Mask
        {
            get { return maskedTextBoxInput.Mask; }

            set
            {
                if (value != null)
                {
                    maskedTextBoxInput.Mask = value;
                }
            }
        }

        [Description("Returns true if the masked textbox contains some text.")]
        public bool HasValue
        {
            get { return maskedTextBoxInput.Text.Trim() != ""; }
        }

        [Description("The string entered by the user.")]
        public string Value
        {
            get { return maskedTextBoxInput.Text; }

            set
            {
                if (value != null)
                {
                    maskedTextBoxInput.Text = value;
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
            maskedTextBoxInput.DataBindings.Add("Text", DataBinder, SourceName, false,
                                                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void MaskedTextInput_EnabledChanged(object sender, EventArgs e)
        {
            maskedTextBoxInput.Enabled = Enabled;
        }
    }
}