using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IGameWinnerStrategy m_winnerStrategy;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerStrategy = a_rulesFactory.GetGameWinnerStrategy();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);
            }
            return false;
        }

        public void getAndDeal(Deck a_deck, Player a_participant, bool show)
        {
            Card c;
            c = a_deck.GetCard();
            c.Show(show);
            a_participant.DealCard(c);
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                getAndDeal(m_deck, a_player, true);
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
                while (m_hitRule.DoHit(this))
                {
                    Hit(this);
                }
            }
            return true;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerStrategy.IsDealerWinner(this, a_player, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
