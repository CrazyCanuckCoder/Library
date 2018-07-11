#region

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            InitializeComponent();
            _widthDiff = panelDescription.Width - labelDescription.Width;
            InitProperties();
        }

        /// <summary>
        /// Contains the difference between the length of the description label
        /// and its containing panel.
        /// </summary>
        /// 
        private readonly int _widthDiff = 0;

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

        /// <summary>
        /// The text to use in this control that describes the file to select.
        /// </summary>
        /// 
        [Description("The text to use in this control that describes the file to select.")]
        public string Prompt
        {
            get { return labelDescription.Text; }

            set { labelDescription.Text = value; }
        }

        /// <summary>
        /// Gets/sets the file chosen by the user.
        /// </summary>
        /// 
        [Description("Gets/sets the file chosen by the user.")]
        public string ChosenFile
        {
            get { return textBoxFilePath.Text; }

            set { textBoxFilePath.Text = value; }
        }

        /// <summary>
        /// Fired when the user selects a file from a dialog box prompt.
        /// </summary>
        /// 
        [Description("Fired when the user selects a file from a dialog box prompt.")]
        public event FileChosenEventHandler FileChosen;

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
            Prompt = "";
            ChosenFile = "";
        }

        /// <summary>
        /// Fires the FileChosen event with information about the file chosen by the user.
        /// </summary>
        /// 
        private void OnFileChosen()
        {
            if (FileChosen != null)
            {
                FileChosen(this, new FileChosenEventArgs(ChosenFile, SelectionMode));
            }
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
            DialogRef.FileName = ChosenFile;
            DialogRef.InitialDirectory = InitialDirectory;
            DialogRef.Title = DialogTitle;

            if (DialogRef.ShowDialog(FindForm()) == DialogResult.OK)
            {
                textBoxFilePath.Text = DialogRef.FileName;
                OnFileChosen();
            }
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

        private void labelDescription_Resize(object sender, EventArgs e)
        {
            //  Adjust the width of the left most panel to accommodate the
            //    description text.

            panelDescription.Width = labelDescription.Width + _widthDiff;
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
    }
}