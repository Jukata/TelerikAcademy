using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    //Define a class Student, which contains data about a student – first, middle and last name,
    //SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. 
    //Use an enumeration for the specialties, universities and faculties. Override the standard 
    //methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

    public class Student : ICloneable, IComparable<Student>
    {
        //fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private byte course;
        private Speciality speciality;
        private University university;
        private Faculty faculty;

        //constructor
        public Student(string firstName, string middleName, string lastName, string ssn, string address,
            string phone, string email, byte course, Speciality speciality, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.PermanentAddress = address;
            this.MobilePhone = phone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        //properties
        public Faculty Faculty
        {
            get { return this.faculty; }
            set { this.faculty = value; }
        }
        public University University
        {
            get { return this.university; }
            set { this.university = value; }
        }
        public Speciality Speciality
        {
            get { return this.speciality; }
            set { this.speciality = value; }
        }
        public byte Course
        {
            get { return this.course; }
            set
            {
                if (value <= 0 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Course must be between 1 and 6.");
                }
                this.course = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Email can't be null, empty, whitespace or less than 5 characters.");
                }
                this.email = value;
            }
        }
        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("MobilePhone can't be null, empty, whitespace or less than 3 characters.");
                }
                this.mobilePhone = value;
            }
        }
        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Address can't be null, empty, whitespace or less than 5 characters.");
                }
                this.permanentAddress = value;
            }
        }
        public string Ssn
        {
            get { return this.ssn; }
            set
            {
                bool isSsn = true;
                foreach (char ch in value)
                {
                    if (!char.IsNumber(ch))
                    {
                        isSsn = false;
                        break;
                    }
                }
                if (isSsn && value.Length == 9)
                {
                    this.ssn = value;
                }
                else
                {
                    throw new ArgumentException("SSN must be nine-digit number.");
                }
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name can't be null, empty, whitespace or less than 2 characters.");
                }
                this.lastName = value;
            }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name can't be null, empty, whitespace or less than 2 characters.");
                }
                this.middleName = value;
            }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name can't be null, empty, whitespace or less than 2 characters.");
                }
                this.firstName = value;
            }
        }

        //Override the standard methods, inherited by  System.Object: 
        //Equals(), ToString(), GetHashCode() and operators == and !=.
        public override bool Equals(object obj)
        {
            Student other = obj as Student;
            if (other == null)
            {
                return false;
            }
            if (this.FirstName == other.FirstName && this.MiddleName == other.MiddleName &&
                this.LastName == other.LastName && this.Ssn == other.Ssn)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !s1.Equals(s2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Student:");
            sb.AppendLine("First Name: " + this.FirstName);
            sb.AppendLine("Middle Name: " + this.MiddleName);
            sb.AppendLine("Last Name: " + this.LastName);
            sb.AppendLine("University: " + this.University);
            sb.AppendLine("Faculty: " + this.Faculty);
            sb.AppendLine("Speciality: " + this.Speciality);
            sb.AppendLine("Course: " + this.Course);
            sb.AppendLine("SSN: " + this.Ssn);
            sb.AppendLine("Address: " + this.PermanentAddress);
            sb.AppendLine("Phone: " + this.MobilePhone);
            sb.AppendLine("Email: " + this.Email);
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int result = 0;
            foreach (char ch in this.LastName)
            {
                result ^= ch;
            }
            foreach (char ch in Ssn)
            {
                result ^= ch;
            }
            return result;
        }

        //Add implementations of the ICloneable interface. The Clone() method should deeply 
        //copy all object's fields into a new object of type Student.
        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.Ssn, this.PermanentAddress
                , this.MobilePhone, this.Email, this.Course, this.Speciality, this.University, this.Faculty);
        }

        //Implement the  IComparable<Student> interface to compare students by names (as first criteria, 
        //in lexicographic order) and by social security number (as second criteria, in increasing order).

        public int CompareTo(Student other)
        {
            int result = 0;
            result = this.FirstName.CompareTo(other.FirstName);
            if (result != 0) return result;
            result = this.MiddleName.CompareTo(other.MiddleName);
            if (result != 0) return result;
            result = this.LastName.CompareTo(other.LastName);
            if (result != 0) return result;
            result = this.Ssn.CompareTo(other.Ssn);
            return result;
        }
    }
}
