#region

using System;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class TimeSpanInput : UserControl
    {
        private TimeSpan curSpan;


        public TimeSpan CurrentSpan
        {
            get { return curSpan; }
        }


        public TimeSpanInput()
        {
            InitializeComponent();

            initSetup();
            curSpan = TimeSpan.MinValue;
        }


        private void initSetup()
        {
            numDays.Minimum = 0;
            numDays.Maximum = TimeSpan.MaxValue.Days;

            numHours.Minimum = 0;
            numHours.Maximum = 24;
        }


        private void validateTimeSpan()
        {
            string duration = formatDuration((int) numDays.Value, (int) numHours.Value, 0, 0);

            bool correct = TimeSpan.TryParse(duration, out curSpan);

            if (!correct)
            {
                errorInput.SetIconAlignment(panTimeSpanInput, ErrorIconAlignment.MiddleRight);
                errorInput.SetError(panTimeSpanInput,
                                    "Days must be less than " + TimeSpan.MaxValue.Days + '\n' +
                                    "Hours must be less than 24 \n Minutes must be less than 60 \n Seconds must be less than 60");
            }
            else
            {
                errorInput.SetError(panTimeSpanInput, string.Empty);
            }
        }

        private string formatDuration(int days, int hours, int minutes, int seconds)
        {
            string formatted = "";

            formatted = days.ToString() + "." + hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();

            return formatted;
        }

        private void numDays_ValueChanged(object sender, EventArgs e)
        {
            validateTimeSpan();
        }

        private void numHours_ValueChanged(object sender, EventArgs e)
        {
            if (numHours.Value == 24)
            {
                numDays.Value++;
                numHours.Value = numHours.Value - 24;
            }

            validateTimeSpan();
        }
    }
}