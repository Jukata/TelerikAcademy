using System;

class SubsetSums
{
    static void Main()
    {

        int[] numbers = {
                           5, 14, 3, 20,1
                        };

        int sum = 19;
        bool[,] possibleSums = new bool[numbers.Length, sum + 1];
        bool[,] isCalculated = new bool[numbers.Length, sum + 1];


        bool result = CalcPossibleSums(numbers, possibleSums, isCalculated, numbers.Length - 1, sum);
        Console.WriteLine(result);

        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            if (CalcPossibleSums(numbers, possibleSums, isCalculated, i - 1, sum - numbers[i]))
            {
                sum -= numbers[i];
                Console.Write(numbers[i] + " ");
            }
            else if (numbers[i] == sum)
            {
                Console.Write(numbers[i] + " ");
                sum -= numbers[i];
            }

            if (sum == 0)
            {
                break;
            }
        }
    }

    private static bool CalcPossibleSums(int[] numbers, bool[,] possibleSums,
        bool[,] isCalculated, int index, int sum)
    {
        if (index < 0 || sum < 0)
        {
            return false;
        }

        if (sum == numbers[index])
        {
            return true;
        }

        if (isCalculated[index, sum])
        {
            return possibleSums[index, sum];
        }

        possibleSums[index, sum] = CalcPossibleSums(numbers, possibleSums, isCalculated, index - 1, sum)
            || CalcPossibleSums(numbers, possibleSums, isCalculated, index - 1, sum - numbers[index]);

        isCalculated[index, sum] = true;
        return possibleSums[index, sum];
    }
}

