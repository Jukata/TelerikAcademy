namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsOlderThan(Student other)
        {
            if (this == null || other == null)
            {
                throw new ArgumentNullException("Can't compare student age with null.");
            }

            return this.BirthDate > other.BirthDate;
        }
    }
}
