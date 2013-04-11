using System;
//Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

class FractionSum
{
    static void Main()
    {
        float sum=1;
        for (int i = 2; i <= 1000; i+=2)
        {
            sum += 1.0f / i;
            sum -= 1.0f / (i + 1);
        }
        Console.WriteLine(sum);


        //for (int i = 1; ; i++)
        //{
        //    if (Math.Abs(sum - (sum + 1.0f / i)) > 0.001)
        //    {
        //        sum += 1.0f / i;
        //    }
        //    else
        //    {
        //        break;
        //    }
        //    if (Math.Abs(sum - (sum - 1.0f / (i + 1))) > 0.001)
        //    {
        //        sum -= 1.0f / (i + 1);
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}
    }
}
