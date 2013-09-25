using System;

class LongestCommonSubsequence
{
    const int NOT_CALCULATED = -1;
    static string first = "aabbaa";
    static string second = "aaabbbaaa";
    static int[,] sequencesLength = new int[first.Length, second.Length];

    static void Main()
    {
        for (int i = 0; i < sequencesLength.GetLength(0); i++)
        {
            for (int j = 0; j < sequencesLength.GetLength(1); j++)
            {
                sequencesLength[i, j] = NOT_CALCULATED;
            }
        }

        int result = CalcLongestCommonSubsequence(first.Length - 1, second.Length - 1);
        Console.WriteLine(result);


        PrintLongestCommonSubsequence(first.Length - 1, second.Length - 1);

    }

    private static void PrintLongestCommonSubsequence(int x, int y)
    {
        while (x >= 0 && y>= 0)
        {
            if (first[x] == second[y])
            {
                if (CalcLongestCommonSubsequence(x - 1, y) > CalcLongestCommonSubsequence(x, y - 1)
                    && CalcLongestCommonSubsequence(x - 1, y) > CalcLongestCommonSubsequence(x - 1, y - 1) + 1)
                {
                    x--;
                }
                else if (CalcLongestCommonSubsequence(x, y - 1) > CalcLongestCommonSubsequence(x - 1, y)
                    && CalcLongestCommonSubsequence(x, y - 1) > CalcLongestCommonSubsequence(x - 1, y - 1) + 1)
                {
                    y--;
                }
                else
                {
                    Console.Write(first[x] + " ");
                    x--;
                    y--;
                }
            }
            else
            {
                if (CalcLongestCommonSubsequence(x - 1, y) > CalcLongestCommonSubsequence(x, y - 1))
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }
        }
        Console.WriteLine();
    }

    private static int CalcLongestCommonSubsequence(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return 0;
        }

        if (sequencesLength[x, y] == -1)
        {
            if (first[x] == second[y])
            {
                sequencesLength[x, y] = Math.Max(
                    1 + CalcLongestCommonSubsequence(x - 1, y - 1),
                    Math.Max(
                        CalcLongestCommonSubsequence(x - 1, y),
                        CalcLongestCommonSubsequence(x, y - 1)
                    )
                );
            }
            else
            {
                sequencesLength[x, y] = Math.Max(
                    CalcLongestCommonSubsequence(x - 1, y),
                    CalcLongestCommonSubsequence(x, y - 1)
                );
            }
        }

        return sequencesLength[x, y];
    }
}

