using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class NumbersGenerator
    {
        public static void GenerateRandomNumbers(string fileName, int count)
        {
            Random random = new Random();
            using (var writer = new System.IO.StreamWriter(fileName))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(1, 1000);
                    writer.WriteLine(number);
                }
            }
        }
    }
}
