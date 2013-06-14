using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class PokerHandsCheckerIsFourOfAKind
    {
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

            bool result = checker.IsFourOfAKind(hand);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotFourOfAKindTrivial()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            bool result = checker.IsFourOfAKind(hand);
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

            bool result = checker.IsFourOfAKind(hand);
            bool expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}
