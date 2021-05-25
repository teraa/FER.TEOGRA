using System;
using System.Diagnostics;
using System.Linq;

namespace TEOGRA.Zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine() ?? throw new FormatException();

            int n = int.Parse(line);
            bool[][] m = new bool[n][];

            Console.ReadLine();

            for (int i = 0; i < m.Length; i++)
            {
                line = Console.ReadLine() ?? throw new FormatException();
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                m[i] = new bool[m.Length];
                for (int j = 0; j < m[i].Length; j++)
                {
                    m[i][j] = parts[j] switch
                    {
                        "0" => false,
                        "1" => true,
                        _ => throw new FormatException(),
                    };
                }
            }

#if DEBUG
            // Verify Matrix
            Debug.Assert(m.Length == n);

            for (int i = 0; i < n; i++)
            {
                Debug.Assert(m[i].Length == n);

                for (int j = i + 1; j < n; j++)
                    Debug.Assert(m[i][j] == m[j][i]);
            }
#endif

            int[] result = FindLongestChain(m);
            for (int i = 0; i < result.Length; i++)
                result[i]++;
            Console.WriteLine(string.Join(", ", result));

            Console.WriteLine(result.Length - 1);
        }

        static int[] FindLongestChain(bool[][] m)
        {
            int[] max = Array.Empty<int>();

            for (int i = 0; i < m.Length; i++)
            {
                int[] tmp = FindLongestChain(i, new int[] { i }, m);
                if (max.Length < tmp.Length)
                    max = tmp;
            }

            return max;
        }

        static int[] FindLongestChain(int v, int[] visited, bool[][] m)
        {
            int[] max = visited;

            for (int i = 0; i < m.Length; i++)
            {
                if (i == v || visited.Contains(i) || !m[v][i])
                    continue;

                int[] newVisited = new int[visited.Length + 1];
                visited.CopyTo(newVisited, 0);
                newVisited[^1] = i;

                int[] tmp = FindLongestChain(i, newVisited, m);
                if (max.Length < tmp.Length)
                    max = tmp;
            }

            return max;
        }
    }
}
