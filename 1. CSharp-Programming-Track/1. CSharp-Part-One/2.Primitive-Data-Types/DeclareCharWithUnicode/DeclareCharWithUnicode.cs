﻿using System;
//Declare a character variable and assign it with the symbol that has Unicode code 72.
//Hint: first use the Windows Calculator to find the hexadecimal representation of 72.


class DeclareCharWithUnicode
{
    static void Main()
    {
        char someChar = '\u0048';
        Console.WriteLine(someChar);
    }
}

