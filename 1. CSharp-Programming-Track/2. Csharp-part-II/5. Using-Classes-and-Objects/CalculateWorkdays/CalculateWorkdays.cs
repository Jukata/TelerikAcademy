//Write a method that calculates the number of workdays between today and given date,
//passed as parameter. Consider that workdays are all days from Monday to Friday 
//except a fixed list of public holidays specified preliminary as array.

using System;

class CalculateWorkdays
{
    static DateTime[] holidays = { new DateTime(2013, 01, 01),
                                   new DateTime(2013, 3, 3),
                                   new DateTime(2013, 5, 24),
                                   new DateTime(2013, 5, 6),
                                   new DateTime(2013, 5, 1),
                                   new DateTime(2013, 9, 6),
                                   new DateTime(2013, 9, 22), 
                                   new DateTime(2013, 11, 1), 
                                   new DateTime(2013, 12, 24),
                                   new DateTime(2013, 12, 25),
                                   new DateTime(2013, 12, 26),
                                   new DateTime(2013, 12, 31),
                                 };
    static void Main()
    {
        Console.Write("Enter year = ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Enter month = ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter day = ");
        int day = int.Parse(Console.ReadLine());
        DateTime inputDate = new DateTime(year, month, day);
        if (inputDate < DateTime.Today)
        {
            Console.WriteLine("The date should be after today. Workdays = 0.");
        }
        else
        {
            Console.WriteLine("Workdays = {0}", Workdays(DateTime.Today, inputDate));
        }
    }
    static int Workdays(DateTime today, DateTime givenDate)
    {
        int workdays = 0;
        do
        {
            today = today.AddDays(1);
            if (today.DayOfWeek != DayOfWeek.Saturday && today.DayOfWeek != DayOfWeek.Sunday)
            {
                bool isHolyday = false;
                for (int i = 0; i < holidays.Length; i++)
                {
                    if (today.Day == holidays[i].Day && today.Month == holidays[i].Month)
                    {
                        isHolyday = true;
                    }
                }
                if (!isHolyday)
                {
                    workdays++;
                }
            }
        } while (today != givenDate);
        return workdays;
    }
}

