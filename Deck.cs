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
        public void SortCards(List<Card> selectedCards, CardsAttributes attribute)
        {
            selectedCards.OrderBy(card => card[attribute]);
        }
        public bool IsTie(List<Card> selectedCards, CardsAttributes attribute)
        {
            var highestCard = selectedCards.OrderBy(card => card[attribute]).First();
            
            for (int i=1; i<selectedCards.Count; i++)
            {
                if(selectedCards[i][attribute] == highestCard[attribute])
                {
                    return true;
                }
            }
            return false;
        }
        public Card GetHighestCard(List<Card> selectedCards, CardsAttributes attribute)
        {
            return selectedCards.OrderBy(card => card[attribute]).First();
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
