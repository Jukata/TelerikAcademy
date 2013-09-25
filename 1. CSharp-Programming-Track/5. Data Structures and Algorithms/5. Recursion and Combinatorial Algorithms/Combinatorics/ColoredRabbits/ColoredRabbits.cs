using System;
using System.Collections.Generic;

class ColoredRabbits
{
    // http://bgcoder.com/Contest/Practice/59 - Task02

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int totalRabbitsCount = 0;

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int currentAnswer = int.Parse(Console.ReadLine());

            if (currentAnswer == 0)
            {
                totalRabbitsCount++;
            }
            else if (dict.ContainsKey(currentAnswer))
            {
                dict[currentAnswer]++;
                if (dict[currentAnswer] % (currentAnswer + 1) == 1)
                {
                    totalRabbitsCount += currentAnswer + 1;
                    dict[currentAnswer] = 1;
                }
            }
            else
            {
                dict[currentAnswer] = 1;
                totalRabbitsCount += currentAnswer + 1;
            }
        }

        Console.WriteLine(totalRabbitsCount);
    }
}

