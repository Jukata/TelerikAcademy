using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    //Cats are Animal

    public abstract class Cat : Animal
    {
        protected Cat(byte age, string name)
            : base(age, name)
        {
        }

        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("Mqu.");
        }
    }
}
