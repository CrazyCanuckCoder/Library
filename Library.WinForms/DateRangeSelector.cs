using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    /// <summary>
    /// A customizable date range selection control.
    /// </summary>
    /// 
    /// <remarks>
    /// To use this control in a project you will need to create two things: an enumeration outlining the 
    /// choices available to the user and a function that will return a date range based on a value in the
    /// enumeration.  The enumeration is the generic type (T) for this control.
    /// 
    /// For example, suppose you have defined the following enumeration:
    /// 
    /// <code>
    /// public enum DateRangeChoices
    /// {
    ///     Weekly,
    ///     Monthly,
    ///     Yearly
    /// }
    /// </code>
    /// 
    /// Suppose you have a method with the following signature in your project:
    /// 
    /// <code>
    /// public static DateRangeResult DetermineProjectDateRange(DateRangeChoices UserRangeChoices)
    /// {
    ///     .
    ///     .
    ///     .
    /// }
    /// </code>
    /// 
    /// To add an instance of this control to your form, you will need to add it programmatically.  For example,
    /// use code similar to the following:
    /// 
    /// <code>
    /// private DateRangeSelector<DateRangeChoices> dateSelector = new DateRangeSelector<DateRangeChoices>(DetermineProjectDateRange);
    /// 
    /// private void SetupDateSelector()
    /// {
    ///     this.panelDateRange.Controls.Add(this.dateSelector);
    /// 
    ///     this.dateSelector.Location = new Point(0, 0);
    ///     this.dateSelector.Name     = "dateSelector";
    ///     this.dateSelector.Size     = new Size(650, 41);
    ///     this.dateSelector.Dock     = DockStyle.Fill;
    ///     this.dateSelector.TabIndex = 0;
    /// 
    ///     this.dateSelector.DateRangeChanged += (object sender, DateRangeChangedEventArgs e) => { this.InitDataLoad(e); };
    /// }
    /// </code>
    /// 
    /// Each member of the enumeration will become an option in the combo box of this control plus a special
    /// option called "Custom..." is added automatically by the control.  When the user selects the custom
    /// option, the date range picker controls become enabled and the user manually selects the date range.
    /// 
    /// When the user clicks the button labelled "Go" on this control, the DateRangeChanged event is fired.
    /// Handle this event to received the user's selected date range.  The DateRangeChangedEvenArgs parameter
    /// contains the start date and the end date that the user selected.
    /// </remarks>
    /// 
    /// <typeparam name = "T">
    /// An enumeration containing the items to appear in the date range combo box.
    /// </typeparam>
    /// 
    public partial class DateRangeSelector<T> : UserControl where T : struct, IConvertible
    {
        public DateRangeSelector()
        {
            InitializeComponent();
        }

        public DateRangeSelector(Func<T, DateRangeResult> NewDetermineDateRange) : this()
        {
            this.DetermineDateRange = NewDetermineDateRange;
            this.SetupComboBox();
        }




        /// <summary>
        /// The text that appears in the combo box indicating the user wants to manually select the date range.
        /// </summary>
        /// 
        private const string CUSTOM_RANGE_CHOICE = "Custom...";




        /// <summary>
        /// Gets the start date of the range selected by the user.
        /// </summary>
        /// 
        public DateTime StartDate
        {
            get
            {
                return this.dateTimePickerStartDate.Value;
            }
        }

        /// <summary>
        /// Gets the end date of the range selected by the user.
        /// </summary>
        /// 
        public DateTime EndDate
        {
            get
            {
                return this.dateTimePickerEndDate.Value;
            }
        }

        /// <summary>
        /// Gets/sets the function that determines the date range when the user selects an option from the
        /// combo box control.
        /// </summary>
        /// 
        public Func<T, DateRangeResult> DetermineDateRange { get; set; }




        /// <summary>
        /// Fires when the user changes the date range.
        /// </summary>
        /// 
        public event DateRangeChangedEventHandler DateRangeChanged;




        /// <summary>
        /// Fires the DateRangeChanged event if there are any listeners.
        /// </summary>
        /// 
        private void OnDateRangeChanged()
        {
            this.DateRangeChanged?.Invoke(this, new DateRangeChangedEventArgs(this.StartDate, this.EndDate));
        }

        /// <summary>
        /// Initializes the combo box with the strings from the T enumeration.
        /// </summary>
        /// 
        private void SetupComboBox()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T for DateRangeSelector must be an enumerated type.");
            }

            this.comboBoxDateRange.Items.AddRange(Enum.GetNames(typeof(T)));

            this.comboBoxDateRange.Items.Add(CUSTOM_RANGE_CHOICE);
            this.comboBoxDateRange.SelectedIndex = 0;
        }

        /// <summary>
        /// Sets the starting and ending dates of this control based on the string sent in the parameter.
        /// </summary>
        /// 
        /// <param name="RangeChoice">
        /// Contains the value selected by the user from the combo box.
        /// </param>
        /// 
        /// <exception cref="NullReferenceException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// 
        private void SetDateRange(string RangeChoice)
        {
            if (RangeChoice != null)
            {
                this.dateTimePickerStartDate.Enabled = (RangeChoice == CUSTOM_RANGE_CHOICE);
                this.dateTimePickerEndDate  .Enabled = (RangeChoice == CUSTOM_RANGE_CHOICE);

                if (Enum.GetNames(typeof(T)).Contains(RangeChoice))
                {
                    if (this.DetermineDateRange != null)
                    {
                        DateRangeResult newDateRange = this.DetermineDateRange((T) Enum.Parse(typeof(T), RangeChoice));

                        this.dateTimePickerStartDate.Value = newDateRange.Start;
                        this.dateTimePickerEndDate  .Value = newDateRange.End;
                    }
                    else
                    {
                        throw new NullReferenceException("The function to determine the date range based on the selected user option has not been set.");
                    }
                }
                else
                {
                    throw new ArgumentException("Selected date range option is invalid.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(RangeChoice));
            }
        }





        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            this.labelStartDate.Text = this.StartDate.ToString("dddd MMMM d, yyyy");
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            this.labelEndDate.Text = this.EndDate.ToString("dddd MMMM d, yyyy");
        }

        private void comboBoxDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetDateRange(this.comboBoxDateRange.SelectedItem.ToString());
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (this.EndDate >= this.StartDate)
            {
                this.OnDateRangeChanged();
            }
            else
            {
                Utility.ShowError(this.FindForm(), "End date must be later than or equal to the start date.");
            }
        }
    }
}
