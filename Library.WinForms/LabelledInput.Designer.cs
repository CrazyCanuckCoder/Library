namespace Library.WinForms
{
    partial class LabelledInput
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelIndicator = new System.Windows.Forms.Label();
            this.pictureBoxErrorIndicator = new System.Windows.Forms.PictureBox();
            this.toolTipBase = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.labelDescription);
            this.splitContainerMain.Panel1.Controls.Add(this.labelIndicator);
            this.splitContainerMain.Panel1MinSize = 60;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.pictureBoxErrorIndicator);
            this.splitContainerMain.Size = new System.Drawing.Size(335, 25);
            this.splitContainerMain.SplitterDistance = 124;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 0;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Location = new System.Drawing.Point(3, 4);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(114, 16);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelIndicator
            // 
            this.labelIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndicator.ForeColor = System.Drawing.Color.Red;
            this.labelIndicator.Location = new System.Drawing.Point(116, 4);
            this.labelIndicator.Name = "labelIndicator";
            this.labelIndicator.Size = new System.Drawing.Size(9, 11);
            this.labelIndicator.TabIndex = 0;
            this.labelIndicator.Text = "*";
            this.labelIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelIndicator.Visible = false;
            // 
            // pictureBoxErrorIndicator
            // 
            this.pictureBoxErrorIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxErrorIndicator.Image = global::Library.WinForms.Properties.Resources.exclamation_red;
            this.pictureBoxErrorIndicator.Location = new System.Drawing.Point(188, 2);
            this.pictureBoxErrorIndicator.Name = "pictureBoxErrorIndicator";
            this.pictureBoxErrorIndicator.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxErrorIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxErrorIndicator.TabIndex = 1;
            this.pictureBoxErrorIndicator.TabStop = false;
            this.pictureBoxErrorIndicator.Visible = false;
            // 
            // LabelledInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "LabelledInput";
            this.Size = new System.Drawing.Size(335, 25);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorIndicator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.SplitContainer splitContainerMain;
        protected System.Windows.Forms.Label labelIndicator;
        protected System.Windows.Forms.Label labelDescription;
        protected System.Windows.Forms.PictureBox pictureBoxErrorIndicator;
        private System.Windows.Forms.ToolTip toolTipBase;

    }
}
