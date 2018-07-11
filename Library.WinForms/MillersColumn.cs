using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.WinForms
{
    public partial class MillersColumn : UserControl, IMillerColumn
    {
        public MillersColumn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Specifies the amount of scrolling done when the user drags an item past the visible items in the list.
        /// </summary>
        /// 
        private const int REORDER_SCROLL_AMT = 1;

        /// <summary>
        /// Tracks the dragging of the defect items to a new position.
        /// </summary>
        /// 
        private bool _isDragging = false;



        [Description("A reference to the Miller's Column control that displays the child items of this control.")]
        public IMillerColumn ChildControl { get; set; }

        [Description("A method that returns a list of Miller's Column items for a given parent ID value.")]
        public Func<int, List<IMillerItem>> GetChildItems { get; set; }

        [Description("Gets the list of Miller's Column items in this control.")]
        public List<IMillerItem> Items { get; private set; }

        [Description("The unique ID of the parent item for this control's items.")]
        public int ParentID { get; set; }

        [Description("The currently selected Miller's Column item.")]
        public IMillerItem SelectedItem { get; private set; }

        [Description("Set to true to indicate the user can reorder the control's items by dragging them with the mouse.")]
        public bool ItemsCanBeMoved { get; set; }



        [Description("Fired when a new item has been added to this control.")]
        public event MillerItemActionEventHandler MillerItemAdded;

        [Description("Fired when an item has been removed from this control's list.")]
        public event MillerItemActionEventHandler MillerItemDeleted;

        [Description("Fired when an item has been moved by the user.")]
        public event MillerItemMovedEventHandler MillerItemMoved;



        /// <summary>
        /// Fires the MillerItemMoved event if there are any listeners.
        /// </summary>
        /// 
        private void OnMillerItemMoved(Control SourceItem, Control DestinationItem)
        {
            if (this.MillerItemMoved != null)
            {
                this.MillerItemMoved(this, new MillerItemMovedEventArgs(SourceItem, DestinationItem));
            }
        }





        /// <summary>
        /// Adds a new Miller's Column item to the list.
        /// </summary>
        /// 
        /// <param name="NewItem">
        /// The item to add.
        /// </param>
        /// 
        /// <returns>
        /// True if the item was added successfully and false if not.
        /// </returns>
        /// 
        public bool AddItem(IMillerItem NewItem)
        {
            bool itemAdded = this.AddMillerItem(NewItem);

            if (itemAdded)
            {
                this.OnMillerColumnAdded(NewItem);
                this.flowLayoutPanelItems.ScrollControlIntoView(NewItem as Control);
            }

            return itemAdded;
        }

        /// <summary>
        /// Adds the list of Miller's Column items to this control's list.
        /// </summary>
        /// 
        /// <param name="ItemList">
        /// The list of Miller's Column items.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate all of the items were added and false to indicate an error.
        /// </returns>
        /// 
        public bool AddItemRange(List<IMillerItem> ItemList)
        {
            bool listAdded = true;

            if (ItemList != null && ItemList.Count > 0)
            {
                foreach (IMillerItem currItem in ItemList)
                {
                    if (!this.AddMillerItem(currItem))
                    {
                        listAdded = false;
                        break;
                    }
                }
            }

            return listAdded;
        }

        /// <summary>
        /// Removes all items from this control's list.
        /// </summary>
        /// 
        /// <returns>
        /// True to indicate all items have been removed and false to indicate an error.
        /// </returns>
        /// 
        public bool ClearItems()
        {
            bool itemsCleared = false;

            if (this.Items != null && this.Items.Count > 0)
            {
                itemsCleared = true;
                for (int listIdx = this.Items.Count - 1; listIdx >= 0; listIdx--)
                {
                    if (!this.RemoveMillerItem(this.Items[listIdx]))
                    {
                        itemsCleared = false;
                        break;
                    }
                }
                this.Items = null;
            }

            return itemsCleared;
        }

        /// <summary>
        /// Removes an item from this control's list. 
        /// </summary>
        /// 
        /// <param name="ItemToRemove">
        /// The Miller's Column Item to remove from this control.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate the item has been removed and false to indicate an error.
        /// </returns>
        /// 
        public bool RemoveItem(IMillerItem ItemToRemove)
        {
            bool itemRemoved = false;

            if (ItemToRemove != null)
            {
                itemRemoved = this.RemoveMillerItem(ItemToRemove);
                this.OnMillerColumnDeleted(ItemToRemove);
                this.SelectedItem = null;
            }

            return itemRemoved;
        }




        /// <summary>
        /// Fires the MillerColumnAdded event if there are any listeners.
        /// </summary>
        /// 
        private void OnMillerColumnAdded(IMillerItem AddedItem)
        {
            if (this.MillerItemAdded != null)
            {
                this.MillerItemAdded(this, new MillerItemEventArgs(AddedItem));
            }
        }

        /// <summary>
        /// Fires the MillerColumnDeleted event if there are any listeners.
        /// </summary>
        /// 
        private void OnMillerColumnDeleted(IMillerItem DeletedItem)
        {
            if (this.MillerItemDeleted != null)
            {
                this.MillerItemDeleted(this, new MillerItemEventArgs(DeletedItem));
            }
        }

        /// <summary>
        /// Adds a Miller's Column item to the list.
        /// </summary>
        /// 
        /// <param name="ItemToAdd">
        /// The Miller's Column item to add to the list.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate the item was successfully added and false if not.
        /// </returns>
        /// 
        private bool AddMillerItem(IMillerItem ItemToAdd)
        {
            bool itemAdded = false;

            if (ItemToAdd != null && ItemToAdd is Control)
            {
                ItemToAdd.MillerItemSelected += MillerColumnItemSelected;

                if (this.ItemsCanBeMoved)
                {
                    (ItemToAdd as IDraggable).DragObject.MouseDown += DragObject_MouseDown;
                    (ItemToAdd as IDraggable).DragObject.MouseUp   += DragObject_MouseUp;
                    (ItemToAdd as IDraggable).DragObject.MouseMove += DragObject_MouseMove;
                }

                if (this.Items == null)
                {
                    this.Items = new List<IMillerItem>();
                }

                this.Items.Add(ItemToAdd);
                this.flowLayoutPanelItems.Controls.Add(ItemToAdd as Control);

                itemAdded = true;
            }

            return itemAdded;
        }

        /// <summary>
        /// Deletes a Miller's Column item from the list.
        /// </summary>
        /// 
        /// <param name="ItemToDelete">
        /// The Miller's Column item to delete from the list.
        /// </param>
        /// 
        /// <returns>
        /// True to indicate the item was successfully deleted and false if not.
        /// </returns>
        /// 
        private bool RemoveMillerItem(IMillerItem ItemToDelete)
        {
            bool itemRemoved = false;

            if (ItemToDelete != null && ItemToDelete is Control)
            {
                ItemToDelete.MillerItemSelected -= MillerColumnItemSelected;

                if (this.ItemsCanBeMoved)
                {
                    (ItemToDelete as IDraggable).DragObject.MouseDown -= DragObject_MouseDown;
                    (ItemToDelete as IDraggable).DragObject.MouseUp   -= DragObject_MouseUp;
                    (ItemToDelete as IDraggable).DragObject.MouseMove -= DragObject_MouseMove;
                }

                if (this.Items != null)
                {
                    this.Items.Remove(ItemToDelete);
                }

                if (this.flowLayoutPanelItems.Controls.Contains(ItemToDelete as Control))
                {
                    this.flowLayoutPanelItems.Controls.Remove(ItemToDelete as Control);
                }

                itemRemoved = true;
            }

            return itemRemoved;
        }

        /// <summary>
        /// Retrieves and adds any child items for a specified parent to the Miller's Column control that is
        /// the child of this control.
        /// </summary>
        /// 
        /// <param name="ParentItem">
        /// The item considered the parent to use for finding the child items.
        /// </param>
        /// 
        private void ShowChildItems(IMillerItem ParentItem)
        {
            if (ParentItem != null)
            {
                if (this.ChildControl != null)
                {
                    if (this.GetChildItems != null)
                    {
                        //  Perform the retrieval of the child items in a different thread then the UI thread.

                        this.backgroundWorker.RunWorkerAsync(ParentItem);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a list of items to the current child control.
        /// </summary>
        /// 
        /// <param name="ChildItems">
        /// List of Miller's Columns items to add to the child control.
        /// </param>
        /// 
        private void SetChildControl(List<IMillerItem> ChildItems)
        {
            if (ChildItems != null)
            {
                if (this.ChildControl != null)
                {
                    this.ChildControl.ClearItems();
                    this.ChildControl.AddItemRange(ChildItems);
                    this.ChildControl.ParentID = this.SelectedItem.ID;
                }
            }
        }




        private void MillerColumnItemSelected(object sender, MillerItemEventArgs e)
        {
            if (this.SelectedItem != e.MillerItem)
            {
                if (this.SelectedItem != null)
                {
                    this.SelectedItem.IsSelected = false;
                }
                this.SelectedItem = e.MillerItem;
                this.ShowChildItems(e.MillerItem);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<IMillerItem> childItems = null;
            IMillerItem parentItem = e.Argument as IMillerItem;

            if (parentItem != null && this.GetChildItems != null)
            {
                childItems = this.GetChildItems(parentItem.ID);
            }

            e.Result = childItems;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                this.SetChildControl(e.Result as List<IMillerItem>);
            }
        }

        private void DragObject_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IDraggable millerItem = (sender as Control).FindParentType<IDraggable>();
                if (millerItem != null)
                {
                    this._isDragging = true;
                    this.Cursor = Cursors.SizeNS;
                    millerItem.Highlight();
                }
            }
        }

        private void DragObject_MouseUp(object sender, MouseEventArgs e)
        {
            if (this._isDragging)
            {
                IDraggable millerItem = (sender as Control).FindParentType<IDraggable>();
                if (millerItem != null)
                {
                    this._isDragging = false;
                    this.Cursor = Cursors.Default;
                    millerItem.UnHighlight();
                }
            }
        }

        private void DragObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._isDragging)
            {
                Point mousePosition = this.flowLayoutPanelItems.PointToClient((sender as Control).PointToScreen(new Point(e.X, e.Y)));

                Control destination = this.flowLayoutPanelItems.GetChildAtPoint(mousePosition);
                Control source      = (Control)(sender as Control).FindParentType<IDraggable>();

                //  Ensure the mouse is hovering over a miller item.

                if (destination != null)
                {
                    int idxDestination = this.flowLayoutPanelItems.Controls.IndexOf(destination);
                    int idxSource      = this.flowLayoutPanelItems.Controls.IndexOf(source);

                    if (idxDestination != -1)
                    {
                        //  Verify that the mouse is not hovering over the item being dragged.

                        if (idxSource != idxDestination)
                        {
                            //  Swap the indices for the source and destination controls.

                            int idxTemp = idxSource;

                            idxSource      = idxDestination;
                            idxDestination = idxTemp;

                            this.OnMillerItemMoved(source, destination);

                            //  Draw the new locations of the affected items.

                            this.flowLayoutPanelItems.SuspendLayout();
                            this.flowLayoutPanelItems.Controls.SetChildIndex(source, idxSource);
                            this.flowLayoutPanelItems.Controls.SetChildIndex(destination, idxDestination);
                            this.flowLayoutPanelItems.Invalidate(true);
                            this.flowLayoutPanelItems.ResumeLayout();
                        }
                    }
                }
                else
                {
                    //  Check if the user has moved the mouse outside of the flow layout panel. If they have,
                    //    scroll the contents of the panel accordingly.

                    Form formRef     = this.flowLayoutPanelItems.FindForm();
                    int panelTopY    = formRef.PointToClient(this.flowLayoutPanelItems.Parent.PointToScreen(this.flowLayoutPanelItems.Location)).Y;
                    int panelBottomY = this.flowLayoutPanelItems.Height + panelTopY;
                    int mouseY       = formRef.PointToClient(MousePosition).Y;

                    while (mouseY >= panelBottomY)
                    {
                        if (this.flowLayoutPanelItems.VerticalScroll.Value + REORDER_SCROLL_AMT <= this.flowLayoutPanelItems.VerticalScroll.Maximum)
                        {
                            this.flowLayoutPanelItems.VerticalScroll.Value = this.flowLayoutPanelItems.VerticalScroll.Value + REORDER_SCROLL_AMT;
                        }
                        mouseY = formRef.PointToClient(MousePosition).Y;
                        this.flowLayoutPanelItems.Refresh();
                    }

                    while (mouseY <= panelTopY)
                    {
                        if (this.flowLayoutPanelItems.VerticalScroll.Value - REORDER_SCROLL_AMT >= this.flowLayoutPanelItems.VerticalScroll.Minimum)
                        {
                            this.flowLayoutPanelItems.VerticalScroll.Value = this.flowLayoutPanelItems.VerticalScroll.Value - REORDER_SCROLL_AMT;
                        }
                        mouseY = formRef.PointToClient(MousePosition).Y;
                        this.flowLayoutPanelItems.Refresh();
                    }
                }
            }
        }
    }
}
