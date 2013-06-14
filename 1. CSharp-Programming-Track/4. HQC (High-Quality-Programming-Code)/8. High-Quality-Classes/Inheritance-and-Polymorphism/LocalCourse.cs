using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name, string teacherName = null, string lab = null, IList<string> students = null)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Local Course: ");
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = " + this.lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
