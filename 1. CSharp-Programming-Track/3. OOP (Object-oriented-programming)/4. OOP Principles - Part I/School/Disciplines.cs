using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    //Disciplines have name, number of lectures and number of exercises.
    public class Disciplines : ICommentable
    {
        //fields
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        //properties
        public string Comments { get; set; }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name can't be empty, null, whitespace or less than two characters.");
                }
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of lectures can't be negative.");
                }
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercise
        {
            get { return this.numberOfExercises; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of exercises can't be negative.");
                }
                this.numberOfExercises = value;
            }
        }

        //constructor
        public Disciplines(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercise = numberOfExercises;
        }

        public override string ToString()
        {
            return this.Name + " { lectures = " + this.NumberOfLectures + ", exercies = " + this.NumberOfExercise + "}";
        }
    }
}
