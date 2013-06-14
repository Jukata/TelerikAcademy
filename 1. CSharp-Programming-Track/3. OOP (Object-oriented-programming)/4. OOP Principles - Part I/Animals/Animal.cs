using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    //All animals can produce sound (specified by the ISound interface).
    //All animals are described by age, name and sex. 

    public abstract class Animal : ISound
    {
        public byte Age { get; set; }
        public string Name { get; set; }
        public abstract Sex Sex { get; set; }

        public virtual void MakeSound()
        {
            Console.Write("I am {0}: ", this.GetType().ToString());
        }

        protected Animal(byte age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString()
        {
            StringBuilder builderToString = new StringBuilder();
            builderToString.AppendLine(this.GetType().ToString());
            builderToString.AppendLine("Name - " + this.Name);
            builderToString.AppendLine("Age - " + this.Age);
            builderToString.AppendLine("Sex - " + this.Sex);

            return builderToString.ToString();
        }

        public static double Average(IEnumerable<Animal> animals)
        {
            double average = animals.Average(animal => animal.Age);
            return average;
        }
    }
}
