using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Timer
{
    public delegate void ExecuteMethod(int seconds);

    public class Timer
    {
        static void Message(int seconds)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.Elapsed.TotalSeconds % seconds == 0)
                {
                    Console.WriteLine("Have a nice day! :)");
                }
            }
        }
    

        static void Main(string[] args)
        {

            ExecuteMethod timer = new ExecuteMethod(Message);
            timer(5);
        }
    }
}
