//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

class ExtratAllDates
{
    static void Main()
    {
        string text = " 12.23.2012 23.12.2012 Write 05.05.05 a program 5.4.2012 05.04.2012 29.02.2013 29.02.2012 that extracts 3.3.3 from 23/12/2012 a given text all dates that match the format DD.MM.YYYY";
        MatchCollection dates = Regex.Matches(text, @"[\d]{1,2}\.[\d]{1,2}.[\d]{4}");
        foreach (Match item in dates)
        {
            DateTime date = new DateTime();
            bool isValidDate = DateTime.TryParseExact(item.Value, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (isValidDate)
            {
                Console.WriteLine("{0}", date.ToString(new CultureInfo("fr-CA")));
            }
        }
    }
}

