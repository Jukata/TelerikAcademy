//Write a program that reads a date and time given in the format: 
//day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes 
//(in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;

class InputDateAndCalculateAfterTime
{
    static void Main()
    {
        try
        {
            //string inputDate = "3.2.2013 23:05:55";
            //string inputDate = "1.1.2012 14:55:25";
            //DateTime date = DateTime.ParseExact(inputDate, "d.M.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            //user input
            Console.Write("Enter first date: ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Console.WriteLine("Input date - {0}", date.ToString(new CultureInfo("bg-BG")));
            date = date.AddHours(6.5);
            Console.WriteLine("Date after 6 hours and 30 minutes - {0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date.ToString(new CultureInfo("bg-BG")));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. The date must be in format d.M.yyyy HH:mm:ss ");
        }
    }
}
