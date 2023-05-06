using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Simulator
    {
        private ITrafficRules _Intersection;
        public int Time { get; set; }
        public Simulator(Intersection intersection,int time = 20)
        {
            _Intersection = (Intersection)intersection.Clone();
            Time = time;
            SubscribeEvents();
        }
        private void Output(TrafficLight trafficLight)
        {

            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss")+"\n"+trafficLight.ToString());
        }

        private void SubscribeEvents()
        {
            foreach (var trafficLight in _Intersection.TrafficLights)
            {
                trafficLight.SetRule += _Intersection.SetRules;
                trafficLight.StateOutput += (trafficLight) => Output(trafficLight);
            }
        }
        public void Run()
        {
            foreach (var trafficlight in _Intersection.TrafficLights)
            {
                trafficlight.FirstRun();
            }
            TimeSpan totalTime = TimeSpan.FromSeconds(Time);

            DateTime startTime = DateTime.Now;

            while (DateTime.Now - startTime < totalTime)
            {
                foreach (var trafficLight in _Intersection.TrafficLights)
                {
                    trafficLight.ChangeState();
                }
                Thread.Sleep(Time * 100);

            }

        }
    }
}