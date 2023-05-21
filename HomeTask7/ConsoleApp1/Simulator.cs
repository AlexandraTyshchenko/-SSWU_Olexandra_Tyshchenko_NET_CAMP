namespace ConsoleApp1
{
    internal class Simulator
    {// На мою думку, світлофор не керує перемиканням. А тому події переключення мали б бути в тому класі, який керує роботою світлофора. Сам по собі світлофор вміє тільки світитись.
   
        private ITrafficRules _Intersection;
        public int Time { get; set; }
        public Simulator(Intersection intersection, int time = 2)
        {
            _Intersection = (Intersection)intersection.Clone();//в майбутньому можна створити об'єкти з іншою реалізацією інтерфейсу
            Time = time;
            SubscribeEvents();
        }
        private void Output(TrafficLight trafficLight)
        {

            Console.WriteLine(Time + " c\n" + trafficLight.ToString());
        }

        private void SubscribeEvents()
        {
            // Ви змушені порушувати інкапсуляцію сітлофорів. 
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

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }
                foreach (var trafficLight in _Intersection.TrafficLights)
                {
                    trafficLight.ChangeState();
                }
                Thread.Sleep(Time * 1000);
            }


        }
    }
}
