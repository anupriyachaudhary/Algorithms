using Lib.Utils;
using Xunit;
using Test.TestUtils;
using System;

namespace Test.Utils
{
    public class ArrayUtilsTests
    {
        [Fact]
        public void TestReverse()
        {
            int[] inputArr = { 1, 2, 3, 4, 5 };
            int[] expectedArr = { 5, 4, 3 , 2, 1 };

            ArrayUtils.Reverse(inputArr);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void TestGetPivot()
        {
            int[] inputArr = { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
            int expectedPivotIndex = 5;

            int output = ArrayUtils.GetPivot(inputArr, 0, inputArr.Length-1);
            Assert.True(output == expectedPivotIndex);
        }

        [Fact]
        public void TestBinarySearch()
        {
            int[] inputArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int key = 8;
            int expectedIndex = 7;

            int output = ArrayUtils.BinarySearch(inputArr, 0, inputArr.Length-1, key);
            Assert.True(output == expectedIndex);
        }
    }
}
