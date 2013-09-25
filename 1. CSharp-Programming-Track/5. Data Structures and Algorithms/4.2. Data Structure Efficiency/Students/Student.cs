using System;

public class Student : IComparable<Student>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get { return this.FirstName + " " + this.LastName; }
    }

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public int CompareTo(Student other)
    {
        if (this == null && other == null)
        {
            return 0;
        }
        else if (this == null)
        {
            return -1;
        }
        else if (other == null)
        {
            return 1;
        }

        int result = this.LastName.CompareTo(other.LastName);


        if (result == 0)
        {
            result = this.FirstName.CompareTo(other.FirstName);
        }

        return result;
    }

    public override string ToString()
    {
        return this.FullName;
    }
}