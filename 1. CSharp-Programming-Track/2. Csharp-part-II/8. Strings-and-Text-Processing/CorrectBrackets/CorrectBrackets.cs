//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class CorrectBrackets
{
    static void Main()
    {
        string expression1 = "(a+b)+(a+(a+b)+(a+b)+c)+d";
        string expression2 = "((a+b)/5-d)";
        string expression3 = ")(a+b))";
        string expression4 = ")a-b(";
        string expression5 = "(a-b)+)a+b(-(a+b)";
        string expression6 = "(a+b+(c+d+(e+f+(g+h+(i+j)))))";
        string expression7 = "(a+b+(c+d+(e+f+(g+h+(i+j))))";
        Console.WriteLine("{0} -> {1}", expression1, CheckBrackets(expression1)); // true
        Console.WriteLine("{0} -> {1}", expression2, CheckBrackets(expression2)); // true
        Console.WriteLine("{0} -> {1}", expression3, CheckBrackets(expression3)); // false
        Console.WriteLine("{0} -> {1}", expression4, CheckBrackets(expression4)); // false
        Console.WriteLine("{0} -> {1}", expression5, CheckBrackets(expression5)); // false
        Console.WriteLine("{0} -> {1}", expression6, CheckBrackets(expression6)); // true
        Console.WriteLine("{0} -> {1}", expression7, CheckBrackets(expression7)); // false
    }

    static bool CheckBrackets(string expression)
    {
        Stack<char> brackets = new Stack<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {

                brackets.Push(expression[i]);
            }
            else if (expression[i] == ')')
            {
                if (brackets.Count < 1 || brackets.Pop() != '(')
                {
                    return false;
                }
            }
        }
        if (brackets.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

