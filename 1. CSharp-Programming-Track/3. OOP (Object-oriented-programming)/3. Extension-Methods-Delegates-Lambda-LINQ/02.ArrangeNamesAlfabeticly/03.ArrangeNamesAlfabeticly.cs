using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace _02.ArrangeNamesAlfabeticly
{
    class Program
    {
        public 
        static void Main(string[] args)
        {
            var students = new []
            {
                new {FirstName="Ivan",SecondName="Petrov"},
                new {FirstName="Albert",SecondName="Georgiev"},
                new {FirstName="Georgi",SecondName="Mihailov"},
                new {FirstName="Evgeni",SecondName="Krunski"},
                new {FirstName="Krasimir",SecondName="Bla"},
            };

            var sortAlfabeticly =
                from student in students
                where student.FirstName[0]<student.SecondName[0]
                select student;

            foreach (var student in sortAlfabeticly)
            {
                Console.WriteLine("{0} {1}",student.FirstName,student.SecondName);
            }
        }
    }
}
