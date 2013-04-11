using System;
//Declare two string variables and assign them with “Hello” and “World”.
//Declare an object variable and assign it with the concatenation of the
//first two variables (mind adding an interval). Declare a third string variable and initialize
//it with the value of the object variable (you should perform type casting).


class DeclareString
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "world!";
        object greetings = new object();
        greetings = firstString + " " + secondString;
        Console.WriteLine(greetings);
        string thirdString = greetings.ToString();
        Console.WriteLine(thirdString);
    }
}
