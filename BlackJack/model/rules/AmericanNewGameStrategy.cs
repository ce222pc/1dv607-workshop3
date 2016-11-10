using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    internal class AmericanNewGameStrategy : NewGameStrategy
    {
        public override bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_dealer.getAndDeal(a_deck, a_player, true);
            a_dealer.getAndDeal(a_deck, a_dealer, true);
            a_dealer.getAndDeal(a_deck, a_player, true);
            a_dealer.getAndDeal(a_deck, a_dealer, false);

            return true;
        }
    }
}
