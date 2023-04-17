using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Garden
    {
        private double _length=0;
        private Tree[,] _matrix;
        private List<Tree> _treeList;
        public double Length
        { get { return _length; }}
        public Garden(List<Tree> trees)
        {
            _treeList = new List<Tree>(trees);
            GenerateMatrix();
            CalculateLength();
        }
        private void GenerateMatrix()
        {
            _matrix = new Tree[_treeList.Max(l => l.Y + 1), _treeList.Max(l => l.X + 1)];//створюю матрицю з розміром максимальних значень x та y
            foreach (var el in _treeList)
            {
                _matrix[el.Y, el.X] = el;//заповнюю матрицю по координатам матриці, а значення не заповнені будуть мати значення null
            }
        }
        public void AddTree(Tree tree)
        {
            if(tree.X<=_matrix.GetLength(0) && tree.Y<=_matrix.GetLength(1))//якщо в межах поточних координат
            {
                if (_matrix[tree.X, tree.Y] == null)
                {
                    _matrix[tree.X, tree.Y] = tree;
                }
                else//якщо дерево з такими координатами вже існує вивести помилку
                {
                    throw new Exception("tree exists");
                }
            }
            else
            {
                _treeList.Add(tree);
                GenerateMatrix();
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] == null)
                    {
                        stringBuilder.Append("||||");//місця не засадженні деревами(травичка)
                    }
                    else
                    {
                        stringBuilder.Append(_matrix[i, j] + " ");

                    }
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }
        private void CalculateLength()
        {
            List<Tree> left = new List<Tree>();
            List<Tree> right = new List<Tree>();
            Tree max = null;
            Tree min = null;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] == null)//буде ігнорувати нульові значення
                        continue;
                    if (max == null)//поточне значення не нуль,
                                    //то буде перевірка цієї умови. Я
                                    //кщо макс не був заповнений то він
                                    //присвоюється поточному значенню
                                    //не виносила за межі циклу по j, тому що поточний елемент може дорівнювати null 
                                    //і макс присвоїться нулю, після чого не зможу знайти максимальне значення
                    {
                        max = new Tree(_matrix[i, j]);
                    }
                    if (min == null)
                    {
                        min = new Tree(_matrix[i, j]);
                    }
                    if (max.X < _matrix[i, j].X)//знаходжу максимальне
                    {
                        max = new Tree(_matrix[i, j].X, _matrix[i, j].Y);
                    }
                    if (min.X > _matrix[i, j].X)//знаходжу мінімальне
                    {
                        min = new Tree(_matrix[i, j].X, _matrix[i, j].Y);
                    }
                }
                if (min != null)
                    left.Add(min);//список елементів зліва - всі мінімальні значення по іксу, тобто краї фігури
                if (max != null)
                    right.Add(max);//список елементів справа - всі максимальні значення по іксу,тобто краї фігури
                min = null;
                max = null;
            }
            for (int i = 1; i < right.Count - 1; i++)
            {
                if (right[i].X < right[i - 1].X && right[i].X < right[i + 1].X)
                {
                    right.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 1; i < left.Count - 1; i++)
            {
                if (left[i].X > left[i - 1].X && left[i].X > left[i + 1].X)
                {
                    left.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 1; i < right.Count; i++)//довжина огорожі справа
            {
                double distance = Math.Sqrt(Math.Pow(right[i].X - right[i - 1].X, 2) + Math.Pow(right[i].Y - right[i - 1].Y, 2));
                _length += distance;
            }
            for (int i = 1; i < left.Count; i++)//довжина огорожі здіва
            {
                double distance = Math.Sqrt(Math.Pow(left[i].X - left[i - 1].X, 2) + Math.Pow(left[i].Y - left[i - 1].Y, 2));
                _length += distance;
            }
            if (!right.First().Equals(left.First()))//якщо перші координати не співпадають, об'єднати ще відстані від першої верхньої точки зліва і першої верхньої точки зправа
            {
                double distance = Math.Sqrt(Math.Pow(left[0].X - right[0].X, 2) + Math.Pow(left[0].Y - right[0].Y, 2));
                _length += distance;
            }
            if (!right.Last().Equals(left.Last()))//так само з нижніми координатами, якщо точки співпадають, то шукати відстань між точками не потрібно
            {
                double distance = Math.Sqrt(Math.Pow(left.Last().X - right.Last().X, 2) + Math.Pow(left.Last().Y - right.Last().Y, 2));
                _length += distance;
            }
            left.Clear();
            right.Clear();
        }
        public static bool operator ==(Garden garden1, Garden garden2)
        {
            if (garden1.Length==garden2.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(Garden garden1, Garden garden2)
        {
            return garden1.Length >= garden2.Length;
        }
        public static bool operator >(Garden garden1, Garden garden2)
        {
            return garden1.Length > garden2.Length;
        }
        public static bool operator <(Garden garden1, Garden garden2)
        {
            return garden1.Length < garden2.Length;
        }
        public static bool operator <=(Garden garden1, Garden garden2)
        {
            return garden1.Length <= garden2.Length;
        }
        public static bool operator !=(Garden garden1, Garden garden2)
        {
            return !(garden1 == garden2);
        }
    }
}
