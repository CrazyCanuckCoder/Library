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
            ColumnName = NewColumnName;
            ItemIsChecked = CheckedState;
        }

        private string _columnName = "";
        private bool _isChecked = false;


        public string ColumnName
        {
            get
            {
                return _columnName;
            }

            set
            {
                if (value != null && value != _columnName)
                {
                    _columnName = value;
                    OnPropertyChanged("ColumnName");
                }
            }
        }

        public bool ItemIsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    OnPropertyChanged("ItemIsChecked");
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
