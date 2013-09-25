using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace Sorting.Tests
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void TesBinarySearchtWithEmptyCollection()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            bool result = collection.BinarySearch(15);
            Assert.IsFalse(result);
            result = collection.BinarySearch(0);
            Assert.IsFalse(result);
            result = collection.BinarySearch(-1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TesBinarySearchtWithOneElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 3 });

            bool result = collection.BinarySearch(3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesBinarySearchtWithOneMissingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 3 });

            bool result = collection.BinarySearch(15);
            Assert.IsFalse(result);
            result = collection.BinarySearch(0);
            Assert.IsFalse(result);
            result = collection.BinarySearch(-1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TesBinarySearchtWithFirstMatchingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { -3, -1, 1, 15, 101, 333, 334, 444 });

            bool result = collection.BinarySearch(-3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesBinarySearchtWithLastMatchingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { -33, -21, 0, 1, 2, 2, 4, 5, 6, 7, 12, 15 });

            bool result = collection.BinarySearch(15);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesBinarySearchTrivialCase()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { -33, -21, 0, 1, 2, 2, 4, 5, 6, 7, 12, 15 });

            bool result = collection.BinarySearch(2);
            Assert.IsTrue(result);
            result = collection.BinarySearch(4);
            Assert.IsTrue(result);
            result = collection.BinarySearch(5);
            Assert.IsTrue(result);
            result = collection.BinarySearch(6);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TesBinarySearchTrivialCaseMissingElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { -33, -21, 0, 1, 2, 2, 4, 5, 6, 7, 12, 15 });

            bool result = collection.BinarySearch(8);
            Assert.IsFalse(result);
            result = collection.BinarySearch(3);
            Assert.IsFalse(result);
            result = collection.BinarySearch(11);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBinarySearchWithSeveralMatchingElements()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { -33, -21, -21, 1, 1, 2, 2, 3, 4, 7, 7, 7, 11, 12, 123, 156 });
            bool result = collection.BinarySearch(7);
            Assert.IsTrue(result);
        }
    }
}
