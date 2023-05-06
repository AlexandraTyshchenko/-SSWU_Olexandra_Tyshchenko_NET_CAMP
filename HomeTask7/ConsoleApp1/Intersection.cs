using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Intersection:ITrafficRules,ICloneable
    {
        private List<TrafficLight> _trafficlights;
        public List<TrafficLight> TrafficLights
        {
            get { return _trafficlights; }
            set { _trafficlights = value; }
        }
        public Intersection()
        {
            _trafficlights = new List<TrafficLight>();
        }
        public Intersection(List<TrafficLight> trafficlights)
        {
            _trafficlights = trafficlights;
        }
        public void SetRules(TrafficLight trafficLight)
        {
            if (trafficLight.From == Direction.South && trafficLight.To == Direction.North ||

                trafficLight.To == Direction.South && trafficLight.From == Direction.North)
            {
                trafficLight.IsRed = true;
                trafficLight.IsGreen = false;
                trafficLight.IsYellow = false;
            }
            if (trafficLight.From == Direction.East && trafficLight.To == Direction.West ||

                trafficLight.To == Direction.West && trafficLight.From == Direction.East)
            {
                trafficLight.IsRed = false;
                trafficLight.IsGreen = true;
                trafficLight.IsYellow = false;
            }
        }

        public object Clone()
        {
            Intersection clone = new Intersection();

            foreach (TrafficLight trafficLight in _trafficlights)
            {
                clone.TrafficLights.Add((TrafficLight)trafficLight.Clone());
            }
            return clone;
        }
    }
}
