using Xunit;
using Lib.Common;
using Test.TestUtils;
using System;

namespace Test.Common
{
    public class MinHeapTests
    {
        private MinHeap minHeap;

        [Fact]
        public void MinHeapify()
        {
            int[] inputArr = { 7, 10, 4, 3, 20, 15 };
            int[] expectedArr = { 3, 4, 7, 10, 20, 15 };

            minHeap = new MinHeap(inputArr.Length);
            for(int i = 0; i < inputArr.Length; i++)
            {
                minHeap.insertKey(inputArr[i]);
            }

            minHeap.MinHeapify(0);
            Assert.True(ArrayTestUtils.ArraysEqual(minHeap.heapArr, expectedArr));
        }
    }
}