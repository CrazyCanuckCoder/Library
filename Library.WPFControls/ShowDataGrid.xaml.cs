using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ShowDataGrid.xaml
    /// </summary>
    public partial class ShowDataGrid : Window
    {
        private ShowDataGrid()
        {
            InitializeComponent();
        }

        public ShowDataGrid(DataTable SourceData, string DialogTitle) : this()
        {
            Title = DialogTitle;
            _sourceTable = SourceData;
            DataGridMain.ItemsSource = SourceData.DefaultView;
        }

        private DataGridSettings _gridSettings = new DataGridSettings(true, true, new List<string>());
        private readonly DataTable _sourceTable;

        private void ExportData()
        {
            if (!string.IsNullOrEmpty(FilePickerCSV.ChosenFile))
            {
                try
                {
                    if (_gridSettings.ExportAllColumns)
                    {
                        Export.DataTableToCSV(FilePickerCSV.ChosenFile, _sourceTable, _gridSettings.IncludeColumnHeaders);
                    }
                    else
                    {
                        Export.DataTableToCSV(FilePickerCSV.ChosenFile, _sourceTable, _gridSettings.IncludeColumnHeaders, _gridSettings.ColumnsToExport);
                    }

                    AppHelper.ShowMessage(this, "Export file successfully created.");
                }
                catch (Exception ex)
                {
                    AppHelper.ShowError(this, "Unable to create export file.  " + ex.Message);
                }
            }
            else
            {
                AppHelper.ShowError(this, "Please select a file name and path before trying to export.");
            }
        }

        private void GetSettings()
        {
            List<string> allColumnNames = new List<string>();
            if (_sourceTable != null)
            {
                foreach (DataColumn currColumn in _sourceTable.Columns)
                {
                    allColumnNames.Add(currColumn.ColumnName);
                }
            }
            ShowDataGridSettings settingsForm = new ShowDataGridSettings(allColumnNames, _gridSettings) { Owner = this };

            if ((bool)settingsForm.ShowDialog())
            {
                _gridSettings = settingsForm.SettingsInfo;
            }
        }

        private void ButtonExportCSV_OnClick(object Sender, RoutedEventArgs E)
        {
            ExportData();
        }

        private void ButtonSettings_OnClick(object Sender, RoutedEventArgs E)
        {
            GetSettings();
        }
    }
}
