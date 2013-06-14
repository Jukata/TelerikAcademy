//Write a method ReadNumber(int start, int end) that enters an integer number
//in given range [start…end]. If an invalid number or non-number text is entered,
//the method should throw an exception. Using this method write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class ReadNumbers
{
    static void Main()
    {
        int[] numbers = new int[10];
        int start = 1;
        int end = 91;
        for (int i = 0; i < 10; i++)
        {
            numbers[i] = ReadNumber(start, end);
            start = numbers[i];
            end++;
        }
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("a{0} = {1}", i + 1, numbers[i]);
        }
    }
    static int ReadNumber(int start, int end)
    {
        int number = 0;
        try
        {
            Console.Write("Enter number in interval [{0} ... {1}]: ", start, end);
            number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                string exceptionMessage = string.Format("Number not in interval [{0} ... {1}]", start, end);
                throw new ArgumentOutOfRangeException(exceptionMessage);
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid number.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Number isn't in correct format.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Number is too big.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return number;
    }
}

