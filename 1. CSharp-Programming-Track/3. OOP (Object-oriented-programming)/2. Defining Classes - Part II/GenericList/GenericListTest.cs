using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericListTest
    {
        static void Main()
        {
            GenericList<string> myList = new GenericList<string>();
            Console.WriteLine(myList.Capacity);
            Console.WriteLine(myList.Count);
            Console.WriteLine(myList.Elements);
            myList.Add("1");
            myList.Add("2");

            myList.Add("3");
            myList.Add("4");
            myList.Add("Gosho");
            myList.RemoveAt(3);
            Console.WriteLine(myList.Capacity);
            Console.WriteLine(myList.Count);
            Console.WriteLine(myList.Elements);
            myList.InsertAt(0, "Viki");
            Console.WriteLine(myList.FindIndex("Viki"));
            Console.WriteLine(myList.FindIndex("1"));
            myList.InsertAt(0, "Viki");
            myList.InsertAt(5, "Viktor");
            myList.InsertAt(7, "Viktor");
            myList.Clear();
            myList.Add("Pesho");
        }
    }
}
