using System;

class Program
{
    static void Main()
    {
        //test with problem in task 8 
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(2);
        for (int i = 1; i <= 50; i++)
        {
            int s = queue.Dequeue();

            queue.Enqueue(s + 1);
            queue.Enqueue(2 * s + 1);
            queue.Enqueue(s + 2);

            Console.WriteLine("{0}. {1}", i, s);
        }
    }
}

