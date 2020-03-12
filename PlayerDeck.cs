using System.Linq;

namespace Card_Game
{
    public class PlayerDeck : Deck
    {
        public Card GetTopCard()
        {
            return Cards.Last();
        }
        public void RemoveTopCard()
        {
            Cards.RemoveAt(Cards.Count -1);
        }
        public void AddCardToDeckBottom(Card card)
        {
            Cards.Insert(0,card);
        }
    }
}
