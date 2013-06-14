using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class PokerHandsCheckerIsValidHand
    {
        [TestMethod]
        public void IsValidHandTrivial()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsValidHand(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIsValidHandForTwoSameCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsValidHand(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsValidHandAllSameSuit()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsValidHand(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsValidHandAllSameFace()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsValidHand(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}
