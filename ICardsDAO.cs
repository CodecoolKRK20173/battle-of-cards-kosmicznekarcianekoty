using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    public interface ICardsDao
    {
        public List<Card> GetCards();
        public Card GetCardByID();

    }
}
