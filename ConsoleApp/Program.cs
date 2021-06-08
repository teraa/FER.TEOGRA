using System;

Gen(new int[3], 0, 2);

static void Gen(int[] digits, int idx, int n)
{
    if (idx + 1 == digits.Length)
    {
        for (int i = 0; i < n; i++)
        {
            digits[idx] = i;
            Console.WriteLine(string.Join("", digits));
        }
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            digits[idx] = i;
            Gen(digits, idx + 1, n);
        }
    }
}
