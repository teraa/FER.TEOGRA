using Xunit;
using static TEOGRA.Zad1.Program;

namespace TEOGRA.Zad1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Graf()
        {
            bool[][] a = new bool[][]
            {
                new [] { false, true, true, false },
                new [] { true, false, true, true },
                new [] { true, true, false, true },
                new [] { false, true, true, false },
            };

            int[] result = FindLongestChain(a);
            int length = result.Length - 1;
            Assert.Equal(3, length);
        }

        [Fact]
        public void Test_Graf_Stablo()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, false, false, false, false, false, false },
                new[] { true, false, true, true, false, false, false, false },
                new[] { false, true, false, true, true, false, false, false },
                new[] { false, true, true, false, false, false, false, false },
                new[] { false, false, true, false, false, true, false, false },
                new[] { false, false, false, false, true, false, true, true },
                new[] { false, false, false, false, false, true, false, false },
                new[] { false, false, false, false, false, true, false, false },
            };

            int[] result = FindLongestChain(a);
            int length = result.Length - 1;
            Assert.Equal(6, length);
        }

        [Fact]
        public void Test_Graf_Petersen()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, true, false, false, true, false, false, false, false },
                new[] { true, false, false, true, false, false, true, false, false, false },
                new[] { true, false, false, false, true, false, false, true, false, false },
                new[] { false, true, false, false, true, false, false, false, true, false },
                new[] { false, false, true, true, false, false, false, false, false, true },
                new[] { true, false, false, false, false, false, false, false, true, true },
                new[] { false, true, false, false, false, false, false, true, false, true },
                new[] { false, false, true, false, false, false, true, false, true, false },
                new[] { false, false, false, true, false, true, false, true, false, false },
                new[] { false, false, false, false, true, true, true, false, false, false },
            };

            int[] result = FindLongestChain(a);
            int length = result.Length - 1;
            Assert.Equal(9, length);
        }
    }
}
