using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class BritishCat : AbstractCat
    {
        //нові властивості
        public override event Move MoveReact;
       

        public override void Invoke()
        {
            MoveReact?.Invoke();
        }
    }
}
