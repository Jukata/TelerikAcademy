using System;
using System.Collections.Generic;
using Collections;

class Program
{
    static void Main()
    {
        HashedSet<int> set = new HashedSet<int>();
        set.Add(5);
        set.Add(5);
        set.Add(6);
        set.Add(1);
        set.Add(3);
        set.Add(3);
        set.Add(8);
        set.Remove(6);

        Console.WriteLine("First set contains 6 - {0}", set.Contains(6));
        Console.WriteLine("First set contains 8 - {0}", set.Contains(8));

        Console.WriteLine("First set");
        foreach (var item in set)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

        Console.WriteLine("Second set");
        HashedSet<int> set2 = new HashedSet<int>();
        set2.Add(13);
        set2.Add(3);
        set2.Add(1);
        foreach (var item in set2)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

        HashedSet<int> union = set.UnionWith(set2);
        Console.WriteLine("Union: ");
        foreach (var item in union)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

        HashedSet<int> intersection = set.IntersectWith(set2);
        Console.WriteLine("Intersection: ");
        foreach (var item in intersection)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}
