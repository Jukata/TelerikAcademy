using System;
using System.Collections.Generic;
using System.Text;

class ShortestSequenceOfOperations
{
    enum Operation
    {
        MultioplyByTwo,
        PlusTwo,
        PlusOne
    }

    static void Main()
    {
        Console.WriteLine("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter M: ");
        int m = int.Parse(Console.ReadLine());

        try
        {
            List<Operation> operations = GetShortestPath(n, m);
            PrintOperations(n, m, operations);

        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void PrintOperations(int n, int m, List<Operation> operations)
    {
        StringBuilder expression = new StringBuilder();
        expression.AppendFormat("N = {0}, M = {1}. Shortestpath: {2}", n, m, Environment.NewLine);

        for (int i = 0; i < operations.Count; i++)
        {
            switch (operations[i])
            {
                case Operation.MultioplyByTwo:
                    expression.AppendFormat("{0} * 2 = {1}{2}", n, n * 2, Environment.NewLine);
                    n *= 2;
                    break;
                case Operation.PlusTwo:
                    expression.AppendFormat("{0} + 2 = {1}{2}", n, n + 2, Environment.NewLine);
                    n += 2;
                    break;
                case Operation.PlusOne:
                    expression.AppendFormat("{0} + 1 = {1}{2}", n, n + 1, Environment.NewLine);
                    n += 1;
                    break;
            }
        }

        Console.WriteLine(expression);
    }

    private static List<Operation> GetShortestPath(int n, int m)
    {
        if (m <= n)
        {
            throw new ArgumentException("N must be smaller than M");
        }

        List<Operation> operations = new List<Operation>();
        if (n < 0)
        {
            while (n < 0)
            {
                if (n + 2 == m)
                {
                    operations.Add(Operation.PlusTwo);
                    return operations;
                }
                else if (n + 1 == m)
                {
                    operations.Add(Operation.PlusOne);
                    return operations;
                }

                n += 2;
                operations.Add(Operation.PlusTwo);
            }
        }

        operations.AddRange(GetShortestPathForPositiveN(n, m));
        return operations;
    }

    private static List<Operation> GetShortestPathForPositiveN(int n, int m)
    {
        List<Operation> operations = new List<Operation>();

        while (true)
        {
            // check if we can directly get the result
            if (m % 2 == 0 && m / 2 == n)
            {
                operations.Add(Operation.MultioplyByTwo);
                break;
            }
            else if (m - 2 == n)
            {
                operations.Add(Operation.PlusTwo);
                break;
            }
            else if (m - 1 == n)
            {
                operations.Add(Operation.PlusOne);
                break;
            }

            // divide by two isn't the shortest path
            if (m == 5 && n == 1)
            {
                operations.Add(Operation.PlusTwo);
                operations.Add(Operation.PlusTwo);
                break;
            }

            // proceed by shortest paath
            if (m % 2 == 0)
            {
                if (m / 2 > n)
                {
                    m /= 2;
                    operations.Add(Operation.MultioplyByTwo);
                }
                else
                {
                    m -= 2;
                    operations.Add(Operation.PlusTwo);
                }
            }
            else
            {
                m -= 1;
                operations.Add(Operation.PlusOne);
            }
        }

        operations.Reverse();
        return operations;
    }
}