int[] array = { 5, 2, 9, 1, 7 };
QuickSort<int>.Sort(array, (x, y) => x.CompareTo(y));
Console.WriteLine(string.Join(", ", array));

string[] array1 = { "apple", "orange", "banana", "pineapple", "kiwi" };
QuickSort<string>.Sort(array1, (x, y) => x.Length.CompareTo(y.Length));
Console.WriteLine(string.Join(", ", array1));


double[] array2 = { 3.5, 1.2, 2.8, 4.9, 2.1 };
QuickSort<double>.Sort(array2, (x, y) => x.CompareTo(y));
Console.WriteLine(string.Join(", ", array2));
