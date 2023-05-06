using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MatrixEnumerator<T> : IEnumerator
    {
        private readonly T[,] _matrix;
        private int i, j;
        bool down = false;
        bool right = false;
        bool upDiagonal=false;
        bool downDiagonal = false;
        bool changedirection= false;
        public object Current => _matrix[i, j];
        public MatrixEnumerator(T[,] matrix)
        {
            _matrix = matrix;
        }
        public bool MoveNext()
        {
            if (down == false && right == false && upDiagonal == false && downDiagonal == false)//якщо ще не було напрямку руху
            {
                down = true;
                return true&&  i< _matrix.GetLength(0) && j< _matrix.GetLength(0);
            }
            if (down == true)
            {
                
                i++;//напрямок вниз
                if (changedirection)
                    downDiagonal = true;//після руху вниз до досягнення першої діагоналі - напрямок вверх по діагоналі, після нього перевірка на зміну напрямку, тоді вниз по діагоналі
                else
                    upDiagonal = true;
                down = false;


                return true && i < _matrix.GetLength(0) && j < _matrix.GetLength(0);//повернути тру з перевіркою чи i i j за межами матриці, якщо так повернути фолс
            }
            if (upDiagonal == true)
            {
                if (i == 1 || j==_matrix.GetLength(0)-2)//якщо досягнули країв матриці
                {
                   if(i==1 && j== _matrix.GetLength(0) - 2)
                    {
                        down = true;
                        changedirection= true;//якщо це побічна діагональ - змінити напрямок
                    }
                    else
                    {
                        if(changedirection)//якщо напрямок змінений(може відбутися у функції downdiagonal), nj то змінити напрямок 
                            down= true;
                        else
                            right = true;
                    }
                        
                    upDiagonal = false;
                }
                i--;
                j++;
                return true && i < _matrix.GetLength(0) && j < _matrix.GetLength(0);
            }
            if (right == true)
            {
                if(changedirection)
                    upDiagonal= true;
                else
                    downDiagonal = true;
                right = false;
         
                j++;
                return true && i < _matrix.GetLength(0) && j < _matrix.GetLength(0);
            }
            if (downDiagonal == true)
            {
                if (j == 1|| i==_matrix.GetLength(0)-2)
                {
                    if(j == 1 && i == _matrix.GetLength(0) - 2)
                    {
                       right= true;
                        changedirection = true;
                    }
                    if (changedirection)
                        right= true;
                    else
                        down = true; 
                    downDiagonal = false;
                }
                i++;
                j--;

                return true && i < _matrix.GetLength(0) && j < _matrix.GetLength(0);
            }
            return false;
        }
        public void Reset()
        {
            i = 0;
            j = 0;
            down = false;
            right = false;
            upDiagonal = false;
            downDiagonal = false;
            changedirection = false;
        }
    }

}