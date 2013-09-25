using System;

class Program
{
    static void Main()
    {
        Stack<string> names = new Stack<string>(3);
        names.Push("Nakov");
        names.Push("Doncho");
        names.Push("Niki");


        Console.WriteLine(names);

        Console.WriteLine(names.Peek());

        Console.WriteLine(names.Pop());

        Console.WriteLine(names);

        names.Push("Joro");
        names.Push("Asya");
        names.Push("Ina");
        names.Push("Svetlin");
        names.Push("Kostov");
        names.Push("Minkov");
        names.Push("Georgiev");
        names.Push("Georgieva");
        names.Push("Dobrilova");

        Console.WriteLine(names);

    }
}