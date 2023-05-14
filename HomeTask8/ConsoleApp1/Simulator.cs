namespace ConsoleApp1
{
    internal delegate void State(Simulator simulator);

    internal class Simulator
    {
        private List<(IIntersection, IIntersectionRules)> _intersections;
        private IOutput _output;
        public int Time { get; set; }
        public Simulator(List<(IIntersection, IIntersectionRules)> intersections,IOutput output, int time = 2)
        {
            _intersections = intersections;
            Time = time;      
            _output = output;
        }  
        public void Run()
        {
            foreach (var (intersection, strategy) in _intersections)
            {
                strategy.Reload(intersection);
            }

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }
                foreach(var (intersection, strategy) in _intersections) {
                    _output.StateTrafficLightOutput(intersection, Time);
                    strategy.ChangeState(intersection);
                    
                }
                Thread.Sleep(Time * 1000);
            }
        }
   
    }
}