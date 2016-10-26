using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Game game = new model.Game();
            view.IView view = new view.SimpleView(); // new view.SwedishView();
            controller.PlayGame controller = new controller.PlayGame(game, view);

            while (controller.Play());
        }
    }
}
