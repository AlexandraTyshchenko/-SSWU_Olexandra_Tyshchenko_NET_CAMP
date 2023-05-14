using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IIntersectionRules
    {
        public void ChangeState(IIntersection intersection);
        public void Reload(IIntersection intersection);
    };
}
