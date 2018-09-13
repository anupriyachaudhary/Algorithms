using System;
using Lib.Utils;
using Lib.Common;

namespace Lib.Array
{
    public class OrderStatistics
    {
        // Complexity average = O(kn) and worst case = O(n2)
        public int KthSmallestElement(int[] arr, int k)
        {
            return KthSmallestElement(arr, 0, arr.Length - 1, k);
        }

        private int KthSmallestElement(int[] arr, int start, int end, int k)
        {
            int pivotIndex = Partition(arr, start, end);
            
            if (pivotIndex == k - 1)
            {
                return arr[pivotIndex];
            }
            else if (pivotIndex > k - 1)
            {
                return KthSmallestElement(arr, start, pivotIndex - 1, k);
            }
            else
            {
                return KthSmallestElement(arr, pivotIndex + 1, end, k);
            }
        }

        private int Partition(int[] arr, int start, int end)
        {
            int pivot = end;
            int leftPointer = start;
            int rightPointer = pivot-1;

            while(leftPointer != rightPointer)
            {
                if(arr[leftPointer] < arr[pivot])
                {
                    ++leftPointer;
                }
                else
                {
                    ArrayUtils.Swap(arr, leftPointer, rightPointer);
                    --rightPointer;
                }
            }

            if(arr[leftPointer] > arr[pivot])
            {
                ArrayUtils.Swap(arr, pivot, leftPointer);
                return leftPointer;
            }
            else
            {
                return pivot;
            } 
        }

        public int KthSmallestElementIn2DArray(int[,] arr, int k)
        {
            MinHeap minHeap;
            minHeap = new MinHeap(arr.GetLength(0));

            for(int index = 0; index < arr.GetLength(0); index++)
            {
                minHeap.insertKey(arr[0, index]);
            }

            int count = 1;
            for (int column = 0; column < arr.GetLength(0) && count < k; column++)
            {
                for (int row = 1; row < arr.GetLength(1) && count < k; row++)
                {
                    minHeap.heapArr[0] = arr[row, column];
                    count++;
                    minHeap.MinHeapify(0);
                }
            }

            return minHeap.heapArr[0];
        }
    }
}
