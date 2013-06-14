using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace SchoolTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestTrivialStudentCase()
        {
            Student s = new Student("Ivan", 12345);

            bool result = s.Name == "Ivan" && s.Id == 12345;
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyName()
        {
            Student s = new Student(string.Empty, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullName()
        {
            Student s = new Student(null, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWhitespaceName()
        {
            Student s = new Student("        ", 12345);
        }

        [TestMethod]
        public void TestMinId()
        {
            Student s = new Student("John", 10000);
            Assert.AreEqual(10000, s.Id);
        }

        [TestMethod]
        public void TestMaxId()
        {
            Student s = new Student("John", 99999);
            Assert.AreEqual(99999, s.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLowerThanMinId()
        {
            Student s = new Student("Ivan", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGreaterThanMaxId()
        {
            Student s = new Student("Ivan", 100000);
        }

        [TestMethod]
        public void TestNameSetter()
        {
            Student s = new Student("go", 99999);
            s.Name = "boo";
            Assert.AreEqual("boo", s.Name);
        }

        [TestMethod]
        public void TestIdSetter()
        {
            Student s = new Student("go", 99999);
            s.Id = 10000;
            Assert.AreEqual(10000, s.Id);
        }
    }
}
