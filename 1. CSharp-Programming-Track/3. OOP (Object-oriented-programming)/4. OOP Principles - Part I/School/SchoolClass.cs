using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //In the school there are classes of students. Each class has a set of teachers. 
    //Classes have unique text identifier. 
    class SchoolClass : ICommentable
    {
        private static long classIDGenerator = 1;
        //fields
        private List<Teacher> teachers;
        private List<Student> students;
        private long classID;

        //properties
        public string Comments { get; set; }
        public long ClassID
        {
            get { return this.classID; }
            private set { this.classID = value; }
        }

        //constructors
        public SchoolClass()
        {
            this.classID = classIDGenerator;
            classIDGenerator++;
            teachers = new List<Teacher>();
            students = new List<Student>();
        }

        //methods
        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }
        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }
        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("ClassID #" + this.ClassID);
            result.AppendLine(new string('.', 40));
            result.AppendLine("@Teachers");
            foreach (Teacher teacher in this.teachers)
            {
                result.AppendLine(teacher.ToString());
            }
            result.AppendLine("@Students");
            foreach (Student student in students)
            {
                result.AppendLine(student.ToString());
            }
            return result.ToString();
        }
    }
}
