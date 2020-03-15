using System;
using System.Collections.Generic;

namespace Card_Game
{
    public class Table
    {
        public List<Player> players;
        private Player startingPlayer;
        public Player roundWinner { get; private set; }
        private TableDeck tableDeck;
        private TableDeck roundDeck;
        private TableDeck benchDeck;

        
        public Table(List<Player> players, ICardsDAO fullDeck)
        {
            if (players.Count > 1)
            {
                this.players = players;
                this.startingPlayer = players[0];
                this.tableDeck = new TableDeck(fullDeck);
                this.roundDeck = new TableDeck();
                this.benchDeck = new TableDeck();
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
                    player.PlayerDeck.AddCardsToDeckBottom(oneCardToDeal);
                    oneCardToDeal[0].Owner = player;
                    tableDeck.RemoveTopCards(1);
                 }
            }
        }

        private void SetCardsToPlay()
        {
            int cardsToRemove = tableDeck.Cards.Count % players.Count;
            tableDeck.RemoveTopCards(cardsToRemove);
        }

        public void GameRound(CardsAttributes chosenAttribute)
        {
            PlayersPlayCard();
            if (roundDeck.IsTie(chosenAttribute))
            {
                CopyCardsToBenchDeck();
            }
            else
            {
                Card highestCard = roundDeck.GetHighestCard(chosenAttribute);
                roundWinner = highestCard.Owner;
                CopyCardsToWinnerDeck();
                SetRoundWinnerStatus();
                SetPlayersNewOrderAfterRound();
            }
            roundDeck.Cards.Clear();
        }
        
        private void PlayersPlayCard()
        {
            foreach (Player player in players)
            {
                List<Card> oneCardToPlay = player.PlayerDeck.GetTopCards(1);
                player.PlayerDeck.RemoveTopCards(1);
                oneCardToPlay[0].Owner = null;
                roundDeck.AddCardsToDeckBottom(oneCardToPlay);
            }
        }

        private void CopyCardsToBenchDeck()
        {
            benchDeck.AddCardsToDeckBottom(roundDeck.Cards);
        }

        private void CopyCardsToWinnerDeck()
        {
            roundDeck.AddCardsToDeckBottom(benchDeck.Cards);
            foreach(Card card in roundDeck.Cards)
            {
                card.Owner = roundWinner;
            }
            roundWinner.PlayerDeck.AddCardsToDeckBottom(roundDeck.Cards);
        }

        private void SetRoundWinnerStatus()
        {
            foreach (Player player in players)
            {
                 player.IsRoundWinner = false;
            }  
            roundWinner.IsRoundWinner = true;
        }

        private void SetPlayersNewOrderAfterRound()
        {
            List<Player> playersInNewOrder = new List<Player>();
            if (roundWinner != startingPlayer)
            {
                int winnerIndex = players.IndexOf(roundWinner);

                for (int i = winnerIndex; i < players.Count; i++)
                {
                    playersInNewOrder.Add(players[i]);
                }

                for (int i = 0; i < winnerIndex; i++)
                {
                    playersInNewOrder.Add(players[i]);
                }

                startingPlayer = roundWinner;
                players = playersInNewOrder;
            }
        }

        public bool GameIsOver()
        {
            foreach (Player player in players)
            {
                if (player.PlayerDeck.IsEmpty())
                {
                    return true;
                }
            }
            return false;
        }
    }
}


//Deck class
// Make Cards public
// remove selecetdCards parameter from 3 methods, instead use Cards field - to discuss
// is SortCards method actually needed?

//TableDeck class
// discuss if to create below metod:
// public void RemoveAllCardsFromDeck()
//         {
//             Cards.Clear();
//         }

//Card class
// add Owner field: public Player Owner { get; set; }
// create SetOwnerAsNull method?

//Player class
// PlayerDeck prop needed
// IsRoundWinner prop needed