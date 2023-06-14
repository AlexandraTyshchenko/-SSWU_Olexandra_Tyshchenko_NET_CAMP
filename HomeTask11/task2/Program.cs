using System;
using task2;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "input.txt";

        // Заповнення файлу з випадковими числами
        NumbersGenerator.GenerateRandomNumbers(inputFile, 100);

        // Сортування чисел з файлу
        MergeSort.SortFromFile(inputFile);

        // Виведення відсортованих чисел на консоль
        Console.WriteLine("Sorted numbers:");
        PrintNumbersFromFile(inputFile);
    }
    static void PrintNumbersFromFile(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
