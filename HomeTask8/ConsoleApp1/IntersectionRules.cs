using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class IntersectionRules: IIntersectionRules
    {

        public void ChangeState(IIntersection intersection)
        {
            Intersection thisintersection = intersection as Intersection;
            ChangeTrafficLightStateOnLane(thisintersection.LaneWestEast);
            ChangeTrafficLightStateOnLane(thisintersection.LaneEastWest);
            ChangeTrafficLightStateOnLane(thisintersection.LaneNorthSouth);
            ChangeTrafficLightStateOnLane(thisintersection.LaneSouthNorth);
        }

        private void ChangeTrafficLightStateOnLane(List<ILane> lanes)
        {
            foreach (var lane in lanes)
            {
                if(lane is LaneWithTrafficLight l)
                {
                    ChangeTrafficLightState(l.Trafficlight);
                }
            }
        }
        private void ChangeTrafficLightState(ITrafficlight trafficLight)
        {
            if (trafficLight.IsRed && trafficLight.IsYellow)
            {
                trafficLight.IsGreen = true;
                trafficLight.IsRed = false;
                trafficLight.IsYellow = false;
                if(trafficLight is TrafficLightWithTurnLamp t)
                {
                    t.TurnGreenLamp = true;
                }
                return;
            }
            if (!trafficLight.IsRed && trafficLight.IsYellow)
            {
                trafficLight.IsRed = true;
                trafficLight.IsYellow = false;
                if (trafficLight is TrafficLightWithTurnLamp t)
                {
                    t.TurnGreenLamp = false;
                }
                return;
            }
            if (trafficLight.IsRed)
            {
                trafficLight.IsYellow = true;//спочатку включається червоне і жовте разом одночасно
                if (trafficLight is TrafficLightWithTurnLamp t)
                {
                    t.TurnGreenLamp = false;
                }
                return;//якщо умова правильна щоб більше умов не перевіряло
            }
            if (trafficLight.IsGreen)
            {
                trafficLight.IsYellow = true;
                trafficLight.IsGreen = false;
                if (trafficLight is TrafficLightWithTurnLamp t)
                {
                    t.TurnGreenLamp = false;
                }
                return;
            }
        }
        public void Reload(IIntersection intersection)
        {
            Intersection thisintersection = intersection as Intersection;
            ReloadOnLane(thisintersection.LaneWestEast);

            ReloadOnLane(thisintersection.LaneEastWest);

            ReloadOnLane(thisintersection.LaneNorthSouth);

            ReloadOnLane(thisintersection.LaneSouthNorth);
            FirstRun(thisintersection.LaneWestEast);
            FirstRun(thisintersection.LaneEastWest);
            FirstRun(thisintersection.LaneNorthSouth);
            FirstRun(thisintersection.LaneSouthNorth);
        }
        private void ReloadOnLane(List<ILane> lanes)
        {
            for(int i = 0; i<lanes.Count; i++)
            {
                if (lanes[i] is LaneWithTrafficLight laneWithTrafficLight)
                {
                    laneWithTrafficLight.Trafficlight.IsGreen = false;
                    laneWithTrafficLight.Trafficlight.IsRed = false;
                    laneWithTrafficLight.Trafficlight.IsYellow = false;
                    if (laneWithTrafficLight.Trafficlight is TrafficLightWithTurnLamp trafficLightWithTurn)
                    {
                        trafficLightWithTurn.TurnGreenLamp = false;

                    }
                }
            }
           
        }
        private void FirstRun(List<ILane> lanes)
        {
            for (int i = 0; i < lanes.Count; i++)
            {
                if (lanes[i] is LaneWithTrafficLight laneWithTrafficLight)
                {
                    if ((lanes[i].LaneDirection.From == DirectionType.South && lanes[i].LaneDirection.To == DirectionType.North)
                   || (lanes[i].LaneDirection.To == DirectionType.South && lanes[i].LaneDirection.From == DirectionType.North)
                   )

                    {
                        laneWithTrafficLight.Trafficlight.IsRed = true;
                        laneWithTrafficLight.Trafficlight.IsGreen = false;//якщо напрямки північ південь чи південь північ перше включення червоне
                        laneWithTrafficLight.Trafficlight.IsYellow = false;
                        if (laneWithTrafficLight.Trafficlight is TrafficLightWithTurnLamp trafficLightWithLamp)
                        {
                            trafficLightWithLamp.TurnGreenLamp = false;
                        }
                    }
                    if ((lanes[i].LaneDirection.From == DirectionType.East && lanes[i].LaneDirection.To == DirectionType.West) ||

              (lanes[i].LaneDirection.To == DirectionType.East && lanes[i].LaneDirection.From == DirectionType.West))
                    {
                        laneWithTrafficLight.Trafficlight.IsRed = false;
                        laneWithTrafficLight.Trafficlight.IsGreen = true;
                        laneWithTrafficLight.Trafficlight.IsYellow = false;
                        if (laneWithTrafficLight.Trafficlight is TrafficLightWithTurnLamp trafficLightWithLamp)
                        {
                            trafficLightWithLamp.TurnGreenLamp = true;
                        }

                    }

                }

            }
        }

   
    }
}