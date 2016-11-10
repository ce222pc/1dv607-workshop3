using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    abstract class NewGameStrategy : INewGameStrategy
    {
        public abstract bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player);
    }
}
