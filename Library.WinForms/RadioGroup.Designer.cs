namespace Library.WinForms
{
    partial class RadioGroup
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
            this.panelGroup = new System.Windows.Forms.Panel();
            this.flowLayoutPanelHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelIndicator = new System.Windows.Forms.Label();
            this.pictureBoxErrorIndicator = new System.Windows.Forms.PictureBox();
            this.panelGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGroup
            // 
            this.panelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGroup.Controls.Add(this.flowLayoutPanelHolder);
            this.panelGroup.Location = new System.Drawing.Point(3, 11);
            this.panelGroup.Margin = new System.Windows.Forms.Padding(0);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(178, 157);
            this.panelGroup.TabIndex = 0;
            // 
            // flowLayoutPanelHolder
            // 
            this.flowLayoutPanelHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelHolder.Location = new System.Drawing.Point(1, 4);
            this.flowLayoutPanelHolder.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelHolder.Name = "flowLayoutPanelHolder";
            this.flowLayoutPanelHolder.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelHolder.Size = new System.Drawing.Size(173, 150);
            this.flowLayoutPanelHolder.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(10, 3);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(48, 13);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = " Header ";
            // 
            // labelIndicator
            // 
            this.labelIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndicator.ForeColor = System.Drawing.Color.Red;
            this.labelIndicator.Location = new System.Drawing.Point(58, 2);
            this.labelIndicator.Name = "labelIndicator";
            this.labelIndicator.Size = new System.Drawing.Size(13, 13);
            this.labelIndicator.TabIndex = 3;
            this.labelIndicator.Text = "*";
            this.labelIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelIndicator.Visible = false;
            // 
            // pictureBoxErrorIndicator
            // 
            this.pictureBoxErrorIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxErrorIndicator.Image = global::Library.WinForms.Properties.Resources.exclamation_red;
            this.pictureBoxErrorIndicator.Location = new System.Drawing.Point(186, 11);
            this.pictureBoxErrorIndicator.Name = "pictureBoxErrorIndicator";
            this.pictureBoxErrorIndicator.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxErrorIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxErrorIndicator.TabIndex = 4;
            this.pictureBoxErrorIndicator.TabStop = false;
            this.pictureBoxErrorIndicator.Visible = false;
            // 
            // RadioGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxErrorIndicator);
            this.Controls.Add(this.labelIndicator);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.panelGroup);
            this.Name = "RadioGroup";
            this.Size = new System.Drawing.Size(206, 173);
            this.panelGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHolder;
        protected System.Windows.Forms.Label labelIndicator;
        protected System.Windows.Forms.PictureBox pictureBoxErrorIndicator;
    }
}
