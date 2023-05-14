using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal  class TrafficLightDecorator : ITrafficlight
    {
        public bool IsRed { get; set; } 
        public bool IsYellow { get; set; } 
        public bool IsGreen { get; set; }
        public TrafficLightDecorator(bool isRed, bool isYellow, bool isGreen)
        {
            IsRed = isRed;
            IsYellow = isYellow;
            IsGreen = isGreen;
        }
        public TrafficLightDecorator()
        {

        }
      
    }
}
