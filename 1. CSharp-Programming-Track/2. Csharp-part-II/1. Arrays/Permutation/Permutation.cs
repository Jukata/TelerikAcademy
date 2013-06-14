//* Write a program that reads a number N and generates and 
//prints all the permutations of the numbers [1 … N]. Example:
//	n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}


using System;

class Permutation
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }
        PermutationMethod(array, 0, array.Length - 1);
        // pertmuation(arr);
        //for i>n
        // arr[0] swap 
        // permutation(arr);
    }

    private static void PermutationMethod(int[] array, int start, int end)
    {
        if (start == end)
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("}");
        }
        int[] permutatedArray = (int[])array.Clone();
        for (int i = start; i <= end; i++)
        {
            int changer = permutatedArray[start];
            permutatedArray[start] = permutatedArray[i];
            permutatedArray[i] = changer;
            PermutationMethod(permutatedArray, start + 1, end);
        }
    }
    
}

