using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;
using Library.WinForms;

namespace Library.Tests
{
    public partial class TestInputVerifierDelegateForm : Form
    {
        public TestInputVerifierDelegateForm()
        {
            InitializeComponent();
            this._verifier.RegisterVerificationMethod(typeof (AddressInput), this.addressInput.AddressInputVerificationFunction);
        }

        private readonly InputVerifier _verifier = new InputVerifier();

        private void VerifyAddressInformation()
        {
            this.errorProvider.Clear();

            if (this._verifier.HasValidInput(new List<Control> { this.addressInput }))
            {
                Utility.ShowMessage(this, "All entries are valid.");
            }
            else
            {
                this.HandleInputErrors();
            }
        }

        private void HandleInputErrors()
        {
            foreach (InputError currError in this._verifier.InputErrors)
            {
                this.errorProvider.SetError(currError.ErrorControl, currError.ErrorMessage);
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            this.VerifyAddressInformation();
        }
    }
}
