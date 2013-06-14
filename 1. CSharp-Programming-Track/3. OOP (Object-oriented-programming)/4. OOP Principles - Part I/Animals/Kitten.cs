using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    //Kittens are cats. Kittens can be only female.

    public class Kitten : Cat
    {
        private Sex sex;

        public override Sex Sex
        {
            get { return this.sex; }
            set
            {
                if (value == Sex.female)
                {
                    this.sex = value;
                }
                else
                {
                    throw new ArgumentException("Kittens can be only female.");
                }
            }
        }

        public Kitten(byte age, string name, Sex sex)
            : base(age, name)
        {
            this.Sex = sex;
        }
    }
}
