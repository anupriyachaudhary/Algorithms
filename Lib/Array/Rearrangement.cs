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
            int pivotIndex = Partition(arr);

            // Place positive and negative numbers in alternate positions using posPointer and negPointer
            int posPointer = -1;
            int negPointer = -1;

            if(pivotIndex != -1)
            {
                posPointer = 0;
            }
            else
                return;
            
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

        private int Partition(int[] arr)
        {
            if(arr.Length <= 0)
            {
                throw new ArgumentException();
            }

            if(arr.Length == 1)
            {
                return 0;
            }

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

            // mainPointer = main pointer to keep track of array index till which all elements are correct
            // tempPointer = temporary pointer to keep find the element to be swapped with the element at main pointer
            for (int mainPointer = 0; mainPointer < arr.Length; mainPointer++)
            {
                int tempLeftPointer = 0;
                int tempRightPointer = 0;
                if (mainPointer % 2 == 0)
                {
                    if (arr[mainPointer] > 0)
                    {
                        continue;
                    }
                    else
                    {
                        tempRightPointer = mainPointer + 1;
                        while(arr[tempRightPointer] < 0 && tempRightPointer < arr.Length)
                        {
                            ++tempRightPointer;
                        }

                        if (tempRightPointer != arr.Length)
                        {
                            
                            swap(arr, mainPointer, tempRightPointer);
                        }
                    }
                }

                else
                {
                    if (arr[mainPointer] < 0)
                    {
                        continue;
                    }
                    else
                    {
                        tempRightPointer = mainPointer + 1;
                        while(arr[tempRightPointer] >= 0 && tempRightPointer < arr.Length)
                        {
                            ++tempRightPointer;
                        }

                        if (tempRightPointer != arr.Length)
                        {
                            swap(arr, mainPointer, tempRightPointer);
                        }
                    }
                }    
            }   
        }
    }
}
