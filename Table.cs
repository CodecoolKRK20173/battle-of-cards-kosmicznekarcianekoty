using System.IO;
using System.Collections.Generic;

namespace Card_Game
{
    public class Table
    {
        private List<Player> players;
        private TableDeck tableDeck;
        private TableDeck roundDeck = new TableDeck();
        private TableDeck benchDeck = new TableDeck();
        private Player roundWinner;
        private Dictionary<Card, Player> cardOwners;


        public Table(params string[] playersNames) // first inserted player will start the game
        {
            CreateTableDeck();
            CreatePlayers(playersNames);
            CreateCardOwners();
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
                case "csv":
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
                cardOwners.Add(card, null);
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
                    List<Card> oneCardToDeal = tableDeck.GetTopCards(1);
                    player.AddCardToPlayerCards(oneCardToDeal[0]);
                    AssignOwnerToCard(player, oneCardToDeal[0]);
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
            if (roundDeck.IsTie(chosenAttribute))
            {
                CopyCardsToDeckFromDeck(benchDeck, roundDeck);
            }
            else
            {
                Card highestCard = roundDeck.GetHighestCard(chosenAttribute);
                AssignOwnerToCard(roundWinner, highestCard);
                CopyCardsToWinnerDeck();
                SetStartingPlayer();
            }
            roundDeck.Cards.Clear();
        }
        
        private void PlayersPlayCard()
        {
            foreach (Player player in players)
            {
                List<Card> oneCardToPlay = player.GetTopCardFromPlayerCards();
                player.RemoveCardFromePlayerCards();
                roundDeck.AddCardsToDeckBottom(oneCardToPlay);
            }
        }

        private void CopyCardsToDeckFromDeck(Deck toDeck, Deck fromDeck)
        {
            toDeck.AddCardsToDeckBottom(fromDeck.Cards);
        }

        private void CopyCardsToWinnerDeck()
        {
            CopyCardsToDeckFromDeck(roundDeck, benchDeck);
            AssignOwnerToDeckOfCards(roundWinner, roundDeck);
            CopyCardsToDeckFromDeck(roundWinner.localDeck, roundDeck);
        }

        private void AssignOwnerToCard(Player owner, Card card)
        {
            cardOwners[card] = owner;
        }

        private void AssignOwnerToDeckOfCards(Player owner, TableDeck deck)
        {
            foreach (Card card in deck.Cards)
            {
                cardOwners[card] = owner;
            }
        }

        private void SetStartingPlayer()
        {
            if (roundWinner != players[0])
            {
                int winnerIndex = players.IndexOf(roundWinner);
                players.RemoveAt(winnerIndex);
                players.Insert(0, roundWinner);
            }
        }

        public bool IsGameOver()
        {
            foreach (Player player in players)
            {
                if (player.localDeck.IsEmpty())
                {
                    return true;
                }
            }
            return false;
        }

        public Player GetWinner()
        {
            Player winner = players[0];
            foreach (Player player in players)
            {
                if (player.GetNumberOfCardsInPlayersDeck() > winner.GetNumberOfCardsInPlayersDeck())
                {
                    winner = player;
                }
            }
            return winner;
        }

        public TableDeck GetRoundDeck()
        {
            return roundDeck;
        }

    }
}
