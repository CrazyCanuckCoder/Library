namespace Library.WinForms
{
    partial class MillersColumn
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
            this.borderPanelList = new Library.WinForms.BorderPanel();
            this.flowLayoutPanelItems = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.borderPanelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderPanelList
            // 
            this.borderPanelList.BackColor = System.Drawing.SystemColors.Window;
            this.borderPanelList.BorderColour = System.Drawing.SystemColors.ControlDark;
            this.borderPanelList.BorderWidth = 1;
            this.borderPanelList.Controls.Add(this.flowLayoutPanelItems);
            this.borderPanelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderPanelList.Location = new System.Drawing.Point(0, 0);
            this.borderPanelList.Name = "borderPanelList";
            this.borderPanelList.Size = new System.Drawing.Size(313, 324);
            this.borderPanelList.TabIndex = 0;
            // 
            // flowLayoutPanelItems
            // 
            this.flowLayoutPanelItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelItems.AutoScroll = true;
            this.flowLayoutPanelItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelItems.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanelItems.Name = "flowLayoutPanelItems";
            this.flowLayoutPanelItems.Size = new System.Drawing.Size(309, 320);
            this.flowLayoutPanelItems.TabIndex = 0;
            this.flowLayoutPanelItems.WrapContents = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // MillersColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.borderPanelList);
            this.Name = "MillersColumn";
            this.Size = new System.Drawing.Size(313, 324);
            this.borderPanelList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BorderPanel borderPanelList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelItems;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}
