using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    //Define new class Student which is derived from Human and has new field – grade.
    class Student : Human
    {
        private byte grade;

        public byte Grade
        {
            get { return this.grade; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Grade cannot be 0.");
                }
                this.grade = value;
            }
        }

        public Student(string firstName, string lastName, byte grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            StringBuilder buildToString = new StringBuilder();

            buildToString.AppendLine(this.FirstName +" "+ this.LastName);
            buildToString.AppendLine("Grade: " + this.Grade);

            return buildToString.ToString();
        }
    }
}
