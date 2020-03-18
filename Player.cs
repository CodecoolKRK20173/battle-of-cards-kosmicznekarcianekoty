
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
<<<<<<< HEAD

=======
>>>>>>> c2e9c8715694887ca13f4773efa617b89b4bc992
        public void RemoveCardFromePlayerCards() => localDeck.RemoveTopCard();
        public int GetNumberOfCardsInPlayersDeck() => localDeck.GetPlayerDeckCount();
    }
}
