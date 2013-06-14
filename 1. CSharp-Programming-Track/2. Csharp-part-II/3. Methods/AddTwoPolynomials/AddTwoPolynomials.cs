//Write a method that adds two polynomials. Represent them as arrays 
//of their coefficients as in the example below:
//		x^2 + 5 = 1x^2 + 0x + 5 --> 5 0 1

using System;

class AddTwoPolynomials
{
    static void Main()
    {
        //hardcoded input
        //int[] firstPolynomial = { 5, 4, 1 };
        //int[] secondPolynomial = { 1,5, 4, 1 };

        //user input
        Console.Write("What is the power of first polynom? ");
        int length = int.Parse(Console.ReadLine());
        int[] firstPolynomial = new int[length + 1];
        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            Console.Write("Enter coefficent for x^{0} = ", i);
            firstPolynomial[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("What is the power of second polynom? ");
        length = int.Parse(Console.ReadLine());
        int[] secondPolynomial = new int[length + 1];
        for (int i = 0; i < secondPolynomial.Length; i++)
        {
            Console.Write("Enter coefficent for x^{0} = ", i);
            secondPolynomial[i] = int.Parse(Console.ReadLine());
        }

        int[] result = AddPolynomials(firstPolynomial, secondPolynomial);
        PrintPolynomial(firstPolynomial);
        Console.WriteLine("+");
        PrintPolynomial(secondPolynomial);
        Console.WriteLine(new string('-', 40));
        PrintPolynomial(result);
        Console.WriteLine();

        result = SubstractPolynomials(firstPolynomial, secondPolynomial);
        PrintPolynomial(firstPolynomial);
        Console.WriteLine("-");
        PrintPolynomial(secondPolynomial);
        Console.WriteLine(new string('-', 40));
        PrintPolynomial(result);
        Console.WriteLine();

        result = MultiplyPolynomials(firstPolynomial, secondPolynomial);
        PrintPolynomial(firstPolynomial);
        Console.WriteLine("*");
        PrintPolynomial(secondPolynomial);
        Console.WriteLine(new string('-', 40));
        PrintPolynomial(result);
        Console.WriteLine();
    }

    static void PrintPolynomial(int[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (polynomial[i] == 0)
            {
                continue;
            }
            if (i == 0)
            {
                Console.WriteLine(polynomial[i]);
                break;
            }
            Console.Write("{0}x^{1} + ", polynomial[i], i);
        }
    }

    static int[] AddPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int[] result = new int[Math.Max(firstPolynomial.Length, secondPolynomial.Length)];
        for (int i = 0; i < result.Length; i++)
        {
            if (i < firstPolynomial.Length && i < secondPolynomial.Length)
            {
                result[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            else if (i < firstPolynomial.Length)
            {
                result[i] = firstPolynomial[i];
            }
            else
            {
                result[i] = secondPolynomial[i];
            }
        }
        return result;
    }

    static int[] SubstractPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int[] result = new int[Math.Max(firstPolynomial.Length, secondPolynomial.Length)];
        for (int i = 0; i < result.Length; i++)
        {
            if (i < firstPolynomial.Length && i < secondPolynomial.Length)
            {
                result[i] = firstPolynomial[i] - secondPolynomial[i];
            }
            else if (i < firstPolynomial.Length)
            {
                result[i] = firstPolynomial[i];
            }
            else
            {
                result[i] = 0 - secondPolynomial[i];
            }
        }
        return result;
    }

    static int[] MultiplyPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int[] result = new int[firstPolynomial.Length + secondPolynomial.Length];
        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            for (int j = 0; j < secondPolynomial.Length; j++)
            {
                result[i + j] = firstPolynomial[i] * secondPolynomial[j] + result[i + j];
            }
        }
        return result;
    }
}

