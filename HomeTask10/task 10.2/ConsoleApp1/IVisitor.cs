using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IVisitor
    {
        void Visit(Electronics electronics);
        void Visit(Flowers flowers);
    }
}
