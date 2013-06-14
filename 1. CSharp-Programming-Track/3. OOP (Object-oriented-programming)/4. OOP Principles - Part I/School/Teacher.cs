using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : Person, ICommentable
    {
        //fields
        private List<Disciplines> disciplines;

        //properties
        public string Comments { get; set; }

        //constructors
        public Teacher(string firstName, string lastName, byte age)
            : base(firstName, lastName, age)
        {
            disciplines = new List<Disciplines>();
        }

        //methods
        public void AddDiscipline(Disciplines discipline)
        {
            this.disciplines.Add(discipline);
        }
        public void RemoveDiscipline(Disciplines discipline)
        {
            this.disciplines.Remove(discipline);
        }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
