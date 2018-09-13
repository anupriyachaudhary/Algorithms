using Xunit;
using Lib.Array;
using Test.TestUtils;
using System;

namespace Test.Array
{
    public class RearrangementTests
    {
        private Rearrangement rearrangement;
        public RearrangementTests()
        {
            rearrangement = new Rearrangement();
        }

        [Fact]
        public void Rearrange()
        {
            int[] inputArr = { -1, -1, 6, 1, 9, 3, 2, -1, 4, -1 };
            int[] expectedArr = { -1, 1, 2, 3, 4, -1, 6, -1, -1, 9 };

            rearrangement.Rearrange(inputArr);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void PosNegRearrange()
        {
            int[] inputArr = { 1, -3 };

            rearrangement.PosNegRearrange(inputArr);
            Console.WriteLine(inputArr.ToString());
        }

        [Fact]
        public void PosNegInOrderRearrange()
        {
            int[] inputArr = { -5, -2, 5, 2, 4, 7, 1, 8, 0, -8 };
            int[] expectedArr = { -5, 5, -2, 2, -8, 4, 7 ,1, 8, 0 };

            rearrangement.PosNegInOrderRearrange(inputArr);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void ZerosRearrange()
        {
            int[] inputArr = { 1, 2, 0, 4, 3, 0, 5, 0 };
            int[] expectedArr = { 1, 2, 4, 3, 5, 0, 0, 0 };

            rearrangement.ZerosRearrange(inputArr);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void MinSwapLessThanK()
        {
            int[] inputArr = { 2, 7, 9, 5, 8, 7, 4 };
            int k = 5;
            int expectedSwaps = 2;

            int swaps = rearrangement.MinSwapLessThanK(inputArr, k);
            Assert.True(swaps == expectedSwaps);
        }

        [Fact]
        public void ReorderArrays()
        {
            int[] inputArr = { 10, 11, 12 };
            int[] inputIndex = { 1, 0, 2 };

            int[] expectedArr = { 11, 10, 12 };
            int[] expectedIndex = { 0, 1, 2 };

            rearrangement.ReorderArrays(inputArr, inputIndex);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
            Assert.True(ArrayTestUtils.ArraysEqual(inputIndex, expectedIndex));
        }

        [Fact]
        public void FormBiggestNumber()
        {
            int[] inputArr = { 1, 34, 3, 98, 9, 76, 45, 4 };
            long expectedOutput = 998764543431;

            long output = rearrangement.FormBiggestNumber(inputArr);
            Assert.True(output == expectedOutput);
        }
    }
}
