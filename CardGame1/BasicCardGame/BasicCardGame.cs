﻿using System.Collections.Generic;
using BasicCard.CardGameFramework;

namespace BasicCard
{
    public class BasicCardGame
    {
        #region Fields

        // private Deck and Player objects for the current deck, dealer, and player
        private Deck deck;
        private readonly Player dealer;
        private readonly Player player;

        #endregion

        #region Properties

        // public properties to return the current player, dealer, and current deck
        public Player CurrentPlayer { get { return player; } }
        public Player Dealer { get { return dealer; } }
        public Deck CurrentDeck { get { return deck; } }

        #endregion

        #region Main Game Constructor

        /// <summary>
        /// Main Constructor for BasicCard Game, balance is added for betting if added
        /// </summary>
        /// <param name="initBalance"></param>
        public BasicCardGame(int initBalance)
        {
            // Create a dealer and one player with the initial balance.
            dealer = new Player();
            player = new Player(initBalance);
        }

        #endregion

        #region Game Methods

        public void NewCardShuffle()
        {
            // Create a new deck and then shuffle the deck
            deck = new Deck();
            deck.Shuffle();

            // Fisher - Yates shuffle algorithm
            //deck.ShuffleCards();
        }

        /// <summary>
        /// Deals a new game. This is invoked through the Deal button in BasicCardForm.cs
        /// </summary>
        public void DealNewGame(int NumberOfCards)
        {

            //// Create a new deck and then shuffle the deck,
            ///  used if we need shuffle after each hand, pass the deal button to next player
            //deck = new Deck();
            //deck.Shuffle();

            //calls Fisher-Yates shuffle algorithm
            //deck.ShuffleCards();

            // Reset the player and the dealer's hands in case this is not the first game
            player.NewHand();
            dealer.NewHand();

            // Deal two cards to each person's hand, 5 cards, 0-4
            for (int i = 0; i <= NumberOfCards; i++)
            {
                Card c = deck.Draw();

                //Set the player's cards to be face-down, the cards will be displayed face-up when sorted
                c.IsCardUp = false;

                player.Hand.Cards.Add(c);

                Card d = deck.Draw();
                // Set the dealer's cards to be facing down
                //if (i == 1)
                    d.IsCardUp = false;

                dealer.Hand.Cards.Add(d);
            }

            // Give the player and the dealer a handle to the current deck
            player.CurrentDeck = deck;
            dealer.CurrentDeck = deck;
        }

        //used for testing sending and receiving parameters in function
        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Update the player's record with a loss
        /// </summary>
        public void PlayerLose()
        {
            player.Losses += 1;
        }

        /// <summary>
        /// Update the player's record with a win
        /// </summary>
        public void PlayerWin()
        {
            player.Balance += player.Bet * 2;
            player.Wins += 1;
        }
        #endregion
    }
}
