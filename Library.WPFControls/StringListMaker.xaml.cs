using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for StringListMaker.xaml
    /// </summary>
    public partial class StringListMaker : UserControl
    {
        public StringListMaker()
        {
            InitializeComponent();
        }

        private string _regularExpressionTest = "";
        private string _regExFailureText = "";


        [Description("Set a regular expression to test if entered text is valid.  The " +
                     "entered expression will be checked against each entry when the " +
                     "user tries to add it to the list.  Leave blank for no testing.")]
        public string RegularExpressionTest
        {
            get
            {
                return this._regularExpressionTest;
            }

            set
            {
                if (value != null)
                {
                    this._regularExpressionTest = value.Trim();
                }
            }
        }


        [Description("The text to display when the user's text fails the regular expression test.")]
        public string RegExFailureText
        {
            get
            {
                return this._regExFailureText;
            }

            set
            {
                if (value != null)
                {
                    this._regExFailureText = value.Trim();
                }
            }
        }


        [Description("Gets a string list of the text entered by the user.")]
        public List<string> StringList
        {
            get
            {
                List<string> stringList = new List<string>();

                if (this.ListBoxEntries.Items.Count > 0)
                {
                    string[] entries = new string[this.ListBoxEntries.Items.Count];
                    this.ListBoxEntries.Items.CopyTo(entries, 0);
                    stringList.AddRange(entries);
                }

                return stringList;
            }
        }

        [Description("Returns the entries in the list as a string delimited by commas.")]
        public string DelimitedStringList
        {
            get
            {
                List<string> origList = this.StringList;
                StringBuilder delimList = new StringBuilder();

                foreach (string entry in origList)
                {
                    delimList.Append(entry + ",");
                }

                return delimList.ToString().TrimEnd(new char[] { ',' });
            }
        }

        [Description("The text to display that describes the list.")]
        public string Description
        {
            get
            {
                return this.LabelDescription.Content.ToString();
            }

            set
            {
                if (value != null)
                {
                    this.LabelDescription.Content = value;
                }
            }
        }

        [Description("True to show a description above the list and false to hide it.")]
        public bool ShowDescription
        {
            get
            {
                return this.LabelDescription.IsVisible;
            }

            set
            {
                this.LabelDescription.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }


        /// <summary>
        /// Adds a new entry to the list after checking if it is valid.
        /// </summary>
        /// 
        private void AddEntry()
        {
            string newEntry = this.TextBoxEntries.Text;

            if (!newEntry.IsEmpty())
            {
                bool canAddEntry = true;
                if (!this.RegularExpressionTest.IsEmpty())
                {
                    canAddEntry = Regex.IsMatch(newEntry, this.RegularExpressionTest, RegexOptions.IgnoreCase);

                    if (!canAddEntry && !this.RegExFailureText.IsEmpty())
                    {
                        Utility.ShowError(null, this.RegExFailureText);
                    }
                }

                if (canAddEntry)
                {
                    this.ListBoxEntries.Items.Add(newEntry);
                    this.TextBoxEntries.Text = "";
                }
            }
            else
            {
                Utility.ShowError(null, "You cannot add blank entries to the list.");
            }
        }


        /// <summary>
        /// Asks the user to confirm the deletion of the currently selected item
        /// and if they confirm, removes it from the list.
        /// </summary>
        /// 
        private void DeleteEntry()
        {
            if (this.ListBoxEntries.SelectedItem != null)
            {
                if (Utility.Confirm(null, "Are you sure you want to delete " + this.ListBoxEntries.SelectedItem.ToString() + " from the list?"))
                {
                    this.ListBoxEntries.Items.Remove(this.ListBoxEntries.SelectedItem);
                }
            }
        }




        private void TextBoxEntries_OnKeyDown(object Sender, KeyEventArgs E)
        {
            if (E.Key == Key.Enter)
            {
                this.AddEntry();
            }
        }

        private void ListBoxEntries_OnSelectionChanged(object Sender, SelectionChangedEventArgs E)
        {
            this.ButtonDeleteEntry.IsEnabled = this.ListBoxEntries.SelectedItem != null;
        }

        private void ButtonDeleteEntry_OnClick(object Sender, RoutedEventArgs E)
        {
            this.DeleteEntry();
        }

        private void ButtonAddEntry_OnClick(object Sender, RoutedEventArgs E)
        {
            this.AddEntry();
        }

        private void TextBoxEntries_OnTextChanged(object Sender, TextChangedEventArgs E)
        {
            this.ButtonAddEntry.IsEnabled = !this.TextBoxEntries.Text.IsEmpty();
        }
    }
}
