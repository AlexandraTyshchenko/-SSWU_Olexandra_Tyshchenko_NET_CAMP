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
        public int Height { get; }
        public int Width { get; }
        public int Length { get; }
        public DepartmentBox(List<ItemBox> itemBoxes)
        {

            ItemBoxes = itemBoxes;
            CalculateSizeOfItemBox();
        }
        private void CalculateSizeOfItemBox()
        {

        }
    }
}
