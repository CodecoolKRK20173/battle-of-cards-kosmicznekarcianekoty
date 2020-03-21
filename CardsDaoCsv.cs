using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Card_Game
{
    public class CardsDaoCsv : ICardsDAO
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
            int id = 0;

            foreach (string record in data)
            {

                cards.Add(ReadCard(record, id++));
            }

            return cards;
        }

        private Card ReadCard(string record, int id)
        {
            var lineValues = record.Split(',');
            string cardName = lineValues[0];
            string cardDescription = lineValues[1];
            var attributes = ReadAttributes(lineValues);

            return new Card(id, cardName, cardDescription, attributes);
        }

        private List<int> ReadAttributes(string[] lineValues)
        {
            List<int> attributes = new List<int>();

            for (int i = 2; i < Enum.GetNames(typeof(CardsAttributes)).Length + 2; i++)
            {
                attributes.Add(int.Parse(lineValues[i]));
            }

            return attributes;
        }
    }
}
