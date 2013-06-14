using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students = new List<string>();

        public Course(string courseName, string teacherName = null, IList<string> students = null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Course name can't be null, empty, whitespace or less than 2 characters");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return new ReadOnlyCollection<string>(this.students);
            }
            set
            {
                if (value == null)
                {
                    this.students = new List<string>();
                }
                else
                {
                    foreach (string student in value)
                    {
                        this.students.Add(student);
                    }
                }
            }
        }

        public void AddStudent(string student)
        {
            if (string.IsNullOrWhiteSpace(student))
            {
                throw new ArgumentException("Input student can't be null, empty, whitespace.");
            }
            //this.Students.Add(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ Name = " + this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = " + this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
