using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : Person, ICommentable
    {
        //fields
        private static long classNumberGenerator = 1;
        private long uniqueClassNumber;

        //properties
        public string Comments { get; set; }
        public long UniqueClassNumber
        {
            get { return this.uniqueClassNumber; }
        }

        //constructors
        public Student(string firstName, string lastName, byte age)
            : base(firstName, lastName, age)
        {
            this.uniqueClassNumber = classNumberGenerator;
            classNumberGenerator++;
        }

        //methods
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
