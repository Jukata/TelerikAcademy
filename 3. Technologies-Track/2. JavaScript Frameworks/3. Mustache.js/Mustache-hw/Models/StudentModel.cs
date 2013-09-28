using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }

        public static StudentModel CreateModelFromEntity(Student st)
        {
            return new StudentModel()
            {
                StudentId = st.StudentId,
                FirstName = st.FirstName,
                LastName = st.LastName,
                Age = st.Age,
                Grade = st.Grade,
            };
        }
    }
}