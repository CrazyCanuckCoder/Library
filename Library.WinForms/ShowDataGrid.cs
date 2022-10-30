using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    public partial class ShowDataGrid : Form
    {
        private ShowDataGrid()
        {
            InitializeComponent();
        }

        public ShowDataGrid(DataTable SourceData, string DialogTitle) : this()
        {
            Text = DialogTitle;
            dataGridView.DataSource = SourceData;
        }

        private DataGridSettings _gridSettings = new DataGridSettings(true, true, new List<string>());

        private void ExportData()
        {
            if (!string.IsNullOrEmpty(filePicker.ChosenFile))
            {
                try
                {
                    if (_gridSettings.ExportAllColumns)
                    {
                        Export.DataTableToCSV(filePicker.ChosenFile, dataGridView.DataSource as DataTable, _gridSettings.IncludeColumnHeaders);
                    }
                    else
                    {
                        Export.DataTableToCSV(filePicker.ChosenFile, dataGridView.DataSource as DataTable, _gridSettings.IncludeColumnHeaders, _gridSettings.ColumnsToExport);
                    }

                    Utility.ShowMessage(this, "Export file successfully created.");
                }
                catch (Exception ex)
                {
                    Utility.ShowError(this, "Unable to create export file.  " + ex.Message);
                }
            }
            else
            {
                Utility.ShowError(this, "Please select a file name and path before trying to export.");
            }
        }

        private void GetSettings()
        {
            List<string> allColumnNames = new List<string>();
            if (dataGridView.DataSource != null)
            {
                foreach (DataColumn currColumn in ((DataTable) dataGridView.DataSource).Columns)
                {
                    allColumnNames.Add(currColumn.ColumnName);
                }
            }
            ShowDataGridSettingsForm settingsForm = new ShowDataGridSettingsForm(allColumnNames, _gridSettings) { Owner = this };

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                _gridSettings = settingsForm.SettingsInfo;
            }
        }


        private void imageButtonExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void imageButtonSettings_Click(object sender, EventArgs e)
        {
            GetSettings();
        }
    }
}
