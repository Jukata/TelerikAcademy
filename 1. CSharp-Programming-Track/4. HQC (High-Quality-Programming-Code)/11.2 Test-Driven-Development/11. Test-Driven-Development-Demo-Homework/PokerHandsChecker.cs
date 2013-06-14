using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (hand.Cards[i].Face == hand.Cards[j].Face &&
                        hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsRoyalFlush(IHand hand)
        {
            hand.Sort();
            bool isRoyalFlush = IsValidHand(hand) && AreAllCardsSequence(hand) &&
                AreAllCardsSameSuit(hand) && hand.Cards[0].Face == CardFace.Ten;
            return isRoyalFlush;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isStraightFlush = IsValidHand(hand) && AreAllCardsSequence(hand) &&
                AreAllCardsSameSuit(hand) && hand.Cards[0].Face != CardFace.Ten;
            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsThereCardsWithSameFace(hand, 4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsThereCardsWithSameFace(hand, 3) && IsThereCardsWithSameFace(hand, 2))
            {
                return true;
            }

            return false;

            //var sorted = hand.Cards.OrderBy(x => x.Face).ToList();
            ////3 + 2
            //if (sorted[0].Face == sorted[1].Face == sorted[2].Face)
            //{
            //    if (sorted[3].Face == sorted[4].Face)
            //    {
            //        return true;
            //    }
            //}
            ////2 + 3
            //if (sorted[0].Face == sorted[1].Face)
            //{
            //    if (sorted[2].Face == sorted[3].Face == sorted[4].Face)
            //    {
            //        return true;
            //    }
            //}
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (AreAllCardsSameSuit(hand) && !AreAllCardsSequence(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (AreAllCardsSequence(hand) && !AreAllCardsSameSuit(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsThereCardsWithSameFace(hand, 3) && !IsThereCardsWithSameFace(hand, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            int[] cardFacesCount = CountCardFacesInHand(hand);

            bool pairFound = false;

            for (int i = 0; i < cardFacesCount.Length; i++)
            {
                if (cardFacesCount[i] == 2)
                {
                    if (pairFound)
                    {
                        return true;
                    }
                    else
                    {
                        pairFound = true;
                    }
                }
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (IsThereCardsWithSameFace(hand, 2) && !IsTwoPair(hand) && !IsFullHouse(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            // high card when all faces are different
            // and there is at least two suits (isn't flush)
            int[] cardFacesCount = CountCardFacesInHand(hand);
            for (int i = 0; i < cardFacesCount.Length; i++)
            {
                // there is same face more than once.
                if (cardFacesCount[i] != 0 && cardFacesCount[i] != 1)
                {
                    return false;
                }
            }

            if (IsFlush(hand))
            {
                return false;
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool IsThereCardsWithSameFace(IHand hand, int count)
        {
            int[] cardFacesCount = CountCardFacesInHand(hand);

            for (int i = 0; i < cardFacesCount.Length; i++)
            {
                if (cardFacesCount[i] == count)
                {
                    return true;
                }
            }

            return false;
        }

        private bool AreAllCardsSequence(IHand hand)
        {
            hand.Sort();

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                int previousCardPower = (int)hand.Cards[i].Face;
                int nextCardPower = (int)hand.Cards[i + 1].Face;
                if (previousCardPower != nextCardPower - 1)
                {
                    // A 2 3 4 5 is also valid sequence
                    bool isStraightWIthAceAsMin = i == 3 && previousCardPower == 5 && nextCardPower == 14;
                    if (!isStraightWIthAceAsMin)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool AreAllCardsSameSuit(IHand hand)
        {
            CardSuit firstCardSuit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (firstCardSuit != hand.Cards[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        private int[] CountCardFacesInHand(IHand hand)
        {
            int[] cardFacesCount = new int[(int)CardFace.Ace + 1];

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var currentCardFace = hand.Cards[i].Face;
                cardFacesCount[(int)currentCardFace]++;
            }

            return cardFacesCount;
        }

        private int[] CountCardSuitsInHand(IHand hand)
        {
            int[] cardSuitsCount = new int[(int)CardSuit.Spades + 1];

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var currentCardSuit = hand.Cards[i].Suit;
                cardSuitsCount[(int)currentCardSuit]++;
            }

            return cardSuitsCount;
        }
    }
}
