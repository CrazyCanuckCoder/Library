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
    public partial class TestInputVerifierForm : Form
    {
        public TestInputVerifierForm()
        {
            InitializeComponent();
        }

        private readonly InputVerifier _entryVerifier = new InputVerifier();

        private void CheckDataEntries()
        {
            this.errorProvider.Clear();

            if (this._entryVerifier.HasValidInput(this.Controls))
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
            foreach (InputError currError in this._entryVerifier.InputErrors)
            {
                this.errorProvider.SetError(currError.ErrorControl, currError.ErrorMessage);
            }
        }


        
        
        
        private void buttonVerifyInputs_Click(object sender, EventArgs e)
        {
            this.CheckDataEntries();
        }
    }
}
