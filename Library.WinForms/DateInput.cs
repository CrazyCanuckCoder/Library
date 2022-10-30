#region

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class DateInput : LabelledInput, IDataEntryControl
    {
        public DateInput()
        {
            InitializeComponent();
            UpdateTimeDisplay();
            CanSelectFutureDates = true;
            CanSelectPastDates = true;
            _previousDate = dateTimePicker.Value;
        }

        private string _dateFormat = "dddd, MMMM d, yyyy";
        private DateTime _previousDate = DateTime.MinValue;

        [Description("True if dates before the current date can be selected by the user.")]
        public bool CanSelectPastDates { get; set; }

        [Description("True if dates after the current date can be selected by the user.")]
        public bool CanSelectFutureDates { get; set; }

        [Description("The format string used for displaying the date.")]
        public string DateFormat
        {
            get { return _dateFormat; }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _dateFormat = value;
                    UpdateTimeDisplay();
                }
            }
        }

        [Description("The latest date the user can enter.")]
        public DateTime MaxDate
        {
            get { return dateTimePicker.MaxDate; }

            set { dateTimePicker.MaxDate = value; }
        }

        [Description("The earliest date the user can enter.")]
        public DateTime MinDate
        {
            get { return dateTimePicker.MinDate; }

            set { dateTimePicker.MinDate = value; }
        }

        [Description("The date picked by the user.")]
        public DateTime Value
        {
            get { return dateTimePicker.Value; }

            set { dateTimePicker.Value = value; }
        }

        [Description("True to indicate the control has a date selected by the user.")]
        public bool HasValue
        {
            get { return Value != DateTime.MinValue; }
        }

        /// <summary>
        /// Displays the date selected by the user in the format specified.
        /// </summary>
        /// 
        private void UpdateTimeDisplay()
        {
            labelTimeDisplay.Text = dateTimePicker.Value.ToString(_dateFormat);
        }

        /// <summary>
        /// Returns true if the control has had data entered by the user.
        /// </summary>
        /// 
        /// <returns>
        /// False when no data is present for mandatory fields and true otherwise.
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
            dateTimePicker.DataBindings.Add("Value", DataBinder, SourceName, false,
                                            DataSourceUpdateMode.OnPropertyChanged);
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!CanSelectPastDates && dateTimePicker.Value.Date < DateTime.Now.Date ||
                !CanSelectFutureDates && dateTimePicker.Value.Date > DateTime.Now.Date)
            {
                dateTimePicker.Value = _previousDate;
            }
            else
            {
                _previousDate = dateTimePicker.Value;
            }

            UpdateTimeDisplay();
        }
    }
}