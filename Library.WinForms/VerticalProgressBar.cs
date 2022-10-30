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
    public partial class VerticalProgressBar : UserControl
    {
        public VerticalProgressBar()
        {
            InitializeComponent();
        }

        private int _percentValue;
        private Color _progressColour;




        public int PercentValue
        {
            get
            {
                return _percentValue;
            }

            set
            {
                if (value.IsBetween(0, 100))
                {
                    double heightFactor = Height / 100.0d;
                    _percentValue = value;
                    labelProgress.Height = (int) (heightFactor * _percentValue);
                    labelProgress.Location = new Point(0, Height - labelProgress.Height);
                }
            }
        }

        public Color ProgressColour
        {
            get
            {
                return _progressColour;
            }

            set
            {
                _progressColour = value;
                labelProgress.BackColor = value;
            }
        }
    }
}
