
using ConsoleApp1;
using System.Collections;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr1 = { 3, 1, 1 };
        int[] arr2 = { 2, 5, 1 };
        int[] arr3 = { 9, 7, 1 };

        var result = Arraycreator.CreateArray(arr1, arr2, arr3);

        foreach (int item in result)
        {
            Console.WriteLine(item);
        }
        string text = "hello hello my world";
        IEnumerable objects= Arraycreator.GetUniqueWords(text);
        foreach (var item in objects) { 
            Console.WriteLine(item);
        }

    }
}
