using System.Collections.Generic;


namespace Card_Game
{
    public class Player 
    {
        bool isPlayerInHand = false;  // na true, jeśli prowadzi grę
        bool isPlayerInGame = false; // na true, jeśli jeszcze w grze
        List<Card> Cards {get; set;}
        /*----*/
        public Player()
        {
            Cards = new List<Card>();
        }
        /*-----*/
        public bool GetIsPlayerInHand() => isPlayerInHand; 
        internal void ChangeIsPlayerInHand() => isPlayerInHand = true;

        public bool GetIsPlayerInGame() => isPlayerInGame;
        public void ChangeIsPlayerInGame() => isPlayerInGame = true;

        public void AddCardToPlayerCards(Card SingleCard) => Cards.Insert(0, SingleCard);
        public void RemoveCardFromePlayerCards(Card SingleCard) => new PlayerDeck().RemoveTopCard();
        public bool CheckIfLoose(List<Card> Cards) => (Cards.Count < 1) ? true : false;
    }
}
