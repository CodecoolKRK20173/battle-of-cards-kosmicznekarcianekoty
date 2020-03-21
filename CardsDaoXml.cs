using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;


namespace Card_Game
{
    class CardsDaoXml : ICardsDAO
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

        public List<Card> LoadCards()
        {
            string path = "files/cards.xml";
            List<Card> cards = new List<Card>();
            XmlDocument file = new XmlDocument();
            file.Load(path);
            int id = 0;
            foreach (XmlNode node in file.DocumentElement.ChildNodes)
            {
                cards.Add(LoadCardFromNode(node, id++));
            }

            return cards;
        }

        private Card LoadCardFromNode(XmlNode card, int id)
        {
            string name = "";
            string description = "";
            List<int> attributes = new List<int>();

            foreach (XmlNode element in card)
            {
                if (element.Name == "name") name = element.InnerText;
                if (element.Name == "description") description = element.InnerText;
                if (element.Name == "attribute") attributes.Add(int.Parse(element.InnerText));
            }

            return new Card(id, name, description, attributes);
        }
    }
}
