using Xunit;
using Lib.Array;
using Test.TestUtils;
using System;

namespace Test.Array
{
    public class OrderStatisticsTests
    {
        private OrderStatistics orderStatistics;
        public OrderStatisticsTests()
        {
            orderStatistics = new OrderStatistics();
        }

        [Fact]
        public void KthSmallestElement()
        {
            int[] inputArr = { 7, 10, 4, 3, 20, 15 };
            int k = 4;
            int expectedOutput = 10;

            int output = orderStatistics.KthSmallestElement(inputArr, k);
            Assert.True(output == expectedOutput);
        }

        [Fact]
        public void KthSmallestElementIn2DArray()
        {
            int[,] array2D = { { 10, 20, 30, 40 }, { 15, 25, 35, 45 }, { 24, 29, 37, 48 }, { 32, 33, 39, 50 } };
            int k = 7;
            int expectedOutput = 30;

            int output = orderStatistics.KthSmallestElementIn2DArray(array2D, k);
            Assert.True(output == expectedOutput);
        }
    }
}
