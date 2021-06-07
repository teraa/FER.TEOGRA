using System;
using System.Linq;

namespace TEOGRA.Zad2
{
    public class Zad2
    {
        // dotnet run -c Release < graf.txt

        static void Main(string[] args)
        {
            string line = Console.ReadLine() ?? throw new FormatException("Missing first line.");

            int n = int.Parse(line);
            bool[][] a = new bool[n][];

            _ = Console.ReadLine() ?? throw new FormatException("Missing separator line.");

            for (int i = 0; i < a.Length; i++)
            {
                line = Console.ReadLine() ?? throw new FormatException($"Missing matrix row {i + 1}.");
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != n)
                    throw new FormatException($"Invalid number of elements: {parts.Length}, expected: {n} for matrix row {i + 1}");

                a[i] = new bool[a.Length];
                for (int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] = parts[j] switch
                    {
                        "0" => false,
                        "1" => true,
                        _ => throw new FormatException($"Matrix value at ({i + 1}, {j + 1}) is not [0, 1]."),
                    };
                }
            }

            bool success = TryFindVertexColoring(4, a, out int[] coloring);
#if DEBUG
            if (success)
                Console.WriteLine(string.Join(", ", coloring.Select(x => x + 1)));
#endif
            Console.WriteLine(success ? 1 : 0);
        }

        static void VerifyMatrix(bool [][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Length != a.Length)
                    throw new ArgumentException($"Matrix is not square. a[{i}] length: {a[i].Length}, expected: {a.Length}");

                for (int j = i + 1; j < a[i].Length; j++)
                    if (a[i][j] != a[j][i])
                        throw new ArgumentException($"Matrix values at ({i + 1}, {j + 1}) and ({j + 1}, {i + 1}) must be same.");
            }
        }

        public static bool TryFindVertexColoring(int colors, bool[][] a, out int[] result)
        {
            VerifyMatrix(a);
            result = new int[a.Length];
            return TryFindVertexColoring(result, 0, colors, a);
        }

        private static bool TryFindVertexColoring(int[] values, int idx, int colors, bool[][] a)
        {
            if (idx + 1 == values.Length)
            {
                for (int i = 0; i < colors; i++)
                {
                    values[idx] = i;
                    if (IsValidColoring(values, a))
                        return true;
                }
            }
            else
            {
                for (int i = 0; i < colors; i++)
                {
                    values[idx] = i;
                    if (TryFindVertexColoring(values, idx + 1, colors, a))
                        return true;
                }
            }

            return false;
        }

        public static bool IsValidColoring(int[] coloring, bool[][] a)
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = i + 1; j < a[i].Length; j++)
                    if (a[i][j] && coloring[i] == coloring[j])
                        return false;

            return true;
        }
    }
}
