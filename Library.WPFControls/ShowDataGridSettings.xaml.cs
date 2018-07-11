using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.WPFControls
{
    /// <summary>
    /// Interaction logic for ShowDataGridSettings.xaml
    /// </summary>
    public partial class ShowDataGridSettings : Window
    {
        private ShowDataGridSettings()
        {
            InitializeComponent();
            this.RadioButtonExportAll.Checked  += this.RadioButtonExportAll_Checked;
            this.RadioButtonExportSome.Checked += this.RadioButtonExportSome_Checked;
        }

        public ShowDataGridSettings(List<string> AllColumns, DataGridSettings CurrentSettings) : this()
        {
            this.AddColumnNamesToListBox(AllColumns);
            this.SettingsInfo = CurrentSettings;
        }

        private DataGridSettings _settingsInfo = new DataGridSettings(true, true, new List<string>());
        
        /// <summary>
        /// Gets the settings selected by the user on this form.
        /// </summary>
        /// 
        public DataGridSettings SettingsInfo
        {
            get
            {
                return this._settingsInfo;
            }

            private set
            {
                this._settingsInfo = value;

                this.CheckBoxIncludeHeaders.IsChecked = this._settingsInfo.IncludeColumnHeaders;
                this.RadioButtonExportAll  .IsChecked = this._settingsInfo.ExportAllColumns;
                this.RadioButtonExportSome .IsChecked = !this._settingsInfo.ExportAllColumns;

                this.SetCheckedColumns(this._settingsInfo.ColumnsToExport);
            }
        }

        public List<CheckedListItem> ExportColumnsList { get; set; }

        /// <summary>
        /// Adds each item in the list to the CheckedListBox control.
        /// </summary>
        /// 
        /// <param name="ColumnsToAdd">
        /// The names of the columns from the original data source.
        /// </param>
        /// 
        private void AddColumnNamesToListBox(List<string> ColumnsToAdd)
        {
            List<CheckedListItem> listItems = new List<CheckedListItem>(ColumnsToAdd.Count);
            listItems.AddRange(ColumnsToAdd.Select(name => new CheckedListItem(name, true)));
            this.ExportColumnsList = listItems;
            this.ListBoxColumns.ItemsSource = this.ExportColumnsList;
        }

        /// <summary>
        /// Using the names of the columns provided in a list, checks the 
        /// corresponding columns in the CheckedListBox control.
        /// </summary>
        /// 
        /// <param name="ColumnsToCheck">
        /// The names of the columns the user wants to include in the output.
        /// </param>
        /// 
        private void SetCheckedColumns(List<string> ColumnsToCheck)
        {
            if (ColumnsToCheck.Count > 0)
            {
                foreach (CheckedListItem listItem in this.ExportColumnsList)
                {
                    listItem.ItemIsChecked = (ColumnsToCheck.Contains(listItem.ColumnName));
                }
            }
        }

        /// <summary>
        /// Enables or disables the checked list box when the user changes the
        /// value of either radio button on the form.
        /// </summary>
        /// 
        private void ChangeColumnControls()
        {
            this.ListBoxColumns.IsEnabled = (bool)this.RadioButtonExportSome.IsChecked;
        }

        /// <summary>
        /// Takes the values from the form and transfers them to the settings property.
        /// </summary>
        /// 
        private void GetValuesFromForm()
        {
            this.SettingsInfo.ExportAllColumns     = (bool)this.RadioButtonExportAll.IsChecked;
            this.SettingsInfo.IncludeColumnHeaders = (bool)this.CheckBoxIncludeHeaders.IsChecked;
            this.SettingsInfo.ColumnsToExport      = new List<string>();
            
            if (!this.SettingsInfo.ExportAllColumns)
            {
                foreach (CheckedListItem currItem in this.ExportColumnsList)
                {
                    this.SettingsInfo.ColumnsToExport.Add(currItem.ColumnName);
                }
            }
        }


        #region  Event Handlers

        private void ButtonSaveSettings_OnClick(object Sender, RoutedEventArgs E)
        {
            this.GetValuesFromForm();
        }

        private void RadioButtonExportAll_Checked(object sender, RoutedEventArgs e)
        {
            this.ChangeColumnControls();
        }

        private void RadioButtonExportSome_Checked(object sender, RoutedEventArgs e)
        {
            this.ChangeColumnControls();
        }

        #endregion  Event Handlers
    }
}
