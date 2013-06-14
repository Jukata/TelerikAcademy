//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//Example: The target substring is "in". The text is as follows:
//We are living in an yellow submarine. We don't have anything else. 
//Inside the submarine is very tight. So we are drinking all the day.
//We will move out of it in 5 days.
//The result is: 9.

using System;

class SubstringCount
{
    static void Main()
    {
        string target = "in";
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        Console.WriteLine("The result is: {0}", CountSubstrings(text, target, false));
    }

    static int CountSubstrings(string text, string target, bool caseSensitive)
    {
        if (!caseSensitive)
        {
            text = text.ToLower();
            target = target.ToLower();
        }

        int count = 0;
        int index = text.IndexOf(target);
        while (index != -1)
        {
            count++;
            index = text.IndexOf(target, index + 1);
        }
        return count;
    }
}

