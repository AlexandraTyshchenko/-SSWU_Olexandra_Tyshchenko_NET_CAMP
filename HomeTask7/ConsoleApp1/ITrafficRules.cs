using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface ITrafficRules//інтерфейс для реалізацій правил на перехресті
    {
        public void SetRules(TrafficLight trafficLight);
        public List<TrafficLight> TrafficLights{ get; set; }
     }
}
