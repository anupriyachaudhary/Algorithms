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

        public void Rotate(int[] arr, int start, int end, int d)
        {
            if(d < 0 || (end - start) < 0)
            {
                throw new ArgumentException();
            }

            if(start == end)
            {
                return;
            }

            if(d == 0)
            {
                return;
            }

            ArrayUtils.Reverse(arr, start, end);
            ArrayUtils.Reverse(arr, start, start + d - 1);
            ArrayUtils.Reverse(arr, start + d, end);
        }

        //Search an element in a sorted and rotated array
        public int SearchRotatedArray(int[] arr, int elem)
        {
            //get pivot
            int pivot = GetPivot(arr, 0, arr.Length-1);
            //search left array of pivot using binary search
            if (arr[pivot] == elem)
                return pivot;
            if (arr[0] < elem)
                return ArrayUtils.BinarySearch(arr, 0, pivot - 1, elem);
            //search right array of pivot using binary search
            return ArrayUtils.BinarySearch(arr, pivot + 1, arr.Length - 1, elem);
        }

        //Given an array that is sorted and then rotated around an unknown point. Find if array has a pair with given sum ‘x’. 
        //It may be assumed that all elements in array are distinct.
        public bool FindSumPair(int[] arr, int sum)
        {
            int arrLength = arr.Length;
            //get pivot
            int pivot = GetPivot(arr, 0, arrLength-1);

            int rightPointer = (pivot + 1) % arrLength;
            int leftPointer = pivot;

            return FindSumPair(arr, leftPointer, rightPointer, sum);
            
        }

        private bool FindSumPair(int[] arr, int leftPointer, int rightPointer, int sum)
        {
            int arrLength = arr.Length;

            if(leftPointer == rightPointer)
                return false;

            if (arr[rightPointer] + arr[leftPointer] == sum)
                return true;
    
            else if (arr[rightPointer] + arr[leftPointer] > sum)
            {
                if (leftPointer > 0)
                    leftPointer = (leftPointer - 1);
                else
                    leftPointer = arrLength - 1;
            }

            else
            {
                if (rightPointer < arrLength - 1)
                    rightPointer = rightPointer + 1;
                else
                    rightPointer = 0;
            }   
            return FindSumPair(arr, leftPointer, rightPointer, sum);
        }

        public int GetPivot(int[] arr, int left, int right)
        {
            if (left > right)
                return -1;
            if (left == right)
                return left;
            
            var mid = (left + right)/2;
            if (mid < right && arr[mid] > arr[mid+1])
                return mid;
            if (mid > left && arr[mid] < arr[mid-1])
                return mid-1;
            if (arr[left] > arr[mid])
                return GetPivot(arr, left, mid -1);

            return GetPivot(arr, mid + 1, right);
        }
    }
}
