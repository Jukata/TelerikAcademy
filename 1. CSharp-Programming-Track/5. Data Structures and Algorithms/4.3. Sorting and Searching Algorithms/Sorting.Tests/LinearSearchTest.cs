using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace Sorting.Tests
{
    [TestClass]
    public class LinearSearchTest
    {
        [TestMethod]
        public void TesLinearSearchtWithEmptyCollection()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            bool result = collection.LinearSearch(15);
            Assert.IsFalse(result);
            result = collection.LinearSearch(0);
            Assert.IsFalse(result);
            result = collection.LinearSearch(-1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TesLinearSearchtWithOneElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 3 });

            bool result = collection.LinearSearch(3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesLinearSearchtWithOneMissingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 3 });

            bool result = collection.LinearSearch(15);
            Assert.IsFalse(result);
            result = collection.LinearSearch(0);
            Assert.IsFalse(result);
            result = collection.LinearSearch(-1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TesLinearSearchtWithFirstMatchingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 5, 3, -3, -1, 51, 1, 0 });

            bool result = collection.LinearSearch(5);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesLinearSearchtWithLastMatchingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 5, 6, 7, 2, 1, 2, 4, -21, 0, 125, -33 });

            bool result = collection.LinearSearch(-33);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesLinearSearchTrivialCase()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 5, 6, 7, 2, 1, 2, 4, -21, 0, 125, -33 });

            bool result = collection.LinearSearch(4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesLinearSearchTrivialCaseMissingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 5, 6, 7, 2, 1, 2, 4, -21, 0, 125, -33 });

            bool result = collection.LinearSearch(8);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLinearSearchWithSeveralMatchingElements()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 7, 5, 7, 1, 7, 2, 7, 7, 1, 2, 4, -21, 1, 11, -33, 7 });

            bool result = collection.LinearSearch(7);
            Assert.IsTrue(result);
        }
    }
}
