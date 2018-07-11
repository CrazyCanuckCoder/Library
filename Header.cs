#region

using System.ComponentModel;
using System.Drawing;

#endregion

namespace Library
{
    public class Header : IHeader
    {
        public Header()
        {
        }

        public Header(string NewText, int NewWidth)
        {
            Text = NewText;
            Width = NewWidth;
        }

        #region  Fields

        private string _text = "";
        private int _width = 0;
        private ContentAlignment _textAlignment = ContentAlignment.MiddleCenter;
        private Color _foreground = SystemColors.ActiveCaptionText;
        private Color _background = SystemColors.ActiveCaption;
        private bool _hasBorder = true;

        #endregion  Fields

        #region  Properties

        [Description("The text to display in the header.")]
        public string Text
        {
            get { return _text; }

            set
            {
                if (value != null)
                {
                    _text = value;
                }
            }
        }

        [Description("The width of the header.")]
        public int Width
        {
            get { return _width; }

            set
            {
                if (value >= 0)
                {
                    _width = value;
                }
            }
        }

        [Description("How the text is aligned in the header.")]
        public ContentAlignment TextAlignment
        {
            get { return _textAlignment; }

            set { _textAlignment = value; }
        }

        [Description("The colour of the text in the header.")]
        public Color Foreground
        {
            get { return _foreground; }

            set { _foreground = value; }
        }

        [Description("The background colour of the header.")]
        public Color Background
        {
            get { return _background; }

            set { _background = value; }
        }

        [Description("Indicates whether the header should have a border.")]
        public bool HasBorder
        {
            get { return _hasBorder; }

            set { _hasBorder = value; }
        }

        #endregion  Properties

        public override string ToString()
        {
            return Text;
        }
    }
}