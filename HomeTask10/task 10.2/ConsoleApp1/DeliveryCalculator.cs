using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DeliveryCalculator : IVisitor
    {
        private int _deliveryPrice;
        public DeliveryCalculator(int deliveryPrice=20)
        {
            _deliveryPrice= deliveryPrice;
        }
        public void Visit(Electronics electronics)
        {
            if (electronics.Size > electronics.MaxSize)
            {
                electronics.DeliveryCost = _deliveryPrice + (double)electronics.Surcharge / 100 * electronics.Price;
            }
            else
            {
                electronics.DeliveryCost = _deliveryPrice;
            }
        }
        public void Visit(Flowers flowers)
        {
            flowers.DeliveryCost = _deliveryPrice + flowers.ExpressDeliveryPrice;
        }
    }
}
