using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Library.WPFControls
{
    /// <summary>
    /// Interaction logic for ToastMessage.xaml
    /// </summary>
    public partial class ToastMessage : Window, INotifyPropertyChanged
    {
        private ToastMessage()
        {
            InitializeComponent();

            HeaderText  = "Header";
            MessageText = "Message text";
            DataContext = this;

            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var workingArea = SystemParameters.WorkArea;
                var transform   = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                var corner      = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

                Left = corner.X - ActualWidth  - 20;
                Top  = corner.Y - ActualHeight - 20;
            }));
        }

        public static readonly DependencyProperty HeaderTextProperty  = DependencyProperty.Register(nameof(HeaderText), typeof(string), typeof(ToastMessage));
        public static readonly DependencyProperty MessageTextProperty = DependencyProperty.Register(nameof(HeaderText), typeof(string), typeof(ToastMessage));


        /// <summary>
        /// The text to display as the header for this control.
        /// </summary>
        /// 
        public string HeaderText
        {
            get
            {
                return (string)GetValue(HeaderTextProperty);
            }

            set
            {
                if (value != null)
                {
                    SetValue(HeaderTextProperty, value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The text to display as the message for this window.
        /// </summary>
        /// 
        public string MessageText
        {
            get
            {
                return (string)GetValue(MessageTextProperty);
            }

            set
            {
                if (value != null)
                {
                    SetValue(MessageTextProperty, value);
                    NotifyPropertyChanged();
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;



        /// <summary>
        /// Displays a message, briefly, in a toast style window.
        /// </summary>
        /// 
        /// <param name="Header">
        /// The title to display on the window.
        /// </param>
        /// 
        /// <param name="Message">
        /// The text to display in the window.
        /// </param>
        /// 
        public static void Show(string Header, string Message)
        {
            ToastMessage newToast = new ToastMessage
            {
                HeaderText = Header,
                MessageText = Message
            };

            newToast.Show();
        }


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

        private void Timeline_OnCompleted(object sender, EventArgs e)
        {
            Close();
        }
    }
}
