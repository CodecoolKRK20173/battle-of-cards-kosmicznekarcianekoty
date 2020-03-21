namespace Card_Game
{
    interface IPlayer
    {
        string Name {get; set;}
        void AddCardToPlayerCards(Card SingleCard);
        void RemoveCardFromPlayerCards();
        Card GetTopCardFromPlayerCards();
        int GetNumberOfCardsInPlayersDeck();
    }
}