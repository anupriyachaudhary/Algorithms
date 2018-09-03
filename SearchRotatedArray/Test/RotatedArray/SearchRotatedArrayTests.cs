using System;
using Xunit;
using Lib.Array;
using Test.TestUtils;

namespace Test.Array
{
    public class RotationTests
    {
        private Rotation rotation;
        public RotationTests()
        {
            rotation = new Rotation();
        }

        [Fact]
        public void RotationShouldWork()
        {
            var d = 2;
            int[] inputArr = { 1, 2, 3, 4, 5, 6, 7};
            int[] expectedArr = {3, 4, 5, 6, 7, 1, 2};

            rotation.Rotate(inputArr, d);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void RotationShouldThrowExceptionIfRotationCountIsNegative()
        {
            var d = -2;
            int[] inputArr = { 1, 2, 3, 4, 5, 6, 7};
            int[] expectedArr = {3, 4, 5, 6, 7, 1, 2};

            Assert.Throws<ArgumentException>(() => rotation.Rotate(inputArr, d));
        }

        [Fact]
        public void RotationShouldThrowExceptionIfArrayIsEmpty()
        {
            var d = 2;
            int[] inputArr = {};
            int[] expectedArr = {};

            Assert.Throws<ArgumentException>(() => rotation.Rotate(inputArr, d));
        }

        [Fact]
        public void RotationShouldWorkForArrayOfSizeOne()
        {
            var d = 2;
            int[] inputArr = {1};
            int[] expectedArr = {1};

            rotation.Rotate(inputArr, d);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void RotationShouldWorkForArrayOfSizeTwo()
        {
            var d = 1;
            int[] inputArr = {1, 2};
            int[] expectedArr = {2, 1};

            rotation.Rotate(inputArr, d);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void RotationShouldWorkIfRotationCountIsGreaterThanArraySize()
        {
             var d = 24;
            int[] inputArr = { 1, 2, 3, 4, 5, 6, 7 };
            int[] expectedArr = { 4, 5, 6, 7, 1, 2, 3 };

            rotation.Rotate(inputArr, d);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }

        [Fact]
        public void RotationShouldWorkIfRotationCountIsDivisibleByArraySize()
        {
             var d = 14;
            int[] inputArr = { 1, 2, 3, 4, 5, 6, 7 };
            int[] expectedArr = {1, 2, 3, 4, 5, 6, 7};

            rotation.Rotate(inputArr, d);
            Assert.True(ArrayTestUtils.ArraysEqual(inputArr, expectedArr));
        }
    }
}


