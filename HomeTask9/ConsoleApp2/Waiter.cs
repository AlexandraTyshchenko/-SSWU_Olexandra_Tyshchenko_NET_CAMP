using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Waiter:IReciever
    {
        List<ICompletedOrder> completedOrders = new List<ICompletedOrder>();
        public void Recieve(object ob)
        {
           if(ob is ICompletedOrder order)
            {
                completedOrders.Add(order);
            }
        }
    }
}
