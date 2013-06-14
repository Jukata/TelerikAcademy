using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    //Create a class Person with two fields – name and age. 
    //Age can be left unspecified (may contain null value. 
    //Write a program to test this functionality.
    public class Person
    {
        //fields
        private string name;
        private byte? age;

        //constructor
        public Person(string name, byte? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        //properties
        public byte? Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Name can't be null, empty, whitespace or less than 3 characters.");
                }
                name = value;
            }
        }

        //Override ToString() to display the information of a person and if age is not specified – to say so. 
        public override string ToString()
        {
            string result = "Name: " + this.Name + Environment.NewLine;
            if (this.Age != null)
            {
                result += "Age: " + this.Age;
            }
            else
            {
                result += "Age: not specified";
            }
            return result;
        }
    }
}
