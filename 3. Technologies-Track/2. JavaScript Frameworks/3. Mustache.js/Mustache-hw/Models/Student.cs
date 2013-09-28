using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }

        public IEnumerable<Mark> Marks { get; set; }
    }
}