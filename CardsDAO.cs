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
            string[] line;
            int[] attributes;

            foreach(string record in data)
            {
                line = record.Split(',');
                attributes = new int[4]
                {
                int.Parse(line[1]),
                int.Parse(line[2]),
                int.Parse(line[3]),
                int.Parse(line[4]),
                };

                cards.Add(new Card(index++, line[0], attributes, line[5]));
            }

            return cards;
        }
    }
}
