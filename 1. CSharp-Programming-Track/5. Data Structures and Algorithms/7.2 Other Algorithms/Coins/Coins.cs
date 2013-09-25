using System;
using System.Collections.Generic;

class Coins
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());

        List<int> coins = new List<int>() { 5, 2, 1 };

        int[] coinsCount = new int[coins.Count];

        for (int i = 0; i < coins.Count; i++)
        {
            coinsCount[i] = sum / coins[i];
            sum = sum % coins[i];
        }

        for (int i = 0; i < coins.Count; i++)
        {
            Console.WriteLine("{0} -> {1} times", coins[i], coinsCount[i]);
        }
    }

}
