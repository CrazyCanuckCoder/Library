#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public partial class BaseSelectionPanel : UserControl, ISelectionPanel
    {
        public BaseSelectionPanel()
        {
            InitializeComponent();
        }

        private ISelectableDataEntry _selectedItem = null;
        private List<ISelectableDataEntry> _items = new List<ISelectableDataEntry>();

        [Description("The currently selected item or null if no item selected.")]
        public ISelectableDataEntry SelectedItem
        {
            get { return _selectedItem; }

            protected set { _selectedItem = value; }
        }

        [Description("The items the user can select.")]
        public List<ISelectableDataEntry> Items
        {
            get { return _items; }

            protected set { _items = value; }
        }

        public event ControlSelectedEventHandler ItemDoubleClicked;

        public void AddHeaders(List<IHeader> Titles)
        {
            int nextXPos = 0;

            panelTitles.Controls.Clear();
            foreach (IHeader currHeader in Titles)
            {
                var tempLabel = new Label
                    {
                        Text = currHeader.Text,
                        TextAlign = currHeader.TextAlignment,
                        Location = new Point(nextXPos, 0),
                        Width = currHeader.Width,
                        Height = panelTitles.Height,
                        ForeColor = currHeader.Foreground,
                        BackColor = currHeader.Background,
                        BorderStyle = currHeader.HasBorder ? BorderStyle.FixedSingle : BorderStyle.None
                    };

                panelTitles.Controls.Add(tempLabel);

                nextXPos += currHeader.Width - 1;
            }
        }

        public void AddItem(ISelectableDataEntry NewItem)
        {
            NewItem.ControlSelected += ItemSelectedHandler;
            NewItem.ControlUnSelected += ItemUnSelectedHandler;
            NewItem.ControlDoubleClicked += ItemDoubleClickedHandler;

            _items.Add(NewItem);
            flowLayoutPanelBody.Controls.Add(NewItem as Control);
        }

        public void RemoveItem(ISelectableDataEntry DeleteItem)
        {
            DeleteItem.ControlSelected -= ItemSelectedHandler;
            DeleteItem.ControlUnSelected -= ItemUnSelectedHandler;
            DeleteItem.ControlDoubleClicked -= ItemDoubleClickedHandler;

            _items.Remove(DeleteItem);
            flowLayoutPanelBody.Controls.Remove(DeleteItem as Control);
        }

        private void OnItemDoubleClicked(ControlSelectedEventArgs e)
        {
            if (ItemDoubleClicked != null)
            {
                ItemDoubleClicked(this, e);
            }
        }

        private void ItemSelectedHandler(object sender, ControlSelectedEventArgs e)
        {
            if (_selectedItem != null)
            {
                _selectedItem.IsSelected = false;
            }
            _selectedItem = e.ControlSelected as ISelectableDataEntry;
        }

        private void ItemUnSelectedHandler(object sender, ControlSelectedEventArgs e)
        {
            if (_selectedItem == e.ControlSelected)
            {
                _selectedItem = null;
            }
        }

        private void ItemDoubleClickedHandler(object sender, ControlSelectedEventArgs e)
        {
            _selectedItem = e.ControlSelected as ISelectableDataEntry;
            OnItemDoubleClicked(e);
        }
    }
}