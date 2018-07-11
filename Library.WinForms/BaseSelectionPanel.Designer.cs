namespace Library.WinForms
{
    partial class BaseSelectionPanel
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
            this.panelTitles = new System.Windows.Forms.Panel();
            this.flowLayoutPanelBody = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panelTitles
            // 
            this.panelTitles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitles.Location = new System.Drawing.Point(0, 0);
            this.panelTitles.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitles.Name = "panelTitles";
            this.panelTitles.Size = new System.Drawing.Size(150, 25);
            this.panelTitles.TabIndex = 0;
            // 
            // flowLayoutPanelBody
            // 
            this.flowLayoutPanelBody.AutoScroll = true;
            this.flowLayoutPanelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelBody.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanelBody.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelBody.Name = "flowLayoutPanelBody";
            this.flowLayoutPanelBody.Size = new System.Drawing.Size(150, 125);
            this.flowLayoutPanelBody.TabIndex = 1;
            this.flowLayoutPanelBody.WrapContents = false;
            // 
            // BaseSelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelBody);
            this.Controls.Add(this.panelTitles);
            this.Name = "BaseSelectionPanel";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelTitles;
        protected System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBody;

    }
}
