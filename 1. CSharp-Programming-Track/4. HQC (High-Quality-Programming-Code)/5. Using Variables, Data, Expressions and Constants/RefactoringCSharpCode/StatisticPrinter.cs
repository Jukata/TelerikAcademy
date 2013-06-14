// ##########################################################
// # <copyright file="StatisticPrinter.cs" company="Telerik Academy">
// # Copyright (c) 2013 Telerik Academy. All rights reserved.
// # </copyright>
// ##########################################################
namespace RefactoringCSharpCode
{
    using System;

    /// <summary>
    /// Print aggregate statistic for sequence of numbers to console.
    /// </summary>
    internal class StatisticPrinter
    {
        /// <summary>
        /// Print aggregate statistic (Min, max, sum, average) for sequence of numbers to console.
        /// </summary>
        /// <param name="numbers">Numbers on which statistic is calculated.</param>
        public void PrintStatistics(double[] numbers)
        {
            double min = this.CalcMin(numbers);
            this.PrintMin(min);

            double max = this.CalcMax(numbers);
            this.PrintMax(max);

            double sum = this.CalcSum(numbers);
            this.PrintSum(sum);

            double avg = this.CalcAvg(numbers);
            this.PrintAvg(avg);
        }

        private double CalcMin(double[] numbers)
        {
            double min = double.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private double CalcMax(double[] numbers)
        {
            double max = double.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private double CalcSum(double[] numbers)
        {
            double sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private double CalcAvg(double[] numbers)
        {
            double avg = this.CalcSum(numbers) / numbers.Length;
            return avg;
        }

        private void PrintMin(double min)
        {
            Console.WriteLine("Minimal value in the array is {0}", min);
        }

        private void PrintMax(double max)
        {
            Console.WriteLine("Maximal value in the array is {0}", max);
        }

        private void PrintSum(double sum)
        {
            Console.WriteLine("Sum of all numbers in array is {0}", sum);
        }

        private void PrintAvg(double avg)
        {
            Console.WriteLine("Average value in the array is {0}", avg);
        }
    }
}
