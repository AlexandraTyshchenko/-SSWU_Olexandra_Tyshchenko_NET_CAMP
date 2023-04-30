using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Arraycreator
    {
        public static int[] CreateArray(params int[][] arrays)
        {
            return SortArrays(arrays).ToArray();
        }
        public static IEnumerable<string> GetUniqueWords(string text)
        {

            List<string> words = new List<string>(text.Split(' ', '.', ',', ';', ':', '!', '?', '\n', '\r', '\t'));
            foreach (var word in words)
            {
                if (words.Count(w => w.ToLower() == word.ToLower()) == 1)//якщо слово зустрічається раз в тексті
                {
                    yield return word;
                }
            }

        }
        private static IEnumerable<int> SortArrays(params int[][] arrays)
        {
            List<int> list = new List<int>();

            foreach (int[] array in arrays)
            {

                list = list.Concat(array).ToList();
            }
            list.Sort();
            foreach (var l in list)
            {
                yield return l;
            }
        }
    }
}
