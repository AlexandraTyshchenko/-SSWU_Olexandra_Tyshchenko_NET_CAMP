namespace ConsoleApp1
{
    internal class Intersection : IIntersection
    {
        private List<ILane> _laneEastWest;//ось тут зробити валідування
        private List<ILane> _laneWestEast;
        private List<ILane> _laneSouthNorth;
        private List<ILane> _laneNorthSouth;
        public Intersection()
        {
            _laneEastWest= new List<ILane>();
            _laneWestEast= new List<ILane>();
            _laneNorthSouth= new List<ILane>();
            _laneSouthNorth = new List<ILane>();
        }
        public Intersection(List<ILane> laneEastWest, List<ILane> laneWestEast, 
            List<ILane> laneSouthNorth, List<ILane> laneNorthSouth)
        {
            _laneEastWest = laneEastWest;
            _laneWestEast = laneWestEast;
            _laneSouthNorth = laneSouthNorth;
            _laneNorthSouth = laneNorthSouth;
        }
        

    }
}
