using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Card_Game
{
    public class CardsDAO : ICardsDAO
    {
        private List<Card> cards = null;
        private List<Card> Cards
        {
            get
            {
                if (cards == null)
                    cards = LoadCards();
                return cards;
            }
        }

        public Card GetCardByID(int id)
        {
            return Cards.FirstOrDefault(x => x.ID == id);
        }

        public List<Card> GetCards()
        {
            return Cards;
        }

        private List<Card> LoadCards()
        {
            string filePath = "files/cards.csv";
            List<string> data = FileHandler.GetFileContentAsList(filePath);
            List <Card> cards = new List<Card>();
            int index = 0;
            string[] lineValues;
            List<int> attributes = new List<int> { };

            foreach(string record in data)
            {
                lineValues = record.Split(',');
                for (int i = 2; i < Enum.GetNames(typeof(CardsAttributes)).Length+2; i++)
                {
                    attributes.Add(int.Parse(lineValues[i]));
                }

                cards.Add(new Card(index++, lineValues[0], lineValues[1], attributes));
            }

            return cards;
        }
    }
}
