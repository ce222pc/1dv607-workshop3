﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Player
    {
        private List<IBlackJackObserver> m_subscribers;
        private List<Card> m_hand = new List<Card>();
        public Player()
        {
            m_subscribers = new List<IBlackJackObserver>();
        }



        public void AddSubscriber(IBlackJackObserver a_sub)
        {
            m_subscribers.Add(a_sub);
        }

        public void DealCard(Card a_card)
        {
            foreach (IBlackJackObserver subscriber in m_subscribers)
            {
                subscriber.OnCardDealt(a_card);
            }
            m_hand.Add(a_card);

        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore(IEnumerable<Card> a_hand = null)
        {
            a_hand = a_hand ?? GetHand();
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in a_hand) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }
    }
}
