using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Pizza : ICompletedOrder
    {
        public string Name { get; set; }
        public int TimeToCook { get; set; }
    }
}
