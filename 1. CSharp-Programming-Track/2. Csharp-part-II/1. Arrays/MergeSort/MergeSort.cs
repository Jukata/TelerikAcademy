//* Write a program that sorts an array of integers 
//using the merge sort algorithm (find it in Wikipedia).

using System;

class MergeSort
{
    static void Main()
    {
        int[] array = { 7, -5, 14, 14, 13, 4, -5, 1, 6, 5, 4 };
        int[] sortedArray = MergeSortMethod(array);
        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.WriteLine(sortedArray[i]);
        }
    }

    static int[] MergeSortMethod(int[] array)
    {
        if (array.Length == 1)
        {
            return array;
        }
        else
        {
            int[] leftArray = new int[array.Length / 2];
            int[] rightArray = new int[array.Length - array.Length / 2];
            for (int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = array[i];
            }
            for (int i = 0; i < rightArray.Length; i++)
            {
                rightArray[i] = array[leftArray.Length + i];
            }
            leftArray = MergeSortMethod(leftArray);
            rightArray = MergeSortMethod(rightArray);

            return MergeArrays(leftArray, rightArray);
        }
    }

    static int[] MergeArrays(int[] leftArray, int[] rightArray)
    {
        int[] mergedArray = new int[leftArray.Length + rightArray.Length];
        int rightArrayIndex = 0;
        int leftArrayIndex = 0;
        for (int i = 0; i < mergedArray.Length; i++)
        {
            if (leftArrayIndex < leftArray.Length && rightArrayIndex < rightArray.Length)
            {
                if (leftArray[leftArrayIndex] < rightArray[rightArrayIndex])
                {
                    mergedArray[i] = leftArray[leftArrayIndex];
                    leftArrayIndex++;
                }
                else
                {
                    mergedArray[i] = rightArray[rightArrayIndex];
                    rightArrayIndex++;
                }
            }
            else
            {
                if (leftArrayIndex == leftArray.Length)
                {
                    mergedArray[i] = rightArray[rightArrayIndex];
                    rightArrayIndex++;
                }
                else
                {
                    mergedArray[i] = leftArray[leftArrayIndex];
                    leftArrayIndex++;
                }
            }
        }
        return mergedArray;
    }

}

