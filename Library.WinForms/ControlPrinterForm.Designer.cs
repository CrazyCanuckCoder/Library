namespace Library.WinForms
{
    partial class ControlPrinterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.borderPanelBase = new Library.WinForms.BorderPanel();
            this.SuspendLayout();
            // 
            // borderPanelBase
            // 
            this.borderPanelBase.BackColor = System.Drawing.Color.White;
            this.borderPanelBase.BorderColour = System.Drawing.SystemColors.ControlDark;
            this.borderPanelBase.BorderWidth = 1;
            this.borderPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderPanelBase.Location = new System.Drawing.Point(0, 0);
            this.borderPanelBase.Name = "borderPanelBase";
            this.borderPanelBase.Size = new System.Drawing.Size(284, 262);
            this.borderPanelBase.TabIndex = 1;
            // 
            // ControlPrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.borderPanelBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlPrinterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ControlPrinterForm";
            this.ResumeLayout(false);

        }

        #endregion

        protected BorderPanel borderPanelBase;
    }
}