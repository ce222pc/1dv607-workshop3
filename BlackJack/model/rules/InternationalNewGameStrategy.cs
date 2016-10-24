using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    internal class InternationalNewGameStrategy : NewGameStrategy
    {

        public override bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            getAndDeal(a_deck, a_player, true);
            getAndDeal(a_deck, a_dealer, true);
            getAndDeal(a_deck, a_player, true);

            return true;
        }
    }
}
