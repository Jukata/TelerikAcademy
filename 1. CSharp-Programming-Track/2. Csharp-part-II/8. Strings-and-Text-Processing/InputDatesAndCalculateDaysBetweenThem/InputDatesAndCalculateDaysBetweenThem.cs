//Write a program that reads two dates in the format: day.month.year 
//and calculates the number of days between them. Example:
//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2006
//Distance: 4 days

using System;
using System.Globalization;

class InputDatesAndCalculateDaysBetweenThem
{
    static void Main()
    {
        try
        {
            Console.Write("Enter first date: ");
            DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Enter second date: ");
            DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("First date - {0}", firstDate);
            Console.WriteLine("Second date - {0}", secondDate);
            Console.WriteLine("Days between them - {0}", Math.Abs((firstDate - secondDate).Days));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. The date must be in format d.MM.yyyy");
        }
    }
}
