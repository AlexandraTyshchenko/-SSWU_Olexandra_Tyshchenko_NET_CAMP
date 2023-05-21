using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ConcreteMediator : IMediator
    {
        IReciever _waiter;
        IReciever _report;
     

        public ConcreteMediator(IReciever waiter,IReciever report)
        {
            _report= report;
            _waiter= waiter;
        }
        public void Notify(object ob)
        {
            if(ob is Person person){
                _report.Recieve(person);
            }
            if(ob is ICompletedOrder order)
            {
                _waiter.Recieve(order);
            }
        }
    }
}
