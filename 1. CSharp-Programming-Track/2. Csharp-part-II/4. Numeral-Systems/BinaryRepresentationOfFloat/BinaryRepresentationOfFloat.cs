//* Write a program that shows the internal binary representation of 
//given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
//Example: -27,25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

using System;

class FloatToBinary
{
    public static void Main()
    {

        Console.Write("Enter float number = ");
        float number = float.Parse(Console.ReadLine());

        string hexNumber = GetBytesFloat(number);
        string binaryNumber = "";
        hexNumber.ToUpper();
        for (int i = 0; i < hexNumber.Length; i++)
        {
            switch (hexNumber[i])
            {
                case '0': binaryNumber += "0000"; break;
                case '1': binaryNumber += "0001"; break;
                case '2': binaryNumber += "0010"; break;
                case '3': binaryNumber += "0011"; break;
                case '4': binaryNumber += "0100"; break;
                case '5': binaryNumber += "0101"; break;
                case '6': binaryNumber += "0110"; break;
                case '7': binaryNumber += "0111"; break;
                case '8': binaryNumber += "1000"; break;
                case '9': binaryNumber += "1001"; break;
                case 'A': binaryNumber += "1010"; break;
                case 'B': binaryNumber += "1011"; break;
                case 'C': binaryNumber += "1100"; break;
                case 'D': binaryNumber += "1101"; break;
                case 'E': binaryNumber += "1110"; break;
                case 'F': binaryNumber += "1111"; break;
            }
        }
        Console.WriteLine("Binary representation:");
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            if (i == 0)
            {
                Console.Write(" Sign = ");
            }
            if (i == 1)
            {
                Console.Write(" exponent = ");
            }
            if (i == 9)
            {
                Console.Write(" mantissa = ");
            }
            Console.Write(binaryNumber[i]);
        }
        Console.WriteLine();
    }

    static string GetBytesFloat(float number)
    {
        byte[] byteArray = BitConverter.GetBytes(number);
        Array.Reverse(byteArray);
        string result = BitConverter.ToString(byteArray);
        return result;
    }
}