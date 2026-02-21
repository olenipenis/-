using System;
using System.Diagnostics;
public class Program
{
    //public static int BinarySearch(int[] array, int target)
    //{
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        if (array[i] == target)
    //            return i;
    //    }
    //    return -1;
    //}

    //static void Main()
    //{
    //    int[] array = { 3, 7, 1, 9, 4, 9, 2, 6 };

    //    Debug.Assert(BinarySearch(array, 9) == 3);
    //    Debug.Assert(BinarySearch(array, 3) == 0);
    //    Debug.Assert(BinarySearch(array, 6) == 6);
    //    Debug.Assert(BinarySearch(array, 5) == -1);
    //    Console.WriteLine("Все подошло");
    //}

    public static int BinarySearch(int[] array, int target)
    {
        int LefSide = 0;
        int RightSide = array.Length - 1;
        while (LefSide <= RightSide)
        {
            int MidlleElement = (LefSide + RightSide) / 2;
            if (array[MidlleElement] < target)
                LefSide = MidlleElement + 1;
            else if (array[MidlleElement] == target)
                return MidlleElement;
            else
                RightSide = MidlleElement - 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                    return i;
            }
        }
        return -1;
    }


    static void Main()
    {
        int[] array = { 3, 7, 1, 9, 4, 9, 2, 6 };
        Debug.Assert(BinarySearch(array, 9) == 3);
        Debug.Assert(BinarySearch(array, 3) == 0);
        Debug.Assert(BinarySearch(array, 6) == 6);
        Debug.Assert(BinarySearch(array, 5) == -1);
        Console.WriteLine("Все подошло");
    }
}
