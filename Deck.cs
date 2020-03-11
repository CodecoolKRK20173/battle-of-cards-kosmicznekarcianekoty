using System;
using System.Collections.Generic;

namespace Card_Game
{
    public abstract class Deck
    {
        protected List<Card> Cards { get; set; }
        private Random rand = new Random();
        public bool IsEmpty()
        {
            if(Cards.Count < 1)
            {
                return true;
            }
            return false;
        }
        public void Shuffle()
        {
            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = rand.Next(n+1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }
    }
}
