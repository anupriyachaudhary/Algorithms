namespace Test.TestUtils
{
    public static class ArrayTestUtils
    {
        public static bool ArraysEqual(int[] a1, int[] a2)
        {
            if (a1.Length == a2.Length)
            {
                for (int i = 0; i < a1.Length; i++)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}