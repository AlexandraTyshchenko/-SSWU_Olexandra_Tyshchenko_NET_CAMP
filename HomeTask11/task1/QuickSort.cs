using System;

public class QuickSort<T>
{
    public static void Sort(T[] array, Func<T, T, int> compare)
    {
        Sort(array, 0, array.Length - 1, compare);
    }

    private static void Sort(T[] array, int left, int right, Func<T, T, int> compare)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right, compare);
            Sort(array, left, pivotIndex - 1, compare);
            Sort(array, pivotIndex + 1, right, compare);
        }
    }

    private static int Partition(T[] array, int left, int right, Func<T, T, int> compare)
    {
        T pivot = array[left];
        int i = left + 1;

        for (int j = left + 1; j <= right; j++)
        {
            if (compare(array[j], pivot) < 0)
            {
                Swap(array, i, j);
                i++;
            }
        }

        Swap(array, left, i - 1);
        return i - 1;
    }

    private static void Swap(T[] array, int index1, int index2)
    {
        T temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
