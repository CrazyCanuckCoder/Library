#region

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class FileInput : LabelledInput, IDataEntryControl
    {
        public FileInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Forces the selection dialog box to verify the chosen file exists.
        /// </summary>
        /// 
        [Description("Forces the selection dialog box to verify the chosen file exists.")]
        public bool CheckFileExists { get; set; }

        /// <summary>
        /// Determines the types of files that can be selected in the selection dialog box.
        /// </summary>
        /// 
        [Description("Determines the types of files that can be selected in the selection dialog box.")]
        public string SelectionFilter { get; set; }

        /// <summary>
        /// The directory to start the selection dialog box in.
        /// </summary>
        /// 
        [Description("The directory to start the selection dialog box in.")]
        public string InitialDirectory { get; set; }

        /// <summary>
        /// The text to display at the top of the selection dialog box.
        /// </summary>
        /// 
        [Description("The text to display at the top of the selection dialog box.")]
        public string DialogTitle { get; set; }

        /// <summary>
        /// Specifies which selection dialog box to display.
        /// </summary>
        /// 
        [Description("Specifies which selection dialog box to display.")]
        public FileSelectMode SelectionMode { get; set; }


        [Description("Returns true if the file has been selected.")]
        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(textBoxFilePath.Text); }
        }

        [Description("The file and path selected by the user.")]
        public string Value
        {
            get { return textBoxFilePath.Text; }

            set
            {
                if (value != null)
                {
                    textBoxFilePath.Text = value;
                }
            }
        }

        /// <summary>
        /// Sets the default values for the properties of this class.
        /// </summary>
        /// 
        private void InitProperties()
        {
            CheckFileExists = false;
            SelectionFilter = "";
            InitialDirectory = "";
            DialogTitle = "";
            SelectionMode = FileSelectMode.Open;
        }

        /// <summary>
        /// Displays the specified dialog box to allow the user to chose a file.
        /// </summary>
        /// 
        /// <param name="DialogRef">
        /// A reference to the dialog box to display to the user.
        /// </param>
        /// 
        private void ChoseFile(FileDialog DialogRef)
        {
            DialogRef.CheckFileExists = CheckFileExists;
            DialogRef.Filter = SelectionFilter;
            DialogRef.FileName = Value;
            DialogRef.InitialDirectory = InitialDirectory;
            DialogRef.Title = DialogTitle;

            if (DialogRef.ShowDialog(FindForm()) == DialogResult.OK)
            {
                textBoxFilePath.Text = DialogRef.FileName;
            }
        }

        public bool HasRequiredInput()
        {
            bool hasInput = true;

            if (IsMandatory)
            {
                hasInput = HasValue;
            }

            pictureBoxErrorIndicator.Visible = !hasInput;

            return hasInput;
        }

        public void SetDataBinding(BindingSource DataBinder, string SourceName)
        {
            textBoxFilePath.DataBindings.Add("Text", DataBinder, SourceName, false,
                                             DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Displays the open file dialog box to the user just as if they had clicked the Browse button.
        /// </summary>
        /// 
        public void OpenFile()
        {
            ChoseFile(openFileDialog);
        }

        /// <summary>
        /// Displays the save file dialog box to the user just as if they had clicked the Browse button.
        /// </summary>
        /// 
        public void SaveFile()
        {
            ChoseFile(saveFileDialog);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            switch (SelectionMode)
            {
                case FileSelectMode.Open:
                    OpenFile();
                    break;

                case FileSelectMode.Save:
                    SaveFile();
                    break;
            }
        }

        private void FileInput_Leave(object sender, EventArgs e)
        {
            HasRequiredInput();
        }

        private void FileInput_EnabledChanged(object sender, EventArgs e)
        {
            textBoxFilePath.Enabled = Enabled;
            buttonBrowse.Enabled = Enabled;
        }
    }
}