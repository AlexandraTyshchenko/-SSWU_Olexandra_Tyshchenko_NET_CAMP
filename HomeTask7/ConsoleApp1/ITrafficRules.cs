using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface ITrafficRules
    {
        public void SetRules(TrafficLight trafficLight);
        public List<TrafficLight> TrafficLights{ get; set; }
     }
}
