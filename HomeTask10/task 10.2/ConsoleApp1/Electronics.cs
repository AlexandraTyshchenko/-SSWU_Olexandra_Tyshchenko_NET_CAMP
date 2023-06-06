using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Electronics : IItem
    {
        public Electronics(double price, double size, double weight, int surcharge=2, int maxSize=30)
        {
            Price = price;
            Size = size;
            Weight = weight;
            Surcharge = surcharge;
            MaxSize = maxSize;
        }

        public double Price { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public double DeliveryCost { get; set; }

        public int Surcharge { get; set; } 
        //надбавка - специфічне поле, оскільки в інших класах
        //її може не бути а може бути інше поле для обрахунку вартості, наприклад,
        //стала ціна доставки за терміновість доставки продукті
        public int MaxSize { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
