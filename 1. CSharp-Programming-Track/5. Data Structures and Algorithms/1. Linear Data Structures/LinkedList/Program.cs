using System;

class Program
{
    static void Main()
    {
        LinkedList<string> names = new LinkedList<string>();
        names.AddFirst("Nakov");
        names.AddLast("Doncho");
        names.AddLast("Niki");
        names.AddLast("Joro");

        Console.WriteLine(names);
    }
}