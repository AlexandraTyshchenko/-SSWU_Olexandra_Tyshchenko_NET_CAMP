using System.Text;

namespace ConsoleApp1
{
    internal class Intersection : IIntersection//можна скомпонувати пререхрестя з різними напрямками,
                                               //їх може бути лише 3 наприклад як в перехресті у формі букви т
                                               //або тільки з 1 полосою тоді реалізувати інтерфейс і лишити не ліст 
                                               //смуг а просто по 1 смузі на кожний напрямок
    {
        public List<ILane> LaneEastWest { get; set; }//ось тут зробити валідування
        public List<ILane> LaneWestEast { get; set; }
        public List<ILane> LaneSouthNorth { get; set; }
        public List<ILane> LaneNorthSouth { get; set; }
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
            LaneEastWest = laneEastWest;
            LaneWestEast = laneWestEast;
            LaneSouthNorth = laneSouthNorth;
            LaneNorthSouth = laneNorthSouth;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.AppendLine("схід захід");
            foreach(var lane in LaneEastWest)
            {
                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine("захід схід");
            foreach (var lane in LaneWestEast)
            {
                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine("північ південь");
            foreach (var lane in LaneNorthSouth)
            {
                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine("південь північ");
            foreach (var lane in LaneSouthNorth)
            {
                stringBuilder.AppendLine(lane.ToString());
            }
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }
}
