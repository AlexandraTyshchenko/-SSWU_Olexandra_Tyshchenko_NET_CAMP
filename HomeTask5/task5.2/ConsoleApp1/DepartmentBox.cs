using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DepartmentBox
    {
        public List<ItemBox> ItemBoxes { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public List<Item> Items => throw new NotImplementedException();

        public DepartmentBox(List<ItemBox> itemBoxes)
        {

            ItemBoxes = itemBoxes;
            CalculateSize();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"DepartmentBox: Height = {Height}, Width = {Width}, Length = {Length}\n");

            foreach (var itemBox in ItemBoxes)
            {
                stringBuilder.Append(itemBox.ToString());
            }

            return stringBuilder.ToString();
        }

        private void CalculateSize()
        {
            int maxHeight = ItemBoxes.Max(ib => ib.Height);
            int maxLength = ItemBoxes.Max(ib => ib.Length);
            int maxWidth = ItemBoxes.Max(ib => ib.Width);

            int totalHeight = ItemBoxes.Sum(ib => ib.Height);
            int totalLength = ItemBoxes.Sum(ib => ib.Length);
            int totalWidth = ItemBoxes.Sum(ib => ib.Width);

            int numBoxesHeight = (int)Math.Ceiling((double)totalHeight / maxHeight);
            int numBoxesLength = (int)Math.Ceiling((double)totalLength / maxLength);
            int numBoxesWidth = (int)Math.Ceiling((double)totalWidth / maxWidth);

            Height = (int)Math.Ceiling((double)totalHeight / numBoxesHeight);
            Length = (int)Math.Ceiling((double)totalLength / numBoxesLength);
            Width = (int)Math.Ceiling((double)totalWidth / numBoxesWidth);
        }
    }
}
