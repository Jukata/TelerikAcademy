using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class School
    {
        private List<Course> courses;
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("School name can't be null, empty or whitespace.");
                }

                this.name = value;
            }
        }

        public List<Course> Courses
        {
            get
            {
                return this.courses.AsReadOnly().ToList();
            }
            set
            {
                if (value == null)
                {
                    this.courses = new List<Course>();
                }

                this.courses = value;
            }
        }

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
        }

        public void AddCourse(Course c)
        {
            if(c == null)
            {
                throw new ArgumentNullException("Course for adding cant be null.");
            }

            this.courses.Add(c);
        }

        public Course RemoveCourse(string name)
        {
            int index = -1;
            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].Name == name)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return null;
            }
            else
            {
                return RemoveCourseAt(index);
            }
        }

        private Course RemoveCourseAt(int index)
        {
            Course removed = this.courses[index];
            this.courses.RemoveAt(index);
            return removed;
        }
    }
}
