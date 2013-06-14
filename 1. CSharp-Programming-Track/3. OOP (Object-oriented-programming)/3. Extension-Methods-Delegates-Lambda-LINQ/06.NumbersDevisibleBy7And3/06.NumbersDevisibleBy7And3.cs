using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.NumbersDevisibleBy7And3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 7, 14, 23, 6, 9, 8, 35, 21, 99, 147 };

            //with lamda expressions
            Console.WriteLine("With lamda expression:");
            var result = numbers.Where(number => number % 21 == 0);
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

            //with LINQ
            Console.WriteLine("With LINQ:");
            var searchedNumber =
                from num in numbers
                where num % 21 == 0
                select num;
            foreach (var number in searchedNumber)
            {
                Console.WriteLine(number);
            }

        }
    }
}
