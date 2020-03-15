using System.Collections.Generic;


namespace Card_Game
{
    public class Player 
    {

        List<Card> Cards {get; set;}
        /*----*/
        public Player()
        {
            Cards = new List<Card>();
        }
        /*-----*/

        public void AddCardToPlayerCards(Card SingleCard) => Cards.Insert(0, SingleCard);
        public void RemoveCardFromePlayerCards(Card SingleCard) => new PlayerDeck().RemoveTopCard();

    }
}
