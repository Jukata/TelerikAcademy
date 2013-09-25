using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        MultiBiDictionary<string, string, int> teachers = new MultiBiDictionary<string, string, int>(true);

        teachers.Add("Svetlin", "Nakov", 12);
        teachers.Add("Preslav", "Nakov", 22);
        teachers.Add("Preslav", "Nakov", 33);
        teachers.Add("Svetlin", "Minkov", 9);
        teachers.Add("Svetlin", "Minkov", 112);
        teachers.Add("Doncho", "Minkov", 13);
        teachers.Add("Niki", "Minkov", 3);
        teachers.Add("Niki", "Kostov", 3);
        teachers.Add("Niki", "Minkov", 3);
        teachers.Add("Svetlin", "Nakov", 15);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Total count -> {0}", teachers.Count);
        Console.ForegroundColor = ConsoleColor.Gray;

        ICollection<int> svetlinsTeachers = teachers.GetValuesByFirstKey("Svetlin");
        Console.WriteLine("Svetlins -> {0}", string.Join(", ", svetlinsTeachers));

        ICollection<int> nakovsTeachers = teachers.GetValuesBySecondKey("Nakov");
        Console.WriteLine("Nakovs -> {0}", string.Join(", ", nakovsTeachers));

        ICollection<int> svetlinNakovsTeachers = teachers.GetValuesByBothKeys("Svetlin", "Nakov");
        Console.WriteLine("Svetlin Nakovs -> {0}", string.Join(", ", svetlinNakovsTeachers));

        teachers.RemoveValueByFirstKey("Svetlin");
        Console.WriteLine("After remove of svetlin key");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Total count -> {0}", teachers.Count);
        Console.ForegroundColor = ConsoleColor.Gray;
        svetlinsTeachers = teachers.GetValuesByFirstKey("Svetlin");
        Console.WriteLine("Svetlins -> {0}", string.Join(", ", svetlinsTeachers));

        teachers.RemoveValueBySecondKey("Nakov");
        Console.WriteLine("After remove of nakov key");
        nakovsTeachers = teachers.GetValuesBySecondKey("Nakov");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Total count -> {0}", teachers.Count);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Nakovs -> {0}", string.Join(", ", nakovsTeachers));

        ICollection<int> nikiMinkovsTeachers = teachers.GetValuesByBothKeys("Niki", "Minkov");
        Console.WriteLine("Niki Minkovs -> {0}", string.Join(", ", svetlinNakovsTeachers));
        teachers.RemoveValueByBothKeys("Niki", "Minkov");
        Console.WriteLine("After remove of Niki Minkov keys");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Total count -> {0}", teachers.Count);
        Console.ForegroundColor = ConsoleColor.Gray;
        nikiMinkovsTeachers = teachers.GetValuesByBothKeys("Niki", "Minkov");
        Console.WriteLine("Niki Minkovs -> {0}", string.Join(", ", nikiMinkovsTeachers));

    }
}
