using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main()
        {
            Person somePerson = new Person("Pesho", 20);
            Person anotherPerson = new Person("Gosho");
            Person oneMorePerson = new Person("Tosho", 33);
            Console.WriteLine(somePerson);
            Console.WriteLine(oneMorePerson);
            Console.WriteLine(anotherPerson);
        }
    }
}
