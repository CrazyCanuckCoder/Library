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
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets/sets the integer value of the text in this textbox.")]
        public int IntValue
        {
            get
            {
                int intValue = 0;
                int.TryParse(Text, out intValue);

                return intValue;
            }

            set
            {
                Text = value.ToString();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets/sets the double value of the text in this textbox.")]
        public double DoubleValue
        {
            get
            {
                double doubleValue = 0d;
                double.TryParse(Text, out doubleValue);

                return doubleValue;
            }

            set
            {
                Text = value.ToString();
            }
        }


        private void InitializeComponent()
        {
            SuspendLayout();
            KeyPress += NumericTextBox_KeyPress;
            ResumeLayout(false);
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
