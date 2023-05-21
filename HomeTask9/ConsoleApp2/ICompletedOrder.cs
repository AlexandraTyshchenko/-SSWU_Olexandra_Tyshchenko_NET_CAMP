using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal interface ICompletedOrder
    {
        string Name { get; set; }
        int TimeToCook { get; set; }
    }
}
