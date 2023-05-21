using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal interface IRequestProcessor
    {
        TypeOfOrder? ReturnFoundOrder(List<OrderItem> orderItem);
        public void CompleteOrder(List<OrderItem> orderItem);
    }
}
