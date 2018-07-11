using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace Library.WPFControls
{
    public static class AppHelper
    {
        /// <summary>
        /// Displays a dialog box prompt for an error message.
        /// </summary>
        /// 
        /// <param name="Owner">
        /// A reference to the form the message will be shown from.
        /// </param>
        /// 
        /// <param name="Message">
        /// The text of the error to display to the user.
        /// </param>
        /// 
        public static void ShowError(Window Owner, string Message)
        {
            MessageBox.Show(Owner, Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Displays a confirmation dialog box to the user.  True is returned if the 
        /// user clicks the Yes button and false if the user clicks the No button.
        /// </summary>
        /// 
        /// <param name="Owner">
        /// A reference to the form the message will be shown from.
        /// </param>
        /// 
        /// <param name="Question">
        /// The confirmation text to display to the user.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate confirmation and false otherwise.
        /// </returns>
        /// 
        public static bool Confirm(Window Owner, string Question)
        {
            return MessageBox.Show(Owner, Question, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        /// <summary>
        /// Displays a dialog box prompt for an informational message.
        /// </summary>
        /// 
        /// <param name="Owner">
        /// A reference to the form the message will be shown from.
        /// </param>
        /// 
        /// <param name="Message">
        /// The text of the information to display to the user.
        /// </param>
        /// 
        public static void ShowMessage(Window Owner, string Message)
        {
            MessageBox.Show(Owner, Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Displays a data table in a data view on a dialog box.  Provides
        /// export capabilities in the form.
        /// </summary>
        /// 
        /// <param name="InfoTable">
        /// The data table to display.
        /// </param>
        /// 
        /// <param name="DialogTitle">
        /// The text to display as the dialog title text.
        /// </param>
        /// 
        public static void ShowDataTable(DataTable InfoTable, string DialogTitle)
        {
            ShowDataGrid dataForm = new ShowDataGrid(InfoTable, DialogTitle);

            dataForm.ShowDialog();
        }
    }
}
