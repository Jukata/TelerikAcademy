using System;

namespace Methods
{
    public class MathUtils
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides of triangle must be positive");
            }

            if (!FormTriangle(a, b, c))
            {
                throw new ArgumentException("The sides don't form triangle. Every side must be lower than sum of the other two.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static bool IsHorizontalLine(double y1, double y2)
        {
            return y1 == y2;
        }

        public static bool IsVerticalLine(double x1, double x2)
        {
            return x1 == x2;
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Input can't be null.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Input must contain at least one element.");
            }

            int max = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Input number is not a digit.");
            }
        }

        private static bool FormTriangle(double a, double b, double c)
        {
            bool result = a + b > c && a + c > b && b + c > a;
            return result;
        }
    }
}
