// Write a program to compare the performance of add, subtract, 
// increment, multiply, divide for int, long, float, double and decimal values.
//Write a program to compare the performance of square root,
//natural logarithm, sinus for float, double and decimal values.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MathOperationsPerformanceForDiffTypes
{
    public class Program
    {
        private static SortedDictionary<TimeSpan, string> timesPerType = new SortedDictionary<TimeSpan, string>();

        static void Main()
        {
            string separator = new string('-', 40);
            int attempts = 15000000; // 15 000 000

            AddPerformanceCheck(attempts);
            Console.WriteLine(separator);
            SubtractPerformanceCheck(attempts);
            Console.WriteLine(separator);
            IncrementPerformanceCheck(attempts);
            Console.WriteLine(separator);
            MultiplyPerformanceCheck(attempts);
            Console.WriteLine(separator);
            DividePerformanceCheck(attempts);
            Console.WriteLine(separator);

            attempts = 15000000; // 15 000 000
            Console.WriteLine(separator);
            SqrtPerformanceCheck(attempts);
            Console.WriteLine(separator);
            LogPerformanceCheck(attempts);
            Console.WriteLine(separator);
            SinPerformanceCheck(attempts);
        }

        private static void AddPerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Add ints
            timer.Start();
            for (int i = 0; i < attempts; i++)
            {
                AddMethods.Add(i, i);
            }
            timer.Stop();
            Console.WriteLine("Add {0} ints time = {1}", attempts, timer.Elapsed);

            // Add longs
            timer.Reset();
            timer.Start();
            for (long i = 0; i < attempts; i++)
            {
                AddMethods.Add(i, i);
            }
            timer.Stop();
            Console.WriteLine("Add {0} longs time = {1}", attempts, timer.Elapsed);

            // Add doubles
            timer.Reset();
            timer.Start();
            for (double i = 0; i < attempts; i++)
            {
                AddMethods.Add(i, i);
            }
            timer.Stop();
            Console.WriteLine("Add {0} doubles time = {1}", attempts, timer.Elapsed);

            // Add decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 0; i < attempts; i++)
            {
                AddMethods.Add(i, i);
            }
            timer.Stop();
            Console.WriteLine("Add {0} decimals time = {1}", attempts, timer.Elapsed);
        }

        private static void SubtractPerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Subtract ints
            timer.Start();
            for (int i = 0; i < attempts; i++)
            {
                SubtractMethods.Subtract(i, i);
            }
            timer.Stop();
            Console.WriteLine("Subtract {0} ints time = {1}", attempts, timer.Elapsed);

            // Subtract longs
            timer.Reset();
            timer.Start();
            for (long i = 0; i < attempts; i++)
            {
                SubtractMethods.Subtract(i, i);
            }
            timer.Stop();
            Console.WriteLine("Subtract {0} longs time = {1}", attempts, timer.Elapsed);

            // Subtract doubles
            timer.Reset();
            timer.Start();
            for (double i = 0; i < attempts; i++)
            {
                SubtractMethods.Subtract(i, i);
            }
            timer.Stop();
            Console.WriteLine("Subtract {0} doubles time = {1}", attempts, timer.Elapsed);

            // Subtract decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 0; i < attempts; i++)
            {
                SubtractMethods.Subtract(i, i);
            }
            timer.Stop();
            Console.WriteLine("Subtract {0} decimals time = {1}", attempts, timer.Elapsed);
        }

        private static void IncrementPerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Increment ints
            timer.Start();
            for (int i = 0; i < attempts; i++)
            {
            }
            timer.Stop();
            Console.WriteLine("Increment {0} ints time = {1}", attempts, timer.Elapsed);

            // Increment longs
            timer.Reset();
            timer.Start();
            for (long i = 0; i < attempts; i++)
            {
            }
            timer.Stop();
            Console.WriteLine("Increment {0} longs time = {1}", attempts, timer.Elapsed);

            // Increment doubles
            timer.Reset();
            timer.Start();
            for (double i = 0; i < attempts; i++)
            {
            }
            timer.Stop();
            Console.WriteLine("Increment {0} doubles time = {1}", attempts, timer.Elapsed);

            // Increment decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 0; i < attempts; i++)
            {
            }
            timer.Stop();
            Console.WriteLine("Increment {0} decimals time = {1}", attempts, timer.Elapsed);
        }

        private static void MultiplyPerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Multiply ints
            timer.Start();
            for (int i = 0; i < attempts; i++)
            {
                MultiplyMethods.Multiply(i, i);
            }
            timer.Stop();
            Console.WriteLine("Multiply {0} ints time = {1}", attempts, timer.Elapsed);

            // Multiply longs
            timer.Reset();
            timer.Start();
            for (long i = 0; i < attempts; i++)
            {
                MultiplyMethods.Multiply(i, i);
            }
            timer.Stop();
            Console.WriteLine("Multiply {0} longs time = {1}", attempts, timer.Elapsed);

            // Multiply doubles
            timer.Reset();
            timer.Start();
            for (double i = 0; i < attempts; i++)
            {
                MultiplyMethods.Multiply(i, i);
            }
            timer.Stop();
            Console.WriteLine("Multiply {0} doubles time = {1}", attempts, timer.Elapsed);

            // Multiply decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 0; i < attempts; i++)
            {
                MultiplyMethods.Multiply(i, i);
            }
            timer.Stop();
            Console.WriteLine("Multiply {0} decimals time = {1}", attempts, timer.Elapsed);
        }

        private static void DividePerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Divide ints
            timer.Start();
            for (int i = 1; i < attempts; i++)
            {
                DivideMethods.Divide(i, i);
            }
            timer.Stop();
            Console.WriteLine("Divide {0} ints time = {1}", attempts, timer.Elapsed);

            // Divide longs
            timer.Reset();
            timer.Start();
            for (long i = 1; i < attempts; i++)
            {
                DivideMethods.Divide(i, i);
            }
            timer.Stop();
            Console.WriteLine("Divide {0} longs time = {1}", attempts, timer.Elapsed);

            // Divide doubles
            timer.Reset();
            timer.Start();
            for (double i = 1; i < attempts; i++)
            {
                DivideMethods.Divide(i, i);
            }
            timer.Stop();
            Console.WriteLine("Divide {0} doubles time = {1}", attempts, timer.Elapsed);

            // Divide decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 1; i < attempts; i++)
            {
                DivideMethods.Divide(i, i);
            }
            timer.Stop();
            Console.WriteLine("Divide {0} decimals time = {1}", attempts, timer.Elapsed);
        }

        private static void SqrtPerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Sqrt floats
            timer.Reset();
            timer.Start();
            for (float i = 1; i < attempts; i++)
            {
                Math.Sqrt(i);
            }
            timer.Stop();
            Console.WriteLine("Sqrt {0} floats time = {1}", attempts, timer.Elapsed);

            // Sqrt doubles
            timer.Reset();
            timer.Start();
            for (double i = 1; i < attempts; i++)
            {
                Math.Sqrt(i);
            }
            timer.Stop();
            Console.WriteLine("Sqrt {0} doubles time = {1}", attempts, timer.Elapsed);

            // Sqrt decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 1; i < attempts; i++)
            {
                Math.Sqrt((double)i);
            }
            timer.Stop();
            Console.WriteLine("Sqrt {0} decimals time = {1}", attempts, timer.Elapsed);
        }

        private static void LogPerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Log floats
            timer.Reset();
            timer.Start();
            for (float i = 1; i < attempts; i++)
            {
                Math.Log(i);
            }
            timer.Stop();
            Console.WriteLine("Log {0} floats time = {1}", attempts, timer.Elapsed);

            // Log doubles
            timer.Reset();
            timer.Start();
            for (double i = 1; i < attempts; i++)
            {
                Math.Log(i);
            }
            timer.Stop();
            Console.WriteLine("Log {0} doubles time = {1}", attempts, timer.Elapsed);

            // Log decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 1; i < attempts; i++)
            {
                Math.Log((double)i);
            }
            timer.Stop();
            Console.WriteLine("Log {0} decimals time = {1}", attempts, timer.Elapsed);
        }

        private static void SinPerformanceCheck(int attempts)
        {
            Stopwatch timer = new Stopwatch();

            // Sin floats
            timer.Reset();
            timer.Start();
            for (float i = 1; i < attempts; i++)
            {
                Math.Sin(i);
            }
            timer.Stop();
            Console.WriteLine("Sin {0} floats time = {1}", attempts, timer.Elapsed);

            // Sin doubles
            timer.Reset();
            timer.Start();
            for (double i = 1; i < attempts; i++)
            {
                Math.Sin(i);
            }
            timer.Stop();
            Console.WriteLine("Sin {0} doubles time = {1}", attempts, timer.Elapsed);

            // Sin decimals
            timer.Reset();
            timer.Start();
            for (decimal i = 1; i < attempts; i++)
            {
                Math.Sin((double)i);
            }
            timer.Stop();
            Console.WriteLine("Sin {0} decimals time = {1}", attempts, timer.Elapsed);
        }
    }
}
