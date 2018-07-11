#region

using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace Library.WinForms
{
    public interface IColorComboBox
    {
        /// <summary>
        /// Gets/sets the selected color of ComboBox
        /// (Default color is Black)
        /// </summary>
        Color Color { get; set; }
    }

    /// <summary>
    /// Inherits from existing ComboBox
    /// </summary>
    /// 
    /// <remarks>
    /// Originally written by Jean Paul.
    /// From an original article called "ColorComboBox to pick Colors" on www.c-sharpcorner.com
    /// http://www.c-sharpcorner.com/uploadfile/40e97e/colorcombobox-to-pick-colors/
    /// </remarks>
    /// 
    public class ColorComboBox : ComboBox, IColorComboBox
    {
        public ColorComboBox()
        {
            FillColors();

            // Change DrawMode for custom drawing
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FillColors()
        {
            Items.Clear();

            // Fill Colors using Reflection
            foreach (
                Color color in
                    typeof (Color).GetProperties(BindingFlags.Static | BindingFlags.Public)
                                  .Where(c => c.PropertyType == typeof (Color))
                                  .Select(c => (Color) c.GetValue(c, null)))
            {
                Items.Add(color);
            }
        }

        /// <summary>
        /// Override Draw Method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                var color = (Color) Items[e.Index];

                int nextX = 0;

                e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
                DrawColor(e, color, ref nextX);
                DrawText(e, color, nextX);
            }
            else
            {
                base.OnDrawItem(e);
            }
        }

        /// <summary>
        /// Draw the Color rectangle filled with item color
        /// </summary>
        /// <param name="e"></param>
        /// <param name="color"></param>
        /// <param name="nextX"></param>
        private void DrawColor(DrawItemEventArgs e, Color color, ref int nextX)
        {
            int width = e.Bounds.Height*2 - 8;
            var rectangle = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, width, e.Bounds.Height - 6);
            e.Graphics.FillRectangle(new SolidBrush(color), rectangle);

            nextX = width + 8;
        }

        /// <summary>
        /// Draw the color name next to the color rectangle
        /// </summary>
        /// <param name="e"></param>
        /// <param name="Color"></param>
        /// <param name="nextX"></param>
        private void DrawText(DrawItemEventArgs e, Color Color, int nextX)
        {
            e.Graphics.DrawString(Color.Name, e.Font, new SolidBrush(e.ForeColor),
                                  new PointF(nextX, e.Bounds.Y + (e.Bounds.Height - e.Font.Height)/2));
        }

        /// <summary>
        /// Gets/sets the selected color of ComboBox
        /// (Default color is Black)
        /// </summary>
        public Color Color
        {
            get
            {
                if (SelectedItem != null)
                {
                    return (Color) SelectedItem;
                }

                return Color.Black;
            }
            set
            {
                int ix = Items.IndexOf(value);
                if (ix >= 0)
                {
                    SelectedIndex = ix;
                }
            }
        }
    }
}