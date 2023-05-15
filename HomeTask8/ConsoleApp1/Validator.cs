using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Validator
    {
        public static void CheckEastWest(List<ILane> LaneEastWest)
        {
            var result = LaneEastWest.FirstOrDefault(x=>x.LaneDirection.From!=DirectionType.East && x.LaneDirection.To != DirectionType.West);
            if (result!=null)
            {
                throw new Exception("В списку смуги з неоднаковим напрямком");
            }
         
        }
        public static void CheckWestEast(List<ILane> LaneWestEast)
        {
            var result = LaneWestEast.FirstOrDefault(x => x.LaneDirection.From != DirectionType.West && x.LaneDirection.To != DirectionType.East);
            if (result != null)
            {
                throw new Exception("В списку смуги з неоднаковим напрямком");
            }

        }
        public static void CheckNorthSouth(List<ILane> LaneNorthSouth)
        {
            var result = LaneNorthSouth.FirstOrDefault(x => x.LaneDirection.From != DirectionType.North && x.LaneDirection.To != DirectionType.South);
            if (result != null)
            {
                throw new Exception("В списку смуги з неоднаковим напрямком");
            }

        }
        public static void CheckSouthNorth(List<ILane> SouthNorth)
        {
            var result = SouthNorth.FirstOrDefault(x => x.LaneDirection.From != DirectionType.South && x.LaneDirection.To != DirectionType.North);
            if (result != null)
            {
                throw new Exception("В списку смуги з неоднаковим напрямком");
            }

        }
        
    }
}
