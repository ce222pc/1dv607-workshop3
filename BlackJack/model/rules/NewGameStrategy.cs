using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    abstract class NewGameStrategy : INewGameStrategy
    {
        public abstract bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player);

        protected void getAndDeal(Deck a_deck, Player a_participant, bool show)
        {
            Card c;
            c = a_deck.GetCard();
            c.Show(show);
            a_participant.DealCard(c);
        }

    }
}
