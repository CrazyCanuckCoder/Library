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
                return this._percentValue;
            }

            set
            {
                if (value.IsBetween(0, 100))
                {
                    double heightFactor = this.Height / 100.0d;
                    this._percentValue = value;
                    this.labelProgress.Height = (int) (heightFactor * this._percentValue);
                    this.labelProgress.Location = new Point(0, this.Height - this.labelProgress.Height);
                }
            }
        }

        public Color ProgressColour
        {
            get
            {
                return this._progressColour;
            }

            set
            {
                this._progressColour = value;
                this.labelProgress.BackColor = value;
            }
        }
    }
}
