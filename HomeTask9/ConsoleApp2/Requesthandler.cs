using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal abstract class RequestHandler
    {
        protected RequestHandler _next;
        public void SetNext(RequestHandler next)
        {
            _next = next;
        }
        public abstract void HandleRequest(List<OrderItem> orders);
    }
}

