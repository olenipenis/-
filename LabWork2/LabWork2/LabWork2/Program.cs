

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

class Program
{
    static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            (array[i], array[minIndex]) = (array[minIndex], array[i]);
            Debug.WriteLine(string.Join("\t", array));
        }
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
                return false;
        }
        return true;
    }

    void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (array[i] > array[j])
                    (array[i], array[j]) = (array[j], array[i]);
            }
            Debug.WriteLine(string.Join("\t", array));
        }
    }

    static void Main()
    {
        int[][] TestArray = new int[][]
        {
            new int[] { 3, 1, 5, -3, 6, 2 },
            new int[] { 1, 2, 3, 4, 5, 6 },
            new int[] { 6, 5, 4, 3, 2, 1 },
            new int[] { 5, 1, 2, 3, 4, 0 },
            new int[] { 1, 2, 3, 4, 5, 0 }

        };
        for (int i = 0; i < TestArray.Length; i++)
        {
            Console.WriteLine($"Тест {i + 1}:");
            int[] copy = (int[])TestArray[i].Clone();
            Debug.WriteLine($"{string.Join("\t", copy)}");
            SelectionSort(copy);
            Debug.Assert(IsSorted(copy), $"Массив {i + 1} не отсортирован");
            Console.WriteLine($"Результат: {string.Join(" ", copy)}");
            Console.WriteLine($"Корректность: {IsSorted(copy)}\n");
        }
    }
}
