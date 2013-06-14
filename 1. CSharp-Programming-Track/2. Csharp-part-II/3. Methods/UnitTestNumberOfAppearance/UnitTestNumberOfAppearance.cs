using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestNumberOfAppearance
{
    [TestClass]
    public class UnitTestNumberOfAppearance
    {
        [TestMethod]
        public void Common1()
        {
            int[] array = { 2, 3, 4, 5, 6, 7, 8, 9 };
            int result = NumberOfAppearance.CheckNumberOfAppearance(array, 5);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Common2()
        {
            int[] array = { 1, 4, 4, 2, 3, 4, 4, 4, 4, 5, 6, 7, 8, 9, 4, 4, 1 };
            int result = NumberOfAppearance.CheckNumberOfAppearance(array, 4);
            Assert.AreEqual(8, result);
        }
        [TestMethod]
        public void EmptyArray()
        {
            int[] array = { };
            int result = NumberOfAppearance.CheckNumberOfAppearance(array, 5);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ZeroAppearacnce()
        {
            int[] array = { 2, 3, 4, 5, 6, 7, 8, 9, -15 };
            int result = NumberOfAppearance.CheckNumberOfAppearance(array, 15);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void BigArray()
        {
            int[] array = { 2, 4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 8, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93, 3, 4, 5, 
                              7, 8, 93, 3, 4, 5, 6, 7, 8, 93, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93,
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93, 
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93,
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93,
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93,
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93, 
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93, 
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93,
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93,
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93, 
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 93, 
                              4, 5, 6, 7, 8, 93, 3, 4, 5, 6, 78, 93, 3, 4, 5, 6, 7, 
                              93, 3, 4, 5, 6, 7, 8, 93, 3, 4, 6, 7, 8, 9 };
            int result = NumberOfAppearance.CheckNumberOfAppearance(array, 93);
            Assert.AreEqual(64, result);
        }
        [TestMethod]
        public void NegativeNumbers()
        {
            int[] array = { -2, -3, -4, -5, -3, -11, -111, -11, 5, 6, 7, 8, 9 };
            int result = NumberOfAppearance.CheckNumberOfAppearance(array, -11);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void BorderAppearance()
        {
            int[] array = { 0, 1, 1, 2, 3, 4, 5, 1, -2, -5, -6, 5, 0 };
            int result = NumberOfAppearance.CheckNumberOfAppearance(array, 0);
            Assert.AreEqual(2, result);
        }
    }
}
