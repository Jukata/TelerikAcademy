using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace SchoolTests
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void TestTrivialCourseCase()
        {
            Course c = new Course("Math");
            Assert.AreEqual("Math", c.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyName()
        {
            Course s = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullName()
        {
            Course s = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWhitespaceName()
        {
            Course s = new Course("     ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUniqueIndentifier()
        {
            Course c = new Course("C# programming");
            Student s1 = new Student("Niki", 12345);
            Student s2 = new Student("Doncho", 12346);
            Student s3 = new Student("George", 12347);
            Student s4 = new Student("Svetlin", 12347);

            c.AddStudent(s1);
            c.AddStudent(s2);
            c.AddStudent(s3);
            c.AddStudent(s4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullStudent()
        {
            Course c = new Course("Math");
            Student s = null;
            c.AddStudent(s);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestMaxStudents()
        {
            Course c = new Course("Math");
            for (int i = 0; i <= 30; i++)
            {
                c.AddStudent(new Student("Johny", 20000 + i));
            }
        }

        [TestMethod]
        public void TestFewAddedStudents()
        {
            Course c = new Course("Math");
            Student s1 = (new Student("Minkov", 10210));
            Student s2 = (new Student("Kostov", 15010));
            Student s3 = (new Student("Nakov", 99010));
            Student s4 = (new Student("Georgiev", 11110));

            c.AddStudent(s1);
            c.AddStudent(s2);
            c.AddStudent(s3);
            c.AddStudent(s4);

            bool result = c.Students.Count == 4;

            result = result && c.Students[0] == s1;
            result = result && c.Students[1] == s2;
            result = result && c.Students[2] == s3;
            result = result && c.Students[3] == s4;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            Course c = new Course("Math");
            Student s1 = new Student("George", 13451);
            Student s2 = new Student("Asya", 66451);
            c.AddStudent(s1);
            c.AddStudent(s2);

            c.RemoveStudent(13451);

            Assert.AreEqual(1, c.Students.Count);
        }

        [TestMethod]
        public void TestRemoveStudent2()
        {
            Course c = new Course("Math");
            Student s1 = new Student("George", 13451);
            Student s2 = new Student("Asya", 66451);
            c.AddStudent(s1);
            c.AddStudent(s2);

            Student removed = c.RemoveStudent(13451);

            Assert.AreEqual(removed, s1);
        }

        [TestMethod]
        public void TestRemoveMissingStudent()
        {
            Course c = new Course("Math");
            Student s1 = new Student("George", 13451);
            Student s2 = new Student("Asya", 66451);
            c.AddStudent(s1);
            c.AddStudent(s2);

            Student removed = c.RemoveStudent(10101);

            Assert.AreEqual(null, removed);
        }
    }
}
