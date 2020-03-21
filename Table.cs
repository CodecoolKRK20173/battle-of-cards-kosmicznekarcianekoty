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
            tableDeck = new TableDeck(new CardsDaoXml());
            RoundDeck = new TableDeck();
            benchDeck = new TableDeck();
            CreatePlayers(playersNames);
            CreateCardOwners();
            RoundWinner = players[0];
        }

        public bool IsTie()
        {
            return !benchDeck.IsEmpty();
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

        public Card GetActivePlayerCard()
        {
            return RoundDeck.Cards[0];
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
                MoveCardsToDeckFromDeck(benchDeck, RoundDeck);
            }
            else
            {
                Card highestCard = RoundDeck.GetHighestCard(chosenAttribute);
                RoundWinner = CardOwners[highestCard];
                MoveCardsToWinnerDeck();
                SetStartingPlayer();
            }
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

        private void MoveCardsToDeckFromDeck(Deck toDeck, Deck fromDeck)
        {
            toDeck.AddCardsToDeckBottom(fromDeck.Cards);
            fromDeck.Cards.Clear();
        }

        private void MoveCardsToWinnerDeck()
        {
            MoveCardsToDeckFromDeck(RoundDeck, benchDeck);
            AssignOwnerToDeckOfCards(RoundWinner, RoundDeck);
            MoveCardsToDeckFromDeck(RoundWinner.localDeck, RoundDeck);
        }

        private void AssignOwnerToCard(Player owner, Card card)
        {
            CardOwners[card] = owner;
        }

        private void AssignOwnerToDeckOfCards(Player owner, Deck deck)
        {
            foreach (Card card in deck.Cards)
            {
                AssignOwnerToCard(owner, card);
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
