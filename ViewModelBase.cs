using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Library
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Indicates a specified property's value has changed.
        /// </summary>
        /// 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fires the PropertyChanged event.
        /// </summary>
        /// 
        /// <param name="PropertyName">
        /// The name of the changed property.
        /// </param>
        /// 
        protected void RaisePropertyChangedEvent(string PropertyName)
        {
            if (PropertyName != null)
            {
                if (PropertyChanged != null)
                {
                    PropertyChangedEventArgs e = new PropertyChangedEventArgs(PropertyName);
                    PropertyChanged(this, e);
                }
            }
            else
            {
                throw new ArgumentNullException("PropertyName");
            }
        }
    }
}
