using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            this.InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets/sets the integer value of the text in this textbox.")]
        public int IntValue
        {
            get
            {
                int intValue = 0;
                int.TryParse(this.Text, out intValue);

                return intValue;
            }

            set
            {
                this.Text = value.ToString();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets/sets the double value of the text in this textbox.")]
        public double DoubleValue
        {
            get
            {
                double doubleValue = 0d;
                double.TryParse(this.Text, out doubleValue);

                return doubleValue;
            }

            set
            {
                this.Text = value.ToString();
            }
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.KeyPress += this.NumericTextBox_KeyPress;
            this.ResumeLayout(false);
        }






        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' '              ||
                char.IsPunctuation(e.KeyChar) ||
                char.IsSymbol     (e.KeyChar) ||
                char.IsLetter     (e.KeyChar))
            {
                //  Prevent non numeric key presses but allow system key
                //    presses such as Del, Backspace, Arrow Keys, etc.

                e.Handled = true;
            }
        }
    }
}
