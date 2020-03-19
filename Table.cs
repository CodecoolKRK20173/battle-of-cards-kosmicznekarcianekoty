using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Card_Game
{
    public class Table
    {
        public Player RoundWinner { get; private set; }
        public Dictionary<Card, Player> CardOwners { get; private set; } = new Dictionary<Card, Player>();
        public TableDeck RoundDeck { get; private set; }
        private List<Player> players;
        private TableDeck tableDeck;
        private TableDeck benchDeck;

        public Table(params string[] playersNames) // first inserted player will start the game
        {
            CreateTableDeck();
            RoundDeck = new TableDeck();
            benchDeck = new TableDeck();
            CreatePlayers(playersNames);
            CreateCardOwners();
            RoundWinner = players[0];
        }

        private void CreateTableDeck()
        {
            string fileName = Path.GetFileName(Directory.GetFiles("files")[0]); // DAO selected according to the only file in the "files" directory
            ICardsDAO fullDeck = GetProperDAO(fileName);
            tableDeck = new TableDeck(fullDeck);
        }

        private ICardsDAO GetProperDAO(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            switch (extension)
            {
                case ".csv":
                    return new CardsDAO();
                default:
                    throw new FileNotFoundException("Not possible to upload cards.");
            }
        }

        private void CreatePlayers(string[] playersNames)
        {
            players = new List<Player>();
            foreach (string name in playersNames)
            {
                Player newPlayer = new Player();
                newPlayer.Name = name;
                players.Add(newPlayer);
            }
        }

        private void CreateCardOwners()
        {
            foreach (Card card in tableDeck.Cards)
            {
                CardOwners.Add(card, null);
            }
        }
        
        public void DealCards()
        {
            tableDeck.Shuffle();
            SetCardsToPlay();
            while (!tableDeck.IsEmpty())
            {
                 foreach (Player player in players)
                 {
                    Card oneCardToDeal = tableDeck.GetTopCard();
                    player.AddCardToPlayerCards(oneCardToDeal);
                    AssignOwnerToCard(player, oneCardToDeal);
                    tableDeck.RemoveTopCards(1);
                 }
            }
        }

        private void SetCardsToPlay()
        {
            int cardsToRemove = tableDeck.Cards.Count % players.Count;
            tableDeck.RemoveTopCards(cardsToRemove);
        }

        public void EndOfRound(CardsAttributes chosenAttribute)
        {
            if (RoundDeck.IsTie(chosenAttribute))
            {
                CopyCardsToDeckFromDeck(benchDeck, RoundDeck);
            }
            else
            {
                Card highestCard = RoundDeck.GetHighestCard(chosenAttribute);
                AssignOwnerToCard(RoundWinner, highestCard);
                CopyCardsToWinnerDeck();
                SetStartingPlayer();
            }
            RoundDeck.Cards.Clear();
        }
        
        public void PlayersPlayCard()
        {
            foreach (Player player in players)
            {
                List<Card> oneCardToPlay = new List<Card> { player.GetTopCardFromPlayerCards() };
                player.RemoveCardFromPlayerCards();
                RoundDeck.AddCardsToDeckBottom(oneCardToPlay);
            }
        }

        private void CopyCardsToDeckFromDeck(Deck toDeck, Deck fromDeck)
        {
            toDeck.AddCardsToDeckBottom(fromDeck.Cards);
        }

        private void CopyCardsToWinnerDeck()
        {
            CopyCardsToDeckFromDeck(RoundDeck, benchDeck);
            AssignOwnerToDeckOfCards(RoundWinner, RoundDeck);
            CopyCardsToDeckFromDeck(RoundWinner.localDeck, RoundDeck);
        }

        private void AssignOwnerToCard(Player owner, Card card)
        {
            CardOwners[card] = owner;
        }

        private void AssignOwnerToDeckOfCards(Player owner, Deck deck)
        {
            foreach (Card card in deck.Cards)
            {
                CardOwners[card] = owner;
            }
        }

        private void SetStartingPlayer()
        {
            if (RoundWinner != players[0])
            {
                int winnerIndex = players.IndexOf(RoundWinner);
                players.RemoveAt(winnerIndex);
                players.Insert(0, RoundWinner);
            }
        }

        public bool IsGameOver()
        {
            return players.Any(player => player.localDeck.IsEmpty());
        }

        public Player GetWinner()
        {
            return players.OrderByDescending(player => player.GetNumberOfCardsInPlayersDeck()).First();
        }
    }
}
