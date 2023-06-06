using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IItem
    {
        double Price { get; set; }
        double Size { get; set; }
        double Weight { get; set; }
        double DeliveryCost { get; set; }
        void Accept(IVisitor visitor);
    }
}
