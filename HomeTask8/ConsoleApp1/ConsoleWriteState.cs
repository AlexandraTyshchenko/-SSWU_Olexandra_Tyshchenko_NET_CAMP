using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConsoleWriteState : IOutput
    {
        public void StateTrafficLightOutput(IIntersection intersection,int time)
        {
            if(intersection is Intersection thisintersection){
                Console.WriteLine(thisintersection+"\n"+time+"c\n");
            }
        }
       
    }
}
