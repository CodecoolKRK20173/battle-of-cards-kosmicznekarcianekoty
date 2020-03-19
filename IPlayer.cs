namespace Card_Game
{
    interface IPlayer
    {
        string Name {get; set;}
        void AddCardToPlayerCards(Card SingleCard);
        void RemoveCardFromePlayerCards();
        void GetTopCardFromPlayerCards();
        int GetNumberOfCardsInPlayersDeck();
    }
}