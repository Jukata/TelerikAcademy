using System;

namespace School
{
    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be null, empty or whitespace.");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("Id must be between 10000 and 99999.");
                }

                this.id = value;
            }
        }

        public override bool Equals(object obj)
        {
            Student other = obj as Student;
            if (other == null)
            {
                return false;
            }

            if (this == null)
            {
                return false;
            }

            if (this.Id == other.Id)
            {
                return true;
            }

            return false;
        }
    }
}
