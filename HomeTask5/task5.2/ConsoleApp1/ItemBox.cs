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
        public int Height { get; }
        public int Width { get; }   
        public int Length { get; }
        
        public ItemBox(List<Item> items)
        {

            Items = items;
            CalculateSizeOfItemBox();
        }
        private void CalculateSizeOfItemBox()
        {

        }
    }
}
