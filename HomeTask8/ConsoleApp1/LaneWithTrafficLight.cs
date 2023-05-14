using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LaneWithTrafficLight:LaneDecorator
    {
        public ITrafficlight Trafficlight { get; set; }//напевно зробити валідацію певного типу, може добавити тип direction
        public Direction LaneDirection { get; set; }
        public LaneWithTrafficLight(ITrafficlight trafficLight,Direction direction):base(direction)
        {
            Trafficlight= trafficLight;
        }
        public LaneWithTrafficLight() : base() 
        {

        }
        public override string ToString()
        {
            return Trafficlight.ToString();
        }
    }
}
