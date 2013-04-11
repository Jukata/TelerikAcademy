using System;
//Write a program that, depending on the user's choice inputs
//int, double or string variable. If the variable is integer or double,
//increases it with 1. If the variable is string, appends "*" at its end. 
//The program must show the value of that variable as a console output. Use switch statement.


class ChooseVariableType
{
    static void Main()
    {
        Console.WriteLine("Choose the type of variable:");
        Console.WriteLine("1. Int");
        Console.WriteLine("2. Double");
        Console.WriteLine("3. String");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                {
                    Console.Write("Enter value for integer:");
                    int inputInt = int.Parse(Console.ReadLine());
                    inputInt++;
                    Console.WriteLine(inputInt);
                    break;
                }
            case 2:
                {
                    Console.Write("Enter value for double:");
                    double inputDouble = double.Parse(Console.ReadLine());
                    inputDouble++;
                    Console.WriteLine(inputDouble);
                    break;
                }
            case 3:
                {
                    Console.Write("Enter string:");
                    string inputStr = Console.ReadLine();
                    inputStr += "*";
                    Console.WriteLine(inputStr);
                    break;
                }
            default: Console.WriteLine("Wrong choice"); break;
        }
    }
}

