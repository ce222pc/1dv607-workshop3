using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.controller
{


    class PlayGame : IBlackJackObserver

    {
        private view.IView m_view;
        private model.Game m_game;
        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_view = a_view;
            m_game = a_game;
            m_game.AddSubscriber(this);
        }

        public void OnCardDealt(model.Card a_card)
        {
            // something something view
            Console.WriteLine("Dealing card...");
            RenderTable();
            m_view.Pause();
        }

        public bool Play()
        {
            RenderTable();

            int input = m_view.GetInput();
            if (input == view.MenuChoice.Play)
            {
                m_game.NewGame();
            }
            else if (input == view.MenuChoice.Hit)
            {
                m_game.Hit();
            } else if (input == view.MenuChoice.Stand)
            {
                m_game.Stand();
            }

            return input != view.MenuChoice.Quit;
        }

        public void RenderTable()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
        }
    }
}
