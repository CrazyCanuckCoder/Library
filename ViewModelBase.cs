using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        protected void RaisePropertyChangedEvent([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
