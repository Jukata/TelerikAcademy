using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace InvalidRangeException
{
    class Program
    {
        //Write a sample application that demonstrates the InvalidRangeException<int>
        //and InvalidRangeException<DateTime> by entering numbers in the range
        //[1..100] and dates in the range [1.1.1980 … 31.12.2013].

        static void Main()
        {
            try
            {
                int startRange = 1;
                int endRange = 100;
                Console.WriteLine("Enter number in range [{0}..{1}]: ", startRange, endRange);
                int inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber < startRange || inputNumber > endRange)
                {
                    throw new InvalidRangeException<int>("Error", startRange, endRange);
                }
                else
                {
                    Console.WriteLine("Number is valid and in range[{0}..{1}].", startRange, endRange);
                }
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine(ire.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                DateTime startDate = new DateTime(1980, 1, 1);
                DateTime endDate = new DateTime(2013, 12, 31);
                Console.WriteLine("Enter date (dd.MM.yyyy) in range [{0:dd.MM.yyyy} ... {1:dd.MM.yyyy}]:", startDate, endDate);
                DateTime inputDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", new CultureInfo("bg-BG"));
                if (inputDate < startDate || inputDate > endDate)
                {
                    throw new InvalidRangeException<DateTime>("Error", startDate, endDate);
                }
                else
                {
                    Console.WriteLine("Date is valid and in range [{0:dd.MM.yyyy} ... {1:dd.MM.yyyy}].", startDate, endDate);
                }
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine(ire.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }
}
