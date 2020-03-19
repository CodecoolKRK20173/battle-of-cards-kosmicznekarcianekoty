using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    public class Game
    {
        public bool isRunning { get; private set; }
        private Table gameTable;
        private int minPlayers = 2;
        private int maxPlayers = 5;
        private View view = new View();
        private string[] playersNames;
        private int rounds = 1;

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

        public void InitializeGame()
        {
            gameTable = new Table(playersNames);
            view.Print($"Created {playersNames.Length} players");
            gameTable.DealCards();
            view.Print($"The cards are shuffled and dealed between players");
        }

        public void PlayRound()
        {
            view.Print($"Round: {rounds++}\nActive player: {gameTable.RoundWinner.Name}");
            gameTable.PlayersPlayCard();
            view.PrintCard(gameTable.GetActivePlayerCard(), gameTable.CardOwners);
            view.Print("Please choose attribute to fight (1-4)");
            view.PrintAttributes();
            CardsAttributes attribute = GetAttribute();
            view.Print($"{gameTable.RoundWinner.Name} plays {attribute}");
        }

        public CardsAttributes GetAttribute()
        {
            int attributesNumber = Enum.GetNames(typeof(CardsAttributes)).Length + 1;
            bool correctInput = false;
            string attribute;
            int value = 0;
            while (!correctInput)
            {
                attribute = Console.ReadLine();
                try
                {
                    value = int.Parse(attribute);
                }
                catch
                {
                    view.Print("Incorrect input type!");
                }
                if (value < attributesNumber && value > 0) correctInput = true;
                else view.Print("Incorrect attribute number!");
            }

            return (CardsAttributes)value-1;

        }
    }
}
