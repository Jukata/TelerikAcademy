using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TestPoker
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestTwoClubsToString()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "2♣";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestFiveDiamondsToString()
        {
            Card card = new Card(CardFace.Five, CardSuit.Diamonds);
            string expected = "5♦";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestNineHeartToString()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Hearts);
            string expected = "9♥";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestTenSpadesToString()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Spades);
            string expected = "10♠";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestQueenSpadesToString()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Spades);
            string expected = "Q♠";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestKingDiamondsToString()
        {
            Card card = new Card(CardFace.King, CardSuit.Spades);
            string expected = "K♠";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAceHeartToString()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            string expected = "A♥";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
