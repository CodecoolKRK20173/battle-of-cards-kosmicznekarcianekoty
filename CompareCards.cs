using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    public class CompareCards : IComparer<Card>
    {
        private CardsAttributes attribute;

        public CompareCards(CardsAttributes attribute)
        {
            this.attribute = attribute;
        }

        int IComparer<Card>.Compare(Card x, Card y)
        {
            if (x[attribute] > y[attribute])
                return 1;

            if (x[attribute] == y[attribute])
                return 0;

            return -1;
        }
    }
}
