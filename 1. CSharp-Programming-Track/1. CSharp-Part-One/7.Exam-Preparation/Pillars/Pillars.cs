using System;

class Pillars
{
    static void Main()
    {
        int[] n = new int[8];
        for (int i = 0; i < 8; i++)
        {
            n[i] = int.Parse(Console.ReadLine());
        }

        int pillarIndex = -1;
        int bestCount = 0;

        for (int pillar = 0; pillar < 8; pillar++)
        {
            int rightCount = 0;
            int leftCount = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < pillar; j++)
                {
                    if ((n[i] >> j & 1) == 1)
                    {
                        rightCount++;
                    }
                }
                for (int j = pillar + 1; j < 8; j++)
                {
                    if ((n[i] >> j & 1) == 1)
                    {
                        leftCount++;
                    }
                }
            }
            if (rightCount == leftCount)
            {
                pillarIndex = pillar;
                bestCount = leftCount;
            }
        }

        if (pillarIndex != -1)
        {
            Console.WriteLine(pillarIndex);
            Console.WriteLine(bestCount);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

