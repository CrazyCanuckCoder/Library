using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Windows.Forms;

namespace Library.Tests
{
    [TestFixture]
    public class InputVerifierTests
    {
        private InputVerifier _verifier = null;
        private List<Control> _controls = null;
            

        [SetUp]
        public void BeforeTest()
        {
            this._verifier = new InputVerifier();
            this._controls = new List<Control>();
        }

        [TearDown]
        public void AfterTest()
        {
            this._verifier = null;
            this._controls = null;
        }



        [Test]
        public void HasValidInput_ReturnsFalse_ForNullParameter()
        {
            Assert.IsFalse(this._verifier.HasValidInput(null), "HasValidInput returned true for null parameter.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForEmptyControlCollection()
        {
            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for empty collection.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForUncheckedRadioButtons()
        {
            Control parentControl = new GroupBox();
            parentControl.Name = "GroupBox1";

            RadioButton radioButton1 = new RadioButton { Parent = parentControl };
            RadioButton radioButton2 = new RadioButton { Parent = parentControl };
            RadioButton radioButton3 = new RadioButton { Parent = parentControl };

            this._controls.Add(radioButton1);
            this._controls.Add(radioButton2);
            this._controls.Add(radioButton3);
            
            Assert.IsTrue(!this._verifier.HasValidInput(this._controls) && this._verifier.InputErrors[0].ErrorControl.Equals(parentControl), 
                "HasValidInput returned true for unchecked radio buttons.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForOneCheckedRadioButton()
        {
            Control parentControl = new GroupBox();
            parentControl.Name = "GroupBox1";

            RadioButton radioButton1 = new RadioButton { Parent = parentControl };
            RadioButton radioButton2 = new RadioButton { Parent = parentControl, Checked = true };
            RadioButton radioButton3 = new RadioButton { Parent = parentControl };

            this._controls.Add(radioButton1);
            this._controls.Add(radioButton2);
            this._controls.Add(radioButton3);
            
            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for a checked radio button.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForCheckedRadioButtonInTwoGroups()
        {
            Control parentControl = new GroupBox();
            parentControl.Name = "GroupBox1";

            RadioButton radioButton1 = new RadioButton { Parent = parentControl };
            RadioButton radioButton2 = new RadioButton { Parent = parentControl, Checked = true };
            RadioButton radioButton3 = new RadioButton { Parent = parentControl };

            Control parentControl2 = new GroupBox();
            parentControl2.Name = "GroupBox2";

            RadioButton radioButton4 = new RadioButton { Parent = parentControl2, Checked = true };
            RadioButton radioButton5 = new RadioButton { Parent = parentControl2 };
            RadioButton radioButton6 = new RadioButton { Parent = parentControl2 };

            this._controls.Add(radioButton1);
            this._controls.Add(radioButton2);
            this._controls.Add(radioButton3);
            this._controls.Add(radioButton4);
            this._controls.Add(radioButton5);
            this._controls.Add(radioButton6);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for checked radio buttons in two groups.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForUncheckedRadioButtonInTwoGroups()
        {
            Control parentControl = new GroupBox();
            parentControl.Name = "GroupBox1";

            RadioButton radioButton1 = new RadioButton { Parent = parentControl };
            RadioButton radioButton2 = new RadioButton { Parent = parentControl, Checked = true };
            RadioButton radioButton3 = new RadioButton { Parent = parentControl };

            Control parentControl2 = new GroupBox();
            parentControl2.Name = "GroupBox2";

            RadioButton radioButton4 = new RadioButton { Parent = parentControl2 };
            RadioButton radioButton5 = new RadioButton { Parent = parentControl2 };
            RadioButton radioButton6 = new RadioButton { Parent = parentControl2 };

            this._controls.Add(radioButton1);
            this._controls.Add(radioButton2);
            this._controls.Add(radioButton3);
            this._controls.Add(radioButton4);
            this._controls.Add(radioButton5);
            this._controls.Add(radioButton6);

            Assert.IsTrue(!this._verifier.HasValidInput(this._controls) && 
                           this._verifier.InputErrors.Count == 1 &&
                           this._verifier.InputErrors[0].ErrorControl.Equals(parentControl2), 
                "HasValidInput returned true for an unchecked radio buttons in two groups.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForBlankTextBox()
        {
            TextBox textBox = new TextBox();

            this._controls.Add(textBox);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for an empty textbox.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForTextBoxWithText()
        {
            TextBox textBox = new TextBox();
            textBox.Text = "contains text";

            this._controls.Add(textBox);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for textbox with text.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForCheckedListBoxWithoutCheckedItems()
        {
            CheckedListBox listBox = new CheckedListBox();

            listBox.Items.Add("Item1");
            listBox.Items.Add("Item2");
            listBox.Items.Add("Item3");

            this._controls.Add(listBox);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls) &&
                           this._verifier.InputErrors.Count == 1 &&
                           this._verifier.InputErrors[0].ErrorControl.Equals(listBox),
                "HasValidInput returned true for checklistbox without checked items.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForCheckedListBoxWithOneCheckedItem()
        {
            CheckedListBox listBox = new CheckedListBox();

            listBox.Items.Add("Item1");
            listBox.Items.Add("Item2");
            listBox.Items.Add("Item3");
            listBox.SetItemCheckState(0, CheckState.Checked);

            this._controls.Add(listBox);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for checklistbox with a checked item.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForDateTimePickerWithMinDateSet()
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Value = dateTimePicker.MinDate;

            this._controls.Add(dateTimePicker);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for date time picker with minimum date.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForDateTimePickerWithCurrentDate()
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Value = DateTime.Now;

            this._controls.Add(dateTimePicker);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for date time picker with current date.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForDomainUpDownWithNoText()
        {
            DomainUpDown domainUpDown = new DomainUpDown();
            domainUpDown.Text = "";

            this._controls.Add(domainUpDown);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for domain updown with no text.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForDomainUpDownWithText()
        {
            DomainUpDown domainUpDown = new DomainUpDown();
            domainUpDown.Items.Add("First");
            domainUpDown.Items.Add("Second");
            domainUpDown.Items.Add("Third");

            domainUpDown.Text = "First";

            this._controls.Add(domainUpDown);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for domain updown with text.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForListBoxWithNoSelectedItem()
        {
            ListBox listBox = new ListBox();
            listBox.Items.Add("First");
            listBox.Items.Add("Second");
            listBox.Items.Add("Third");

            this._controls.Add(listBox);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for listbox with no selected item.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForListBoxWithSelectedItem()
        {
            ListBox listBox = new ListBox();
            listBox.Items.Add("First");
            listBox.Items.Add("Second");
            listBox.Items.Add("Third");

            listBox.SelectedIndex = 0;

            this._controls.Add(listBox);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for listbox with a selected item.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForMaskedTextBoxWithoutText()
        {
            MaskedTextBox textBox = new MaskedTextBox();
            textBox.Mask = "(999) 000-0000";
            textBox.Text = "";

            this._controls.Add(textBox);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for masked textbox without text.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForMaskedTextBoxWithText()
        {
            MaskedTextBox textBox = new MaskedTextBox();
            textBox.Mask = "(999) 000-0000";
            textBox.Text = "(519) 555-1234";

            this._controls.Add(textBox);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for masked textbox with text.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForNumericUpDownWithNoValue()
        {
            NumericUpDown numUpDown = new NumericUpDown();
            numUpDown.Value = 0M;

            this._controls.Add(numUpDown);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for numeric updown with no value.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForNumericUpDownWithValue()
        {
            NumericUpDown numUpDown = new NumericUpDown();
            numUpDown.Value = 1M;

            this._controls.Add(numUpDown);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for numeric updown with a value.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForNumericUpDownWithMinimumValue()
        {
            NumericUpDown numUpDown = new NumericUpDown();
            numUpDown.Minimum = 1M;
            numUpDown.Value = 1M;

            this._controls.Add(numUpDown);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for numeric updown with minimum value.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForNumericUpDownWithMoreThanMinimumValue()
        {
            NumericUpDown numUpDown = new NumericUpDown();
            numUpDown.Minimum = 1M;
            numUpDown.Value = 2M;

            this._controls.Add(numUpDown);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for numeric updown with minimum value.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForRichTextBoxWithNoText()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Text = "";

            this._controls.Add(richTextBox);

            Assert.IsFalse(this._verifier.HasValidInput(this._controls), "HasValidInput returned true for rich textbox with no text.");
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForRichTextBoxWithText()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Text = "Text";

            this._controls.Add(richTextBox);

            Assert.IsTrue(this._verifier.HasValidInput(this._controls), "HasValidInput returned false for rich textbox with text.");
        }


        private string ExampleVerificationFunction(Control ControlToCheck)
        {
            return "";
        }


        [Test]
        public void RegisterVerificationMethod_ReturnsFalse_ForNullControlParameter()
        {
            Assert.IsFalse(this._verifier.RegisterVerificationMethod(null, ExampleVerificationFunction), 
                "RegisterVerificationMethod returned true for null control parameter.");
        }

        [Test]
        public void RegisterVerificationMethod_ReturnsFalse_ForNullDelegateParameter()
        {
            Assert.IsFalse(this._verifier.RegisterVerificationMethod(typeof(TextBox), null), 
                "RegisterVerificationMethod returned true for null delegate parameter.");
        }

        [Test]
        public void RegisterVerificationMethod_ReturnsFalse_ForExistingControlDelegate()
        {
            if (this._verifier.RegisterVerificationMethod(typeof(TextBox), ExampleVerificationFunction))
            {
                Assert.IsFalse(this._verifier.RegisterVerificationMethod(typeof(TextBox), ExampleVerificationFunction),
                    "RegisterVerificationMethod returned true for existing control delegate.");
            }
            else
            {
                Assert.Fail("RegisterVerificationMethod returned false when adding valid control and delegate.");
            }
        }

        [Test]
        public void RegisterVerificationMethod_ReturnsFalse_ForNonControlParameter()
        {
            Assert.IsFalse(this._verifier.RegisterVerificationMethod(typeof(string), ExampleVerificationFunction), 
                "RegisterVerificationMethod returned true for non control parameter.");
        }

        private const string EXPECTED_TEXT_FOR_TEXTBOX = "Some example text"; 
        private string TextBoxVerificationFunction(Control TextBoxToCheck)
        {
            return ((TextBoxToCheck as TextBox).Text == EXPECTED_TEXT_FOR_TEXTBOX ? "" : "Invalid text entered");
        }

        [Test]
        public void RegisterVerificationMethod_ReturnsTrue_ForCorrectRegistration()
        {
            Assert.IsTrue(this._verifier.RegisterVerificationMethod(typeof(TextBox), TextBoxVerificationFunction),
                "RegisterVerificationMethod returned false for the correct registration of a method.");
        }

        [Test]
        public void HasValidInput_ReturnsFalse_ForVerificationMethodReturningErrorString()
        {
            if (this._verifier.RegisterVerificationMethod(typeof(TextBox), TextBoxVerificationFunction))
            {
                TextBox testTextBox = new TextBox();
                testTextBox.Text = "invalid text";

                this._controls.Add(testTextBox);

                Assert.IsFalse(this._verifier.HasValidInput(this._controls), 
                    "HasValidInput returned true for empty textbox verified through external method.");
            }
            else
            {
                Assert.Fail("RegisterVerificationMethod returned false for the correct registration of a method.");
            }
        }

        [Test]
        public void HasValidInput_ReturnsTrue_ForVerificationMethodReturningEmptyString()
        {
            if (this._verifier.RegisterVerificationMethod(typeof(TextBox), TextBoxVerificationFunction))
            {
                TextBox testTextBox = new TextBox();
                testTextBox.Text = EXPECTED_TEXT_FOR_TEXTBOX;

                this._controls.Add(testTextBox);

                Assert.IsTrue(this._verifier.HasValidInput(this._controls), 
                    "HasValidInput returned false for textbox with text verified through external method.");
            }
            else
            {
                Assert.Fail("RegisterVerificationMethod returned false for the correct registration of a method.");
            }
        }

    }
}
