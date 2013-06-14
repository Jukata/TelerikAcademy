using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class Program
    {
        //Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy()
        //extension method). Initialize a list of 10 workers and sort them by money per hour in descending order.
        //Merge the lists and sort them by first name and last name.

        static void Main()
        {
            List<Student> students = new List<Student>(10);
            students.Add(new Student("Petar", "Petrov", 5));
            students.Add(new Student("Petar", "Petrov", 4));
            students.Add(new Student("Petar", "Petrov", 3));
            students.Add(new Student("Ivan", "Ivanov", 1));
            students.Add(new Student("Georgi", "Petrov", 5));
            students.Add(new Student("Ivan", "Petrov", 2));
            students.Add(new Student("Dimityr", "Nikolov", 3));
            students.Add(new Student("Kostadin", "Stoyanov", 5));
            students.Add(new Student("Todor", "Todorov", 6));
            students.Add(new Student("Nikolay", "Kolev", 1));

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Svetlin", "Nakov", 150.99m, 5, 6));
            workers.Add(new Worker("Nikolay", "Kostov", 350.99m, 8));
            workers.Add(new Worker("Doncho", "Minkov", 550, 6));
            workers.Add(new Worker("George", "Georgiev", 150.99m, 8, 5));
            workers.Add(new Worker("Ina", "Dobrilova", 550.99m, 8, 4));
            workers.Add(new Worker("Ralica", "Petrova", 1150.99m, 10, 3));
            workers.Add(new Worker("Aleksander", "Kaziiski", 3150.99m, 8));
            workers.Add(new Worker("Borislav", "Tatarski", 150.99m, 12, 1));
            workers.Add(new Worker("Elena", "Ivanova", 350.99m, 7, 2));
            workers.Add(new Worker("Damqn", "Rusinov", 2450.99m, 15, 5));

            //sort students
            students.Sort((x, y) => x.Grade.CompareTo(y.Grade));

            //var st = students.OrderByDescending(x => x.Grade);
            //var st =
            //    from student in students
            //    orderby student.Grade ascending
            //    select student;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Students sorted by grade:\n");
            foreach (Student student in students)
            {
                Console.Write(student);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('=', 40));

            //sort workers
            workers.Sort((x, y) => -x.MoneyPerHour().CompareTo(y.MoneyPerHour()));

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Workers sorted by money per hour:\n");
            foreach (Worker worker in workers)
            {
                Console.Write(worker);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('=', 40));

            //merge lists
            var people = new List<Human>(students).Concat(workers);
            //var people = people.Concat(workers);

            //foreach in sorted full list
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Workers and students sorted by first and last name:\n");
            foreach (var human in people.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                Console.Write(human);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('=', 40));

        }
    }
}
