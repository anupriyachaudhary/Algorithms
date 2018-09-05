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
    }
}
