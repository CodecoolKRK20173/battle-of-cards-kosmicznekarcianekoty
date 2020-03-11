using System.Collections.Generic;

namespace Card_Game
{
    public class TableDeck : Deck
    {
        private List<Player> Players { get; set; }
        private ICardsDAO FullDeck { get; set; }
        public TableDeck(ICardsDAO fullDeck)
        {
            FullDeck = fullDeck;
            Cards = FullDeck.GetCards();
        }
        public void DealCards()
        {
            var cardsPerPlayer = Cards.Count/Players.Count;

            for(int i = 0; i < cardsPerPlayer; i++)
            {
                foreach(var player in Players)
                {
                    var lastCard = Cards.Count -1;
                    player.Cards.Add(Cards[lastCard]);
                    Cards.RemoveAt(lastCard);
                }
             }   
        }
    }
}
