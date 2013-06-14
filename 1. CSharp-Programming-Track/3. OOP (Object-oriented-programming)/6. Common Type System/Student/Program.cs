using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            //public Student(string firstName, string middleName, string lastName, string ssn, string address,
            //string phone, string email, byte course, Speciality speciality, University university, Faculty faculty)
            Student firstStudent = new Student("Ivan","Ivanov","Ivanov","123456789","Sofia city","0888888888"
                ,"ivan@ivanov.com",2,Speciality.ComputerSystem,University.NewBulgarianUniversity,Faculty.FKSU);
            Console.WriteLine(firstStudent);
            Student secondStudent = firstStudent.Clone() as Student;
            Console.WriteLine(secondStudent);
            secondStudent.Ssn = "000123784";
            Student thirdStudent = new Student("Pesho", "Ivanov", "Peshov", "123456789", "Sofia city", "0888888888"
                , "pesho@peshov.com", 3, Speciality.InformationTechnologies, University.SofiaUniversity, Faculty.FMI);
            Console.WriteLine(thirdStudent);
            Student[] students = { firstStudent, secondStudent, thirdStudent };
            Array.Sort(students);
            Console.WriteLine("Sorted...");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
