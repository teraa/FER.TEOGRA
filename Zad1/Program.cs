using System;
using System.Diagnostics;
using System.Linq;

namespace TEOGRA.Zad1
{
    class Program
    {
        // dotnet run -c Release < graf.txt

        static void Main(string[] args)
        {
            string line = Console.ReadLine() ?? throw new FormatException("First line cannot be null");

            int n = int.Parse(line);
            bool[][] a = new bool[n][];

            Console.ReadLine();

            for (int i = 0; i < a.Length; i++)
            {
                line = Console.ReadLine() ?? throw new FormatException($"Missing line number {i + 1}.");
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                a[i] = new bool[a.Length];
                for (int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] = parts[j] switch
                    {
                        "0" => false,
                        "1" => true,
                        _ => throw new FormatException($"Value at ({i + 1}, {j + 1}) is not 0 or 1."),
                    };
                }
            }

#if DEBUG
            // Verify Matrix
            Debug.Assert(a.Length == n);

            for (int i = 0; i < n; i++)
            {
                Debug.Assert(a[i].Length == n);

                for (int j = i + 1; j < n; j++)
                    Debug.Assert(a[i][j] == a[j][i], $"a[{i}][{j}] and a[{j}][{i}] do not match.");
            }
#endif

            int[] result = FindLongestChain(a);
#if DEBUG
            Console.WriteLine(string.Join(", ", result.Select(x => x + 1)));
#endif
            Console.WriteLine(result.Length - 1);
        }

        static int[] FindLongestChain(bool[][] a)
        {
            int[] max = Array.Empty<int>();

            for (int i = 0; i < a.Length; i++)
            {
                int[] tmp = FindLongestChain(i, new int[] { i }, a);
                if (max.Length < tmp.Length)
                    max = tmp;
            }

            return max;
        }

        static int[] FindLongestChain(int v, int[] visited, bool[][] a)
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
