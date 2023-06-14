public class MergeSort
{
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
}
