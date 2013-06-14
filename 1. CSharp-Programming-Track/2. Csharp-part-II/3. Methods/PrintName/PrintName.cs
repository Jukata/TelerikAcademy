//Write a method that asks the user for his name and prints “Hello, <name>” 
//(for example, “Hello, Peter!”). Write a program to test this method.

using System;

class PrintName
{
    static void Main()
    {
        string name = GetUserName();
        Console.WriteLine("Hello, {0}!", name);
    }

    static string GetUserName()
    {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        return name;
    }
}
