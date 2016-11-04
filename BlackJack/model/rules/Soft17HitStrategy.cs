using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if (a_dealer.CalcScore() < g_hitLimit) return true;
            if (!playerDeckContainsAces(a_dealer)) return false;
            return calcPlayerScoreWithoutFirstAce(a_dealer) == 6;
        }

        private bool playerDeckContainsAces(model.Player a_dealer)
        {
            return a_dealer.GetHand().Any(c => c.GetValue() == Card.Value.Ace);
        }

        private int calcPlayerScoreWithoutFirstAce(model.Player a_dealer)
        {
            List<Card> remainingHand = new List<Card>();
            bool aceRemoved = false;

            foreach (var card in a_dealer.GetHand())
            {
                if (card.GetValue() == Card.Value.Ace && !aceRemoved)
                {
                    aceRemoved = true;
                    continue;
                }

                remainingHand.Add(card);
            }

            return a_dealer.CalcScore(remainingHand);
        }
    }
}
