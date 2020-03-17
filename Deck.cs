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
        public void SortCards(CardsAttributes attribute)
        {
            Cards.OrderBy(card => card[attribute]);
        }
        public bool IsTie(CardsAttributes attribute)
        {
            var highestCard = GetHighestCard(attribute);
            
            return Cards[1][attribute] == highestCard[attribute];
        }
        public Card GetHighestCard(CardsAttributes attribute)
        {
            return Cards.OrderBy(card => card[attribute]).First();
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
