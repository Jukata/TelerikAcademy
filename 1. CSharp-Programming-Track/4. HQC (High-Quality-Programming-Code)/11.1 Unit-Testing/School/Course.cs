using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private const int MaxNumberOfStudent = 29;
        private List<Student> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name can't be null, empty or whitespaca.");
                }

                this.name = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students.AsReadOnly().ToList();
            }
            set
            {
                if (value == null)
                {
                    this.students = new List<Student>();
                }

                if (value.Count > MaxNumberOfStudent)
                {
                    throw new OverflowException("Maximum number of students is" + MaxNumberOfStudent + ".");
                }

                this.students = value;
            }
        }

        public void AddStudent(Student s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("The student for add can't be null.");
            }

            if (this.students.Count >= MaxNumberOfStudent)
            {
                throw new OverflowException("Maximum number of students is" + MaxNumberOfStudent + ".");
            }

            bool isDistinct = !this.students.Contains(s);

            if (isDistinct)
            {
                this.students.Add(s);
            }
            else
            {
                throw new ArgumentException("Student must have unique indentifier.");
            }
        }

        public Student RemoveStudent(int id)
        {
            int index = -1;
            for (int i = 0; i < this.students.Count; i++)
            {
                if (this.students[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return null;
            }
            else
            {
                return RemoveStudentAt(index);
            }
        }

        private Student RemoveStudentAt(int index)
        {
            Student removed = students[index];
            this.students.RemoveAt(index);
            return removed;
        }
    }
}
