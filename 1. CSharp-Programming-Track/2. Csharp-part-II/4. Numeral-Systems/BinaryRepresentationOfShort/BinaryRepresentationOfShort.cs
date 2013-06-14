//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short

using System;


class BinaryRepresentationOfShort
{
    static void Main()
    {
        Console.Write("Enter short number = ");
        short number = short.Parse(Console.ReadLine());
        string binaryNubmer = "";
        for (int i = 0; i < 16; i++)
        {
            binaryNubmer = (number >> i & 1) + binaryNubmer;
        }
        Console.WriteLine("Bits representation:");
        Console.WriteLine(binaryNubmer);

        //int[] remainders = new int[16];
        //string remainder = "";
        //if (number < 0)
        //{
        //    remainders[15] = 1;
        //    number *= -1;
        //    number -= 1;
        //    do
        //    {
        //        remainder += number % 2;
        //        number /= 2;
        //    } while (number > 0);
        //    for (int i = 0, j = remainder.Length - 1; i < remainders.Length; i++, j--) // TO DO HERE
        //    {
        //        if (j >= 0)
        //        {
        //            if (remainder[j] == int.Parse('1'.ToString()))
        //            {
        //                remainders[i] = 0;
        //            }
        //            else
        //            {
        //                remainders[i] = 1;
        //            }
        //        }
        //        else
        //        {
        //            remainders[i] = 1;
        //        }
        //    }
        //}
        //else
        //{
        //    remainders[15] = 0;
        //    do
        //    {
        //        remainder += (char)(number % 2);
        //        number /= 2;
        //    } while (number > 0);
        //    for (int i = remainder.Length - 1; i >= 0; i--)
        //    {
        //        remainders[i] = remainder[i];
        //    }
        //}
        //Console.WriteLine("Bits representation: ");
        //for (int i = remainders.Length - 1; i >= 0; i--)
        //{
        //    Console.Write(remainders[i]);
        //}
        //Console.WriteLine();
    }
}
