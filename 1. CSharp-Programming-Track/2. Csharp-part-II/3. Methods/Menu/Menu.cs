//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//		Create appropriate methods.
//		Provide a simple text-based menu for the user to choose which task to solve.
//		Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;

class Menu
{
    static void Main()
    {
        int choice = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Reverses the digits of a number.");
            Console.WriteLine("2. Calculates the average of a sequence of integers.");
            Console.WriteLine("3. Solves a linear equation a * x + b = 0.");
            Console.WriteLine("4. Exit.");
            do
            {
                Console.Write("Enter choice = ");
            } while (!(int.TryParse(Console.ReadLine(), out choice)) || choice < 1 || choice > 4);
            switch (choice)
            {
                case 1:
                    {
                        decimal number;
                        do
                        {
                            Console.Write("Enter non-negative number = ");
                        } while (!(decimal.TryParse(Console.ReadLine(), out number)) || number < 0);
                        number = ReverseDigits(number);
                        Console.WriteLine("Reversed number = {0}", number);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        int length;
                        do
                        {
                            Console.Write("Enter sequence length = ");
                        } while (!(int.TryParse(Console.ReadLine(), out length)) || length < 1);

                        int[] numbers = new int[length];
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            do
                            {
                                Console.Write("Enter numbers[{0}] = ", i);
                            } while (!(int.TryParse(Console.ReadLine(), out numbers[i])));
                        }
                        double averageNumber = CalcAverage(numbers);
                        Console.WriteLine("Average = {0}", averageNumber);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        double a;
                        do
                        {
                            Console.Write("Enter coefficient A = ");
                        } while (!(double.TryParse(Console.ReadLine(), out a)) || a == 0);
                        double b;
                        do
                        {
                            Console.Write("Enter coefficient B = ");
                        } while (!(double.TryParse(Console.ReadLine(), out b)));
                        double x = CalculateLinearEquation(a, b);
                        Console.WriteLine("The solution of equation {0}x + {1} = 0 is \nx={2}", a, b, x);

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                case 4: Console.WriteLine("Bye!"); break;
                default: Console.WriteLine("Error!"); break;
            }

        } while (choice != 4);
    }

    private static double CalculateLinearEquation(double a, double b)
    {
        double x;
        x = -b / a;
        return x;
    }

    private static double CalcAverage(int[] numbers)
    {
        double sum = 0;
        int count = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            count++;
        }
        return sum / count; // average
    }

    static decimal ReverseDigits(decimal number)
    {
        bool negative = false;
        if (number < 0)
        {
            number *= -1;
            negative = true;
        }
        char[] reversedNumber = number.ToString().ToCharArray();
        Array.Reverse(reversedNumber);
        number = decimal.Parse(new string(reversedNumber));

        if (negative)
        {
            number *= -1;
        }

        return number;
    }

}
