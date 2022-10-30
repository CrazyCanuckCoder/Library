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
    public partial class ShowDataGridSettingsForm : Form
    {
        private ShowDataGridSettingsForm()
        {
            InitializeComponent();
        }

        public ShowDataGridSettingsForm(List<string> AllColumns, DataGridSettings CurrentSettings) : this()
        {
            AddColumnNamesToListBox(AllColumns);
            SettingsInfo = CurrentSettings;
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
                return _settingsInfo;
            }

            private set
            {
                _settingsInfo = value;

                checkBoxIncludeHeaders.Checked    = _settingsInfo.IncludeColumnHeaders;
                radioButtonExportAll.Checked      = _settingsInfo.ExportAllColumns;
                radioButtonExportSelected.Checked = !_settingsInfo.ExportAllColumns;

                SetCheckedColumns(_settingsInfo.ColumnsToExport);
            }
        }

        /// <summary>
        /// Adds each item in the list to the CheckedListBox control.
        /// </summary>
        /// 
        /// <param name="ColumnsToAdd">
        /// The names of the columns from the original data source.
        /// </param>
        /// 
        private void AddColumnNamesToListBox(IEnumerable<string> ColumnsToAdd)
        {
            foreach (string name in ColumnsToAdd)
            {
                checkedListBoxColumns.Items.Add(name, true);
            }
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
            for (int itemIDX = 0; itemIDX < checkedListBoxColumns.Items.Count; itemIDX++)
            {
                checkedListBoxColumns.SetItemChecked(itemIDX, 
                    ColumnsToCheck.Contains(checkedListBoxColumns.Items[itemIDX].ToString()));
            }
        }

        /// <summary>
        /// Enables or disables the checked list box when the user changes the
        /// value of either radio button on the form.
        /// </summary>
        /// 
        private void ChangeColumnControls()
        {
            checkedListBoxColumns.Enabled = radioButtonExportSelected.Checked;
        }

        /// <summary>
        /// Takes the values from the form and transfers them to the settings property.
        /// </summary>
        /// 
        private void GetValuesFromForm()
        {
            SettingsInfo.ExportAllColumns = radioButtonExportAll.Checked;
            SettingsInfo.IncludeColumnHeaders = checkBoxIncludeHeaders.Checked;
            SettingsInfo.ColumnsToExport = new List<string>();
            if (!SettingsInfo.ExportAllColumns)
            {
                foreach (int checkedItemIDX in checkedListBoxColumns.CheckedIndices)
                {
                    SettingsInfo.ColumnsToExport.Add(checkedListBoxColumns.Items[checkedItemIDX].ToString());
                }
            }
        }



        #region  Event Handlers

        private void radioButtonExportAll_CheckedChanged(object sender, EventArgs e)
        {
            ChangeColumnControls();
        }

        private void radioButtonExportSelected_CheckedChanged(object sender, EventArgs e)
        {
            ChangeColumnControls();
        }

        private void imageButtonSave_Click(object sender, EventArgs e)
        {
            GetValuesFromForm();
            DialogResult = DialogResult.OK;
        }

        #endregion  Event Handlers
    }
}
