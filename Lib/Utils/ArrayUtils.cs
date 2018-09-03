using System;

namespace Lib.Utils
{
    public static class ArrayUtils
    {
        public static void Reverse(int[] arr)
        {
            Reverse(arr, 0, arr.Length - 1);
        }

        public static void Reverse(int[] arr, int start, int end)
        {
            if(start < 0 || end >= arr.Length)
            {
                throw new ArgumentException();
            }

            for (int i = start, j = end; i < j; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
}
