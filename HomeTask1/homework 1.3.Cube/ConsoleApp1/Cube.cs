using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeTask
{
    internal class Cube
    {
        private int _size;
        private int[,,] _arr;
        private readonly Random random;
        public int Size
        {
            get { return _size; }
            set { if(value>1)_size = value; }
        }
        public Cube(int size=2)
        {
            random = new Random();
            _size= size;
            _arr = new int[_size ,_size,_size];
        }
        public void GenerateCube()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    for (int z = 0; z < _size; z++)
                    {
                        _arr[x, y, z] = random.Next(0, 2);
                    }
                }
            }
        }
        public List<Coordinates> FindHoles()
        {
            int check_diagonal = 0;
            int check_horizontal = 0;
            int check_diagonal2 = 0;
            int check_vertical = 0;
            int check_vertical2 = 0;
            var holes = new List<Coordinates>();
            for (int k = 0; k < _size; k++)
            {
                check_diagonal = 0;
                check_diagonal2 = 0;
                for (int i = 0; i < _size; i++)
                {
                    check_horizontal = 0;
                    check_vertical = 0;
                    check_vertical2 = 0;
                    for (int j = 0; j < _size; j++)
                    {
                        if (_arr[i, j, k] == 0)
                            check_vertical++;
                        if (i == j && _arr[i, j, k] == 0)
                            check_diagonal++;
                        if (i == _arr.GetLength(1) - 1 - j && _arr[i, j, k] == 0)
                            check_diagonal2++;
                        if (_arr[j, i, k] == 0)
                            check_horizontal++;
                        
                        if (_arr[i,k, j] == 0)
                            check_vertical2++;

                       
                    }
                    if (check_vertical2 == _size)
                    {
                        holes.Add(new Coordinates(i,k, 0, i,k, _size - 1));
                        
                    }
                    if (check_vertical == _size)
                    {
                        holes.Add(new Coordinates(i, 0, k, i, _size - 1, k));
                    }
                    if (check_horizontal == _size)
                    {
                        holes.Add(new Coordinates(0, i, k, _size - 1, i, k));
                    }
                    if (check_diagonal == _size)
                    {
                        holes.Add(new Coordinates(0, 0, k, _size - 1, _size - 1, k));
                    }
                    if (check_diagonal2 == _size)
                    {
                        holes.Add(new Coordinates(0, _size - 1, k, _size - 1, 0, k));
                    }
                }
            }
            return holes;
        }
        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();

            for (int z = 0; z < _size; z++)
            {
                sb.Append("z = " + z + "\n");
                sb.Append("x");
                for (int i = 0; i < _size; i++)
                {
                    sb.Append("|" + i);
                }
                sb.Append('|' + "\n");
                sb.Append("y|"+"\n");
                for (int y = 0; y < _size; y++)
                {
                    sb.Append(y + "|");
                    for (int x = 0; x < _size; x++)
                    {
                        sb.Append(_arr[x, y, z] + " ");
                    }
                    sb.Append("\n");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }
}
