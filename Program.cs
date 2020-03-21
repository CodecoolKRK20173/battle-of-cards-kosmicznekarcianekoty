using System;

namespace Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.IntroducePlayers();
            game.InitializeGame();
            game.PlayUntilEnd();

        }
    }
}
