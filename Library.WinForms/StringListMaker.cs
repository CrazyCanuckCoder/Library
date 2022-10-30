using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Library.WinForms
{
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
                return _regularExpressionTest;
            }

            set
            {
                if (value != null)
                {
                    _regularExpressionTest = value.Trim();
                }
            }
        }

        
        [Description("The text to display when the user's text fails the regular expression test.")]
        public string RegExFailureText
        {
            get
            {
                return _regExFailureText;
            }
            
            set
            {
                if (value != null)
                {
                    _regExFailureText = value.Trim();
                }
            }
        }

        
        [Description("Gets a string list of the text entered by the user.")]
        public List<string> StringList
        {
            get
            {
                List<string> stringList = new List<string>();

                if (listBoxEntries.Items.Count > 0)
                {
                    string[] entries = new string[listBoxEntries.Items.Count];
                    listBoxEntries.Items.CopyTo(entries, 0);
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
                List<string> origList = StringList;
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
                return labelDescription.Text;
            }

            set
            {
                if (value != null)
                {
                    labelDescription.Text = value;
                }
            }
        }

        [Description("True to show a description above the list and false to hide it.")]
        public bool ShowDescription
        {
            get
            {
                return labelDescription.Visible;
            }

            set
            {
                labelDescription.Visible = value;
            }
        }

        /// <summary>
        /// Imports items into the list.
        /// </summary>
        /// 
        /// <param name="DelimitedValues">
        /// A string delimited by commas containing the items to import.
        /// </param>
        /// 
        public void ImportItems(string DelimitedValues)
        {
            if (DelimitedValues != null)
            {
                if (DelimitedValues.IndexOf(",") >= 0)
                {
                    ImportItems(DelimitedValues.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    ImportItems(new string[] { DelimitedValues });
                }
            }
            else
            {
                throw new ArgumentNullException("DelimitedValues");
            }
        }

        /// <summary>
        /// Imports items into the list.
        /// </summary>
        /// 
        /// <param name="ListValues">
        /// An array of strings to import.
        /// </param>
        /// 
        public void ImportItems(string[] ListValues)
        {
            if (ListValues != null)
            {
                if (ListValues.Length > 0)
                {
                    foreach (string entry in ListValues)
                    {
                        listBoxEntries.Items.Add(entry);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("ListValues");
            }
        }


        /// <summary>
        /// Adds a new entry to the list after checking if it is valid.
        /// </summary>
        /// 
        private void AddEntry()
        {
            string newEntry = textBoxEntries.Text;

            if (!string.IsNullOrEmpty(newEntry))
            {
                bool canAddEntry = true;
                if (!string.IsNullOrEmpty(RegularExpressionTest))
                {
                    canAddEntry = Regex.IsMatch(newEntry, RegularExpressionTest, RegexOptions.IgnoreCase);

                    if (!canAddEntry && !string.IsNullOrEmpty(RegExFailureText))
                    {
                        Utility.ShowError(FindForm(), RegExFailureText);
                    }
                }

                if (canAddEntry)
                {
                    listBoxEntries.Items.Add(newEntry);
                    textBoxEntries.Text = "";
                }
            }
            else
            {
                Utility.ShowError(FindForm(), "You cannot add blank entries to the list.");
            }
        }

        /// <summary>
        /// Asks the user to confirm the deletion of the currently selected item
        /// and if they confirm, removes it from the list.
        /// </summary>
        /// 
        private void DeleteEntry()
        {
            if (Utility.Confirm(FindForm(), "Are you sure you want to delete " + listBoxEntries.SelectedItem.ToString() +
                                                 " from the list?"))
            {
                listBoxEntries.Items.Remove(listBoxEntries.SelectedItem);
            }
        }



        private void textBoxEntries_TextChanged(object sender, EventArgs e)
        {
            imageButtonAddEntry.Enabled = !string.IsNullOrEmpty(textBoxEntries.Text);
        }

        private void listBoxEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageButtonDeleteEntry.Enabled = listBoxEntries.SelectedItem != null;
        }

        private void imageButtonAddEntry_Click(object sender, EventArgs e)
        {
            AddEntry();
        }

        private void imageButtonDeleteEntry_Click(object sender, EventArgs e)
        {
            DeleteEntry();
        }

        private void textBoxEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddEntry();
            }
        }
    }
}
