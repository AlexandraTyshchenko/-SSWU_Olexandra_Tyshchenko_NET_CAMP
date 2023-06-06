using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Client
    {
        public void CalculateDeliveryCost(List<IItem> items, IVisitor calculator)
        {
            foreach(var item in items)
            {
                item.Accept(calculator);
            }
        }
    }
}
