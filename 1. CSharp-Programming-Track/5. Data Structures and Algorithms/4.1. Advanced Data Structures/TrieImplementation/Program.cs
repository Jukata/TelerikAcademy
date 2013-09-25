using System;

class Program
{
    static void Main()
    {
        Trie trie = new Trie();
        trie.Insert("Svetlin");
        trie.Insert("Nakov");
        trie.Insert("Niki");

        Console.WriteLine("Searching for svetlin -> {0}", trie.Search("svetlin"));
        Console.WriteLine("Searching for nakov -> {0}", trie.Search("nakov"));
        Console.WriteLine("Searching for Svetlin -> {0}", trie.Search("Svetlin"));
        Console.WriteLine("Searching for Nakov -> {0}", trie.Search("Nakov"));
        Console.WriteLine("Searching for Nik -> {0}", trie.Search("Nik"));
        Console.WriteLine("Searching for iki-> {0}", trie.Search("iki"));
        Console.WriteLine("Searching for Niki -> {0}", trie.Search("Niki"));
    }
}
