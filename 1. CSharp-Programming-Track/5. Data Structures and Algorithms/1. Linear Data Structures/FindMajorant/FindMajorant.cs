using System;
using System.Collections.Generic;

class FindMajorant
{
    static void Main()
    {
        int[] numbers = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        Dictionary<int, int> numbersOccurrence = new Dictionary<int, int>();

        foreach (var number in numbers)
        {
            if (numbersOccurrence.ContainsKey(number))
            {
                numbersOccurrence[number]++;
            }
            else
            {
                numbersOccurrence.Add(number, 1);
            }
        }

        foreach (var item in numbersOccurrence)
        {
            if (item.Value > numbers.Length / 2)
            {
                Console.WriteLine("Majorant - {0} -> {1} times", item.Key, item.Value);
                return;
            }
        }

        Console.WriteLine("There isn't majorant in this collection.");


        // Stack implementation
        //Stack<int> stack = new Stack<int>();
        //foreach (int number in numbers)
        //{
        //    if (stack.Count == 0)
        //    {
        //        stack.Push(number);
        //    }

        //    if (number == stack.Peek())
        //    {
        //        stack.Push(number);
        //    }
        //    else
        //    {
        //        stack.Pop();
        //    }
        //}

        //if (stack.Count > 0)
        //{
        //    Console.WriteLine("Majorant - {0}", stack.Pop());
        //}
        //else
        //{
        //    Console.WriteLine("There isn't majorant in this collection.");
        //}
    }
}