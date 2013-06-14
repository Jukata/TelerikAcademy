//* Write a program to compare the performance of insertion sort, selection sort, quicksort 
//for int, double and string values. Check also the following cases: 
//random values, sorted values, values sorted in reversed order.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SortTests
{
    public class SortingTests
    {
        private static Random randomGenerator = new Random();
        private static Stopwatch timer = new Stopwatch();
        private static readonly string separator = new string('-', 40);
        private const string AllChars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz`1234567890-=~!@#$%^&*()_+[]{}'\"\\/.,<>";

        static void Main()
        {
            int numberOfElements = 10000;

            #region test with random values
            int[] intArray = GenerateRandomIntArray(numberOfElements, -1000, 1000);
            Console.WriteLine("Test random integers.");
            Console.WriteLine(separator);
            TestIntArray(intArray);
            Console.WriteLine();

            double[] doubleArray = GenerateRandomDoubleArray(numberOfElements, -1000, 1000);
            Console.WriteLine("Test random doubles.");
            Console.WriteLine(separator);
            TestDoubleArray(doubleArray);
            Console.WriteLine();

            string[] stringArray = GenerateRandomStringArray(numberOfElements, 0, 10);
            Console.WriteLine("Test random strings");
            Console.WriteLine(separator);
            TestStringArray(stringArray);
            Console.WriteLine();
            #endregion

            Console.WriteLine("Press any key to proceed with next test.");
            Console.ReadKey();
            Console.Clear();

            #region test with sorted 
            Array.Sort(intArray);
            Console.WriteLine("Test sorted integers.");
            Console.WriteLine(separator);
            TestIntArray(intArray);
            Console.WriteLine();

            Array.Sort(doubleArray);
            Console.WriteLine("Test sorted doubles.");
            Console.WriteLine(separator);
            TestDoubleArray(doubleArray);
            Console.WriteLine();

            Array.Sort(stringArray);
            Console.WriteLine("Test sorted strings");
            Console.WriteLine(separator);
            TestStringArray(stringArray);
            Console.WriteLine();
            #endregion

            Console.WriteLine("Press any key to proceed with next test.");
            Console.ReadKey();
            Console.Clear();

            #region test with reversed order
            Array.Reverse(intArray);
            Console.WriteLine("Test reversed integers.");
            Console.WriteLine(separator);
            TestIntArray(intArray);
            Console.WriteLine();

            Array.Reverse(doubleArray);
            Console.WriteLine("Test reversed doubles.");
            Console.WriteLine(separator);
            TestDoubleArray(doubleArray);
            Console.WriteLine();

            Array.Reverse(stringArray);
            Console.WriteLine("Test reversed strings");
            Console.WriteLine(separator);
            TestStringArray(stringArray);
            Console.WriteLine();
            #endregion

        }

        private static void TestIntArray(int[] array)
        {
            int length = array.Length;

            int[] arrayWrapper = new int[length];
            array.CopyTo(arrayWrapper, 0);

            Console.WriteLine("Number of elements: " + length);
            timer.Reset();
            timer.Start();
            InsertionSort(arrayWrapper);
            timer.Stop();
            Console.WriteLine("Insertion sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);

            array.CopyTo(arrayWrapper, 0);
            timer.Reset();
            timer.Start();
            SelectionSort(arrayWrapper);
            timer.Stop();
            Console.WriteLine("Selection sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);

            array.CopyTo(arrayWrapper, 0);
            timer.Reset();
            timer.Start();
            arrayWrapper = QuickSort(arrayWrapper.ToList()).ToArray();
            timer.Stop();
            Console.WriteLine("Quick sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);
        }

        private static void TestDoubleArray(double[] array)
        {
            int length = array.Length;

            double[] arrayWrapper = new double[length];
            array.CopyTo(arrayWrapper, 0);

            Console.WriteLine("Number of elements: " + length);
            timer.Reset();
            timer.Start();
            InsertionSort(arrayWrapper);
            timer.Stop();
            Console.WriteLine("Insertion sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);

            array.CopyTo(arrayWrapper, 0);
            timer.Reset();
            timer.Start();
            SelectionSort(arrayWrapper);
            timer.Stop();
            Console.WriteLine("Selection sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);

            array.CopyTo(arrayWrapper, 0);
            timer.Reset();
            timer.Start();
            arrayWrapper = QuickSort(arrayWrapper.ToList()).ToArray();
            timer.Stop();
            Console.WriteLine("Quick sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);
        }

        private static void TestStringArray(string[] array)
        {
            int length = array.Length;

            string[] arrayWrapper = new string[length];
            array.CopyTo(arrayWrapper, 0);

            Console.WriteLine("Number of elements: " + length);
            timer.Reset();
            timer.Start();
            InsertionSort(arrayWrapper);
            timer.Stop();
            Console.WriteLine("Insertion sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);

            array.CopyTo(arrayWrapper, 0);
            timer.Reset();
            timer.Start();
            SelectionSort(arrayWrapper);
            timer.Stop();
            Console.WriteLine("Selection sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);

            array.CopyTo(arrayWrapper, 0);
            timer.Reset();
            timer.Start();
            arrayWrapper = QuickSort(arrayWrapper.ToList()).ToArray();
            timer.Stop();
            Console.WriteLine("Quick sort time -> " + timer.Elapsed);
            Console.WriteLine(separator);
        }

        #region Generate randoms
        private static string[] GenerateRandomStringArray(int length, int minWordLength, int maxWordLength)
        {
            string[] randomStrings = new string[length];
            for (int i = 0; i < length; i++)
            {
                int wordLength = randomGenerator.Next(minWordLength, maxWordLength);
                randomStrings[i] = GenerateRandomString(wordLength);
            }

            return randomStrings;
        }

        private static string GenerateRandomString(int length)
        {

            char[] word = new char[length];
            for (int i = 0; i < length; i++)
            {
                int randomCharIndex = randomGenerator.Next(0, AllChars.Length);
                word[i] = AllChars[randomCharIndex];
            }

            return new string(word);
        }

        private static int[] GenerateRandomIntArray(int length, int minValue, int maxValue)
        {
            int[] randomValues = new int[length];
            for (int i = 0; i < length; i++)
            {
                randomValues[i] = randomGenerator.Next(minValue, maxValue);
            }

            return randomValues;
        }

        private static double[] GenerateRandomDoubleArray(int length, int minValue, int maxValue)
        {
            double[] randomValues = new double[length];
            for (int i = 0; i < length; i++)
            {
                randomValues[i] = minValue + randomGenerator.NextDouble() * (maxValue - minValue + 1);
            }

            return randomValues;
        }
        #endregion

        #region sorting methods
        private static void InsertionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T currElement = arr[i];
                int j;
                for (j = i; j > 0; j--)
                {
                    if (currElement.CompareTo(arr[j - 1]) < 0)
                    {
                        arr[j] = arr[j - 1];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j] = currElement;
            }
        }

        private static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                T minElement = arr[i];
                int minElementIndex = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(minElement) < 0)
                    {
                        minElement = arr[j];
                        minElementIndex = j;
                    }
                }
                arr[minElementIndex] = arr[i];
                arr[i] = minElement;
            }
        }

        private static List<T> QuickSort<T>(List<T> arr) where T : IComparable<T>
        {
            if (arr.Count < 2)
            {
                // sorted
                return arr;
            }

            int length = arr.Count;
            T pivot = arr[length / 2];

            List<T> less = new List<T>(length / 2);
            List<T> greater = new List<T>(length / 2);

            for (int i = 0; i < length; i++)
            {
                if (i == length / 2)
                {
                    continue;
                }

                if (arr[i].CompareTo(pivot) <= 0)
                {
                    less.Add(arr[i]);
                }
                else
                {
                    greater.Add(arr[i]);
                }
            }

            less = QuickSort(less);
            greater = QuickSort(greater);

            List<T> result = new List<T>(length);
            result.AddRange(less);
            result.Add(pivot);
            result.AddRange(greater);

            return result;
        }
        #endregion
    }
}
