using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    public partial class CheckedListBoxSelectAll<T> : UserControl
    {
        public CheckedListBoxSelectAll()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return labelTitle.Text;
            }

            set
            {
                labelTitle.Text = value;
            }
        }

        public List<T> CheckedItems
        {
            get
            {
                List<T> checkedItems = new List<T>();

                foreach (object currObj in checkedListBox.CheckedItems)
                {
                    checkedItems.Add((T) currObj);
                }

                return checkedItems;
            }
        }


        public void SetupItems(IEnumerable<T> AllItems, IEnumerable<T> InitialCheckedItems)
        {
            checkedListBox.DataSource = AllItems;
            List<T> checkedItems = InitialCheckedItems == null ? null : InitialCheckedItems.ToList();

            if (checkedItems != null && checkedItems.Count() > 0)
            {
                for (int idx = 0; idx < checkedListBox.Items.Count; idx++)
                {
                    checkedListBox.SetItemChecked(idx, checkedItems.Contains((T) checkedListBox.Items[idx]));
                }
            }
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int idx = 0; idx < checkedListBox.Items.Count; idx++)
            {
                checkedListBox.SetItemChecked(idx, checkBoxSelectAll.Checked);
            }
        }
    }
}
