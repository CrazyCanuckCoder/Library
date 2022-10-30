#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class IPAddressInput : UserControl
    {
        private const int NUM_TEXT_BOXES           = 4;
        private const int SPACE_BETWEEN_TEXT_BOXES = 10;
        private const int NUM_DOTS                 = 3;
        private const int MAX_QUADRANT_CHARACTERS  = 3;

        public IPAddressInput()
        {
            InitializeComponent();

            //  Create arrays that reference the textbox and label controls for
            //    easy manipulation later.

            _textBoxRefs = new TextBox[]
                {
                    textBoxQuadrant1,
                    textBoxQuadrant2,
                    textBoxQuadrant3,
                    textBoxQuadrant4
                };
            _labelRefs = new Label[]
                {
                    labelDot1,
                    labelDot2,
                    labelDot3
                };
        }

        public IPAddressInput(IPv4Address NewAddress) : this()
        {
            Address = NewAddress;
        }

        private readonly TextBox[] _textBoxRefs = null;
        private readonly Label[]   _labelRefs   = null;

        /// <summary>
        /// Gets or sets the IP Address associated with this control.
        /// </summary>
        /// 
        public IPv4Address Address
        {
            get
            {
                var quadrants = new int[NUM_TEXT_BOXES];

                for (int idx = 0; idx < quadrants.Length; idx++)
                {
                    int tempNum = 0;
                    int.TryParse(_textBoxRefs[idx].Text, out tempNum);
                    quadrants[idx] = tempNum;
                }

                return new IPv4Address(quadrants);
            }

            set
            {
                if (value != null)
                {
                    for (int idx = 0; idx < value.Quadrants.Length; idx++)
                    {
                        _textBoxRefs[idx].Text = value.Quadrants[idx].ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Determines the new width for the textboxes and the location of the
        /// labels containing the dots when this control has been resized.
        /// </summary>
        /// 
        private void IPAddressInput_Resize(object sender, EventArgs e)
        {
            //  Determine the new width of the textboxes.

            int currX = 0;
            int textBoxWidth = (Width - (SPACE_BETWEEN_TEXT_BOXES * NUM_DOTS)) / NUM_TEXT_BOXES;

            //  Resize and move each textbox.

            foreach (TextBox currTextBox in _textBoxRefs)
            {
                currTextBox.Size = new Size(textBoxWidth, Height);
                currTextBox.Location = new Point(currX, 0);

                currX += textBoxWidth + SPACE_BETWEEN_TEXT_BOXES;
            }

            //  Move the labels containing the periods.

            currX = textBoxWidth;
            foreach (Label currDot in _labelRefs)
            {
                currDot.Size = new Size(currDot.Width, Height);
                currDot.Location = new Point(currX, 0);

                currX += textBoxWidth + SPACE_BETWEEN_TEXT_BOXES;
            }
        }

        /// <summary>
        /// Allows only numbers to be entered by the user, valid system keys
        /// (such as Del, Backspace, etc), a maximum of 3 digits and ensures
        /// the value entered isn't greater than the maximum value allowed
        /// for an IP quadrant.
        /// </summary>
        /// 
        private void QuadrantKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                //  Get a copy of the current text in the textbox.

                var textBoxRef = sender as TextBox;
                if (textBoxRef != null)
                {
                    string textBoxText = textBoxRef.Text;

                    //  Delete any selected text as it will be overwritten.

                    if (textBoxRef.SelectionLength > 0)
                    {
                        textBoxText = textBoxText.Remove(textBoxRef.SelectionStart, textBoxRef.SelectionLength);
                    }

                    //  Ensure only a maximum of 3 numbers can be entered.

                    if (textBoxText.Length == MAX_QUADRANT_CHARACTERS)
                    {
                        e.Handled = true;
                    }
                    else if (textBoxText.Length == (MAX_QUADRANT_CHARACTERS - 1))
                    {
                        //  Ensure the value entered is less than the maximum allowed.
                        //    First, place the new number is the correct location of
                        //    the current text.

                        string tempText = textBoxText.Insert(textBoxRef.SelectionStart, e.KeyChar.ToString());

                        //  Convert the text from the textbox and the new number into
                        //    a numeric value to ensure it is not greater than the 
                        //    maximum value allowed for a quadrant.

                        int quadrantValue = 0;

                        int.TryParse(tempText, out quadrantValue);
                        if (quadrantValue > IPv4Address.MAX_QUADRANT_VALUE)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            else
            {
                //  Entering a period moves focus to the next quadrant textbox.

                if (e.KeyChar == '.')
                {
                    SendKeys.Send("\t");
                    e.Handled = true;
                }
                else if (e.KeyChar == ' ' || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) ||
                         char.IsLetter(e.KeyChar))
                {
                    //  Prevent non numeric key presses but allow system key
                    //    presses; such as Del, Backspace, Arrow Keys, etc.

                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Selects all the text in a textbox when it receives focus.
        /// </summary>
        /// 
        private void QuadrantEnter(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            if (box != null)
            {
                box.SelectAll();
            }
        }
    }
}