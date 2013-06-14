using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SubstringToStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            str.Append("Abra cadabra sin salabim");
            int index = 1;
            int lenght = 7;
            Console.WriteLine(str.SubString(index,lenght).ToString());
            
        }
    }
}
