//We are given a school. In the school there are classes of students.
//Each class has a set of teachers. Each teacher teaches a set of disciplines.
//Students have name and unique class number. Classes have unique text identifier.
//Teachers have name. Disciplines have name, number of lectures and number of exercises.
//Both teachers and students are people. Students, classes, teachers and disciplines could
//have optional comments (free text block).
//Your task is to identify the classes (in terms of  OOP) and their attributes and operations,
//encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        static void Main()
        {
            School TelerikSchool = new School("Telerik");

            SchoolClass telerikClass = new SchoolClass();
            SchoolClass writersClass = new SchoolClass();
            SchoolClass dotaCharactersClass = new SchoolClass();

            telerikClass.AddStudent(new Student("Svetlin", "Nakov", 30));
            telerikClass.AddStudent(new Student("Doncho", "Minkov", 25));
            telerikClass.AddStudent(new Student("Nikolay", "Kostov", 23));
            telerikClass.AddStudent(new Student("George", "Georgiev", 22));
            telerikClass.AddTeacher(new Teacher("Pavel", "Kolev", 24));
            telerikClass.AddTeacher(new Teacher("Mihail", "Petrov", 23));
            telerikClass.AddTeacher(new Teacher("Lyubomir", "Yanchev", 18));

            writersClass.AddStudent(new Student("Ivan", "Vazov", 23));
            writersClass.AddStudent(new Student("Lyuben", "Karavelov", 22));
            writersClass.AddTeacher(new Teacher("Dimcho", "Debelqnov", 24));
            writersClass.AddTeacher(new Teacher("Nikola", "Vapcarov", 23));

            dotaCharactersClass.AddStudent(new Student("Tinker", "Bouch", 22));
            dotaCharactersClass.AddStudent(new Student("Spectre", "Mercurial", 22));
            dotaCharactersClass.AddStudent(new Student("Alleria", "Windrunner", 22));
            dotaCharactersClass.AddStudent(new Student("Drow", "Ranger", 22));
            dotaCharactersClass.AddTeacher(new Teacher("Zeus", "Lord of olympia", 24));
            dotaCharactersClass.AddTeacher(new Teacher("Kunka", "Captain", 24));
            dotaCharactersClass.AddTeacher(new Teacher("Mortred", "Phantom assassin", 24));
            dotaCharactersClass.AddTeacher(new Teacher("Pudge", "Butcher", 24));
            dotaCharactersClass.AddTeacher(new Teacher("Mirana", "Priestess of the moon", 23));

            TelerikSchool.AddClass(new SchoolClass());
            TelerikSchool.AddClass(telerikClass);
            TelerikSchool.AddClass(writersClass);
            TelerikSchool.AddClass(dotaCharactersClass);

            Console.WriteLine(TelerikSchool);

            
        }
    }
}
