using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace Sorting.Tests
{
    [TestClass]
    public class InsertionSorterTest
    {
        [TestMethod]
        public void InsertionSorterTestWithEmptyCollection()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Sort(new InsertionSorter<int>());
            Assert.AreEqual(0, collection.Items.Count);
        }

        [TestMethod]
        public void InsertionSorterTestWithOneElement()
        {
            SortableCollection<int> collection = new SortableCollection<int>(new int[] { 5 });
            collection.Sort(new InsertionSorter<int>());
            Assert.AreEqual(1, collection.Items.Count);
            Assert.AreEqual(5, collection.Items[0]);
        }

        [TestMethod]
        public void InsertionSorterTestWithFiveElements()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 5, 12, -21, -1, 3 });
            collection.Sort(new InsertionSorter<int>());

            Assert.AreEqual(-21, collection.Items[0]);
            Assert.AreEqual(-1, collection.Items[1]);
            Assert.AreEqual(3, collection.Items[2]);
            Assert.AreEqual(5, collection.Items[3]);
            Assert.AreEqual(12, collection.Items[4]);
        }

        [TestMethod]
        public void InsertionSorterTestWithPairOfEqualElements()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                new int[] { 5, 5, 7, 7, 5, 7, 3, -1 });
            collection.Sort(new InsertionSorter<int>());

            Assert.AreEqual(-1, collection.Items[0]);
            Assert.AreEqual(3, collection.Items[1]);
            Assert.AreEqual(5, collection.Items[2]);
            Assert.AreEqual(5, collection.Items[3]);
            Assert.AreEqual(5, collection.Items[4]);
            Assert.AreEqual(7, collection.Items[5]);
            Assert.AreEqual(7, collection.Items[6]);
            Assert.AreEqual(7, collection.Items[7]);
        }

        [TestMethod]
        public void InsertionSorterTestSortedCollection()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                           new int[] { -1, 0, 1, 2, 3 });
            collection.Sort(new InsertionSorter<int>());

            Assert.AreEqual(-1, collection.Items[0]);
            Assert.AreEqual(0, collection.Items[1]);
            Assert.AreEqual(1, collection.Items[2]);
            Assert.AreEqual(2, collection.Items[3]);
            Assert.AreEqual(3, collection.Items[4]);
        }

        [TestMethod]
        public void InsertionSorterTestReversedSortedCollection()
        {
            SortableCollection<int> collection = new SortableCollection<int>(
                           new int[] { 11, 8, -3, -115, -200, -300 });
            collection.Sort(new InsertionSorter<int>());

            Assert.AreEqual(-300, collection.Items[0]);
            Assert.AreEqual(-200, collection.Items[1]);
            Assert.AreEqual(-115, collection.Items[2]);
            Assert.AreEqual(-3, collection.Items[3]);
            Assert.AreEqual(8, collection.Items[4]);
            Assert.AreEqual(11, collection.Items[5]);
        }
    }
}
