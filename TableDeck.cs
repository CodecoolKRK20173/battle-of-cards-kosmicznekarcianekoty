using System;

namespace Card_Game
{
    public class TableDeck : Deck
    {
        private ICardsDAO FullDeck { get; set; }
        public TableDeck() {}
        public TableDeck(ICardsDAO fullDeck)
        {
            FullDeck = fullDeck;
            Cards = FullDeck.GetCards();
        }
        public void Shuffle()
        {
            Random rand = new Random();

            for (int deckSize = Cards.Count - 1; deckSize > 0; --deckSize)
            {
                int randomIndex = rand.Next(deckSize+1);
                Card currentCard = Cards[deckSize];
                Cards[deckSize] = Cards[randomIndex];
                Cards[randomIndex] = currentCard;
            }
        }
        public Card GetTopCard()
        {
            return Cards[0];
        }
        public void RemoveTopCards(int amount)
        {
            for(int i=0; i<amount; i++)
            {
                Cards.RemoveAt(0);
            }
        }
    }
}
