using System;
using System.Diagnostics;

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

            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine() ?? throw new FormatException();

                m[i] = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    m[i][j] = line[j * 2] switch
                    {
                        '0' => false,
                        '1' => true,
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

            int result = FindLongestChain(n, m);
            Console.WriteLine(result);
        }

        static int FindLongestChain(int n, bool[][] m)
        {
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int tmp = FindLongestChain(n, i, j, m);
                    if (max < tmp)
                        max = tmp;
                }
            }

            return max;
        }

        static int FindLongestChain(int n, int i, int j, bool[][] m)
        {
            Console.WriteLine($"({i}, {j})");
            return 0;
        }
    }
}
