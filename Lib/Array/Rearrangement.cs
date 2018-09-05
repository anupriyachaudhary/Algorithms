using System;
using Lib.Utils;

namespace Lib.Array
{
    public class Rearrangement
    {
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
                    swap(arr, arr[i], i);

                    // swap again & again if the element at index i is still not at its right position
                    // No need to swap if element at index i is -1 or if a[i] = i
                    while(arr[i] != -1 && arr[i] != i)
                    {
                        swap(arr, arr[i], i);
                    }
                }
            }
        }

        private void swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
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

            // Place positive and negative numbers in alternate positions using posPointer and negPointer
            int posPointer = -1;
            int negPointer = -1;

            // pivotIndex is negative when there are no positive numbers in array
            if(pivotIndex != -1)
            {
                posPointer = 0;
            }
            else
                return;
            
            // if pivot index is (arr.Length-1) there are no negative numbers
            if(pivotIndex != arr.Length - 1)
            {
                negPointer = pivotIndex + 1;
            }
            else 
                return;

            while(negPointer < arr.Length)
            {
                ++posPointer;
                swap(arr, posPointer, negPointer);
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
                    swap(arr, 0, 1);
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
                    swap(arr, leftPointer, rightPointer);
                    --rightPointer;
                }
            }

            if(arr[leftPointer] > 0 && arr[pivot] > 0)
            {
                swap(arr, pivot, leftPointer + 1);
                return leftPointer + 1;
            }
            else if(arr[leftPointer] < 0 && arr[pivot] > 0)
            {
                swap(arr, pivot, leftPointer);
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
                            Rotate(arr, index, tempPointer, 1, 1);
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
                            Rotate(arr, index, tempPointer, 1, 1);
                        }
                    }
                }    
            }   
        }

        // rotate: right = 1, left = 0
        private void Rotate(int[] arr, int start, int end, int d, int rotate)
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

            if(rotate == 1)
            {
                ArrayUtils.Reverse(arr, start, end);
                ArrayUtils.Reverse(arr, start, start + d - 1);
                ArrayUtils.Reverse(arr, start + d, end);
            }

            if(rotate == 0)
            {
                ArrayUtils.Reverse(arr, start, end);
                ArrayUtils.Reverse(arr, start, end - d);
                ArrayUtils.Reverse(arr, end - d + 1, end);
            }
        }

        // complexity ??
        /*public void ZerosRearrange(int[] arr)
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
 
            int index = 0;
            int zeroPointer = 0;
            int zeroCount = 0;
            while(index < arr.Length)
            {
                if(arr[index] == 0)
                {
                    zeroPointer = index + zeroCount + 1;

                    while(zeroPointer < arr.Length && arr[zeroPointer] != 0)
                    {
                        ++zeroPointer;
                    }

                    if(zeroPointer != arr.Length && index + zeroCount != zeroPointer - 1)
                    {
                        Rotate(arr, index, zeroPointer - 1, zeroCount + 1, 0);
                    }
                    if (zeroPointer == arr.Length && arr[zeroPointer - 1] != 0)
                    {
                        Rotate(arr, index, zeroPointer - 1, zeroCount + 1, 0);
                    }
                    if(zeroPointer == arr.Length && arr[zeroPointer - 1] == 0)
                    {
                        break;
                    }
                    
                    ++zeroCount;
                    index = zeroPointer - zeroCount;
                }
                
                else
                {
                    ++index;
                }
            }
        }*/

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

        //reorder array according to given indices
        public void ReorderArrays(int[] arr, int[] index)
        {
            int tempIndex1 = -1;
            int tempValue1 = -1;
            int tempIndex2 = -1;
            int tempValue2 = -1;

            for(int i = 0; i < index.Length; i++)
            {
                tempIndex1 = i;

                while(index[tempIndex1] != tempIndex1)
                {
                    int k = index[tempIndex1];
                    tempValue2 = arr[index[tempIndex1]];
                    k = index[tempIndex1];
                    tempIndex2 = index[index[tempIndex1]];

                    index[index[tempIndex1]] = index[tempIndex1];
                    arr[index[tempIndex1]] = arr[tempIndex1];

                    tempValue1 = tempValue2;
                    tempIndex1 = tempIndex2;
                }
                
            }
        }

    }
}
