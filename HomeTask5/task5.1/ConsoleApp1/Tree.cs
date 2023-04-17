using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Tree
    {
       
        private int _x=0;
        private int _y=0;
        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }
        public Tree(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Tree(Tree tree)
        {
            _x= tree._x;
            _y= tree._y;
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Tree other = (Tree)obj;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}
