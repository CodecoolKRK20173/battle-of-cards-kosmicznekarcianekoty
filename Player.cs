namespace Card_Game
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        // public List<Card> Cards {get; private set;}
        public PlayerDeck localDeck;
        /*----*/
        public Player()
        {
            localDeck = new PlayerDeck();
        }
        /*-----*/

        public void AddCardToPlayerCards(Card SingleCard)
        {
            if (SingleCard is null)
            {
                throw new System.ArgumentNullException(nameof(SingleCard));
            }
            localDeck.AddCardToDeckBottom(SingleCard);
        }
        public void GetTheTopCardFromPlayerCards() => localDeck.GetTopCard();
        public void RemoveCardFromePlayerCards() => localDeck.RemoveTopCard();
        public void GetTopCardFromPlayerCards() => localDeck.GetTopCard();
        public int GetNumberOfCardsInPlayersDeck() => localDeck.GetPlayerDeckCount();
    }
}