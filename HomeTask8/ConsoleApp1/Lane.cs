using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Lane:ILane//можна реалізувати інтерфейс без trafficlight
    {
        public ITrafficlight Trafficlight { get; set; }//напевно зробити валідацію певного типу, може добавити тип direction
        public Direction LaneDirection { get; set; }
        public Lane(ITrafficlight trafficLight,Direction direction)
        {
            Trafficlight= trafficLight;
            LaneDirection= direction;
        }
        public Lane()
        {

        }
      
    }
}
