using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class PokerHandsCheckerIsStraightFlush
    {
        [TestMethod]
        public void Straight()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraightFlush(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StraightWithTwoAsMin()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraightFlush(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StraighFlushtWithTwoAsMin()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraightFlush(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StraightFlushhtWithAceAsMin()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraightFlush(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotStraightFlushA2457()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraightFlush(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FourSequenceWithSameSuit()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraightFlush(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FlushOnlyNoStraight()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraightFlush(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}
