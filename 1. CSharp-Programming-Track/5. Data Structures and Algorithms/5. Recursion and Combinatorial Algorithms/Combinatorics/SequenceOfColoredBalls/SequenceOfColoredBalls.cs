using System;
using System.Collections.Generic;
using System.Numerics;

class SequenceOfColoredBalls
{
    // http://bgcoder.com/Contest/Practice/59 - Task04

    private static char[] balls;
    private static BigInteger[] factorials = new BigInteger['Z' + 1];
    //private static HashSet<string> sequences;

    static void Main()
    {
        balls = Console.ReadLine().ToCharArray();

        //sequences = new HashSet<string>();
        //GenerateBallsSequences(new int[balls.Length], new bool[balls.Length], 0);
        //Console.WriteLine(sequences.Count);

        Console.WriteLine(CountSequences(balls));
    }


    private static BigInteger CountSequences(char[] balls)
    {
        int[] ballsCount = new int['Z' + 1];

        for (int i = 0; i < balls.Length; i++)
        {
            ballsCount[balls[i]]++;
        }

        BigInteger denom = 1;
        for (int i = 0; i < ballsCount.Length; i++)
        {
            if (ballsCount[i] != 0)
            {
                BigInteger factI = CalcFactorial(ballsCount[i]);
                denom *= factI;
            }
        }

        return CalcFactorial(balls.Length) / denom;
    }

    private static BigInteger CalcFactorial(int n)
    {
        if (factorials[n] == 0)
        {
            BigInteger fact = 1;
            for (int i = n; i >= 1; i--)
            {
                fact *= i;
            }
            factorials[n] = fact;
        }

        return factorials[n];
    }

    //very slow solution 
    //private static void GenerateBallsSequences(int[] indices, bool[] used, int currentIndex)
    //{
    //    if (currentIndex == indices.Length)
    //    {
    //        string sequence = "";
    //        for (int i = 0; i < indices.Length; i++)
    //        {
    //            sequence += balls[indices[i]];
    //        }
    //        sequences.Add(sequence);
    //        return;
    //    }

    //    for (int i = 0; i < indices.Length; i++)
    //    {
    //        if (!used[i])
    //        {
    //            used[i] = true;
    //            indices[currentIndex] = i;
    //            GenerateBallsSequences(indices, used, currentIndex + 1);
    //            used[i] = false;
    //        }
    //    }
    //}
}


