using System.Linq;

namespace Card_Game
{
    public class PlayerDeck : Deck
    {
        public Card GetTopCard()
        {
            return Cards[0];
        }
        public void RemoveTopCard()
        {
            Cards.RemoveAt(0);
        }
        public void AddCardToDeckBottom(Card card)
        {
            Cards.Insert(0,card);
        }
        public int GetPlayerDeckCount()
        {
            return Cards.Count();            
        }
    }
}
