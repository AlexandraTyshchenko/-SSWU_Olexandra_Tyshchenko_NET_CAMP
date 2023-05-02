using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MatrixGenerator<T> : IEnumerable
    {
        private T[,] _matrix;
        private IEnumerator _enumerator;
        public MatrixGenerator(T[,] matrix)
        {
            _matrix = new T[matrix.GetLength(0), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }
            // Не бачу потребу у створенні окремого класу.
            _enumerator = new MatrixEnumerator<T>(_matrix);//передаю посилання на масив щоб його не створювати і не переписувати
        }     
        public IEnumerator GetEnumerator()
        {
            return _enumerator;
        }
    }
}
