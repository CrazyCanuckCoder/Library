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
                return this.labelTitle.Text;
            }

            set
            {
                this.labelTitle.Text = value;
            }
        }

        public List<T> CheckedItems
        {
            get
            {
                List<T> checkedItems = new List<T>();

                foreach (object currObj in this.checkedListBox.CheckedItems)
                {
                    checkedItems.Add((T) currObj);
                }

                return checkedItems;
            }
        }


        public void SetupItems(IEnumerable<T> AllItems, IEnumerable<T> InitialCheckedItems)
        {
            this.checkedListBox.DataSource = AllItems;
            List<T> checkedItems = InitialCheckedItems == null ? null : InitialCheckedItems.ToList();

            if (checkedItems != null && checkedItems.Count() > 0)
            {
                for (int idx = 0; idx < this.checkedListBox.Items.Count; idx++)
                {
                    this.checkedListBox.SetItemChecked(idx, checkedItems.Contains((T) this.checkedListBox.Items[idx]));
                }
            }
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int idx = 0; idx < this.checkedListBox.Items.Count; idx++)
            {
                this.checkedListBox.SetItemChecked(idx, this.checkBoxSelectAll.Checked);
            }
        }
    }
}
