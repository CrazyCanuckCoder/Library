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

                if (this.listBoxEntries.Items.Count > 0)
                {
                    string[] entries = new string[this.listBoxEntries.Items.Count];
                    this.listBoxEntries.Items.CopyTo(entries, 0);
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
                return this.labelDescription.Text;
            }

            set
            {
                if (value != null)
                {
                    this.labelDescription.Text = value;
                }
            }
        }

        [Description("True to show a description above the list and false to hide it.")]
        public bool ShowDescription
        {
            get
            {
                return this.labelDescription.Visible;
            }

            set
            {
                this.labelDescription.Visible = value;
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
                    this.ImportItems(DelimitedValues.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    this.ImportItems(new string[] { DelimitedValues });
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
                        this.listBoxEntries.Items.Add(entry);
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
            string newEntry = this.textBoxEntries.Text;

            if (!newEntry.IsEmpty())
            {
                bool canAddEntry = true;
                if (!this.RegularExpressionTest.IsEmpty())
                {
                    canAddEntry = Regex.IsMatch(newEntry, this.RegularExpressionTest, RegexOptions.IgnoreCase);

                    if (!canAddEntry && !this.RegExFailureText.IsEmpty())
                    {
                        Utility.ShowError(this.FindForm(), this.RegExFailureText);
                    }
                }

                if (canAddEntry)
                {
                    this.listBoxEntries.Items.Add(newEntry);
                    this.textBoxEntries.Text = "";
                }
            }
            else
            {
                Utility.ShowError(this.FindForm(), "You cannot add blank entries to the list.");
            }
        }

        /// <summary>
        /// Asks the user to confirm the deletion of the currently selected item
        /// and if they confirm, removes it from the list.
        /// </summary>
        /// 
        private void DeleteEntry()
        {
            if (Utility.Confirm(this.FindForm(), "Are you sure you want to delete " + this.listBoxEntries.SelectedItem.ToString() +
                                                 " from the list?"))
            {
                this.listBoxEntries.Items.Remove(this.listBoxEntries.SelectedItem);
            }
        }



        private void textBoxEntries_TextChanged(object sender, EventArgs e)
        {
            this.imageButtonAddEntry.Enabled = !this.textBoxEntries.Text.IsEmpty();
        }

        private void listBoxEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.imageButtonDeleteEntry.Enabled = this.listBoxEntries.SelectedItem != null;
        }

        private void imageButtonAddEntry_Click(object sender, EventArgs e)
        {
            this.AddEntry();
        }

        private void imageButtonDeleteEntry_Click(object sender, EventArgs e)
        {
            this.DeleteEntry();
        }

        private void textBoxEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AddEntry();
            }
        }
    }
}
