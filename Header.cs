using System.ComponentModel;
using System.Drawing;


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




        private string _text = "";
        private int _width = 0;




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
        public ContentAlignment TextAlignment { get; set; } = ContentAlignment.MiddleCenter;

        [Description("The colour of the text in the header.")]
        public Color Foreground { get; set; } = SystemColors.ActiveCaptionText;

        [Description("The background colour of the header.")]
        public Color Background { get; set; } = SystemColors.ActiveCaption;

        [Description("Indicates whether the header should have a border.")]
        public bool HasBorder { get; set; } = true;




        public override string ToString()
        {
            return Text;
        }
    }
}