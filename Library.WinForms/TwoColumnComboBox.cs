using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    public partial class TwoColumnComboBox : ComboBox
    {
        public TwoColumnComboBox()
        {
            InitializeComponent();
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += TwoColumnComboBox_DrawItem;
        }

        private double _firstColumnWidthRatio  = 0.5;
        private double _secondColumnWidthRatio = 0.5;

        [Description("The ratio used to decide the width of the first column.")]
        public double FirstColumnWidthRatio
        {
            get
            {
                return _firstColumnWidthRatio;
            }

            set
            {
                if (value < 0d)
                {
                    _firstColumnWidthRatio = 0d;
                }
                else if (value > 1.0d)
                {
                    _firstColumnWidthRatio = 1.0d;
                }
                else
                {
                    _firstColumnWidthRatio = value;
                }

                _secondColumnWidthRatio = 1.0d - _firstColumnWidthRatio;
            }
        }

        [Description("The ratio used to decide the width of the second column.")]
        public double SecondColumnWidthRatio
        {
            get
            {
                return _secondColumnWidthRatio;
            }

            set
            {
                if (value < 0d)
                {
                    _secondColumnWidthRatio = 0d;
                }
                else if (value > 1.0d)
                {
                    _secondColumnWidthRatio = 1.0d;
                }
                else
                {
                    _secondColumnWidthRatio = value;
                }

                _firstColumnWidthRatio = 1.0d - _secondColumnWidthRatio;
            }
        }

        /// <summary>
        /// Checks that each of the properties the DrawItem event handler relies
        /// on has been set properly.
        /// </summary>
        /// 
        [Conditional("DEBUG")]
        private void VerifyEssentialProperties()
        {
            bool noIssue = false;
            string message = "";

            if (string.IsNullOrEmpty(ValueMember))
            {
                message = "ValueMember property cannot be empty.";
            }
            else if (string.IsNullOrEmpty(DisplayMember))
            {
                message = "DisplayMember property cannot be empty.";
            }
            else if (DataSource == null)
            {
                message = "DataSource property cannot be null.";
            }
            else if (!(DataSource is DataTable))
            {
                message = "DataSource must be a DataTable.";
            }
            else if (!(DataSource as DataTable).Columns.Contains(ValueMember))
            {
                message = "DataSource does not contain the ValueMember column.";
            }
            else if (!(DataSource as DataTable).Columns.Contains(DisplayMember))
            {
                message = "DataSource does not contain the DisplayMember column.";
            }
            else
            {
                noIssue = true;
            }

            Debug.Assert(noIssue, message);
        }

        private void TwoColumnComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            VerifyEssentialProperties();

            // Draw the default background
            e.DrawBackground();

            if (e.Index >= 0)
            {
                // The ComboBox is bound to a DataTable,
                // so the items are DataRowView objects.
                DataRowView drv = (DataRowView) Items[e.Index];

                // Retrieve the value of each column.
                string valueColumn   = drv[ValueMember].ToString();
                string displayColumn = drv[DisplayMember].ToString();

                // Get the bounds for the first column
                Rectangle r1 = e.Bounds;
                r1.Width     = (int) (r1.Width * _firstColumnWidthRatio);

                // Draw the text on the first column
                using (SolidBrush sb = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(valueColumn, e.Font, sb, r1);
                }

                // Draw a line to isolate the columns 
                using (Pen p = new Pen(Color.Black))
                {
                    e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom);
                }

                // Get the bounds for the second column
                Rectangle r2 = e.Bounds;
                r2.X     = e.Bounds.Width - (int) (e.Bounds.Width * _secondColumnWidthRatio);
                r2.Width = (int) (r2.Width * _secondColumnWidthRatio);

                // Draw the text on the second column
                using (SolidBrush sb = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(displayColumn, e.Font, sb, r2);
                }
            }
        }
    }
}
