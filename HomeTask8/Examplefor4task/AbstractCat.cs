using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public delegate void Move();
    internal abstract class AbstractCat 
    {

            public abstract event Move MoveReact;
             public abstract void Invoke();
    }
}
