using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Faculty
    {
        private ICollection<Course> courses;

        public Faculty()
        {
            this.courses = new HashSet<Course>();
        }

        [Key]
        public int FacultyId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
