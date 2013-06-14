using System;

namespace RefactorLoop
{
    public class Program
    {
        private static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            int numbersLength = 100;
            int[] numbers = GenerateRandomNumbers(numbersLength);

            int expectedValue = 42;
            bool found = false;
            for (int i = 0; i < numbersLength; i++)
            {
                Console.WriteLine(numbers[i]);
                if (i % 10 == 0 && numbers[i] == expectedValue)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine("{0} found.", expectedValue);
            }
            else
            {
                Console.WriteLine("{0} not found.", expectedValue);
            }
        }

        private static int[] GenerateRandomNumbers(int numbersLength, int min = 0, int max = 50)
        {
            int[] numbers = new int[numbersLength];

            for (int i = 0; i < numbersLength; i++)
            {
                numbers[i] = RandomGenerator.Next(min, max);
            }

            return numbers;
        }
    }
}
