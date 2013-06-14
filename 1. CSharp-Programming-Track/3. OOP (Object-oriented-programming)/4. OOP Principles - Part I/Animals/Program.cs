using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Program
    {
        //Create arrays of different kinds of animals and calculate the average age of 
        //each kind of animal using a static method (you may use LINQ).

        static void Main()
        {
            Kitten[] kittens = 
            {
                new Kitten(3,"Macka",Sex.female),
                new Kitten(6,"Pisanka",Sex.female),
                new Kitten(5,"Kotanka",Sex.female),
            };
            Tomcat[] tomcats = 
            {
                new Tomcat(5,"Kotaran",Sex.male),
                new Tomcat(1,"Pisan",Sex.male),
                new Tomcat(3,"Macan",Sex.male),
            };
            Dog[] dogs = 
            {
                new Dog(3,"Sharo",Sex.male),
                new Dog(5,"Rex",Sex.male),
                new Dog(3,"Lora",Sex.female),
                new Dog(3,"Casper",Sex.male),
            };
            Frog[] frogs = 
            {
                new Frog(1,"Jabok",Sex.male),
                new Frog(1,"Jaborana",Sex.female),
                new Frog(1,"Jabo",Sex.other),
            };

            Console.WriteLine("Kittens:");
            foreach (Kitten kitten in kittens)
            {
                Console.Write(kitten);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('=', 40));

            Console.WriteLine("Tomcats:");
            foreach (Tomcat tomcat in tomcats)
            {
                Console.Write(tomcat);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('=', 40));

            Console.WriteLine("Dogs:");
            foreach (Dog dog in dogs)
            {
                Console.Write(dog);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('=', 40));

            Console.WriteLine("Frogs:");
            foreach (Frog frog in frogs)
            {
                Console.Write(frog);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('=', 40));

            Console.WriteLine("Kittens average age = {0:0.00}", Animal.Average(kittens));
            Console.WriteLine("Tomcats average age = {0:0.00}", Animal.Average(tomcats));
            Console.WriteLine("Dogs average age = {0:0.00}", Animal.Average(dogs));
            Console.WriteLine("Frogs average age = {0:0.00}", Animal.Average(frogs));
        }
    }
}
