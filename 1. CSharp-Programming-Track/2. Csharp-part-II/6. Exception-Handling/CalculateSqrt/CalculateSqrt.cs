//Write a program that reads an integer number and calculates and 
//prints its square root. If the number is invalid or negative, print "Invalid number".
//In all cases finally print "Good bye". Use try-catch-finally.

using System;

class CalculateSqrt
{
    static void Main()
    {
        Console.Write("Enter non-negative integer number = ");
        try
        {
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine("Sqrt({0}) = {1}", number, Sqrt(number));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Too big number.");
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }

    static double Sqrt(double number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Sqrt for negative numbers is undefined!");
        }
        else
        {
            return Math.Sqrt(number);
        }
    }
}

