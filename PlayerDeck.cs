using System.Linq;

namespace Card_Game
{
    public class PlayerDeck : Deck
    {
        public Card GetTopCard()
        {
            return Cards.Last();
        }
    }
}
