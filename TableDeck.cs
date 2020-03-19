using System;
using System.Collections.Generic;
using System.Linq;

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

            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = rand.Next(n+1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
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
                Cards.RemoveAt(Cards.Count -1);
            }
        }

        public void ChangeCardsOwner(Player owner)
        {
            foreach (Card card in Cards) card.ChangeOwner(owner);
        }
    }
}
