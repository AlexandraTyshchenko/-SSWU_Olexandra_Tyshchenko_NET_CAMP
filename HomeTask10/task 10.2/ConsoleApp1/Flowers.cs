using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Flowers : IItem
    //квіти треба доставляти терміново
    {
        public Flowers(double price, double size, double weight, double expressDeliveryPrice=100)
        {
            Price = price;
            Size = size;
            Weight = weight;
            ExpressDeliveryPrice = expressDeliveryPrice;
        }

        public double Price { get; set ; }
        public double Size { get ; set; }
        public double Weight { get; set ; }
        public double DeliveryCost { get; set;}
        public double ExpressDeliveryPrice { get; set; } 

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
