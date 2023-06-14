using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    using System;
    using System.IO;
    using System.Linq;

    public class MergeSort
    {
        public static void SortFromFile(string inputFile)
        {
            int[] array = ReadArrayFromFile(inputFile);

            Sort(array);

            WriteArrayToFile(array, inputFile);
        }

        public static void Sort(int[] array)
        {
            int[] tempArray = new int[array.Length];
            Sort(array, tempArray, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int[] tempArray, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                Sort(array, tempArray, left, middle);
                Sort(array, tempArray, middle + 1, right);
                Merge(array, tempArray, left, middle, right);
            }
        }

        private static void Merge(int[] array, int[] tempArray, int left, int middle, int right)
        {
            int leftStart = left;
            int leftEnd = middle;
            int rightStart = middle + 1;
            int rightEnd = right;
            int tempIndex = left;

            while (leftStart <= leftEnd && rightStart <= rightEnd)
            {
                if (array[leftStart] <= array[rightStart])
                {
                    tempArray[tempIndex] = array[leftStart];
                    leftStart++;
                }
                else
                {
                    tempArray[tempIndex] = array[rightStart];
                    rightStart++;
                }
                tempIndex++;
            }

            while (leftStart <= leftEnd)
            {
                tempArray[tempIndex] = array[leftStart];
                leftStart++;
                tempIndex++;
            }

            while (rightStart <= rightEnd)
            {
                tempArray[tempIndex] = array[rightStart];
                rightStart++;
                tempIndex++;
            }

            for (int i = left; i <= right; i++)
            {
                array[i] = tempArray[i];
            }
        }

        private static int[] ReadArrayFromFile(string inputFile)
        {
            string[] lines = File.ReadAllLines(inputFile);
            return lines.Select(int.Parse).ToArray();
        }

        private static void WriteArrayToFile(int[] array, string outputFile)
        {
            string[] lines = array.Select(x => x.ToString()).ToArray();
            File.WriteAllLines(outputFile, lines);
        }
    }
}