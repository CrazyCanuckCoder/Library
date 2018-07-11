#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

#endregion

namespace Library
{
    public interface IErrorMessage
    {
        string ErrorMessage { get; }
    }

    public interface ISelectable
    {
        bool IsSelected { get; set; }

        event ControlSelectedEventHandler ControlSelected;
        event ControlSelectedEventHandler ControlUnSelected;
        event ControlSelectedEventHandler ControlDoubleClicked;
    }

    public interface ISelectableDataEntry : ISelectable
    {
        object Value { get; set; }
    }

    public interface IFlowLayoutPanelList<T> where T : Control
    {
        T[] Items { get; }

        void AddItem(T NewItem);
        void Clear();
        void RemoveItem(T DeleteItem);
        void Sort(Comparison<T> CompareMethod);
        int GetIndex(T IndexItem);
        bool SetIndex(T IndexItem, int NewIndex);
    }

    public interface IDataEntryControl
    {
        string Descriptor { get; set; }
        bool IsMandatory { get; set; }
        bool HasValue { get; }

        bool HasRequiredInput();
        void SetDataBinding(BindingSource DataBinder, string SourceName);
    }

    public interface ILabelledInput
    {
        int DescriptionPanelWidth { get; set; }
        bool ShowIndicator { get; set; }
    }

    public interface ITextInput
    {
        bool IsMultiline { get; set; }
        string Value { get; set; }
    }

    public interface IMaskedTextInput
    {
        string Mask { get; set; }
        char PromptChar { get; set; }
        string Value { get; set; }
    }

    public interface IHeader
    {
        Color Background { get; set; }
        Color Foreground { get; set; }
        string Text { get; set; }
        ContentAlignment TextAlignment { get; set; }
        int Width { get; set; }
        bool HasBorder { get; set; }
    }

    public interface ISelectionPanel
    {
        List<ISelectableDataEntry> Items { get; }
        ISelectableDataEntry SelectedItem { get; }

        event ControlSelectedEventHandler ItemDoubleClicked;

        void AddHeaders(List<IHeader> Titles);
        void AddItem(ISelectableDataEntry NewItem);
        void RemoveItem(ISelectableDataEntry DeleteItem);
    }

    public interface IBaseDataEntryForm
    {
        [Description("Specifies the entry type of the form.")]
        EntryType DataEntryType { get; set; }
    }

    public interface IBaseSelectionForm
    {
        [Description("A panel containing the list of objects to be selected.")]
        ISelectionPanel SelectionPanel { get; }

        [Description("The item selected by the user.")]
        ISelectableDataEntry ItemSelected { get; }

        [Description("True to add a scroll bar width when resizing this control.")]
        bool AddScrollBarWidth { get; set; }
    }

    public interface IIPv4Address
    {
        int[] Quadrants { get; set; }
        string ToString();
    }

    /// <summary>
    /// The interface for the Specification classes.
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// The type of the specification object.
    /// </typeparam>
    /// 
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T Candidate);
    }

    public interface IInputVerifier
    {
        List<InputError> InputErrors { get; }
        bool HasValidInput(IEnumerable ControlsToVerify);
        bool RegisterVerificationMethod(Type ControlType, Func<Control, string> MethodToUse);
    }

    public interface IRepository<T>
    {
        void Insert(T Entity);
        void Delete(T Entity);
        void Save();
        IQueryable<T> SearchFor(Expression<Func<T, bool>> Predicate);
        IQueryable<T> GetAll();
        T GetByID(int ID);
    }

    public interface IEntity
    {
        int ID { get; }
    }

    public interface IControlPrinter : IErrorMessage
    {
        bool Print(Control ControlToPrint);
        bool Print(Control ControlToPrint, PrinterSettings NewSettings);
        Bitmap GeneratePrintImage(Control ControlToImage, PageSettings PrintPageSettings);
    }

    /// <summary>
    /// The interface for items contained in a Miller's Column control.
    /// </summary>
    /// 
    public interface IMillerItem
    {
        int ID { get; }
        string Description { get; set; }
        int ParentID { get; set; }
        bool IsSelected { get; set; }

        event MillerItemActionEventHandler MillerItemSelected;
        event MillerItemActionEventHandler MillerItemDeleted;

        bool Save();
        bool Delete();
        bool Edit();
    }

    /// <summary>
    /// The interface for the Miller's Columns control.
    /// </summary>
    /// 
    public interface IMillerColumn
    {
        int ParentID { get; set; }
        IMillerColumn ChildControl { get; set; }
        IMillerItem SelectedItem { get; }
        List<IMillerItem> Items { get; }
        Func<int, List<IMillerItem>> GetChildItems { get; set; }
        bool ItemsCanBeMoved { get; set; }


        event MillerItemActionEventHandler MillerItemAdded;
        event MillerItemActionEventHandler MillerItemDeleted;


        bool AddItem(IMillerItem NewItem);
        bool AddItemRange(List<IMillerItem> ItemList);
        bool RemoveItem(IMillerItem ItemToRemove);
        bool ClearItems();
    }

    /// <summary>
    /// The interface for objects that can be moved with the mouse.
    /// </summary>
    /// 
    public interface IDraggable
    {
        Control DragObject { get; }

        void Highlight();
        void UnHighlight();
    }
}