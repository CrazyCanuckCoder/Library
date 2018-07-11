#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    /// <summary>
    /// This class emulates a FlowLayoutPanel to ensure that only specific types
    /// of objects can be added to the panel.
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// Specifies the type of controls that can be added to the panel.
    /// </typeparam>
    /// 
    public partial class FlowLayoutPanelList<T> : UserControl, IFlowLayoutPanelList<T> where T : Control
    {
        public FlowLayoutPanelList()
        {
            InitializeComponent();
        }




        /// <summary>
        /// Contains a list of all T objects from the panel before a search was performed.
        /// </summary>
        /// 
        protected List<T> _originalItems = null;

        /// <summary>
        /// Contains a list of all T objects added to the panel.
        /// </summary>
        /// 
        protected List<T> _items = new List<T>();

        /// <summary>
        /// Gets an array containing the list of objects in the panel.
        /// </summary>
        /// 
        public T[] Items
        {
            get
            {
                //var items = new T[_items.Count];
                //_items.CopyTo(items);

                //return items;
                return this._items.ToArray();
            }
        }

        /// <summary>
        /// Add a new item to the panel.
        /// </summary>
        /// 
        /// <param name="NewItem">
        /// The item to add.
        /// </param>
        /// 
        public virtual void AddItem(T NewItem)
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
        public virtual void RemoveItem(T DeleteItem)
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
                    _items.Remove(DeleteItem);
                    flowLayoutPanelBase.Controls.Remove(DeleteItem);
                }
            }
        }

        /// <summary>
        /// Deletes all items from the panel.
        /// </summary>
        /// 
        public virtual void Clear()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(Clear
                           ));
            }
            else
            {
                _items.Clear();
                flowLayoutPanelBase.Controls.Clear();
            }
        }

        /// <summary>
        /// Sorts the items in the panel using a comparison method that is
        /// specific to the item type.
        /// </summary>
        /// 
        /// <param name="CompareMethod">
        /// The method to use to sort the items in the panel.
        /// </param>
        /// 
        public virtual void Sort(Comparison<T> CompareMethod)
        {
            if (_items.Count > 1)
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate { Sort(CompareMethod); }
                               ));
                }
                else
                {
                    _items.Sort(CompareMethod);
                    flowLayoutPanelBase.Controls.Clear();
                    flowLayoutPanelBase.Controls.AddRange(Items);
                }
            }
        }

        /// <summary>
        /// Returns the index value of the specified control.
        /// </summary>
        /// 
        /// <param name="IndexItem">
        /// The control that you want the index of.
        /// </param>
        /// 
        /// <returns>
        /// -1 if the control is not contained in the flow layout panel or the
        /// index value if the control is contained in the flow layout panel.
        /// </returns>
        /// 
        public virtual int GetIndex(T IndexItem)
        {
            int index = -1;

            if (flowLayoutPanelBase.Controls.Contains(IndexItem as Control))
            {
                index = flowLayoutPanelBase.Controls.IndexOf(IndexItem as Control);
            }

            return index;
        }

        /// <summary>
        /// Sets the index of the specified control.
        /// </summary>
        /// 
        /// <param name="IndexItem">
        /// The control to set the index of.
        /// </param>
        /// 
        /// <param name="NewIndex">
        /// The new index value for the control.
        /// </param>
        /// 
        /// <returns>
        /// True if the index value was successfully set for the control and 
        /// false if not.
        /// </returns>
        /// 
        public virtual bool SetIndex(T IndexItem, int NewIndex)
        {
            bool indexSet = false;

            if (flowLayoutPanelBase.Controls.Contains(IndexItem as Control))
            {
                flowLayoutPanelBase.Controls.SetChildIndex(IndexItem as Control, NewIndex);
                indexSet = true;
            }

            return indexSet;
        }
    }
}