namespace Library.Tests
{
    partial class AddressInput
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxStreet1 = new System.Windows.Forms.TextBox();
            this.textBoxStreet2 = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.labelStreet = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelProvState = new System.Windows.Forms.Label();
            this.comboBoxProvState = new System.Windows.Forms.ComboBox();
            this.labelPostalZip = new System.Windows.Forms.Label();
            this.textBoxPostalZip = new System.Windows.Forms.TextBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.labelCoutnry = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxStreet1
            // 
            this.textBoxStreet1.Location = new System.Drawing.Point(96, 23);
            this.textBoxStreet1.Name = "textBoxStreet1";
            this.textBoxStreet1.Size = new System.Drawing.Size(299, 20);
            this.textBoxStreet1.TabIndex = 0;
            // 
            // textBoxStreet2
            // 
            this.textBoxStreet2.Location = new System.Drawing.Point(96, 49);
            this.textBoxStreet2.Name = "textBoxStreet2";
            this.textBoxStreet2.Size = new System.Drawing.Size(299, 20);
            this.textBoxStreet2.TabIndex = 1;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(96, 75);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(299, 20);
            this.textBoxCity.TabIndex = 2;
            // 
            // labelStreet
            // 
            this.labelStreet.Location = new System.Drawing.Point(3, 27);
            this.labelStreet.Name = "labelStreet";
            this.labelStreet.Size = new System.Drawing.Size(87, 13);
            this.labelStreet.TabIndex = 3;
            this.labelStreet.Text = "Street:";
            this.labelStreet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCity
            // 
            this.labelCity.Location = new System.Drawing.Point(3, 78);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(87, 13);
            this.labelCity.TabIndex = 4;
            this.labelCity.Text = "City:";
            this.labelCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelProvState
            // 
            this.labelProvState.Location = new System.Drawing.Point(3, 105);
            this.labelProvState.Name = "labelProvState";
            this.labelProvState.Size = new System.Drawing.Size(87, 13);
            this.labelProvState.TabIndex = 5;
            this.labelProvState.Text = "Province/State:";
            this.labelProvState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxProvState
            // 
            this.comboBoxProvState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvState.DropDownWidth = 171;
            this.comboBoxProvState.FormattingEnabled = true;
            this.comboBoxProvState.Location = new System.Drawing.Point(96, 101);
            this.comboBoxProvState.Name = "comboBoxProvState";
            this.comboBoxProvState.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProvState.TabIndex = 6;
            // 
            // labelPostalZip
            // 
            this.labelPostalZip.Location = new System.Drawing.Point(223, 104);
            this.labelPostalZip.Name = "labelPostalZip";
            this.labelPostalZip.Size = new System.Drawing.Size(62, 13);
            this.labelPostalZip.TabIndex = 7;
            this.labelPostalZip.Text = "Postal/Zip:";
            this.labelPostalZip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPostalZip
            // 
            this.textBoxPostalZip.Location = new System.Drawing.Point(291, 101);
            this.textBoxPostalZip.Name = "textBoxPostalZip";
            this.textBoxPostalZip.Size = new System.Drawing.Size(104, 20);
            this.textBoxPostalZip.TabIndex = 8;
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Items.AddRange(new object[] {
            "Canada",
            "United States",
            "-",
            "Other"});
            this.comboBoxCountry.Location = new System.Drawing.Point(96, 128);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(161, 21);
            this.comboBoxCountry.TabIndex = 10;
            this.comboBoxCountry.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountry_SelectedIndexChanged);
            // 
            // labelCoutnry
            // 
            this.labelCoutnry.Location = new System.Drawing.Point(3, 132);
            this.labelCoutnry.Name = "labelCoutnry";
            this.labelCoutnry.Size = new System.Drawing.Size(87, 13);
            this.labelCoutnry.TabIndex = 9;
            this.labelCoutnry.Text = "Country:";
            this.labelCoutnry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddressInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.labelCoutnry);
            this.Controls.Add(this.textBoxPostalZip);
            this.Controls.Add(this.labelPostalZip);
            this.Controls.Add(this.comboBoxProvState);
            this.Controls.Add(this.labelProvState);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelStreet);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxStreet2);
            this.Controls.Add(this.textBoxStreet1);
            this.Name = "AddressInput";
            this.Size = new System.Drawing.Size(404, 173);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStreet1;
        private System.Windows.Forms.TextBox textBoxStreet2;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label labelStreet;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelProvState;
        private System.Windows.Forms.ComboBox comboBoxProvState;
        private System.Windows.Forms.Label labelPostalZip;
        private System.Windows.Forms.TextBox textBoxPostalZip;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Label labelCoutnry;
    }
}
