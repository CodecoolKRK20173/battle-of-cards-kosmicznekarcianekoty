
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

        public void AddCardToLocalDeck(Card SingleCard) => localDeck.AddCardToDeckBottom(SingleCard);
        public void RemoveCardFromePlayerCards(Card SingleCard) => localDeck.RemoveTopCard();
        public int GetNumberOfCardsInPlayersDeck() => localDeck.GetPlayerDeckCount();
    }
}
