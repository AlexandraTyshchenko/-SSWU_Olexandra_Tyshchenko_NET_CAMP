// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Console.WriteLine("Hello, World!");
Console.OutputEncoding = System.Text.Encoding.UTF8;
List<TrafficLight> list = new List<TrafficLight>()
{
    new TrafficLight(Direction.South,Direction.North),
    new TrafficLight(Direction.East,Direction.West),
    new TrafficLight(Direction.West,Direction.East),
    new TrafficLight(Direction.North,Direction.South)
};
Intersection Intersection = new Intersection(list);

Simulator simulator = new Simulator(Intersection,2);
simulator.Run();