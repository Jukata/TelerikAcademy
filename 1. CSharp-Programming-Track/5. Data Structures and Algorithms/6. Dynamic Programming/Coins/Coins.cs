using System;

class Coins
{
    static void Main()
    {
        int[] coins = { 12123, 4 };
        int targetSum = 1233456;

        bool[] possibleSums = new bool[targetSum + 1];

        possibleSums[0] = true;

        for (int i = 0; i < possibleSums.Length; i++)
        {
            if (possibleSums[i])
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    int currentSum = coins[j] + i;
                    if (currentSum <= targetSum)
                    {
                        possibleSums[currentSum] = true;
                    }
                }
            }
        }

        if (possibleSums[targetSum])
        {
            while (true)
            {
                for (int i = 0; i < coins.Length; i++)
                {
                    int sum = targetSum - coins[i];
                    if (sum >= 0 && possibleSums[sum])
                    {
                        Console.Write(coins[i] + " ");
                        targetSum -= coins[i];
                        break;
                    }
                }

                if (targetSum == 0)
                {
                    break;
                }
            }
        }
        Console.WriteLine("\n" + possibleSums[targetSum]);

    }
}