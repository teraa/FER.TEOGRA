using Xunit;
using static TEOGRA.Zad2.Program;

namespace TEOGRA.Zad2.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Test_TryFindVertexColoring_w5__1()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, true, true, true },
                new[] { true, false, true, false, true },
                new[] { true, true, false, true, false },
                new[] { true, false, true, false, true },
                new[] { true, true, false, true, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.True(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_w6__1()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, true, true, true, true },
                new[] { true, false, true, false, false, true },
                new[] { true, true, false, true, false, false },
                new[] { true, false, true, false, true, false },
                new[] { true, false, false, true, false, true },
                new[] { true, true, false, false, true, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.True(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_k_2_2__1()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, false, true, true },
                new[] { false, false, true, true },
                new[] { true, true, false, false },
                new[] { true, true, false, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.True(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_k_2_3__1()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, false, true, true, true },
                new[] { false, false, true, true, true },
                new[] { true, true, false, false, false },
                new[] { true, true, false, false, false },
                new[] { true, true, false, false, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.True(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_stablo2__1()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, false, false, false, false, false },
                new[] { true, false, true, true, true, false, false },
                new[] { false, true, false, false, false, true, true },
                new[] { false, true, false, false, false, false, false },
                new[] { false, true, false, false, false, false, false },
                new[] { false, false, true, false, false, false, false },
                new[] { false, false, true, false, false, false, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.True(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_petersen__1()
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

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.True(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_k5__0()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, true, true, true },
                new[] { true, false, true, true, true },
                new[] { true, true, false, true, true },
                new[] { true, true, true, false, true },
                new[] { true, true, true, true, false },
            };
        }

        [Fact]
        public void Test_TryFindVertexColoring_k6_e1__0()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, false, true, true, true, true },
                new[] { false, false, true, true, true, true },
                new[] { true, true, false, true, true, true },
                new[] { true, true, true, false, true, true },
                new[] { true, true, true, true, false, true },
                new[] { true, true, true, true, true, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.False(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_k6_e2__0()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, true, true, true, true },
                new[] { true, false, true, true, true, true },
                new[] { true, true, false, true, true, false },
                new[] { true, true, true, false, true, true },
                new[] { true, true, true, true, false, true },
                new[] { true, true, false, true, true, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.False(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_k6_e3__0()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, true, true, true, true },
                new[] { true, false, true, true, true, true },
                new[] { true, true, false, true, false, true },
                new[] { true, true, true, false, true, true },
                new[] { true, true, false, true, false, true },
                new[] { true, true, true, true, true, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.False(success);
        }

        [Fact]
        public void Test_TryFindVertexColoring_c5__1()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, false, false, true },
                new[] { true, false, true, false, false },
                new[] { false, true, false, true, false },
                new[] { false, false, true, false, true },
                new[] { true, false, false, true, false },
            };

            bool success = TryFindVertexColoring(4, a, out _);
            Assert.True(success);
        }

        [Fact]
        public void Test_IsValidColoring_c5__1()
        {
            bool[][] a = new bool[][]
            {
                new[] { false, true, false, false, true },
                new[] { true, false, true, false, false },
                new[] { false, true, false, true, false },
                new[] { false, false, true, false, true },
                new[] { true, false, false, true, false },
            };

            int[] coloring_true = { 1, 2, 1, 2, 3 };
            int[] coloring_false = { 1, 2, 1, 2, 1 };

            Assert.True(IsValidColoring(coloring_true, a));
            Assert.False(IsValidColoring(coloring_false, a));
        }
    }
}
