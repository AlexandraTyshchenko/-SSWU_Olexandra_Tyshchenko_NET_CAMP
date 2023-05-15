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
        public LaneWithTrafficLight(ITrafficlight trafficLight,Direction direction):base(direction)
        {
            Trafficlight= trafficLight;
        }
        public LaneWithTrafficLight() 
        {

        }
        public override string ToString()
        {
            return Trafficlight.ToString();
        }
        public override object Clone()
        {
            LaneWithTrafficLight lane = new LaneWithTrafficLight();
            lane.LaneDirection = new Direction(LaneDirection.From, LaneDirection.To);

            lane.Trafficlight = (ITrafficlight)Trafficlight.Clone();//можна посилання тому що світлофор може відноситись до кілька перехресть і може існувати незалежно від того чи є перехрестя чи нема
            return lane;
        }
    }
}
