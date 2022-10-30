using System;
using System.Collections;
using System.Windows.Forms;

namespace Library
{
    /// <summary>
    /// This class is used along with a ListView control to sort columns in a
    /// multiple column ListView.
    /// </summary>
    /// 
    public class ListViewColumnSorter : IComparer
    {
        public ListViewColumnSorter()
        {
        }




        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        /// 
        private readonly CaseInsensitiveComparer _objectCompare = new CaseInsensitiveComparer();




        /// <summary>
        /// Gets or sets the index of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        /// 
        public int SortColumn { set; get; } = 0;

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        /// 
        public SortOrder Order { set; get; } = SortOrder.None;




        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the 
        /// two objects passed using a case insensitive comparison.
        /// </summary>
        /// 
        /// <param name="x">
        /// First object to be compared
        /// </param>
        /// 
        /// <param name="y">
        /// Second object to be compared
        /// </param>
        /// 
        /// <returns>
        /// The result of the comparison. "0" if equal, negative if 'x' is
        /// less than 'y' and positive if 'x' is greater than 'y'
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException" />
        /// 
        public int Compare(object x, object y)
        {
            return Compare((ListViewItem) x, (ListViewItem) y);
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the 
        /// two objects passed using a case insensitive comparison.
        /// </summary>
        /// 
        /// <param name="FirstItem">
        /// First list view item to be compared.
        /// </param>
        /// 
        /// <param name="SecondItem">
        /// Second list view item to be compared.
        /// </param>
        /// 
        /// <returns>
        /// The result of the comparison. "0" if equal, negative if 'x' is
        /// less than 'y' and positive if 'x' is greater than 'y'
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException" />
        /// 
        public int Compare(ListViewItem FirstItem, ListViewItem SecondItem)
        {
            int compareResult;

            // Cast the objects to be compared to ListViewItem objects

            if (FirstItem != null && SecondItem != null)
            {
                // Compare the two items

                compareResult = _objectCompare.Compare(FirstItem .SubItems[SortColumn].Text,
                                                       SecondItem.SubItems[SortColumn].Text);

                // Calculate correct return value based on specified sort order

                if (Order == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation

                    compareResult = -compareResult;
                }
                else if (Order == SortOrder.None)
                {
                    // Return '0' to indicate they are equal

                    compareResult = 0;
                }
            }
            else
            {
                throw new ArgumentNullException(FirstItem == null ? nameof(FirstItem) : nameof(SecondItem));
            }

            return compareResult;
        }
    }
}