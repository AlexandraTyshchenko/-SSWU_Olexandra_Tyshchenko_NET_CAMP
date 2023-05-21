using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal interface ISender
    {
        IMediator mediator { get; set; }
        public void Send(object ob);
    }
}
