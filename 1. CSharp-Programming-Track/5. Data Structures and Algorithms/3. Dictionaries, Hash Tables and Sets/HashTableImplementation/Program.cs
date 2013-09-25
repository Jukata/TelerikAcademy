using System;
using Collections;

class Program
{
    static void Main()
    {
        HashTable<string, int> hash = new HashTable<string, int>(32);

        hash.Add("Pesho", 6);
        hash.Add("Pesho", 6);
        hash.Add("Pesho", 3);
        hash.Add("Gosho", 9);
        hash.Add("Tosho", 4);
        hash.Add("Viko", 7);
        hash.Add("Viko", 7);
        hash.Add("high 5", 7);
        hash["Johnatan"] = 3333;
        hash["viko"] = 1111111;
        hash.Remove("Tosho");

        foreach (var item in hash)
        {
            Console.WriteLine("{0} -> {1}", item.Key, item.Value);
        }

        hash.Clear();

        foreach (var item in hash)
        {
            Console.WriteLine("{0} -> {1}", item.Key, item.Value);
        }
    }
}

