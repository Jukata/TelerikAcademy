using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class School
    {
        //fields
        private string name;
        private List<SchoolClass> classes;

        //properties
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name can't be empty, null, whitespace or less than two characters.");
                }
                this.name = value;
            }
        }

        //constructors
        public School(string name)
        {
            this.Name = name;
            classes = new List<SchoolClass>();
        }

        //methods
        public void AddClass(SchoolClass schoolClass)
        {
            this.classes.Add(schoolClass);
        }

        public void RemoveClass(SchoolClass schoolClass)
        {
            this.classes.Remove(schoolClass);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("School - " + this.Name);
            result.AppendLine(new string('=', 40));
            foreach (SchoolClass schoolClass in classes)
            {
                result.AppendLine(schoolClass.ToString());
            }

            return result.ToString();
        }

    }
}
