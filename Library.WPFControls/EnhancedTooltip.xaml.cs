using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Library.WPFControls
{
    /// <summary>
    /// Interaction logic for EnhancedTooltip.xaml
    /// </summary>
    /// 
    public partial class EnhancedTooltip : UserControl, INotifyPropertyChanged
    {
        public EnhancedTooltip()
        {
            InitializeComponent();
            HeaderText = "Header";
            TooltipText = "Tooltip text";
            DataContext = this;
        }

        public static readonly DependencyProperty HeaderTextProperty  = DependencyProperty.Register(nameof(HeaderText),  typeof(string), typeof(EnhancedTooltip));
        public static readonly DependencyProperty TooltipTextProperty = DependencyProperty.Register(nameof(TooltipText), typeof(string), typeof(EnhancedTooltip));


        /// <summary>
        /// The text to display as the header for this control.
        /// </summary>
        /// 
        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);

            set
            {
                SetValue(HeaderTextProperty, value ?? string.Empty);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The text to display as the message for this tool tip.
        /// </summary>
        /// 
        public string TooltipText
        {
            get => (string)GetValue(TooltipTextProperty);

            set
            {
                SetValue(TooltipTextProperty, value ?? string.Empty);
                NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Fired when a value of a property has been updated.
        /// </summary>
        /// 
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Fires the PropertyChanged event if there are listeners to the event.
        /// </summary>
        /// 
        /// <param name="PropertyName">
        /// The name of the property being changed.
        /// </param>
        /// 
        private void NotifyPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
