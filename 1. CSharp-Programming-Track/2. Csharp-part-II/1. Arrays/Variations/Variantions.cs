//Write a program that reads two numbers N and K and generates 
//all the variations of K elements from the set [1..N]. Example:
//	N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
// N = 4 k = 3 -> 111


using System;

class Variantions
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter k = ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];
        VariantionsMethod(array, 0, n);
    }

    static void VariantionsMethod(int[] array, int k, int n)
    {
        if (k == array.Length)
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("}");
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                array[k] = i + 1;
                VariantionsMethod(array, k+1, n);
            }
        }
    }
}

