using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class PokerHandsCheckerIsStraight
    {
        [TestMethod]
        public void StraightTrivial()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = true;

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

            bool result = checker.IsStraight(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StraightWithAceAsMax()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StraightWithAceAsMin()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotStraightA2457()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FourSequence()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ThreeOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FourOfAKindTrivial()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotStraight()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TwoOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TwoPairs()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsStraight(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}
