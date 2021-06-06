using System;
using System.Diagnostics;
using System.Linq;

namespace TEOGRA.Zad1
{
    public class Program
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

            int[] result = FindLongestChain(a);
#if DEBUG
            Console.WriteLine(string.Join(", ", result.Select(x => x + 1)));
#endif
            Console.WriteLine(result.Length - 1);
        }

        static void VerifyMatrix(bool [][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Length != a.Length)
                    throw new ArgumentException($"Matrix is not square. a[{i}] length: {a[i].Length}, expected: {a.Length}");

                for (int j = i + 1; j < a.Length; j++)
                    if (a[i][j] != a[j][i])
                        throw new ArgumentException($"Matrix values at ({i + 1}, {j + 1}) and ({j + 1}, {i + 1}) must be same.");
            }
        }

        public static int[] FindLongestChain(bool[][] a)
        {
            VerifyMatrix(a);

            int[] max = Array.Empty<int>();

            for (int i = 0; i < a.Length; i++)
            {
                int[] tmp = FindLongestChain(i, new int[] { i }, a);
                if (max.Length < tmp.Length)
                    max = tmp;
            }

            return max;
        }

        public static int[] FindLongestChain(int v, int[] visited, bool[][] a)
        {
            int[] max = visited;

            for (int i = 0; i < a.Length; i++)
            {
                if (i == v || visited.Contains(i) || !a[v][i])
                    continue;

                int[] newVisited = new int[visited.Length + 1];
                visited.CopyTo(newVisited, 0);
                newVisited[^1] = i;

                int[] tmp = FindLongestChain(i, newVisited, a);
                if (max.Length < tmp.Length)
                    max = tmp;
            }

            return max;
        }
    }
}
