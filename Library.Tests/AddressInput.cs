using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.Tests
{
    public partial class AddressInput : UserControl
    {
        public AddressInput()
        {
            InitializeComponent();
        }

        public string AddressInputVerificationFunction(Control AddressInputToCheck)
        {
            StringBuilder errMsg = new StringBuilder();

            if (this.textBoxStreet1.Text.IsEmpty() && this.textBoxStreet2.Text.IsEmpty())
            {
                errMsg.AppendLine("A street address must be specified.");
            }

            if (this.textBoxCity.Text.IsEmpty())
            {
                errMsg.AppendLine("A city must be specified.");
            }

            if (this.comboBoxCountry.Text != "Other")
            {
                if (this.comboBoxProvState.SelectedItem == null)
                {
                    errMsg.AppendLine("A state or province must be selected.");
                }

                if (this.textBoxPostalZip.Text.IsEmpty())
                {
                    errMsg.AppendLine("A postal or zip code must be specified.");
                }
            }

            if (this.comboBoxCountry.SelectedItem == null)
            {
                errMsg.AppendLine("A country must be selected.");
            }
            else if (this.comboBoxCountry.Text == "-")
            {
                errMsg.AppendLine("An invalid country was selected.  Please choose another one.");
            }

            return errMsg.ToString();
        }

        private void AdjustCountrySettings()
        {
            this.comboBoxProvState.DataSource = null;
            this.comboBoxProvState.Enabled = (this.comboBoxCountry.Text != "Other");
            this.textBoxPostalZip.Enabled  = (this.comboBoxCountry.Text != "Other");

            if (this.comboBoxCountry.Text == "Canada")
            {
                this.comboBoxProvState.DataSource = Regions.Instance.CdnProvinces;
            }
            else if (this.comboBoxCountry.Text == "United States")
            {
                this.comboBoxProvState.DataSource = Regions.Instance.USStates;
            }
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AdjustCountrySettings();
        }
    }
}
