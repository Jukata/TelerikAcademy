using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindNamesByAges
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new[]
            {
                new{FirstName="Ivan",SecondName="Petrov",Age=24},
                new{FirstName="Petar",SecondName="Ivanov",Age=19},
                new{FirstName="Viki",SecondName="Kirqkov",Age=1},
                new{FirstName="Misho",SecondName="Slivev",Age=25},
                new{FirstName="Bojo",SecondName="Banarev",Age=20},
                new{FirstName="Goro",SecondName="Nikolov",Age=3},
            };

            var findNames =
                from student in students
                where student.Age > 18 && student.Age < 24
                select student;
            foreach (var student in findNames)
            {
                Console.WriteLine("{0} {1} with age {2}",student.FirstName,student.SecondName,student.Age);
            }
        }
    }
}
