using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private static Random random = new Random();
        private IEnumerable<Student> data;

        public StudentsController()
        {
            this.data = GenerateRandomStudents(10);
        }

        //GET api/students
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return this.data;
        }

        //Get api/students/{studentId}/marks
        [HttpGet]
        [ActionName("marks")]
        public IEnumerable<Mark> GetStudentMarks(int studentId)
        {
            return this.data.FirstOrDefault(st => st.StudentId == studentId).Marks;
        }

        private IEnumerable<Student> GenerateRandomStudents(int count)
        {
            List<Student> students = new List<Student>();
            for (int i = 1; i <= count; i++)
            {
                Student student = new Student()
                {
                    StudentId = i,
                    Name = "Name#" + i,
                };
                int marksCount = random.Next(0, 10);
                student.Marks = GenerateMarks(marksCount);
                students.Add(student);
            }
            return students;
        }

        private IEnumerable<Mark> GenerateMarks(int marksCount)
        {
            List<Mark> marks = new List<Mark>();

            for (int i = 1; i <= marksCount; i++)
            {
                Mark mark = new Mark()
                {
                    Score = random.Next(2, 6) + Math.Round(random.NextDouble(), 2), //GetRandomBetween(2, 6),
                    Subject = "Subject#" + i,
                };
                marks.Add(mark);
            }

            return marks;
        }

        private double GetRandomBetween(int min, int max)
        {
            double num = random.NextDouble() + min * (max - min);
            return num;
        }
    }
}
