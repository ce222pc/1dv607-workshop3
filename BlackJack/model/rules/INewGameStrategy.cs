using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface INewGameStrategy
    {
        bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player);
        void getAndDeal(Deck a_deck, Player a_participant, bool show);
    }
}
