using System.Collections.Generic;
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
        public void AddCardsToDeckBottom(Card card)
        {
            Cards.Insert(0,card);
        }
        public void AddCardsToDeckBottom(List<Card> wonCards)
        {
            foreach(var card in wonCards)
            {
                Cards.Insert(0, card);
            }
        }
    }
}
