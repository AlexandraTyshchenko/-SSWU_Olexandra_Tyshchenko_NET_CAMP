// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Console.OutputEncoding = System.Text.Encoding.UTF8;
ILane Lane = new LaneWithTrafficLight(new TrafficLightDecorator(), new Direction(DirectionType.South,DirectionType.North));
ILane Lane1 = new LaneWithTrafficLight(new TrafficLightWithTurnLamp(), new Direction(DirectionType.South, DirectionType.North));
List<ILane> lanesSouthNorth = new List<ILane>() { Lane,Lane1};
ILane Lane2 = new LaneWithTrafficLight(new TrafficLightDecorator(), new Direction(DirectionType.North, DirectionType.South));
ILane Lane3 = new LaneWithTrafficLight(new TrafficLightWithTurnLamp(), new Direction(DirectionType.North, DirectionType.South));
List<ILane> lanesNorthSouth = new List<ILane>() { Lane2, Lane3 };
ILane Lane4 = new LaneWithTrafficLight(new TrafficLightDecorator(), new Direction(DirectionType.East, DirectionType.West));
ILane Lane5 = new LaneWithTrafficLight(new TrafficLightWithTurnLamp(), new Direction(DirectionType.East, DirectionType.West));
List<ILane> lanesEastWest = new List<ILane>() { Lane4, Lane5 };
ILane Lane6 = new LaneWithTrafficLight(new TrafficLightDecorator(), new Direction(DirectionType.West, DirectionType.East));
ILane Lane7 = new LaneWithTrafficLight(new TrafficLightWithTurnLamp(), new Direction(DirectionType.West, DirectionType.East));
List<ILane> lanesWestEast = new List<ILane>() { Lane6, Lane7 };
IIntersection Intersection = new Intersection(lanesEastWest,lanesWestEast,lanesSouthNorth,lanesNorthSouth);
IIntersection Intersection2 = new Intersection(lanesEastWest, lanesWestEast, lanesSouthNorth, lanesNorthSouth);
List<(IIntersection, IIntersectionRules)> intersections = new List<(IIntersection, IIntersectionRules)>
{(Intersection,new IntersectionRules()),
(Intersection2,new IntersectionRules()),
};
IOutput output = new ConsoleWriteState();
Simulator simulator = new Simulator(intersections,output,2);
simulator.Run();
