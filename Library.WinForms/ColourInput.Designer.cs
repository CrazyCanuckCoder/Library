namespace Library.WinForms
{
    partial class ColourInput
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
            this.colorComboBoxInput = new Library.WinForms.ColorComboBox();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.colorComboBoxInput);
            // 
            // colorComboBoxInput
            // 
            this.colorComboBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorComboBoxInput.Color = System.Drawing.Color.Black;
            this.colorComboBoxInput.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBoxInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBoxInput.FormattingEnabled = true;
            this.colorComboBoxInput.Location = new System.Drawing.Point(4, 2);
            this.colorComboBoxInput.Name = "colorComboBoxInput";
            this.colorComboBoxInput.Size = new System.Drawing.Size(179, 21);
            this.colorComboBoxInput.TabIndex = 2;
            this.colorComboBoxInput.Leave += new System.EventHandler(this.colorComboBoxInput_Leave);
            // 
            // ColourInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ColourInput";
            this.EnabledChanged += new System.EventHandler(this.ColourInput_EnabledChanged);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorIndicator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorComboBox colorComboBoxInput;
    }
}
