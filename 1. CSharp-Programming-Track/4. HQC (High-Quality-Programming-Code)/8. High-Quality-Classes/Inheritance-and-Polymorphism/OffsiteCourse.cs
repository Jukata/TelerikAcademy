using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name, string teacherName = null, IList<string> students= null, string town = null)
            : base(name,teacherName, students )
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Offsite course: ");
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = " + this.Town);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
