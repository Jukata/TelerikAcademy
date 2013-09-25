using System;

class Salaries
{
    static void Main()
    {
        int c = int.Parse(Console.ReadLine());

        bool[,] graph = new bool[c, c];

        for (int i = 0; i < c; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == 'Y')
                {
                    graph[i, j] = true;
                }
            }
        }

        long[] calculatedSalaries = new long[c];

        long result = 0;
        for (int i = 0; i < c; i++)
        {
            result += FindSalary(i, graph, calculatedSalaries);
        }

        Console.WriteLine(result);
    }

    private static long FindSalary(int employee, bool[,] graph, long[] calculatedSalaries)
    {
        if (calculatedSalaries[employee] > 0)
        {
            return calculatedSalaries[employee];
        }

        long currentSalary = 0;
        for (int i = 0; i < graph.GetLength(1); i++)
        {
            if (graph[employee, i])
            {
                currentSalary += FindSalary(i, graph, calculatedSalaries);
            }
        }

        if (currentSalary == 0)
        {
            currentSalary = 1;
        }

        calculatedSalaries[employee] = currentSalary;

        return currentSalary;
    }
}


