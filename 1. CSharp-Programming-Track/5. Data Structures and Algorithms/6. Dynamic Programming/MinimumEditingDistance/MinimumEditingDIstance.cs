using System;


class MinimumEditingDIstance
{
    //private const double NOT_CALCULATED = -1;
    private const double DELETE_COST = 0.9;
    private const double INSERT_COST = 0.8;
    private const double REPLACE_COST = 1;

    private static string firstWord = "developer";
    private static string secondWord = "enveloped";
    //private static double[,] distances = new double[firstWord.Length, secondWord.Length];

    static void Main()
    {
        //Write a program to calculate the "Minimum Edit Distance" (MED) between two words. 
        //MED(x, y) is the minimal sum of costs of edit operations used to transform x to y.
        //Sample costs are given below:
        //cost (replace a letter) = 1
        //cost (delete a letter) = 0.9
        //cost (insert a letter) = 0.8
        //Example: x = "developer", y = "enveloped" -> cost = 2.7 
        //delete ‘d’:  "developer" -> "eveloper", cost = 0.9
        //insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
        //replace ‘r’ -> ‘d’:  "enveloper" -> "enveloped", cost = 1

        //double minCost = CalcMinimumEditingDistanceRecursive(firstWord.Length - 1, secondWord.Length - 1);
        //Console.WriteLine("Recursive = {0} // don't work properly", minCost);

        Console.WriteLine("Total cost = {0}", CalcLevensteinDistance(firstWord, secondWord));
    }

    private static double CalcLevensteinDistance(string firstWord, string secondWord)
    {
        int m = firstWord.Length;
        int n = secondWord.Length;

        string w1 = "_" + firstWord;
        string w2 = "_" + secondWord;

        double[,] distances = new double[m + 1, n + 1];

        for (int i = 0; i <= m; i++)
        {
            distances[i, 0] = i * DELETE_COST;
        }

        for (int j = 0; j <= n; j++)
        {
            distances[0, j] = j * INSERT_COST;
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (w1[i] == w2[j])
                {
                    distances[i, j] = distances[i - 1, j - 1];
                }
                else
                {
                    distances[i, j] = Math.Min(
                        distances[i - 1, j] + DELETE_COST,
                        Math.Min(
                            distances[i, j - 1] + INSERT_COST,
                            distances[i - 1, j - 1] + REPLACE_COST
                        )
                    );
                }
            }
        }

        return distances[m, n];
    }

    ////recursivly - don't work properly
    //private static double CalcMinimumEditingDistanceRecursive(int x, int y)
    //{
    //    if (x < 0 || y < 0)
    //    {
    //        return 0;
    //    }

    //    if (distances[x, y] == NOT_CALCULATED)
    //    {
    //        if (firstWord[x] == secondWord[y])
    //        {
    //            distances[x, y] = Math.Min(
    //                distances[x, y] = CalcMinimumEditingDistanceRecursive(x - 1, y - 1),
    //                Math.Min(
    //                    CalcMinimumEditingDistanceRecursive(x - 1, y) + DELETE_COST,
    //                    Math.Min(
    //                        CalcMinimumEditingDistanceRecursive(x - 1, y - 1) + REPLACE_COST,
    //                        CalcMinimumEditingDistanceRecursive(x, y - 1) + INSERT_COST
    //                    )
    //                )
    //            );
    //        }
    //        else
    //        {
    //            distances[x, y] = Math.Min(
    //                CalcMinimumEditingDistanceRecursive(x - 1, y) + DELETE_COST,
    //                Math.Min(
    //                    CalcMinimumEditingDistanceRecursive(x - 1, y - 1) + REPLACE_COST,
    //                    CalcMinimumEditingDistanceRecursive(x, y - 1) + INSERT_COST
    //                )
    //            );
    //        }
    //    }

    //    return distances[x, y];
    //}
}

