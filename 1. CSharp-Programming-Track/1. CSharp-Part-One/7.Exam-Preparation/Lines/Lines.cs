using System;

class Lines
{
    static void Main()
    {
        int[,] numbers = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                if ((inputNumber >> j & 1) == 1)
                {
                    numbers[i, j] = 1;
                }
            }
        }
        int bestLenght = 0;
        int count = 0;
        int currentLenght = 0;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (numbers[i, j] == 1)
                {
                    currentLenght++;
                }
                else
                {
                    if (currentLenght == bestLenght)
                    {
                        count++;
                    }
                    else if (currentLenght > bestLenght)
                    {
                        bestLenght = currentLenght;
                        count = 1;
                    }
                    currentLenght = 0;
                }
            }

            if (currentLenght == bestLenght)
            {
                count++;
            }
            else if (currentLenght > bestLenght)
            {
                bestLenght = currentLenght;
                count = 1;
            }
            currentLenght = 0;
        }
        currentLenght = 0;
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (numbers[i, j] == 1)
                {
                    currentLenght++;
                }
                else
                {
                    if (currentLenght == bestLenght)
                    {
                        count++;
                    }
                    else if (currentLenght > bestLenght)
                    {
                        bestLenght = currentLenght;
                        count = 1;
                    }
                    currentLenght = 0;
                }
            }

            if (currentLenght == bestLenght)
            {
                count++;
            }
            else if (currentLenght > bestLenght)
            {
                bestLenght = currentLenght;
                count = 1;
            }
            currentLenght = 0;
        }
        if (bestLenght == 1)
        {
            count /= 2;
        }
        Console.WriteLine(bestLenght);
        Console.WriteLine(count);
    }
}

