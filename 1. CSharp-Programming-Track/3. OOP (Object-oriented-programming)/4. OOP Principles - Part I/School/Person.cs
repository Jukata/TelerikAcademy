using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Person
    {
        //fields
        private string firstName;
        private string lastName;
        private byte age;

        //properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name can't be empty, null, whitespace or less than two characters.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name can't be empty, null, whitespace or less than two characters.");
                }
                this.lastName = value;
            }
        }

        public byte Age
        {
            get { return this.age; }
            set
            {
                this.age = value;
            }
        }

        //constructors
        public Person(string firstName, string lastName, byte age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
