using System.Text;

namespace ConsoleApp1
{
    internal class Intersection : IIntersection//можна скомпонувати пререхрестя з різними напрямками,
                                               //їх може бути лише 3 наприклад як в перехресті у формі букви т
                                               //або тільки з 1 полосою тоді реалізувати інтерфейс і лишити не ліст 
                                               //смуг а просто по 1 смузі на кожний напрямок
    {    
        public List<ILane> LaneEastWest { get;  }
        public List<ILane> LaneWestEast { get;  }
        public List<ILane> LaneSouthNorth { get;  }
        public List<ILane> LaneNorthSouth { get;  }
       
        public Intersection()
        {
            LaneEastWest = new List<ILane>();
            LaneWestEast = new List<ILane>();
            LaneNorthSouth = new List<ILane>();
            LaneSouthNorth = new List<ILane>();
        }
       public Intersection(List<ILane> laneEastWest, List<ILane> laneWestEast,
            List<ILane> laneSouthNorth, List<ILane> laneNorthSouth)
        {
            Validator.CheckSouthNorth(laneSouthNorth);
            Validator.CheckNorthSouth(laneNorthSouth);
            Validator.CheckEastWest(laneEastWest);
            Validator.CheckSouthNorth(laneSouthNorth);
            LaneEastWest = new List<ILane>();
            LaneWestEast = new List<ILane>();
            LaneSouthNorth = new List<ILane>();
            LaneNorthSouth = new List<ILane>();
            foreach (var lane in laneEastWest)
            {
                LaneEastWest.Add((ILane)lane.Clone());
            }
            foreach (var lane in laneWestEast)
            {
                LaneWestEast.Add((ILane)lane.Clone());
            }
            foreach (var lane in laneSouthNorth)
            {
                LaneSouthNorth.Add((ILane)lane.Clone());
            }
            foreach (var lane in laneNorthSouth)
            {
                LaneNorthSouth.Add((ILane)lane.Clone());
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.AppendLine("------------------------");
            stringBuilder.AppendLine("схід захід");
            int id = 1;
            foreach(var lane in LaneEastWest)
            {
                stringBuilder.AppendLine(Convert.ToString(id++)+"смуга");
                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("захід схід");
            id = 1;
            foreach (var lane in LaneWestEast)
            {
                stringBuilder.AppendLine(Convert.ToString(id++) + "смуга");

                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("північ південь");
            id = 1;
            foreach (var lane in LaneNorthSouth)
            {
                stringBuilder.AppendLine(Convert.ToString(id++) + "смуга");

                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("південь північ");
            id = 1;
            foreach (var lane in LaneSouthNorth)
            {
                stringBuilder.AppendLine(Convert.ToString(id++) + "смуга");

                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine("------------------------");
            return stringBuilder.ToString();
        }
    }
}
