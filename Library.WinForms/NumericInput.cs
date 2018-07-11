#region

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class NumericInput : LabelledInput, IDataEntryControl
    {
        public NumericInput()
        {
            InitializeComponent();
        }

        [Description("The number of decimal places to display in the numeric input field.")]
        public int DecimalPlaces
        {
            get { return numericUpDown.DecimalPlaces; }

            set { numericUpDown.DecimalPlaces = value; }
        }

        [Description("The amount to increment the value each time the up or down arrow is clicked.")]
        public decimal Increment
        {
            get { return numericUpDown.Increment; }

            set { numericUpDown.Increment = value; }
        }

        [Description("The maximum value the user is allowed to enter in the numeric input field.")]
        public decimal Maximum
        {
            get { return numericUpDown.Maximum; }

            set { numericUpDown.Maximum = value; }
        }

        [Description("The minimum value the user is allowed to enter in the numeric input field.")]
        public decimal Minimum
        {
            get { return numericUpDown.Minimum; }

            set { numericUpDown.Minimum = value; }
        }

        [Description("True to display the character used to delineate thousand values in the numeric input field.")]
        public bool ThousandsSeparator
        {
            get { return numericUpDown.ThousandsSeparator; }

            set { numericUpDown.ThousandsSeparator = value; }
        }

        [Description("The current value in the numeric input field.")]
        public decimal Value
        {
            get { return numericUpDown.Value; }

            set { numericUpDown.Value = value; }
        }

        [Description("The current value in the numeric input field expressed as an integer.")]
        public int IntValue
        {
            get { return (int) numericUpDown.Value; }

            set { numericUpDown.Value = value; }
        }

        [Description("The current value in the numeric input field expressed as a double.")]
        public double DoubleValue
        {
            get { return (double) numericUpDown.Value; }

            set { numericUpDown.Value = (decimal) value; }
        }

        public bool HasValue
        {
            get { return Value != 0; }
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
            numericUpDown.DataBindings.Add("Value", DataBinder, SourceName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void NumericInput_EnabledChanged(object sender, EventArgs e)
        {
            numericUpDown.Enabled = Enabled;
        }

        private void NumericInput_Leave(object sender, EventArgs e)
        {
            HasRequiredInput();
        }
    }
}