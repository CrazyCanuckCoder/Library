#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    /// <summary>
    /// Extends the FlowLayoutPanelList to manage items the user can select.
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// Specifies the type of controls that can be added to the panel.
    /// </typeparam>
    /// 
    public partial class FlowLayoutPanelListSelectable<T> : FlowLayoutPanelList<T> where T : Control, ISelectable
    {
        public FlowLayoutPanelListSelectable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the item the user selected.
        /// </summary>
        /// 
        public T SelectedItem { get; private set; }



        public event ControlSelectedEventHandler ItemSelected;
        public event ControlSelectedEventHandler ItemUnSelected;


        /// <summary>
        /// Add new item to panel.
        /// </summary>
        /// 
        /// <param name="NewItem">
        /// The item to add.
        /// </param>
        /// 
        public override void AddItem(T NewItem)
        {
            if (!_items.Contains(NewItem))
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate { AddItem(NewItem); }
                               ));
                }
                else
                {
                    NewItem.ControlSelected   -= NewItem_ControlSelected;
                    NewItem.ControlUnSelected -= NewItem_ControlUnSelected;
                    NewItem.ControlSelected   += NewItem_ControlSelected;
                    NewItem.ControlUnSelected += NewItem_ControlUnSelected;
                    _items.Add(NewItem);
                    flowLayoutPanelBase.Controls.Add(NewItem);
                }
            }
        }

        /// <summary>
        /// Removes an item from the panel.
        /// </summary>
        /// 
        /// <param name="DeleteItem">
        /// The item to remove.
        /// </param>
        /// 
        public override void RemoveItem(T DeleteItem)
        {
            if (_items.Contains(DeleteItem))
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate { RemoveItem(DeleteItem); }
                               ));
                }
                else
                {
                    if (SelectedItem == DeleteItem)
                    {
                        SelectedItem = null;
                    }
                    DeleteItem.ControlSelected -= NewItem_ControlSelected;
                    DeleteItem.ControlUnSelected -= NewItem_ControlUnSelected;
                    _items.Remove(DeleteItem);
                    flowLayoutPanelBase.Controls.Remove(DeleteItem);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="NewPredicate"></param>
        /// 
        public void Search(Predicate<T> NewPredicate)
        {
            if (NewPredicate != null)
            {
                if (_originalItems == null)
                {
                    _originalItems = new List<T>();
                    _originalItems.AddRange(_items.ToArray());
                }
                else
                {
                    _items = new List<T>();
                    _items.AddRange(_originalItems.ToArray());
                }

                List<T> foundItems = _items.FindAll(NewPredicate);
                AddRange(foundItems);
            }
        }

        public void ClearSearch()
        {
            if (_originalItems != null)
            {
                AddRange(_originalItems);
                _originalItems = null;
            }
        }

        public void AddRange(List<T> NewItems)
        {
            Clear();

            foreach (T item in NewItems)
            {
                AddItem(item);
            }
        }




        private void OnItemSelected(ControlSelectedEventArgs OriginalArgs)
        {
            if (ItemSelected != null)
            {
                ItemSelected(this, OriginalArgs);
            }
        }

        private void OnItemUnSelected(ControlSelectedEventArgs OriginalArgs)
        {
            if (ItemUnSelected != null)
            {
                ItemUnSelected(this, OriginalArgs);
            }
        }

        /// <summary>
        /// Sets the selected item property and lets the previously selected item
        /// know that it is no longer selected.
        /// </summary>
        /// 
        private void NewItem_ControlSelected(object sender, ControlSelectedEventArgs e)
        {
            if (SelectedItem != null)
            {
                SelectedItem.IsSelected = false;
            }
            SelectedItem = e.ControlSelected as T;
            OnItemSelected(e);
        }

        /// <summary>
        /// Determines if the user unselected the currently selected item.
        /// </summary>
        /// 
        private void NewItem_ControlUnSelected(object sender, ControlSelectedEventArgs e)
        {
            if (SelectedItem == e.ControlSelected)
            {
                SelectedItem = null;
            }
            OnItemUnSelected(e);
        }
    }
}