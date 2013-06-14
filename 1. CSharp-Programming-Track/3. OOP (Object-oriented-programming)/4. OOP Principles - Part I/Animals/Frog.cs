using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    //Frogs and cats are Animals

    class Frog : Animal
    {
        public override Sex Sex { get; set; }

        public Frog(byte age, string name, Sex sex)
            : base(age, name)
        {
            this.Sex = sex;
        }

        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("Krqk.");
        }
    }
}
