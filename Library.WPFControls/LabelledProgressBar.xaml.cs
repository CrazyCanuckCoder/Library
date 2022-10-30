using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.WPFControls
{
    /// <summary>
    /// Interaction logic for LabelledProgressBar.xaml
    /// </summary>
    public partial class LabelledProgressBar : UserControl, INotifyPropertyChanged
    {
        public LabelledProgressBar()
        {
            InitializeComponent();
            DataContext = this;
        }

        private int _progressValue = 0;
        private int _minimumValue = 0;
        private int _maximumValue = 100;

        /// <summary>
        /// The DependencyProperty for the Text property.
        /// </summary>
        /// 
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text),
                                        typeof(string),
                                        typeof(LabelledProgressBar), 
                                        new PropertyMetadata(string.Empty));


        /// <summary>
        /// The current progress value.  Can't be less than the MinimumValue or
        /// greater than the MaximumValue.
        /// </summary>
        /// 
        public int ProgressValue
        {
            get => _progressValue;

            set
            {
                _progressValue = value < MinimumValue ? MinimumValue : 
                    (value > MaximumValue ? MaximumValue : value);
            }
        }

        /// <summary>
        /// The minimum value that the progress value can be.
        /// </summary>
        public int MinimumValue 
        {
            get => _minimumValue;
            
            set
            {
                if (value <= MaximumValue)
                {
                    _minimumValue = value;
                }
            }
        }

        /// <summary>
        /// The maximum value that the progress value can be.
        /// </summary>
        /// 
        public int MaximumValue 
        {
            get => _maximumValue;

            set
            {
                if (value >= MinimumValue)
                {
                    _maximumValue = value;
                }
            }
        }

        /// <summary>
        /// Gets the width of the progress label.
        /// </summary>
        /// 
        public int ProgressLabelWidth
        {
            get
            {
                int labelWidth = 0;

                if (ProgressValue > MinimumValue)
                {
                    int minMaxDifference = MaximumValue - MinimumValue;
                    double percentOfWidth = ProgressValue / (double) minMaxDifference;
                    labelWidth = (int)(LabelDescription.ActualWidth * percentOfWidth);
                }

                return labelWidth;
            }
        }

        /// <summary>
        /// The text to display on the control.
        /// </summary>
        /// 
        public string Text 
        { 
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value ?? string.Empty);
        }

        /// <summary>
        /// Fired when a property's value has changed.
        /// </summary>
        /// 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes the PropertyChanged event to update the UI when a property has changes.
        /// </summary>
        /// 
        /// <param name="propertyName">
        /// The name of the property.  Is is the caller member's name unless specified.
        /// </param>
        /// 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
