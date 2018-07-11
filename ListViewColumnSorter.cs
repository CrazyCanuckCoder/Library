#region

using System.Collections;
using System.Windows.Forms;

#endregion

namespace Library
{
    /// <summary>
    /// This class is used along with a ListView control to sort columns in a
    /// multiple column ListView.
    /// </summary>
    /// 
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        /// 
        public ListViewColumnSorter()
        {
        }

        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        /// 
        private int _columnToSort = 0;

        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        /// 
        private SortOrder _orderOfSort = SortOrder.None;

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        /// 
        private readonly CaseInsensitiveComparer _objectCompare = new CaseInsensitiveComparer();

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        /// 
        public int SortColumn
        {
            set { _columnToSort = value; }
            get { return _columnToSort; }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        /// 
        public SortOrder Order
        {
            set { _orderOfSort = value; }
            get { return _orderOfSort; }
        }


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
        public int Compare(object x, object y)
        {
            int compareResult = 0;

            // Cast the objects to be compared to ListViewItem objects

            var listviewX = (ListViewItem) x;
            var listviewY = (ListViewItem) y;

            // Compare the two items

            compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text,
                                                   listviewY.SubItems[_columnToSort].Text);

            // Calculate correct return value based on specified sort order

            if (_orderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation

                compareResult = (-compareResult);
            }
            else if (_orderOfSort == SortOrder.None)
            {
                // Return '0' to indicate they are equal

                compareResult = 0;
            }

            return compareResult;
        }
    }
}