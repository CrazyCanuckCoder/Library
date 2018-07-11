using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Library.WPFControls
{
    public class CheckedListItem : INotifyPropertyChanged
    {
        public CheckedListItem(string NewColumnName, bool CheckedState)
        {
            this.ColumnName = NewColumnName;
            this.ItemIsChecked = CheckedState;
        }

        private string _columnName = "";
        private bool _isChecked = false;


        public string ColumnName
        {
            get
            {
                return this._columnName;
            }

            set
            {
                if (value != null && value != this._columnName)
                {
                    this._columnName = value;
                    this.OnPropertyChanged("ColumnName");
                }
            }
        }

        public bool ItemIsChecked
        {
            get
            {
                return this._isChecked;
            }

            set
            {
                if (value != this._isChecked)
                {
                    this._isChecked = value;
                    this.OnPropertyChanged("ItemIsChecked");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }

}
