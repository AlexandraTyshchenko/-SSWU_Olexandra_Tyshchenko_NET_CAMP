using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Person:RequestHandler,ISender
    {
        private IRequestProcessor _requestProcessor;
        public override void HandleRequest(List<OrderItem> orders)
        {
           var item = _requestProcessor.ReturnFoundOrder(orders);

           if (item != null) {
                Send(this);
                _requestProcessor.CompleteOrder(orders);
           }
           if(_next!= null)
            {
                _next.HandleRequest(orders);
            }
        }

        public void Send(object ob)
        {
            if(ob is Person person)
            {
                mediator.Notify(person);
            }
        }

        private string _name;

        public IMediator mediator { get; set; }

        public Person(string name, IRequestProcessor requestProcessor,IMediator mediator)
        {
            _name = name;
            _requestProcessor = requestProcessor;
            this.mediator = mediator;
        }
    }
}
