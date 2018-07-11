using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using Library;
using Library.WinForms;

namespace Library.Tests
{
    [TestFixture]
    public class TouchErrorProviderTests
    {
        #region  Test Utilities

        private TouchErrorProvider _errorProvider;

        [SetUp]
        public void Init()
        {
            this._errorProvider = new TouchErrorProvider();
        }

        [TearDown]
        public void Exit()
        {
            this._errorProvider = null;
        }

        #endregion




        #region CanExtend() Tests

        [Test]
        public void CanExtend_ReturnsFalse_ForNonControl()
        {
            bool result = this._errorProvider.CanExtend(new object());

            Assert.IsFalse(result, "CanExtend returned true for an object that wasn't a Control.");
        }

        [Test]
        public void CanExtend_ReturnsTrue_ForControl()
        {
            bool result = this._errorProvider.CanExtend(new Control());

            Assert.IsTrue(result, "CanExtend returned false for an object that is a Control.");
        }

        #endregion




        #region SetToolTipProvider() Tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetToolTipProvider_ThrowsException_ForNullParameter()
        {
            this._errorProvider.SetToolTipProvider(null);
        }

        #endregion




        #region SetError() Tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetError_ThrowsException_ForNullErrorControl()
        {
            this._errorProvider.SetError(null, null, "New error text.", ErrorIconAlignment.MiddleRight);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetError_ThrowsException_ForNullIconControl()
        {
            this._errorProvider.SetError(new TextBox(), null, "New error text.", ErrorIconAlignment.MiddleRight);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SetError_ThrowsException_ForEmptyErrorText()
        {
            this._errorProvider.SetError(new TextBox(), new TextBox(), "", ErrorIconAlignment.MiddleRight);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SetError_ThrowsException_ForExistingErrorControl()
        {
            Panel tempPanel = new Panel();
            TextBox sampleTextBox = new TextBox {Text = "sample"};
            tempPanel.Controls.Add(sampleTextBox);

            this._errorProvider.SetError(sampleTextBox, "New error text.");
            this._errorProvider.SetError(sampleTextBox, "New error text.");
        }

        #endregion




        #region GetError() Tests

        [Test]
        public void GetError_ReturnsErrorText_ForNullErrorControl()
        {
            string result = this._errorProvider.GetError(null);

            Assert.That(result == "Invalid argument, ErrorControl is null.", "GetError did not return error message for null parameter.  Result: " + result);
        }

        [Test]
        public void GetError_ReturnsBlankText_ForErrorControlNotInCollection()
        {
            string result = this._errorProvider.GetError(new TextBox());

            Assert.That(result == "", "GetError did not return blank result for control not in collection.  Result: " + result);
        }

        [Test]
        public void GetError_ReturnsErrorText_ForCorrectErrorControl()
        {
            Panel tempPanel = new Panel();
            TextBox sampleTextBox = new TextBox {Text = "sample"};
            tempPanel.Controls.Add(sampleTextBox);

            this._errorProvider.SetError(sampleTextBox, "New error text.");

            string result = this._errorProvider.GetError(sampleTextBox);

            Assert.That(result == "New error text.", "GetError did not return the proper error text for existing control.  Result: " + result);
        }

        #endregion




        #region  SetIconControl() Tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIconControl_ThrowsException_ForNullErrorControl()
        {
            this._errorProvider.SetIconControl(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIconControl_ThrowsException_ForNullIconControl()
        {
            this._errorProvider.SetIconControl(new Control(), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Specified control does not have an error instance.")]
        public void SetIconControl_ThrowsException_ForErrorControlNotInCollection()
        {
            this._errorProvider.SetIconControl(new Control(), new Control());
        }

        #endregion




        #region  GetIconControl() Tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetIconControl_ThrowsException_ForNullErrorControl()
        {
            this._errorProvider.GetIconControl(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Specified control does not have an error instance.")]
        public void GetIconControl_ThrowsException_ForErrorControlNotInCollection()
        {
            this._errorProvider.GetIconControl(new Control());
        }

        [Test]
        public void GetIconControl_ReturnsIconControl_ForErrorControl()
        {
            Panel tempPanel = new Panel();
            TextBox sampleTextBox = new TextBox { Text = "sample" };
            Label iconLabel = new Label { Text = "Show error icon" };
            tempPanel.Controls.Add(sampleTextBox);
            tempPanel.Controls.Add(iconLabel);

            this._errorProvider.SetError(sampleTextBox, iconLabel, "New error text.");

            Control result = this._errorProvider.GetIconControl(sampleTextBox);

            Assert.AreEqual(iconLabel, result);
        }

        #endregion




        #region  ClearError() Tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClearError_ThrowsException_ForNullErrorControl()
        {
            this._errorProvider.ClearError(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Specified control does not have an error instance.")]
        public void ClearError_ThrowsException_ForErrorControlNotInCollection()
        {
            this._errorProvider.ClearError(new Control());
        }

        [Test]
        public void ClearError_RemovesError_ForErrorControl()
        {
            Panel tempPanel = new Panel();
            TextBox sampleTextBox = new TextBox { Text = "sample" };
            tempPanel.Controls.Add(sampleTextBox);

            this._errorProvider.SetError(sampleTextBox, "error text");
            this._errorProvider.ClearError(sampleTextBox);

            string result = this._errorProvider.GetError(sampleTextBox);

            Assert.That(result == "", "Clear error did not remove error for valid error control.");
        }

        #endregion




        #region  SetIconAlignment() Tests

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetIconAlignment_ThrowsException_ForNullErrorControl()
        {
            this._errorProvider.SetIconAlignment(null, ErrorIconAlignment.MiddleRight);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Specified control does not have an error instance.")]
        public void SetIconAlignment_ThrowsException_ForErrorControlNotInCollection()
        {
            this._errorProvider.SetIconAlignment(new Control(), ErrorIconAlignment.MiddleRight);
        }

        [Test]
        public void SetIconAlignment_ChangesAlignment_ForValidErrorControl()
        {
            Panel tempPanel = new Panel();
            TextBox sampleTextBox = new TextBox { Text = "sample" };
            tempPanel.Controls.Add(sampleTextBox);

            this._errorProvider.SetError(sampleTextBox, "error text");  //  Sets default alignment (MiddleRight).
            
            this._errorProvider.SetIconAlignment(sampleTextBox, ErrorIconAlignment.BottomLeft);
            ErrorIconAlignment newAlignment = this._errorProvider.GetIconAlignment(sampleTextBox);

            Assert.AreEqual(ErrorIconAlignment.BottomLeft, newAlignment);
        }

        #endregion
    }
}
