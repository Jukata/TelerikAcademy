using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Repositories
{
    public class FakeStudentRepository : IRepository<Student>
    {
        private readonly List<Student> students;

        public FakeStudentRepository()
        {
            this.students = new List<Student>();
            AddTestInitialStudents();
        }

        public Student Add(Student item)
        {
            item.StudentId = this.students.Count;
            this.students.Add(item);
            return item;
        }

        public IEnumerable<Student> GetAll()
        {
            return this.students;
        }

        public Student GetById(int id)
        {
            return this.students[id];
        }

        private void AddTestInitialStudents()
        {
            this.Add(new Student()
            {
                FirstName = "Svetlin",
                LastName = "Nakov",
                Age = 30,
                Grade = 6,
                Marks = new List<Mark>()
                {
                    new Mark(){ Subject = "Math",Score = 6},
                    new Mark(){ Subject = "C#",Score = 16},
                    new Mark(){ Subject = "Java",Score = 8},
                },
            });

            this.Add(new Student()
            {
                FirstName = "Doncho",
                LastName = "Minkov",
                Age = 25,
                Grade = 4,
                Marks = new List<Mark>()
                {
                    new Mark(){ Subject = "JavaScript", Score = 666},
                    new Mark(){ Subject = "C#" , Score = 15},
                },
            });

            this.Add(new Student()
            {
                FirstName = "Nikolay",
                LastName = "Kostov",
                Age = 25,
                Grade = 4,
                Marks = new List<Mark>()
                {
                    new Mark(){ Subject = "ASP.NET MVC", Score = 30},
                    new Mark(){ Subject = "C#" , Score = 35},
                },
            });

            this.Add(new Student()
            {
                FirstName = "George",
                LastName = "Georgiev",
                Age = 25,
                Grade = 4,
            });
        }

        public void Update(int id, Student item)
        {
            this.students[id] = item;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}