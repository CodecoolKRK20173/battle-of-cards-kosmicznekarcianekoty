
namespace Card_Game
{
    interface IPlayer
    {
        string Name {get; set;}
        void AddCardToPlayerCards(Card SingleCard);
        void AddCardToLocalDeck(Card SingleCard);
        void RemoveCardFromePlayerCards(Card SingleCard);
        int GetNumberOfCardsInPlayersDeck();
    }
}