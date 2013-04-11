using System;
//Write an if statement that examines two integer variables
//and exchanges their values if the first one is greater than the second one.


class GreaterVariable
{
    static void Main()
    {
        int firstVariable = 13;
        int secondVariable = 3;
        if (firstVariable > secondVariable)
        {
            firstVariable = firstVariable + secondVariable;
            secondVariable = firstVariable - secondVariable;
            firstVariable = firstVariable - secondVariable;
        }
        Console.WriteLine("First number = {0}", firstVariable);
        Console.WriteLine("Second number = {0}", secondVariable);
    }
}

