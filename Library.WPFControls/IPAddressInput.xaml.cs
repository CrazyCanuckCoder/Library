using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Library.WPFControls
{
    /// <summary>
    /// Interaction logic for IPAddressInput.xaml
    /// </summary>
    public partial class IPAddressInput : UserControl
    {
        private const int NUM_TEXT_BOXES = 4;
        private const int MAX_QUADRANT_CHARACTERS = 3;

        public IPAddressInput()
        {
            InitializeComponent();

            //  Create the array that reference the textbox controls for easy manipulation later.

            _textBoxRefs = new TextBox[]
                {
                    TextBoxQuadrant1,
                    TextBoxQuadrant2,
                    TextBoxQuadrant3,
                    TextBoxQuadrant4
                };
        }

        public IPAddressInput(IPv4Address NewAddress) : this()
        {
            Address = NewAddress;
        }

        /// <summary>
        /// A List of textboxex used in this class to obtain the IP address.
        /// </summary>
        /// 
        private readonly TextBox[] _textBoxRefs = new TextBox[NUM_TEXT_BOXES];

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
                    int.TryParse(_textBoxRefs[idx].Text, out int tempNum);
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
        /// Allows only numbers to be entered by the user, valid system keys
        /// (such as Del, Backspace, etc), a maximum of 3 digits and ensures
        /// the value entered isn't greater than the maximum value allowed
        /// for an IP quadrant.
        /// </summary>
        /// 
        private void QuadrantPreviewTextInput(object Sender, TextCompositionEventArgs E)
        {
            var textBoxRef = Sender as TextBox;
            if (textBoxRef != null)
            {
                if (char.IsDigit(E.Text[0]))
                {
                //  Get a copy of the current text in the textbox.

                    string textBoxText = textBoxRef.Text;

                    //  Delete any selected text as it will be overwritten.

                    if (textBoxRef.SelectionLength > 0)
                    {
                        textBoxText = textBoxText.Remove(textBoxRef.SelectionStart, textBoxRef.SelectionLength);
                    }

                    //  Ensure only a maximum of 3 numbers can be entered.

                    if (textBoxText.Length == MAX_QUADRANT_CHARACTERS)
                    {
                        E.Handled = true;
                    }
                    else if (textBoxText.Length == (MAX_QUADRANT_CHARACTERS - 1))
                    {
                        //  Ensure the value entered is less than the maximum allowed.
                        //    First, place the new number in the correct location of
                        //    the current text.

                        string tempText = textBoxText.Insert(textBoxRef.SelectionStart, E.Text);

                        //  Convert the text from the textbox and the new number into
                        //    a numeric value to ensure it is not greater than the 
                        //    maximum value allowed for a quadrant.

                        int.TryParse(tempText, out int quadrantValue);
                        if (quadrantValue > IPv4Address.MAX_QUADRANT_VALUE)
                        {
                            E.Handled = true;
                        }
                    }
                }
                else
                {
                    char keyChar = E.Text[0];

                    //  Entering a period moves focus to the next quadrant textbox.

                    if (keyChar == '.')
                    {
                        textBoxRef.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        E.Handled = true;
                    }
                    else if (keyChar == ' '              ||
                             char.IsPunctuation(keyChar) ||
                             char.IsSymbol(keyChar)      ||
                             char.IsLetter(keyChar))
                    {
                        //  Prevent non numeric key presses but allow system key
                        //    presses; such as Del, Backspace, Arrow Keys, etc.

                        E.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Selects all the text in a textbox when it receives focus.
        /// </summary>
        /// 
        private void QuadrantGotFocus(object Sender, RoutedEventArgs E)
        {
            var box = Sender as TextBox;
            if (box != null)
            {
                box.SelectAll();
            }
        }

        /// <summary>
        /// Determines if text is selected in a specified textbox.
        /// </summary>
        /// 
        /// <param name="OrigObject">
        /// The object representing the textbox to check.
        /// </param>
        /// 
        /// <param name="SentTextBox">
        /// Returns the first parameter cast as a textbox.  Could be null.
        /// </param>
        /// 
        /// <returns>
        /// True if no text is selected in the textbox, false if not or the original object is not a textbox.
        /// </returns>
        /// 
        private bool NoSelectedTextInTextBox(object OrigObject, out TextBox SentTextBox)
        {
            bool textSelected = false;

            SentTextBox = OrigObject as TextBox;
            if (SentTextBox != null)
            {
                textSelected = (SentTextBox.SelectionLength == 0);
            }

            return textSelected;
        }

        /// <summary>
        /// If the user pressed the Home or End keys, takes the appropriate action.
        /// </summary>
        /// 
        /// <param name="KeyInfo">
        /// The EventArgs from the textbox indicating which keys were pressed, if any.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate either the Home or End key has been pressed.
        /// </returns>
        /// 
        private bool HomeOrEndKeyPressed(KeyEventArgs KeyInfo)
        {
            bool keysPressed = false;

            if (KeyInfo.IsDown)
            {
                if (KeyInfo.Key == Key.Home)
                {
                    if (TextBoxQuadrant1.Focus())
                    {
                        TextBoxQuadrant1.SelectionStart = 0;
                    }
                    keysPressed = true;
                }
                else if (KeyInfo.Key == Key.End)
                {
                    if (TextBoxQuadrant4.Focus())
                    {
                        TextBoxQuadrant4.SelectionStart = TextBoxQuadrant4.Text.Length;
                    }
                    keysPressed = true;
                }
            }

            return keysPressed;
        }


        /// <summary>
        /// If the user presses the right arrow key in the first quadrant textbox with the cursor at the end
        /// of the entered text, the cursor will be moved to the next textbox.
        /// </summary>
        /// 
        private void TextBoxQuadrant1_OnPreviewKeyDown(object Sender, KeyEventArgs E)
        {
            if (!HomeOrEndKeyPressed(E))
            {
                if (NoSelectedTextInTextBox(Sender, out TextBox textBox))
                {
                    if (textBox.SelectionStart == textBox.Text.Length)
                    {
                        if (E.IsDown && E.Key == Key.Right)
                        {
                            E.Handled = true;
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Moves the cursor in the textbox based on the key pressed and the current location of the cursor.
        /// </summary>
        /// 
        private void MiddleQuadrant_OnPreviewKeyDown(object Sender, KeyEventArgs E)
        {
            if (!HomeOrEndKeyPressed(E))
            {
                TextBox textBox = null;
                if (NoSelectedTextInTextBox(Sender, out textBox))
                {
                    //  Is the cursor at the start of the textbox?

                    if (textBox.SelectionStart == 0)
                    {
                        if (E.IsDown)
                        {
                            //  Move the cursor to the previous textbox if they pressed the left arrow or backspace key.

                            if (E.Key == Key.Left || E.Key == Key.Back)
                            {
                                E.Handled = true;
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                            }

                            //  Move the cursor to the next textbox if the user pressed the right arrow key and there is
                            //    no text entered.

                            else if (textBox.Text.Length == 0 && E.Key == Key.Right)
                            {
                                E.Handled = true;
                                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                            }
                        }
                    }

                    //  Is the cursor at the end of the text in the textbox?

                    else if (textBox.SelectionStart == textBox.Text.Length)
                    {
                        //  Move the cursor to the next textbox if the user pressed the right arrow key.

                        if (E.IsDown && E.Key == Key.Right)
                        {
                            E.Handled = true;
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// If the user presses the left arrow or backspace key when the cursor is at the beginning of the
        /// textbox, the cursor will be moved to the previous textbox.
        /// </summary>
        /// 
        private void TextBoxQuadrant4_OnPreviewKeyDown(object Sender, KeyEventArgs E)
        {
            if (!HomeOrEndKeyPressed(E))
            {
                TextBox textBox = null;
                if (NoSelectedTextInTextBox(Sender, out textBox))
                {
                    if (textBox.SelectionStart == 0)
                    {
                        if (E.IsDown && E.Key == Key.Left || E.Key == Key.Back)
                        {
                            E.Handled = true;
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                        }
                    }
                }
            }
        }
    }
}
