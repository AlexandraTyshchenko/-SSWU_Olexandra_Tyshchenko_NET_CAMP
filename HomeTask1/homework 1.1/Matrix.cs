using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace homework_1._1
{
    enum direction
    {
        left,
        right
    }
    internal class Matrix
    {
        private int[,] _matrix;
        private int _m;
        private int _n;
        public Matrix(int m=3,int n = 3)
        {
            _matrix = new int[_m=m,_n=n];
            GenerateСounterclockwise();//за замовчуванням буде проти годинникової стрілки
        }
        public void GenerateSpiral(direction dir = direction.left)
        {
            if (dir == direction.left)
                GenerateСounterclockwise();
            else
                Generateclockwise();
        }
        private void Generateclockwise()
        {
            Array.Clear(_matrix, 0, _matrix.Length);
            int value = 1;
            int index = 0;
            int count = 0;
            int i = 0;
            while (_matrix[index, i] == 0)
            {

                _matrix[index, i] = value++;
                if (i == _matrix.GetLength(1) - 1 - count)
                {
                    index = i;
                    for (int j = 1 + count; j < _matrix.GetLength(0) - count; j++)
                        _matrix[j, index] = value++;

                    index = _matrix.GetLength(0) - 1 - count;
                    for (int k = _matrix.GetLength(1) - 2 - count; k >= 0 + count; k--)
                        _matrix[index, k] = value++;
                    index = 0 + count;

                    for (int l = _matrix.GetLength(0) - 2 - count; l > 0 + count; l--)
                        _matrix[l, index] = value++;

                    i = count;
                    index = ++count;
                }

                i++;
            }
        }
        private void GenerateСounterclockwise()
        {
            Array.Clear(_matrix, 0, _matrix.Length);
            int value = 1;
            int index = 0;
            int count = 0;
            int i = 0;
            while (_matrix[i, index] == 0)
            {

                _matrix[i, index] = value++;
                if (i == _matrix.GetLength(0) - 1 - count)
                {
                    index = i;
                    for (int j = 1 + count; j < _matrix.GetLength(1) - count; j++)
                        _matrix[index, j] = value++;

                    index = _matrix.GetLength(1) - 1 - count;
                    for (int k = _matrix.GetLength(0) - 2 - count; k >= 0 + count; k--)
                        _matrix[k, index] = value++;
                    index = 0 + count;

                    for (int l = _matrix.GetLength(1) - 2 - count; l > 0 + count; l--)
                        _matrix[index, l] = value++;

                    i = count;
                    index = ++count;
                }

                i++;
            }
        }
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < _matrix.GetLength(1); ++j)
                {
                    sb.Append(string.Format("{0," + 4 + "}", _matrix[i, j]));
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
        private int returnvaluebyindex(direction dir,int i,int j)//для скорочення коду приватний метод для перевірки 
        {
            if(dir== direction.left)//проти стрілкою
            {
                return _matrix[i,j];
            }
            else
            {
               return  _matrix[j,i];
            }
        }
       
}
}
