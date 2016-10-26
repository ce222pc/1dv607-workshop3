﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.BlackJackObserver
    {
        private view.IView m_view;
        private model.Game m_game;
        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_view = a_view;
            m_game = a_game;
            m_game.AddSubscriber(this);
        }

        public bool Play()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            String input = m_view.GetInput().ToString();

            if (input == "Play")
            {
                m_game.NewGame();
            }
            else if (input == "Hit")
            {
                m_game.Hit();
            } else if (input == "Stand")
            {
                m_game.Stand();
            }

            return input != "Quit";
        }
    }
}
