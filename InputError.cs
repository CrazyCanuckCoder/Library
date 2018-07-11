using System.Windows.Forms;

namespace Library
{
    /// <summary>
    /// Used in conjunction with the InputVerifier class, this class stores the 
    /// errors found by the verification routines.
    /// </summary>
    /// 
    public class InputError
    {
        /// <summary>
        /// The control that has invalid input.
        /// </summary>
        /// 
        public Control ErrorControl { get; set; }

        /// <summary>
        /// The error string associated with the invalid input.
        /// </summary>
        /// 
        public string ErrorMessage { get; set; }

        public InputError(Control NewControl, string NewMessage)
        {
            this.ErrorControl = NewControl;
            this.ErrorMessage = NewMessage;
        }
    }
}
