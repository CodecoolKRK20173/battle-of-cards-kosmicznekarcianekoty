using System;
using System.Collections.Generic;

namespace Card_Game
{
    public class View
    {
        private int cardWidth = 35;
        public void PrintEmptyLine()
        {
            Console.WriteLine();
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintCard(Card card)
        {
            PrintEmptyLine();
            string nameToPrint = $"{card.Owner.Name}'s card:";
            PrintRowWithNoFrame(nameToPrint);
            PrintLine();
            PrintRow(card.Name);
            PrintLine();
            PrintRow("");
            foreach (KeyValuePair<CardsAttributes, int> attribute in card.attributes)
            {
                string textToPrint = $"{attribute.Key}: {attribute.Value}";
                PrintRow(textToPrint);
            }
            PrintRow("");
            PrintRow(card.Description);
            PrintLine();
        }

        private void PrintLine()
        {
            Console.Write(" ");
            Console.WriteLine(new string('-', cardWidth));
        }

        private void PrintRow(string text)
        {
            string row = "|";
            row += AlignCentre(text, cardWidth) + "|";
            Console.WriteLine(row);
        }

        private void PrintRowWithNoFrame(string text)
        {
            string row = " ";
            row += AlignCentre(text, cardWidth) + " ";
            Console.WriteLine(row);
        }

        private string AlignCentre(string text, int cardWidth)
        {
            text = text.Length > cardWidth ? text.Substring(0, cardWidth - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', cardWidth);
            }
            else
            {
                return text.PadRight(cardWidth - (cardWidth - text.Length) / 2).PadLeft(cardWidth);
            }
        }
    }
}