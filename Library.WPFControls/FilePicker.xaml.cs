using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Library.WPFControls
{
    /// <summary>
    /// Interaction logic for FilePicker.xaml
    /// </summary>
    public partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            InitializeComponent();
            this.InitProperties();
        }


        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
        private readonly SaveFileDialog _saveFileDialog = new SaveFileDialog();

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
            get { return this.LabelDescription.Content.ToString(); }

            set { this.LabelDescription.Content = value; }
        }

        /// <summary>
        /// Gets/sets the file chosen by the user.
        /// </summary>
        /// 
        [Description("Gets/sets the file chosen by the user.")]
        public string ChosenFile
        {
            get { return this.TextBoxFilePath.Text; }

            set { this.TextBoxFilePath.Text = value; }
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
            this.CheckFileExists  = false;
            this.SelectionFilter  = "";
            this.InitialDirectory = "";
            this.DialogTitle      = "";
            this.SelectionMode    = FileSelectMode.Open;
            this.Prompt           = "";
            this.ChosenFile       = "";
        }

        /// <summary>
        /// Fires the FileChosen event with information about the file chosen by the user.
        /// </summary>
        /// 
        private void OnFileChosen()
        {
            if (this.FileChosen != null)
            {
                this.FileChosen(this, new FileChosenEventArgs(this.ChosenFile, this.SelectionMode));
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
            DialogRef.CheckFileExists  = this.CheckFileExists;
            DialogRef.Filter           = this.SelectionFilter;
            DialogRef.FileName         = this.ChosenFile;
            DialogRef.InitialDirectory = this.InitialDirectory;
            DialogRef.Title            = this.DialogTitle;

            var showDialog = DialogRef.ShowDialog();
            if (showDialog != null && (bool)showDialog)
            {
                this.TextBoxFilePath.Text = DialogRef.FileName;
                this.OnFileChosen();
            }
        }

        /// <summary>
        /// Displays the appropriate dialog box based on the setting of the SelectionMode property.
        /// </summary>
        /// 
        private void PromptUserForFilePath()
        {
            switch (this.SelectionMode)
            {
                case FileSelectMode.Open:
                    this.OpenFile();
                    break;

                case FileSelectMode.Save:
                    this.SaveFile();
                    break;
            }
        }

        /// <summary>
        /// Displays the open file dialog box to the user just as if they had clicked the Browse button.
        /// </summary>
        /// 
        public void OpenFile()
        {
            this.ChoseFile(this._openFileDialog);
        }

        /// <summary>
        /// Displays the save file dialog box to the user just as if they had clicked the Browse button.
        /// </summary>
        /// 
        public void SaveFile()
        {
            this.ChoseFile(this._saveFileDialog);
        }



        private void ButtonBrowse_OnClick(object Sender, RoutedEventArgs E)
        {
            this.PromptUserForFilePath();
        }
    }
}
