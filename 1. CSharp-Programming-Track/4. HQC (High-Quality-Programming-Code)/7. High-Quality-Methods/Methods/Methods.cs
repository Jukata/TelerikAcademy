using System;

namespace Methods
{
    public class Methods
    {
        static void Main()
        {
            Console.WriteLine(MathUtils.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(MathUtils.NumberToDigit(5));

            Console.WriteLine(MathUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsRealNumber(1.3, 2);
            PrintAsPercent(0.75, 0);
            PrintRightAligned(2.30, 8);

            double x1 = 3;
            double y1 = -3;
            double x2 = 3;
            double y2 = 2.5;

            Console.WriteLine(MathUtils.CalcDistance(x1, y1, x2, y2));
            Console.WriteLine("Horizontal? " + MathUtils.IsHorizontalLine(y1, y2));
            Console.WriteLine("Vertical? " + MathUtils.IsVerticalLine(x1, x2));

            Student peter = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                OtherInfo = "From Sofia",
                BirthDate = new DateTime(1992, 03, 17)
            };

            Student stella = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova",
                OtherInfo = "From Vidin, gamer, high results",
                BirthDate = new DateTime(1993, 11, 03)
            };

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        private static void PrintAsRealNumber(double number, int precision)
        {
            string formatingString = "{0:F" + precision + "}";
            Console.WriteLine(formatingString, number);
        }

        private static void PrintAsPercent(double number, int precision)
        {
            string formatingString = "{0:P" + precision + "}";
            Console.WriteLine(formatingString, number);
        }

        private static void PrintRightAligned(double number, int totalWidth)
        {
            string formatingString = "{0," + totalWidth + "}";
            Console.WriteLine(formatingString, number);
        }
    }
}
