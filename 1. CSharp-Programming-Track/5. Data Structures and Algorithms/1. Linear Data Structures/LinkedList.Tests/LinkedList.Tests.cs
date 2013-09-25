using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestAddFirstMethod()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddFirst("John");
            var item2 = list.AddFirst("Joe");
            var item3 = list.AddFirst("Jo");
            var item4 = list.AddFirst("Bradly");

            Assert.AreEqual(4, list.Count);
            Assert.AreSame(item1, list.Last);
            Assert.AreSame(item2, list.Last.Previous);
            Assert.AreSame(item3, list.First.Next);
            Assert.AreSame(item4, list.First);
        }

        [TestMethod]
        public void TestAddLastMethod()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddLast("John");
            var item2 = list.AddLast("Joe");
            var item3 = list.AddLast("Jo");
            var item4 = list.AddLast("Bradly");
            var item5 = list.AddLast("Antony");
            var item6 = list.AddLast("Charley");

            Assert.AreEqual(6, list.Count);
            Assert.AreSame(item1, list.First);
            Assert.AreSame(item2, list.First.Next);
            Assert.AreSame(item3, list.Last.Previous.Previous.Previous);
            Assert.AreSame(item4, list.Last.Previous.Previous);
            Assert.AreSame(item5, list.Last.Previous);
            Assert.AreSame(item6, list.Last);
        }

        [TestMethod]
        public void TestRemoveFirstMethod()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddLast("John");
            var item2 = list.AddLast("Joe");
            var item3 = list.AddLast("Jo");
            var item4 = list.AddLast("Bradly");
            var item5 = list.AddLast("Charley");

            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveFirst();

            Assert.AreEqual(2, list.Count);
            Assert.AreSame(item4, list.First);
            Assert.AreSame(item5, list.Last);
        }

        [TestMethod]
        public void TestRemoveLastMethod()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddLast("John");
            var item2 = list.AddLast("Joe");
            var item3 = list.AddLast("Jo");
            var item4 = list.AddLast("Bradly");
            var item5 = list.AddLast("Charley");

            list.RemoveLast();
            list.RemoveLast();

            Assert.AreEqual(3, list.Count);
            Assert.AreSame(item1, list.First);
            Assert.AreSame(item2, list.First.Next);
            Assert.AreSame(item3, list.First.Next.Next);
        }

        [TestMethod]
        public void TestClearMethod()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddLast("John");
            var item2 = list.AddLast("Joe");
            var item3 = list.AddLast("Jo");
            var item4 = list.AddLast("Bradly");
            var item5 = list.AddLast("Charley");
            var item6 = list.AddLast("Alexander");
            var item7 = list.AddLast("Borislav");
            var item8 = list.AddLast("Rodjer");
            var item9 = list.AddLast("Djane");

            list.Clear();

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(null, list.First);
            Assert.AreEqual(null, list.Last);
        }

        [TestMethod]
        public void TestAddAfterLast()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddLast("John");
            var item2 = list.AddAfter(item1, "Green");

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(item1, list.First);
            Assert.AreEqual(item2, list.Last);

            list.Clear();
            var item3 = list.AddFirst("Peter");
            var item4 = new ListItem<string>("Petrov");
            var item5 = new ListItem<string>("Petrovki");

            list.AddAfter(item3, item4);
            list.AddAfter(item3, item5);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(item3, list.First);
            Assert.AreEqual(item5, list.First.Next);
            Assert.AreEqual(item4, list.First.Next.Next);
        }

        [TestMethod]
        public void TestAddBeforeFirst()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddFirst("Michael");
            var item2 = list.AddBefore(item1, "Brown");

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(item1, list.Last);
            Assert.AreEqual(item2, list.First);

            list.Clear();

            var item3 = list.AddFirst("Todor");
            var item4 = new ListItem<string>("Ivanov");
            var item5 = new ListItem<string>("Nikolov");
            var item6 = new ListItem<string>("Vasil");

            list.AddBefore(item3, item4);
            list.AddBefore(item3, item5);
            list.AddBefore(item5, item6);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(item3, list.Last);
            Assert.AreEqual(item4, list.First);
            Assert.AreEqual(item5, list.Last.Previous);
            Assert.AreEqual(item6, list.First.Next);
        }

        [TestMethod]
        public void RemoveMisingValue()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddFirst("Michael");
            var item2 = list.AddBefore(item1, "Brown");

            var result = list.Remove("michael");

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(false, result);
            Assert.AreEqual(item1, list.Last);
            Assert.AreEqual(item2, list.First);
        }

        [TestMethod]
        public void RemoveValue()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddFirst("Michael");
            var item2 = list.AddBefore(item1, "Brown");
            var item3 = list.AddFirst("Michael");
            var item4 = list.AddLast("Brown");

            var result = list.Remove("Michael");

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(true, result);
            Assert.AreEqual(item1, list.Last.Previous);
            Assert.AreEqual(item2, list.First);
            Assert.AreEqual(item4, list.Last);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveMisingNode()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = list.AddFirst("Michael");
            var item2 = list.AddBefore(item1, "Brown");

            list.Remove(new ListItem<string>("Brown"));
        }

        [TestMethod]
        public void RemoveListNode()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = new ListItem<string>("Martin");
            var item2 = new ListItem<string>("Kevin");
            var item3 = new ListItem<string>("Kevin");
            var item4 = new ListItem<string>("Jo");
            var item5 = new ListItem<string>("Joey");
            var item6 = new ListItem<string>("Marto");
            var item7 = new ListItem<string>("Mitko");
            var item8 = new ListItem<string>("Joey");

            list.AddFirst(item1);
            list.AddFirst(item2);
            list.AddFirst(item3);
            list.AddFirst(item4);
            list.AddFirst(item5);
            list.AddFirst(item6);
            list.AddFirst(item7);
            list.AddFirst(item8);

            list.Remove(item2);
            list.Remove(item1);
            list.Remove(item5);

            Assert.AreEqual(5, list.Count);
            Assert.AreSame(item8, list.First);
            Assert.AreSame(item7, list.First.Next);
            Assert.AreSame(item6, list.First.Next.Next);
            Assert.AreSame(item4, list.First.Next.Next.Next);
            Assert.AreSame(item3, list.First.Next.Next.Next.Next);
        }

        [TestMethod]
        public void TestContainsValue()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = new ListItem<string>("Martin");
            var item2 = new ListItem<string>("Kevin");
            var item3 = new ListItem<string>("Kevin");
            var item4 = new ListItem<string>("Jo");

            list.AddFirst(item1);
            list.AddFirst(item2);
            list.AddFirst(item3);
            list.AddFirst(item4);

            Assert.AreEqual(list.Contains("Jo"), true);
            Assert.AreEqual(list.Contains("Kevin"), true);
            Assert.AreEqual(list.Contains("Martin"), true);
        }

        [TestMethod]
        public void TestContainsMissingValue()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = new ListItem<string>("Martin");
            var item2 = new ListItem<string>("Kevin");
            var item3 = new ListItem<string>("Kevin");
            var item4 = new ListItem<string>("Jo");

            list.AddFirst(item1);
            list.AddFirst(item2);
            list.AddFirst(item3);
            list.AddFirst(item4);

            Assert.AreEqual(list.Contains("Joe"), false);
            Assert.AreEqual(list.Contains("kevin"), false);
        }

        [TestMethod]
        public void TestContainsNode()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = new ListItem<string>("Martin");
            var item2 = new ListItem<string>("Kevin");
            var item3 = new ListItem<string>("Kevin");
            var item4 = new ListItem<string>("Jo");

            list.AddFirst(item1);
            list.AddFirst(item2);
            list.AddFirst(item3);
            list.AddFirst(item4);

            Assert.AreEqual(list.Contains(item1), true);
            Assert.AreEqual(list.Contains(item2), true);
            Assert.AreEqual(list.Contains(item3), true);
            Assert.AreEqual(list.Contains(item4), true);
        }

        [TestMethod]
        public void TestContainsMissingNode()
        {
            LinkedList<string> list = new LinkedList<string>();

            var item1 = new ListItem<string>("Martin");
            var item2 = new ListItem<string>("Kevin");
            var item3 = new ListItem<string>("Kevin");
            var item4 = new ListItem<string>("Jo");

            list.AddFirst(item1);
            list.AddFirst(item2);
            list.AddFirst(item3);
            list.AddFirst(item4);

            var item = new ListItem<string>("Kevin");
            bool result = list.Contains(item);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestFind()
        {
            LinkedList<string> list = new LinkedList<string>();

            var actual = list.Find("john");
            Assert.AreEqual(null, actual);

            var item = list.AddFirst("john");
            actual = list.Find("john");
            Assert.AreEqual(actual, item);

            var item1 = list.AddFirst("Steven");
            var item2 = list.AddFirst("Steven");
            var item3 = list.AddFirst("Steven");
            var item4 = list.AddFirst("Steven");

            actual = list.Find("Steven");
            Assert.AreEqual(item4, actual);
        }

        [TestMethod]
        public void TestFindLast()
        {
            LinkedList<string> list = new LinkedList<string>();

            var actual = list.Find("john");
            Assert.AreEqual(null, actual);

            var item = list.AddFirst("john");
            actual = list.Find("john");
            Assert.AreEqual(actual, item);

            var item1 = list.AddFirst("Steven");
            var item2 = list.AddFirst("Steven");
            var item3 = list.AddFirst("Steven");
            var item4 = list.AddFirst("Steven");

            actual = list.FindLast("Steven");
            Assert.AreEqual(item1, actual);
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            ListItem<string>[] items = new ListItem<string>[100];
            LinkedList<string> list = new LinkedList<string>();

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ListItem<string>("name" + i);
                list.AddLast(items[i]);
            }

            int index = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(items[index].Value, item);
                index++;
            }
        }

        [TestMethod]
        public void TestToString()
        {
            LinkedList<string> list = new LinkedList<string>();

            for (int i = 0; i < 14; i++)
            {
                list.AddLast(new ListItem<string>("name" + i));
            }

            string expected = "name0 <-> name1 <-> name2 <-> name3 <->"
                + " name4 <-> name5 <-> name6 <-> name7 <-> name8 <->"
                + " name9 <-> name10 <-> name11 <-> name12 <-> name13";
            string actual = list.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
