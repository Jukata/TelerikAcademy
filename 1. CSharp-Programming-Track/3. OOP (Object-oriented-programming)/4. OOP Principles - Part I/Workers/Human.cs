using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    //Define abstract class Human with first name and last name. 

    abstract class Human
    {
        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Constructor for childs
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
