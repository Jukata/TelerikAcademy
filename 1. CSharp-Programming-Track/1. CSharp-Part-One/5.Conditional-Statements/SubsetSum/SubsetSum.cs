using System;
//We are given 5 integer numbers. Write a program that checks if 
//the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.

class SubsetSum
{
    static void Main() 
    {
        int sum = 0;
        Console.Write("Enter 1st number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter 2nd number:");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter 3rd number:");
        int thirdNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter 4th number:");
        int forthNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter 5th number:");
        int fifthNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    for (int m = 0; m < 2; m++)
                    {
                        for (int n = 0; n < 2; n++)
                        {
                            if (i != 0 || j != 0 || k != 0 || m != 0 || n != 0)
                            {
                                sum = 0;
                                sum += i * firstNumber + j * secondNumber + k * thirdNumber + m * forthNumber + n * fifthNumber;
                                if (sum == 0)
                                {
                                    Console.WriteLine("The sum of some subset = 0.");
                                    return;
                                }
                            }

                        }
                    }
                }
            }
        }
        Console.WriteLine("No subset with sum = 0.");
    }
}

