using System;

class SumsOfSubsequences
{
    // http://bgcoder.com/Contest/Practice/59 - Task06

    private static int sum;
    private static int[] inputNums;

    static void Main()
    {
        int tests = int.Parse(Console.ReadLine());

        for (int i = 0; i < tests; i++)
        {
            string[] nAndK = Console.ReadLine().Split(' ');
            int n = int.Parse(nAndK[0]);
            int k = int.Parse(nAndK[1]);

            inputNums = new int[n];
            string[] inputNumsAsString = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                inputNums[j] = int.Parse(inputNumsAsString[j]);
            }

            sum = 0;

            CalcSumOfSubsequences(new int[n - k], 0, 0, n);
            Console.WriteLine(sum);
        }
    }

    private static void CalcSumOfSubsequences(int[] indices, int startIndex, int currentIndex, int n)
    {
        if (currentIndex == indices.Length)
        {
            for (int i = 0; i < indices.Length; i++)
            {
                sum += inputNums[indices[i]];
                //Console.Write(inputNums[indices[i]] + " ");
            }
            //Console.WriteLine();
            return;
        }

        for (int i = startIndex; i < n; i++)
        {
            indices[currentIndex] = i;
            CalcSumOfSubsequences(indices, i + 1, currentIndex + 1, n);
        }
    }
}