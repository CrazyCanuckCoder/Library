using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library;

namespace Library.WPFControls
{
    /// <summary>
    /// Interaction logic for EnhancedTooltip.xaml
    /// </summary>
    /// 
    /// 
    public partial class EnhancedTooltip : UserControl, INotifyPropertyChanged
    {
        public EnhancedTooltip()
        {
            InitializeComponent();
            this.HeaderText = "Header";
            this.TooltipText = "Tooltip text";
            this.DataContext = this;
        }

        public static readonly DependencyProperty HeaderTextProperty  = DependencyProperty.Register("HeaderText",  typeof(string), typeof(EnhancedTooltip));
        public static readonly DependencyProperty TooltipTextProperty = DependencyProperty.Register("TooltipText", typeof(string), typeof(EnhancedTooltip));


        /// <summary>
        /// The text to display as the header for this control.
        /// </summary>
        /// 
        public string HeaderText
        {
            get
            {
                return (string)this.GetValue(HeaderTextProperty);
            }

            set
            {
                if (value != null)
                {
                    this.SetValue(HeaderTextProperty, value);
                    this.NotifyPropertyChanged("HeaderText");
                }
            }
        }

        /// <summary>
        /// The text to display as the message for this tool tip.
        /// </summary>
        /// 
        public string TooltipText
        {
            get
            {
                return (string) this.GetValue(TooltipTextProperty);
            }

            set
            {
                if (value != null)
                {
                    this.SetValue(TooltipTextProperty, value);
                    this.NotifyPropertyChanged("TooltipText");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Fires the PropertyChanged event if there are listeners to the event.
        /// </summary>
        /// 
        /// <param name="PropertyName">
        /// The name of the property being changed.
        /// </param>
        /// 
        private void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                if (!PropertyName.IsEmpty())
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
        }

    }
}
