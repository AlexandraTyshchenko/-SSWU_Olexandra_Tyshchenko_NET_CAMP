using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class ItemBox
    {
        
        public List<Item> Items { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }   
        public int Length { get; set; }
        
        public ItemBox(List<Item> items)
        {

            Items = items;
            CalculateSize();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ItemBox contents:");
            foreach (Item item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"ItemBox dimensions: Height: {Height}, Width: {Width}, Length: {Length}");
            return sb.ToString();
        }

        private void CalculateSize()
        {
            int maxWidth = Items.Max(item => item.Width);
            int totalWidth = Items.Sum(item => item.Width);
            int numBoxes = (int)Math.Ceiling((double)totalWidth / maxWidth);
            Width= (int)Math.Ceiling((double)totalWidth / numBoxes);
            int maxHeight = Items.Max(item => item.Height);
            int totalHeight = Items.Sum(item => item.Height);
            numBoxes = (int)Math.Ceiling((double)totalHeight / maxHeight);
            Height= (int)Math.Ceiling((double)totalHeight / numBoxes);
            int maxLength = Items.Max(item => item.Length);
            int totalLength = Items.Sum(item => item.Length);
            numBoxes = (int)Math.Ceiling((double)totalLength / maxLength);
            Length =  (int)Math.Ceiling((double)totalLength / numBoxes);
        }
    }
}
