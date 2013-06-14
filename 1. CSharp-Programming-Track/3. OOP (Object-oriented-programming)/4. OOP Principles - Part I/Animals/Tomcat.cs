using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    //Tomcats are cats. Tomcats can be only male. 

    public class Tomcat : Cat
    {
        private Sex sex;

        public override Sex Sex
        {
            get { return this.sex; }
            set
            {
                if (value == Sex.male)
                {
                    this.sex = value;
                }
                else
                {
                    throw new ArgumentException("Tomcats can be only male. ");
                }
            }
        }

        public Tomcat(byte age, string name, Sex sex)
            : base(age, name)
        {
            this.Sex = sex;
        }
    }
}
