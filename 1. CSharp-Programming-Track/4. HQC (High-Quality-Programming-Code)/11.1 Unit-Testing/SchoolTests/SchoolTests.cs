using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace SchoolTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void TestTrivialSchoolCase()
        {
            School.School s = new School.School("SMG");
            Assert.AreEqual("SMG", s.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyName()
        {
            School.School s = new School.School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullName()
        {
            School.School s = new School.School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWhitespaceName()
        {
            School.School s = new School.School("  ");
        }

        [TestMethod]
        public void TestAddFewCourses()
        {
            School.School s = new School.School("PMG");

            Course c1 = new Course("Math");
            Course c2 = new Course("Physics");
            Course c3 = new Course("Chemistry");

            s.AddCourse(c1);
            s.AddCourse(c2);
            s.AddCourse(c3);

            bool result = s.Courses.Count == 3;
            result = result && s.Courses[0].Name == c1.Name;
            result = result && s.Courses[1].Name == c2.Name;
            result = result && s.Courses[2].Name == c3.Name;

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullCourse()
        {
            School.School s = new School.School("MySchool");
            Course c = null;
            s.AddCourse(c);
        }


        [TestMethod]
        public void TestRemoveCourse()
        {
            School.School s = new School.School("foo");
            Course c1 = new Course("Math");
            Course c2 = new Course("Biology");

            s.AddCourse(c1);
            s.AddCourse(c2);

            Course removed = s.RemoveCourse("Math");

            Assert.AreEqual(removed, c1);
        }

        [TestMethod]
        public void TestSeveralCoursesWithSameName()
        {
            School.School s = new School.School("bar");
            Course c = new Course("Math");
            Course c1 = new Course("alpha");
            Course c2 = new Course("beta");
            Course c3 = new Course("gama");
            Course c4 = new Course("Math");
            Course c5 = new Course("Math");

            s.AddCourse(c);
            s.AddCourse(c1);
            s.AddCourse(c2);
            s.AddCourse(c3);
            s.AddCourse(c4);
            s.AddCourse(c5);

            Course removed = s.RemoveCourse("Math");

            bool result = removed == c;
            result = result && s.Courses[0] == c1 &&
                s.Courses[1] == c2 && s.Courses[2] == c3
                && s.Courses[3] == c4 && s.Courses[4] == c5;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRemoveMissingStudent()
        {
            School.School s = new School.School("bar");
            Course c = new Course("Math");
            Course c1 = new Course("alpha");
            Course c2 = new Course("beta");

            s.AddCourse(c);
            s.AddCourse(c1);
            s.AddCourse(c2);

            Course removed = s.RemoveCourse("omega");
            bool result = removed == null;
            result = result && s.Courses[0] == c &&
                s.Courses[1] == c1 && s.Courses[2] == c2;

            Assert.IsTrue(result);
        }
    }
}
