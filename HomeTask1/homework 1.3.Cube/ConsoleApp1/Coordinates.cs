using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeTask
{
    internal class Coordinates
    {
        private int x1;
        private int y1;
        private int z1;
        private int x2;
        private int y2;
        private int z2;
        public Coordinates(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.z1 = z1;
            this.x2 = x2;
            this.y2 = y2;
            this.z2 = z2;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"({x1},{y1},{z1})({x2},{y2},{z2})");
            return sb.ToString();
        }
    }
}
