using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class Program
    {
        static void Main()
        {
            BitArray64 b = new BitArray64(8);
            Console.WriteLine(b.Value); // 8
            b[1] = 1;
            Console.WriteLine(b.Value); // 10
            b[3] = 0;
            Console.WriteLine(b.Value); // 2
            foreach (var bit in b)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
        }
    }
}
