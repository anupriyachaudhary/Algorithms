using Lib.Utils;
using Xunit;
using Test.TestUtils;

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
    }
}
