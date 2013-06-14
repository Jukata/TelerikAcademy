using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.NamesInDescendingOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new[]
            {
                new{FirstName="Ivan",SecondName="Petrov"},
                new{FirstName="Petar",SecondName="Ivanov"},
                new{FirstName="Ivan",SecondName="Kirqkov"},
                new{FirstName="Misho",SecondName="Slivev"},
                new{FirstName="Bojo",SecondName="Banarev"},
                new{FirstName="Goro",SecondName="Nikolov"},
            };

            //with lamda expression
            var sort = students.OrderByDescending(student => student.FirstName).ThenByDescending(student=>student.SecondName);

            Console.WriteLine("Lamda expression:");
            foreach (var student in sort)
            {
                
                Console.WriteLine("{0} {1}",student.FirstName,student.SecondName);
            }

            Console.WriteLine();

            //with LINQ
            var sortedNames =
                from student in students
                orderby student.FirstName descending, student.SecondName descending
                select student;

            Console.WriteLine("LINQ:");
            foreach (var student in sortedNames)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.SecondName);
            }

        }
    }
}
