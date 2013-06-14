using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestTrivialHandToString()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            string result = hand.ToString();
            string expected = "2♣3♦4♥5♠6♣";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestTrivialHand2ToString()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));

            Hand hand = new Hand(cards);
            string result = hand.ToString();
            string expected = "10♣Q♦K♥J♠A♣";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCardsWithSameFaceToString()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));

            Hand hand = new Hand(cards);
            string result = hand.ToString();
            string expected = "Q♣Q♦Q♥J♠Q♠";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestEmptyHandToString()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);

            string result = hand.ToString();
            string expected = string.Empty;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestOneCardHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            Hand hand = new Hand(cards);

            string result = hand.ToString();
            string expected = "8♦";

            Assert.AreEqual(expected, result);
        }
    }
}
