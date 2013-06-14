using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class SortHandTest
    {
        [TestMethod]
        public void SortAllCards()
        {
            IList<ICard> allCards = GenerateAllCards();
            Hand handOfAllCards = new Hand(allCards);

            handOfAllCards.Sort();
            bool result = IsSorted(handOfAllCards);

            Assert.IsTrue(result);
        }

        private bool IsSorted(Hand handOfAllCards)
        {
            IList<ICard> allCardsSorted = GenerateSortedCards();
            Hand handOfAllSortedCards = new Hand(allCardsSorted);

            for (int i = 0; i < handOfAllCards.Cards.Count; i++)
            {
                if (handOfAllCards.Cards[i].Face != handOfAllSortedCards.Cards[i].Face ||
                    handOfAllCards.Cards[i].Suit != handOfAllSortedCards.Cards[i].Suit
                    )
                {
                    return false;
                }
            }

            return true;
        }

        private IList<ICard> GenerateSortedCards()
        {
            IList<ICard> cards = new List<ICard>();

            int minSuit = (int)CardSuit.Clubs;
            int maxSuit = (int)CardSuit.Spades;
            int minFace = (int)CardFace.Two;
            int maxFace = (int)CardFace.Ace;

            for (int i = minFace; i <= maxFace; i++)
            {
                CardFace currentFace = (CardFace)i;
                for (int j = minSuit; j <= maxSuit; j++)
                {
                    CardSuit currentSuit = (CardSuit)j;
                    cards.Add(new Card(currentFace, currentSuit));
                }
            }

            return cards;
        }

        private IList<ICard> GenerateAllCards()
        {
            IList<ICard> cards = new List<ICard>();

            int minSuit = (int)CardSuit.Clubs;
            int maxSuit = (int)CardSuit.Spades;
            int minFace = (int)CardFace.Two;
            int maxFace = (int)CardFace.Ace;

            for (int i = minSuit; i <= maxSuit; i++)
            {
                CardSuit currentSuit = (CardSuit)i;
                for (int j = minFace; j <= maxFace; j++)
                {
                    CardFace currentFace = (CardFace)j;
                    cards.Add(new Card(currentFace, currentSuit));
                }
            }

            return cards;
        }
    }
}
