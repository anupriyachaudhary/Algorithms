using System;
using Lib.Utils;

namespace Lib.Common
{
    public class MinHeap
    {
        public int[] heapArr; // pointer to array of elements in heap
        public int capacity; // maximum possible size of min heap
        public int heap_size; // current number of elements in min heap

        // Constructor
        public MinHeap(int cap)
        {
            heap_size = 0;
            capacity = cap;
            heapArr = new int[capacity];
        }

        // Inserts a new key 'key'
        public void insertKey(int key)
        {
            if (heap_size == capacity)
            {
                throw new ArgumentException();
            }

            // First insert the new key at the end
            heap_size++;
            int i = heap_size - 1;
            heapArr[i] = key;

            // Fix the min heap property if it is violated
            while (i != 0 && heapArr[parent(i)] > heapArr[i])
            {
                ArrayUtils.Swap(heapArr, i, parent(i));
                i = parent(i);
            }
        }

        // to heapify a subtree with the root at given index
        public void MinHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int smallest = i;
            if (l < heap_size && heapArr[l] < heapArr[i])
                smallest = l;
            if (r < heap_size && heapArr[r] < heapArr[smallest])
                smallest = r;
            if (smallest != i)
            {
                ArrayUtils.Swap(heapArr, i, smallest);
                MinHeapify(smallest);
            }
        }
 
        public int parent(int i) 
        { 
            return (i-1)/2; 
        }
 
        // to get index of left child of node at index i
        public int left(int i) 
        { 
            return (2*i + 1); 
        }
 
        // to get index of right child of node at index i
        public int right(int i) 
        { 
            return (2*i + 2); 
        }
 
        // Returns the minimum key (key at root) from min heap
        public int getMin() 
        { 
            return heapArr[0]; 
        }
    }
}