//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.


using System;


class IsLeapYear
{
    static void Main()
    {
        Console.Write("Enter year = ");
        int year = int.Parse(Console.ReadLine());
        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("{0} year is leap.",year);
        }
        else
        {
            Console.WriteLine("{0} year isn't leap.", year);
        }
    }
}

