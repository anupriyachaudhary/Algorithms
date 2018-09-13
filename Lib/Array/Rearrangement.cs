using System;
using System.Collections.Generic;
using Lib.Utils;


namespace Lib.Array
{
    public class Rearrangement
    {
        private Rotation rotation;
        public Rearrangement()
        {
            rotation = new Rotation();
        }

        // Given an array of elements of length N, ranging from 1 to N. All elements may not be present in the array. 
        // If element is not present then there will be -1 present in the array. Rearrange the array such that A[i] = i 
        //and if i is not present, display -1 at that place.
        public void Rearrange(int[] arr)
        {
            // check for invalid input
            if(arr.Length <= 0)
            {
                throw new ArgumentException();
            }

            if(arr.Length == 1)
            {
                return;
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == -1)
                {
                    continue;
                }
                else if (arr[i] == i)
                {
                    continue;
                }
                else
                {
                    // swap element(e) at index i with element at index e
                    ArrayUtils.Swap(arr, arr[i], i);

                    // swap again & again if the element at index i is still not at its right position
                    // No need to swap if element at index i is -1 or if a[i] = i
                    while(arr[i] != -1 && arr[i] != i)
                    {
                        ArrayUtils.Swap(arr, arr[i], i);
                    }
                }
            }
        }

        //Given an array of n elements. Our task is to write a program to rearrange the array such that elements
        // at even positions are greater than all elements before it and elements at odd positions are less than 
        //all elements before it.
        public void PosNegRearrange(int[] arr)
        {
            // check for invalid input
            if(arr.Length <= 0)
            {
                throw new ArgumentException();
            }

            if(arr.Length == 1)
            {
                return;
            }

            // Partition array with last element as pivot. All positive numbers on left and negative numbers on right
            int pivotIndex = PartitionPosNeg(arr);
            
            // pivotIndex is negative when there are no positive numbers in array
            // if pivot index is (arr.Length-1) there are no negative numbers
            if(pivotIndex == -1 || pivotIndex == arr.Length - 1)
            {
                return;
            }

            // Place positive and negative numbers in alternate positions using posPointer and negPointer
            int  posPointer = 0;
            int negPointer = pivotIndex + 1;
            
            while(negPointer < arr.Length)
            {
                ArrayUtils.Swap(arr, ++posPointer, negPointer);
                ++negPointer;
                ++posPointer;
            }
        }

        private int PartitionPosNeg(int[] arr)
        {
            if(arr.Length == 2)
            {
                if(arr[0] < 0 && arr[1] > 0)
                {
                    ArrayUtils.Swap(arr, 0, 1);
                    return 0;
                }

                else if (arr[0] < 0 && arr[1] < 0)
                {
                    return -1;
                }

                else
                    return 0;
            }

            int pivot = arr.Length - 1;
            int leftPointer = 0;
            int rightPointer = pivot-1;

            while(leftPointer != rightPointer)
            {
                if(arr[leftPointer] >= 0)
                {
                    ++leftPointer;
                }
                else
                {
                    ArrayUtils.Swap(arr, leftPointer, rightPointer);
                    --rightPointer;
                }
            }

            if(arr[leftPointer] > 0 && arr[pivot] > 0)
            {
                ArrayUtils.Swap(arr, pivot, leftPointer + 1);
                return leftPointer + 1;
            }
            else if(arr[leftPointer] < 0 && arr[pivot] > 0)
            {
                ArrayUtils.Swap(arr, pivot, leftPointer);
                return leftPointer;
            }
            else if(arr[leftPointer] < 0 && arr[pivot] < 0)
            {
                return leftPointer - 1;
            }
            else
            {
                return leftPointer;
            }
        }

        // rearrange array in alternating positive and negative items with O(1) extra space, maintaining the order of appearance
        public void PosNegInOrderRearrange(int[] arr)
        {
            // check for invalid input
            if(arr.Length <= 0)
            {
                throw new ArgumentException();
            }

            if(arr.Length == 1)
            {
                return;
            }

            for (int index = 0; index < arr.Length; index++)
            {
                int tempPointer = 0;
                if (index % 2 == 0)
                {
                    if (arr[index] < 0)
                    {
                        continue;
                    }
                    else
                    {
                        tempPointer = index + 1;
                        while(tempPointer < arr.Length && arr[tempPointer] >= 0)
                        {
                            ++tempPointer;
                        }

                        if (tempPointer != arr.Length)
                        {
                            rotation.Rotate(arr, index, tempPointer, 1);
                        }
                    }
                }

                else
                {
                    if (arr[index] >= 0)
                    {
                        continue;
                    }
                    else
                    {
                        tempPointer = index + 1;
                        while(tempPointer < arr.Length && arr[tempPointer] < 0)
                        {
                            ++tempPointer;
                        }

                        if (tempPointer != arr.Length)
                        {
                            rotation.Rotate(arr, index, tempPointer, 1);
                        }
                    }
                }    
            }   
        }

