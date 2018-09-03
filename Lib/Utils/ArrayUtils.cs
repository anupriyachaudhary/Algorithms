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

        public static void GetPivot(int[] arr, int left, int right)
        {
            if (left > right)
                return -1;
            if (left = right)
                return left;
            
            var mid = (left + right)/2
            if (arr[mid] > arr[mid+1])
                return mid;
            if (arr[mid] < arr[mid-1])
                return mid-1;
            else
                return GetPivot(arr, left, mid)

            return GetPivot(arr, mid + 1, right )
        }

        public static void BinarySearch(int[] arr, int left, int right, int elem)
        {
            if (right >= left) 
            { 
                int mid = left + (right - left)/2; 

                if (arr[mid] == elem)   
                    return mid; 
  
                if (arr[mid] > elem)  
                    return binarySearch(arr, left, mid-1, elem); 
    
                return binarySearch(arr, mid+1, right, elem); 
            } 
  
            return -1; 
        }
    }
}
