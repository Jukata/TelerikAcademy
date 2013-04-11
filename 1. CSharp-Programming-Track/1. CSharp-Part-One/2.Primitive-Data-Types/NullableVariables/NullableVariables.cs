using System;
//Create a program that assigns null values to an integer and to double variables.
//Try to print them on the console, try to add some values or the null literal to them and see the result.



class NullableVariables
{
    static void Main()
    {
        int? nullableInt = null;
        double? nullableDouble = null;
        Console.WriteLine(nullableInt+" "+nullableDouble);
        nullableInt = null + 1; // this is always null
        Console.WriteLine(nullableInt);
    }
}