        public void ZerosRearrange(int[] arr)
        {
            // check for invalid input
            if(arr.Length <= 0)
            {
                throw new ArgumentException();
            }

            if(arr.Length == 1)
            {
                return;
            }

            bool isZeroEncountered = false;
            int lastNonZeroPointer = 0;

            for(int index = 0; index < arr.Length; index++)
            {
                if(arr[index] != 0)
                {
                    if(isZeroEncountered)
                    {
                        arr[lastNonZeroPointer] = arr[index];
                        arr[index] = 0;
                    }
                    ++lastNonZeroPointer;
                }

                else
                {
                    isZeroEncountered = true;
                }
            }
        }

        //Given an array of n positive integers and a number k. Find the minimum swaps required to bring all elements
        //less than or equal to k together
        // Complexity = O(n) + O(nd), where n = length of array and d = number of elements less than k
        public int MinSwapLessThanK(int[] arr, int k)
        {
            // count the number of all elements less than or equal to K
            int countLessThanK = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= k)
                {
                    countLessThanK++;
                }
            }

            int start = 0;                          // start index of sub-array
            int end = countLessThanK - 1;           // end index of sub-array
            int maxCount = -1;                      // maximum count of elements less than or equal to K among all sub-array so far

            // check all possible sub arrays and find the sub array with maximum number of elements less than or equal to K
            while(end < arr.Length)
            {
                int tempCount = 0;                  // count of elements less than or equal to K in given sub-array
                for(int j = start; j <= end; j++)
                {
                    if (arr[j] <= k)
                    {
                        tempCount++;
                    }
                }

                if(tempCount > maxCount)
                {
                    maxCount = tempCount;
                }
                start++;
                end++;
            }

            return (countLessThanK - maxCount);
        }

        // Given two integer arrays of same size "arr[]" and "index[]" reorder elements in "arr[]" according to given index array. 
        //It is not allowed to use given array arr's length
        public void ReorderArrays(int[] arr, int[] index)
        {
            int tempIndex1 = -1;
            int tempValue1 = -1;
            int tempIndex2 = -1;
            int tempValue2 = -1;

            for(int i = 0; i < index.Length; i++)
            {
                tempIndex1 = index[i];
                tempValue1 = arr[i];

                while(index[tempIndex1] != tempIndex1)
                {
                    tempValue2 = arr[tempIndex1];
                    tempIndex2 = index[tempIndex1];

                    index[tempIndex1] = tempIndex1;
                    arr[tempIndex1] = tempValue1;

                    tempValue1 = tempValue2;
                    tempIndex1 = tempIndex2;
                }
                
            }
        }

        // Given an array of numbers, arrange them in a way that yields the largest value.

        public long FormBiggestNumber1(int[] arr)
        {
            MergeSortArray(arr, 0, arr.Length - 1);
            return concat(arr);
        }
        public long FormBiggestNumber(int[] arr)
        {
            MergeSortArray(arr, 0, arr.Length - 1);
            return concat(arr);
        }

        private void MergeSortArray(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int middle = left + (right - left)/2;
                MergeSortArray(arr, left, middle);
                MergeSortArray(arr, middle + 1, right);

                MergeArray(arr, left, middle, right);
            }
        }

        private void MergeArray(int[] arr, int left, int middle, int right)
        {
            int i, j, k;
            int n1 = middle - left + 1;
            int n2 = right - middle;
            // create temp arrays
            int[] arrayLeft = new int[n1];
            int[] arrayRight = new int[n2];

            // copy data to temp arrays 
            for(i = 0; i < n1; i++)
            {
                arrayLeft[i] = arr[left + i];
            }
            for(j = 0; j < n2; j++)
            {
                arrayRight[j] = arr[middle + 1 + j];
            }

            // Merge the temp arrays back into arr[0.....right]
            i = 0;
            j = 0;
            k = left;
            while (i < n1 && j < n2)
            {
                if (IsNumberGreater(arrayLeft[i], arrayRight[j]))
                {
                    arr[k] = arrayLeft[i];
                    i++;
                }
                else
                {
                    arr[k] = arrayRight[j];
                    j++;
                }
                k++;
            }
            
            // copy the remaining elements of arrayRight[], if there are any
            while(i < n1)
            {
                arr[k] = arrayLeft[i];
                i++;
                k++;
            }

            // copy the remaining elements of arrayleft[], if there are any
            while(j < n2)
            {
                arr[k] = arrayRight[j];
                j++;
                k++;
            }
        }

        private bool IsNumberGreater(int number1, int number2)
        {
            string temp1 = number1.ToString();
            string temp2 = number2.ToString();


            if (Int32.Parse(temp1+temp2) > Int32.Parse(temp2+temp1))
            {
                return true;
            }
            return false;
        }

        private long concat(int[] arr)
        {
            string result = "";
            string tempString = "";

            for(int i = 0; i < arr.Length; i++)
            {
                tempString = arr[i].ToString();
                result += tempString;
            }

            return Int64.Parse(result);
        }

    }
}
