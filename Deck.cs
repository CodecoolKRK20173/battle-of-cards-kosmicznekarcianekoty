using System.Collections.Generic;
using System.Linq;

namespace Card_Game
{
    public abstract class Deck
    {
        public List<Card> Cards { get; internal set; } = new List<Card> ();
        public bool IsEmpty()
        {
            return Cards.Count < 1;
        }
        public void SortCards(CardsAttributes attribute)
        {
            Cards = Cards.OrderByDescending(card => card[attribute]).ToList();
        }
        public bool IsTie(CardsAttributes attribute)
        {
            var highestCard = GetHighestCard(attribute);
            
            return Cards[1][attribute] == highestCard[attribute];
        }
        public Card GetHighestCard(CardsAttributes attribute)
        {
            SortCards(attribute);
            return Cards[0];
        }
        public void AddCardsToDeckBottom(List<Card> wonCards)
        {
            Cards.AddRange(wonCards);
        }
    }
}
