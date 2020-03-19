using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    public class Game
    {
        private Table gameTable;
        private int minPlayers = 2;
        private int maxPlayers = 5;
        private View view = new View();
        private string[] playersNames;

        public void IntroducePlayers()
        {
            view.Print("Welcome to Space Cats Game! \nPlease introduce yourself and other players, seperate names with comma. \nThe limit of players is " + maxPlayers);
            playersNames = Console.ReadLine().Split(',');
            while (playersNames.Length < minPlayers || playersNames.Length > maxPlayers)
            {
                view.Print("Invalid numbers of players! Please try again!");
                playersNames = Console.ReadLine().Split(',');
            }
            view.Print($"Welcome {string.Concat(playersNames)}!");
        }
    }
}
