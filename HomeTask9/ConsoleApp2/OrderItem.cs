using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class OrderItem
    {
        public OrderItem(string name,TypeOfOrder typeOfOrders) 
        {
            Name= name;
            Order = typeOfOrders;
        }
        public string Name { get; set; }
        public TypeOfOrder Order{ get; set; }
        public int Amount { get; set; }
    }
}
