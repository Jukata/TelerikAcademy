using System;
//* Write a program that converts a number in the range [0...999] 
//to a text corresponding to its English pronunciation. Examples:
//	0  "Zero"
//	273  "Two hundred seventy three"
//	400  "Four hundred"
//	501  "Five hundred and one"
//	711  "Seven hundred and eleven"

class PrintNumbersInEnglish
{
    static void Main()
    {
        Console.Write("Enter number [0...900]: ");
        int inputNum;
        if (int.TryParse(Console.ReadLine(), out inputNum) && inputNum >= 0 && inputNum <= 999)
        {
            if (inputNum < 20)
            {
                switch (inputNum % 100)
                {
                    case 0: Console.Write("Zero"); break;
                    case 1: Console.Write("One"); break;
                    case 2: Console.Write("Two"); break;
                    case 3: Console.Write("Three"); break;
                    case 4: Console.Write("Four"); break;
                    case 5: Console.Write("Five"); break;
                    case 6: Console.Write("Six"); break;
                    case 7: Console.Write("Seven"); break;
                    case 8: Console.Write("Eight"); break;
                    case 9: Console.Write("Nine"); break;
                    case 10: Console.Write("Ten"); break;
                    case 11: Console.Write("Eleven"); break;
                    case 12: Console.Write("Twelve"); break;
                    case 13: Console.Write("Thirteen"); break;
                    case 14: Console.Write("Fourteen"); break;
                    case 15: Console.Write("Fifteen"); break;
                    case 16: Console.Write("Sixteen"); break;
                    case 17: Console.Write("Seventeen"); break;
                    case 18: Console.Write("Eighteen"); break;
                    case 19: Console.Write("Nineteen"); break;
                    default: Console.WriteLine("Error!"); break;
                }
            }
            else
            {
                switch (inputNum / 100)
                {
                    case 0: break;
                    case 1: Console.Write("One hundred "); break;
                    case 2: Console.Write("Two hundred "); break;
                    case 3: Console.Write("Three hundred "); break;
                    case 4: Console.Write("Four hundred "); break;
                    case 5: Console.Write("Five hundred "); break;
                    case 6: Console.Write("Six hundred "); break;
                    case 7: Console.Write("Seven hundred "); break;
                    case 8: Console.Write("Eight hundred "); break;
                    case 9: Console.Write("Nine hundred "); break;
                    default: Console.WriteLine("Error!"); break;
                }
                if (inputNum % 100 < 20)
                {
                    switch (inputNum % 100)
                    {
                        case 0: break;
                        case 1: Console.Write("and one"); break;
                        case 2: Console.Write("and two"); break;
                        case 3: Console.Write("and three"); break;
                        case 4: Console.Write("and four"); break;
                        case 5: Console.Write("and five"); break;
                        case 6: Console.Write("and six"); break;
                        case 7: Console.Write("and seven"); break;
                        case 8: Console.Write("and eight"); break;
                        case 9: Console.Write("and nine"); break;
                        case 10: Console.Write("and ten"); break;
                        case 11: Console.Write("and eleven"); break;
                        case 12: Console.Write("and twelve"); break;
                        case 13: Console.Write("and thirteen"); break;
                        case 14: Console.Write("and fourteen"); break;
                        case 15: Console.Write("and fifteen"); break;
                        case 16: Console.Write("and sixteen"); break;
                        case 17: Console.Write("and seventeen"); break;
                        case 18: Console.Write("and eighteen"); break;
                        case 19: Console.Write("and nineteen"); break;
                        default: Console.WriteLine("Error!"); break;
                    }
                }
                else
                {
                    switch ((inputNum % 100) / 10)
                    {
                        case 0: break;
                        case 1: break;
                        case 2: Console.Write("twenty "); break;
                        case 3: Console.Write("thirty "); break;
                        case 4: Console.Write("fourty "); break;
                        case 5: Console.Write("fifty "); break;
                        case 6: Console.Write("sixty "); break;
                        case 7: Console.Write("seventy "); break;
                        case 8: Console.Write("eighty "); break;
                        case 9: Console.Write("ninety "); break;
                        default: Console.Write("Error!"); break;
                    }

                    switch (inputNum % 10)
                    {
                        case 0: break;
                        case 1: Console.Write("one"); break;
                        case 2: Console.Write("two"); break;
                        case 3: Console.Write("three"); break;
                        case 4: Console.Write("four"); break;
                        case 5: Console.Write("five"); break;
                        case 6: Console.Write("six"); break;
                        case 7: Console.Write("seven"); break;
                        case 8: Console.Write("eight"); break;
                        case 9: Console.Write("nine"); break;
                        default: Console.WriteLine("Error!"); break;
                    }
                }
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Input error!");
        }
    }
}

