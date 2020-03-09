using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Card_Game
{
    public class Card : IComparable
    {
        private string name;
        private Dictionary<CardsAttributes, int> attributes;
        private string description;
        public int ID { get; private set; }

        public Card(int ID, string name, int[] attributes, string description)
        {
            this.ID = ID;
            this.name = name;
            this.description = description;
            this.attributes = new Dictionary<CardsAttributes, int>
            {
                {CardsAttributes.Fluffiness, attributes[0]},
                {CardsAttributes.Madness, attributes[1]},
                {CardsAttributes.Gluttony, attributes[2]},
                {CardsAttributes.Laziness, attributes[3]},
            };
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
