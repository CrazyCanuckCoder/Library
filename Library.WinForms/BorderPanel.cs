using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    public class BorderPanel : Panel
    {
        public BorderPanel() : base()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private Color _borderColour = SystemColors.ControlDark;
        private int _borderWidth = 1;

        /// <summary>
        /// The colour of the border around the panel.
        /// </summary>
        /// 
        public Color BorderColour
        {
            get
            {
                return this._borderColour;
            }

            set
            {
                this._borderColour = value;
            }
        }

        /// <summary>
        /// The width of the border around the panel.
        /// </summary>
        /// 
        public int BorderWidth
        {

            get
            {
                return this._borderWidth;
            }

            set
            {
                if (value >= 0)
                {
                    this._borderWidth = value;
                }
            }
        }

        /// <summary>
        /// Draws the border in the colour specified by the BorderColour property
        /// and as wide as specified by the BorderWidth property.
        /// </summary>
        /// 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle borderRect = this.ClientRectangle;
            borderRect.Width--;
            borderRect.Height--;

            e.Graphics.DrawRectangle(new Pen(new SolidBrush(this._borderColour), this._borderWidth), borderRect);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BorderPanel
            // 
            this.Resize += new System.EventHandler(this.BorderPanel_Resize);
            this.ResumeLayout(false);

        }

        private void BorderPanel_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
