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
            this.Text = DialogTitle;
            this.dataGridView.DataSource = SourceData;
        }

        private DataGridSettings _gridSettings = new DataGridSettings(true, true, new List<string>());

        private void ExportData()
        {
            if (!this.filePicker.ChosenFile.IsEmpty())
            {
                try
                {
                    if (this._gridSettings.ExportAllColumns)
                    {
                        Export.DataTableToCSV(this.filePicker.ChosenFile, this.dataGridView.DataSource as DataTable, this._gridSettings.IncludeColumnHeaders);
                    }
                    else
                    {
                        Export.DataTableToCSV(this.filePicker.ChosenFile, this.dataGridView.DataSource as DataTable, this._gridSettings.IncludeColumnHeaders, this._gridSettings.ColumnsToExport);
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
            if (this.dataGridView.DataSource != null)
            {
                foreach (DataColumn currColumn in ((DataTable) this.dataGridView.DataSource).Columns)
                {
                    allColumnNames.Add(currColumn.ColumnName);
                }
            }
            ShowDataGridSettingsForm settingsForm = new ShowDataGridSettingsForm(allColumnNames, this._gridSettings) { Owner = this };

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                this._gridSettings = settingsForm.SettingsInfo;
            }
        }


        private void imageButtonExport_Click(object sender, EventArgs e)
        {
            this.ExportData();
        }

        private void imageButtonSettings_Click(object sender, EventArgs e)
        {
            this.GetSettings();
        }
    }
}
