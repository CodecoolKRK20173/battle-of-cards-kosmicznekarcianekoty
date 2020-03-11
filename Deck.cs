using System.Collections.Generic;
using System.Linq;

namespace Card_Game
{
    public abstract class Deck
    {
        protected List<Card> Cards { get; set; }
        public bool IsEmpty()
        {
            if(Cards.Count < 1)
            {
                return true;
            }
            return false;
        }
        public Card GetHighestCard(List<Card> selectedCards, CardsAttributes attribute)
        {
            return selectedCards.OrderBy(card => card[attribute]).First();
        }
    }
}
