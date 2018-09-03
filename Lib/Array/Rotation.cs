using System;
using Lib.Utils;

namespace Lib.Array
{
    public class Rotation
    {
        public void Rotate(int[] arr, int d)
        {
            // check for invalid input
            if(d < 0 || arr.Length <= 0)
            {
                throw new ArgumentException();
            }

            if(arr.Length == 1)
            {
                return;
            }

            if(d >= arr.Length)
            {
                d = d % arr.Length;
            }

            if(d == 0)
            {
                return;
            }

            ArrayUtils.Reverse(arr);
            ArrayUtils.Reverse(arr, 0, arr.Length - d - 1);
            ArrayUtils.Reverse(arr, arr.Length - d, arr.Length - 1);
        }

        public void SearchRotatedArray(int[] arr, int elem)
        {
            //get pivot
            int pivot = ArrayUtils.GetPivot(int[] arr, int start, int end)
            //search left array of pivot using binary search
            return ArrayUtils.BinarySearch(arr, start, pivot, elem)
            //search right array of pivot using binary search
            return ArrayUtils.BinarySearch(arr, pivot + 1, end, elem)
        }
    }
}
