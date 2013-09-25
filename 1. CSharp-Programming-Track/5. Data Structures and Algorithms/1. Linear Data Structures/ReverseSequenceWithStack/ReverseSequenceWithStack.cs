using System;
using System.Collections.Generic;

class ReverseSequenceWithStack
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        Stack<int> numbers = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter next number: ");
            int number = int.Parse(Console.ReadLine());
            numbers.Push(number);
        }

        Console.WriteLine("Numbers in reversed order:");
        while (numbers.Count > 0)
        {
            Console.WriteLine(numbers.Pop());
        }
    }
}
