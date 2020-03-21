using System;
using System.Collections.Generic;
using System.Xml;


namespace Card_Game
{
    class CardsDaoXml : ICardsDAO
    {

        private List<Card> cards = new List<Card>();

        public Card GetCardByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetCards()
        {
            throw new NotImplementedException();
        }

        public void LoadCards()
        {
            string path = "files/cards.xml";
            XmlDocument file = new XmlDocument();
            file.Load(path);
            int id = 0;
            foreach (XmlNode node in file.DocumentElement.ChildNodes)
            {
                cards.Add(LoadCardFromNode(node, id++));
            }
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
