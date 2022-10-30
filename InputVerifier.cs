using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Library
{
    /// <summary>
    /// Checks a list of controls for user input and fills a property with error
    /// messages associated to the controls with errors.
    /// </summary>
    /// 
    /// <remarks>
    /// Use this class to check for user input on a form.  Pass the form's Controls
    /// collection property or create a list of controls that contains the input
    /// from a user and call the HasValidInput method.  If any control does not meet
    /// the minimum amount of user input, the method returns false.  Each control
    /// that has an issue will be referenced in the InputErrors property.  The
    /// InputErrors property is a List of InputError objects.  Each InputError object
    /// has a Control property and a string property.  The string property contains
    /// the error text associated with the Control property.
    /// 
    /// Currently, the following controls are checked for valid input:
    /// 
    /// RadioButton
    /// TextBox
    /// CheckedListBox
    /// ComboBox
    /// DateTimePicker
    /// DomainUpDown
    /// ListBox
    /// MaskedTextBox
    /// NumericUpDown
    /// RichTextBox
    /// 
    /// The following code example comes from the TestInputVerifierForm of the 
    /// Library.Tests project.  The CheckDataEntries method is called by a button
    /// on the form.  Error results are provided through an ErrorProvider control
    /// that is driven by results found in the InputErrors property of the
    /// InputVerifier object.
    /// 
    ///
    /// private readonly InputVerifier _entryVerifier = new InputVerifier();
    ///
    /// private void CheckDataEntries()
    /// {
    ///     this.errorProvider.Clear();
    ///
    ///     if (this._entryVerifier.HasValidInput(this.Controls))
    ///     {
    ///         Utility.ShowMessage(this, "All entries are valid.");
    ///     }
    ///     else
    ///     {
    ///         this.HandleInputErrors();
    ///     }
    /// }
    ///
    /// private void HandleInputErrors()
    /// {
    ///     foreach (InputError currError in this._entryVerifier.InputErrors)
    ///     {
    ///         this.errorProvider.SetError(currError.ErrorControl, currError.ErrorMessage);
    ///     }
    /// }
    /// 
    /// To expand the checking of controls beyond the default actions, create a
    /// method that verifies a type of control based on your own rules.  This
    /// method must accept a control object and return a string containing an
    /// error message if the user input is invalid.  If the user input in the
    /// control is valid, return a blank string.
    /// 
    /// Once the method has been created, call the RegisterVerificationMethod to 
    /// register it for the specific type of control.  When the controls are being
    /// checked for valid user input, any registered method for a type of control
    /// are called instead of the default check for user input.  You can register
    /// as many methods for as many types of controls as you want as long as there
    /// is one method per type.
    /// 
    /// For an example of a complex control using a custom method, see the control
    /// called AddressInput and its AddressInputVerificationFunction method.  To
    /// see how it applies in an actual form, look at the TestInputVerifierDelegateForm
    /// class' code.
    /// </remarks>
    /// 
    public class InputVerifier : IInputVerifier
    {
        public InputVerifier()
        {
        }




        private Dictionary<Control, List<RadioButton>> _radioButtons = null;
        private readonly Dictionary<Type, Func<Control, string>> _verificationDelegates = new Dictionary<Type, Func<Control, string>>();




        /// <summary>
        /// Gets the list of InputError objects that detail the controls that
        /// had errors and what the error for the control was.
        /// </summary>
        /// 
        /// <remarks>
        /// If the HasValidInput method returns false, check this List for an 
        /// explanation of the controls that had errors.
        /// </remarks>
        /// 
        public List<InputError> InputErrors { get; private set; } = null;




        /// <summary>
        /// Checks through each control in a supplied collection of controls for 
        /// valid user input.
        /// </summary>
        /// 
        /// <remarks>
        /// This method was turned into a stub to call the ValidateUserEntries method
        /// so that the fields used by the function can be reset every time the method
        /// is called.
        /// </remarks>
        /// 
        /// <param name="ControlsToVerify">
        /// A collection of controls to check for user input.
        /// </param>
        /// 
        /// <returns>
        /// True if all controls contain valid input and false if at least one
        /// control has invalid input.
        /// </returns>
        /// 
        public bool HasValidInput(IEnumerable ControlsToVerify)
        {
            InputErrors = new List<InputError>();
            _radioButtons = new Dictionary<Control, List<RadioButton>>();

            return ValidateUserEntries(ControlsToVerify);
        }

        /// <summary>
        /// Registers a verification method to be used for a specified control.
        /// </summary>
        /// 
        /// <param name="ControlType">
        /// The type of the control to be used in the verification method.
        /// </param>
        /// 
        /// <param name="MethodToUse">
        /// A method that takes a Control as a parameter and returns text to 
        /// indicate the user input was not valid.
        /// </param>
        /// 
        /// <returns>
        /// True if the method was registered for the specified control and false
        /// if not.
        /// </returns>
        /// 
        public bool RegisterVerificationMethod(Type ControlType, Func<Control, string> MethodToUse)
        {
            bool wasRegistered = false;

            if (ControlType != null)
            {
                if (MethodToUse != null)
                {
                    if (ControlType.IsSubclassOf(typeof (Control)))
                    {
                        if (!_verificationDelegates.ContainsKey(ControlType))
                        {
                            _verificationDelegates.Add(ControlType, MethodToUse);
                            wasRegistered = true;
                        }
                    }
                }
            }

            return wasRegistered;
        }

        /// <summary>
        /// Removes the verification method for a specified control type from the
        /// list of verification methods.
        /// </summary>
        /// 
        /// <param name="ControlType">
        /// The type of control associated with the verification method.
        /// </param>
        /// 
        /// <returns>
        /// True if the method was successfully removed and false if not.
        /// </returns>
        /// 
        public bool UnregisterVerificationMethod(Type ControlType)
        {
            bool wasUnregistered = false;

            if (ControlType != null)
            {
                if (_verificationDelegates.ContainsKey(ControlType))
                {
                    wasUnregistered = _verificationDelegates.Remove(ControlType);
                }
            }

            return wasUnregistered;
        }

        /// <summary>
        /// Checks each control in the parameter for valid user input.
        /// </summary>
        /// 
        /// <remarks>
        /// If this method returns false, check the InputErrors property.
        /// This method is recursive when controls in the collection parameter
        /// contain controls.
        /// </remarks>
        /// 
        /// <param name="ControlsToValidate">
        /// A list of controls containing user input.
        /// </param>
        /// 
        /// <returns>
        /// True if all found controls contain valid user input; otherwise returns false.
        /// </returns>
        /// 
        private bool ValidateUserEntries(IEnumerable ControlsToValidate)
        {
            //  Check that the parameter is valid.

            if (ControlsToValidate != null)
            {
                List<Control> controlsToVerify;
                if (ControlsToValidate is List<Control>)
                {
                    controlsToVerify = ControlsToValidate as List<Control>;
                }
                else
                {
                    controlsToVerify = new List<Control>();
                    controlsToVerify.AddRange(ControlsToValidate.OfType<Control>());
                }

                if (controlsToVerify.Count > 0)
                {
                    //  Check the controls in the list.

                    foreach (Control currControl in controlsToVerify)
                    {
                        //  If the control is a container, check each of its controls.
                        //    The DomainUpDown control acts like a container with the text
                        //    entry area actually a textbox.

                        if (currControl.Controls.Count > 0 && IsActualContainer(currControl))
                        {
                            ValidateUserEntries(currControl.Controls);
                        }
                        else
                        {
                            VerifyControl(currControl);
                        }
                    }

                    CheckRadioButtonControls();
                }
                else
                {
                    InputErrors.Add(new InputError(new Control(), "No controls were found to verify."));
                }
            }
            else
            {
                InputErrors.Add(new InputError(new Control(), "Attempted to verify non existent collection of controls."));
            }

            return (InputErrors.Count == 0);
        }

        /// <summary>
        /// Returns true if the passed control is an actual container control and 
        /// not a control that acts like a container.
        /// </summary>
        /// 
        /// <param name="ContainerControl">
        /// The control to test.
        /// </param>
        /// 
        /// <returns>
        /// False if the specified control is one of the controls acting like a container
        /// and true if not one of those controls.
        /// </returns>
        /// 
        private bool IsActualContainer(Control ContainerControl)
        {
            bool isContainer = true;

            //  Ensure any container controls are checked by a registered verification method
            //    if they've had a verification method registered for them.

            if (_verificationDelegates.ContainsKey(ContainerControl.GetType()))
            {
                isContainer = false;
            } 
            else if (ContainerControl is DomainUpDown)
            {
                isContainer = false;
            }
            else if (ContainerControl is NumericUpDown)
            {
                isContainer = false;
            }

            return isContainer;
        }

        /// <summary>
        /// Checks the control parameter's user input for validity.  Adds an
        /// entry to the InputErrors property if the input is not valid.
        /// </summary>
        /// 
        /// <param name="ControlToCheck">
        /// The control with user input to validate.  Must be one of the types
        /// of controls that can contain user input and if not, it is ignored.
        /// </param>
        /// 
        private void VerifyControl(Control ControlToCheck)
        {
            if (_verificationDelegates.ContainsKey(ControlToCheck.GetType()))
            {
                string errMsg = _verificationDelegates[ControlToCheck.GetType()](ControlToCheck);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    InputErrors.Add(new InputError(ControlToCheck, errMsg));
                }
            }
            else if (ControlToCheck is RadioButton)
            {
                AddRadioButtonToDictionary(ControlToCheck as RadioButton);
            }
            else if (ControlToCheck is TextBox)
            {
                if (string.IsNullOrEmpty((ControlToCheck as TextBox).Text))
                {
                    InputErrors.Add(new InputError(ControlToCheck, "Text is required."));
                }
            }
            else if (ControlToCheck is CheckedListBox)
            {
                if ((ControlToCheck as CheckedListBox).CheckedItems.Count == 0)
                {
                    InputErrors.Add(new InputError(ControlToCheck, "At least one item must be checked."));
                }
            }
            else if (ControlToCheck is ComboBox)
            {
                if ((ControlToCheck as ComboBox).SelectedItem == null)
                {
                    InputErrors.Add(new InputError(ControlToCheck, "An option must be selected."));
                }
            }
            else if (ControlToCheck is DateTimePicker)
            {
                if ((ControlToCheck as DateTimePicker).Value == (ControlToCheck as DateTimePicker).MinDate)
                {
                    InputErrors.Add(new InputError(ControlToCheck, 
                        string.Format("A date greater than {0} must be selected.", (ControlToCheck as DateTimePicker).MinDate)));
                }
            }
            else if (ControlToCheck is DomainUpDown)
            {
                if (string.IsNullOrEmpty((ControlToCheck as DomainUpDown).Text))
                {
                    InputErrors.Add(new InputError(ControlToCheck, "An option must be selected."));
                }
            }
            else if (ControlToCheck is ListBox)
            {
                if ((ControlToCheck as ListBox).SelectedItem == null)
                {
                    InputErrors.Add(new InputError(ControlToCheck, "An item must be selected."));
                }
            }
            else if (ControlToCheck is MaskedTextBox)
            {
                if (!(ControlToCheck as MaskedTextBox).MaskCompleted)
                {
                    InputErrors.Add(new InputError(ControlToCheck, "Field must be completed."));
                }
            }
            else if (ControlToCheck is NumericUpDown)
            {
                NumericUpDown numUpDown = (ControlToCheck as NumericUpDown);
                if (numUpDown.Minimum == 0M && numUpDown.Value == numUpDown.Minimum) 
                {
                    InputErrors.Add(new InputError(ControlToCheck, "A value must be entered."));
                }
            }
            else if (ControlToCheck is RichTextBox)
            {
                if (string.IsNullOrEmpty((ControlToCheck as RichTextBox).Text))
                {
                    InputErrors.Add(new InputError(ControlToCheck, "Text is required."));
                }
            }
        }

        /// <summary>
        /// Adds a radiobutton control to the dictionary field based on the
        /// control that acts as the radiobutton's parent.
        /// </summary>
        /// 
        /// <param name="NewRadioButton">
        /// The radiobutton control to add to the dictionary.
        /// </param>
        /// 
        private void AddRadioButtonToDictionary(RadioButton NewRadioButton)
        {
            List<RadioButton> listRef;
            if (_radioButtons.ContainsKey(NewRadioButton.Parent))
            {
                listRef = _radioButtons[NewRadioButton.Parent];
            }
            else
            {
                listRef = new List<RadioButton>();
                _radioButtons.Add(NewRadioButton.Parent, listRef);
            }

            listRef.Add(NewRadioButton);
        }

        /// <summary>
        /// Checks each group of radio buttons to see if one of the radio buttons
        /// in the group is checked.
        /// </summary>
        /// 
        private void CheckRadioButtonControls()
        {
            foreach (Control parentControl in _radioButtons.Keys)
            {
                if (!_radioButtons[parentControl].Any(currButton => currButton.Checked))
                {
                    InputErrors.Add(new InputError(parentControl, "At least one option must be selected."));
                }
            }
        }
    }
}
