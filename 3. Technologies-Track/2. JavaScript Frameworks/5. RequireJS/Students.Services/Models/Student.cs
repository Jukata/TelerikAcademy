using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
    }
}