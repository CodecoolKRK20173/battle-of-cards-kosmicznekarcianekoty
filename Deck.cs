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
            Cards = Cards.OrderBy(card => card[attribute]).ToList();
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
            Cards.AddRange(wonCards);
        }
    }
}
