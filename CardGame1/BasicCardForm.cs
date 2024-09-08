using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BasicCard.CardGameFramework;
using System.Media;

namespace BasicCard
{
    partial class BasicCardForm : Form
    {
        //to expand regions, highlight all then use keys ctrl + M to expand
        //Tools -> Options -> Text Editor -> C# -> Advanced

        //add the pictureBox Action>Click>Method (cardClick function) to the array
        //cardButtons[i].Click += new System.EventHandler(cardClick);
        //cardButtons[i].Click += cardClick;

        #region Fields
        //Creates a new card game with one player and an inital balance set through the settings designer
        private readonly BasicCardGame game = new BasicCardGame(Properties.Settings.Default.InitBalance);
        
        private PictureBox[] playerCards;
        private PictureBox[] dealerCards;
        private bool firstTurn;

        //set value of animation interval, the lower the number the faster the dealing cards
        private readonly int AnimationTimerInterval = 15;
        private bool AnimationDone = false;

        private int PlayerCardLocationX, PlayerCardLocationY;
        private int DealerCardLocationX, DealerCardLocationY;

        private int PlayerDiscardLocationX, PlayerDiscardLocationY;
        private int DealerDiscardLocationX, DealerDiscardLocationY;

        public int MAXCARDS = 52;
        public int CardsInDeck;
        public int CardsInPlayersHand;
        public int CardsInDealersHand;

        //initial numbers of cards in initial hand, 5 cards, 0-4
        private readonly int NumberOfCards = 4;
        //how fast to deal cards, 50
        private readonly int DealSpeed = 50;
        //how fast to remove discards, 60
        private readonly int DiscardSpeed = 60;

        private bool FlagShuffleCards;

        //start new game, not used at this time
        //private bool NewGameStarted;
        //who won the hand, not used at this time
        //private string WhoWonHand;

        private int P1CardTotal, P2CardTotal;
        //who won the discards
        private string WhoWonDiscards;

        #endregion

        #region Player Card Animation Field(s)
        // Fields needed to control the player card dealing animation

        private Point _startPoint;
        private Point _discardstartPoint;
        private Point _deckstartPoint;

        private int _PlayerCardIndex;
        private int _DealerCardIndex;
        private int _a, _b;
        private int _x, _y;
        private int _Increment;
        private int _x1, _y1;

        // Load the card back skin image from file
        private Image cardBackSkin = Image.FromFile(Properties.Settings.Default.CardGameImageSkinPath);

        #endregion

        // the @ which will allow us the use of single slashes instead of using double slashes. 
        // the path is set to the sound folder under the bin folder.
        public const string SoundFileFolder = @"Sounds\";

        //the location to the sound file
        public static object SoundFileLocation;

        //turn sound on/off, 1,0, default off
        private short NSound = 1;

        //*************************
        //set to true to show hand totals for the player and dealer, set to false to hide totals when going live.
        private readonly bool tShowHandTotals = false;

        //used for testing card game, displays the number of cards left in deck, number of cards dealt to dealer and player
        //set to true to show labels, set to false to hide labels, set to false to hide labels when going live.
        private readonly bool tFlag = false;

        //*************************

        #region Main Constructor

        /// <summary>
        /// Main constructor for the BasicCardForm.  Initializes components, loads the card skin images, and sets up the new game
        /// </summary>
        public BasicCardForm()
        {
            InitializeComponent();
            LoadCardSkinImages();
            SetUpNewGame();
        }

        #endregion

        #region Game Event Handlers

        private void BasicCardForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            AnimationTimerPlayer.Interval = AnimationTimerInterval;
            AnimationTimerPlayer.Tick += new EventHandler(AnimatePlayerCardTimer_Tick);

            AnimationTimerDealer.Interval = AnimationTimerInterval;
            AnimationTimerDealer.Tick += new EventHandler(AnimateDealerCardTimer_Tick);

            AnimationTimerPlayerDiscard.Interval = AnimationTimerInterval;
            AnimationTimerPlayerDiscard.Tick += new EventHandler(AnimatePlayerDiscardTimer_Tick);

            AnimationTimerDealerDiscard.Interval = AnimationTimerInterval;
            AnimationTimerDealerDiscard.Tick += new EventHandler(AnimateDealerDiscardTimer_Tick);

            AnimationTimerAllDiscards.Interval = AnimationTimerInterval;
            AnimationTimerAllDiscards.Tick += new EventHandler(AnimateAllDiscardsTimer_Tick);

            //DeckCard
            DeckCardPB.Location = deckCard3.Location;
            DeckCardPB.Show();
            DeckCardPB.BringToFront();

            // Save the original location of the DeckCardPB pictureBox
            _deckstartPoint = DeckCardPB.Location;
            _x = DeckCardPB.Location.X;
            _y = DeckCardPB.Location.Y;
            _Increment = 0;

            _discardstartPoint = DisCardPB.Location;
            DisCardPB.Hide();

            CardsInDeck = MAXCARDS;

            if (tShowHandTotals)
            {
                //hide card totals
                playerTotalLabel.Show();
                //hide card totals
                dealerTotalLabel.Show();
            }

            if (!tShowHandTotals)
            {
                playerTotalLabel.Hide();
                dealerTotalLabel.Hide();
            }

            //start new game not used at this time
            //NewGameStarted = false;
            FlagShuffleCards = true;

            if (tFlag)
            {
                lblNew.Show();
                //lblNew.Text = "";
                lblDeck.Show();
                lblDealer.Show();
                lblPlayer.Show();
                lblCardsInDeck.Show();
                lblCardsInPlayersHand.Show();
                lblCardsInDealersHand.Show();
            }
            else
            {
                lblNew.Hide();
                //lblNew.Text = "";
                lblDeck.Hide();
                lblDealer.Hide();
                lblPlayer.Hide();
                lblCardsInDeck.Hide();
                lblCardsInPlayersHand.Hide();
                lblCardsInDealersHand.Hide();
            }
            lblNew.Text = "";

            //deckCard1 = discard pile for dealer cards
            deckCard1.Visible = false;
            //deckCard2 = discard pile for dealer cards
            deckCard2.Visible = false;

            playerDiscard1.Visible = false;
            dealerDiscard1.Visible = false;
            WhoWonDiscards = "";
        }

        /// <summary>
        /// Invoked when the deal button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tShowHandTotals)
                {
                    //hide card totals
                    playerTotalLabel.Show();
                    //hide card totals
                    dealerTotalLabel.Show();
                }

                //Creates a new BasicCard game with one player and an inital balance set through the settings designer
                //private readonly BasicCardGame game = new BasicCardGame(Properties.Settings.Default.InitBalance);
                //game is a readonly variable of the class BasicCardGame, created in the #region Fields above

                //used if betting is added to game
                game.CurrentPlayer.Bet = 10;

                // If the current bet is equal to 0, ask the player to place a bet
                if ((game.CurrentPlayer.Bet == 0) && (game.CurrentPlayer.Balance > 0))
                {
                    MessageBox.Show("You must place a bet before the dealer deals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    //call to Shuffle Cards, DealNewGame is in BasicCardGames.cs
                    if ((CardsInDeck <= 10 || CardsInDeck == MAXCARDS) && (FlagShuffleCards == true))
                    {
                        PlaySoundFiles("shuffling_cards");

                        //card delay of 1.0 sec
                        Delay(500);

                        //refers to BasicCardGame.NewCardShuffle()
                        game.NewCardShuffle();
                        CardsInDeck = MAXCARDS;
                        lblCardsInDeck.Text = CardsInDeck.ToString();

                        CardsInPlayersHand = 0;
                        lblCardsInPlayersHand.Text = CardsInPlayersHand.ToString();

                        CardsInDealersHand = 0;
                        lblCardsInDealersHand.Text = CardsInDealersHand.ToString();

                        if (tFlag)
                        {
                            lblNew.Show();
                            lblNew.Text = "New Deck";
                            lblNew.ForeColor = Color.Gold;
                        }
                        FlagShuffleCards = false;
                    }
                    else
                    {
                        lblNew.Hide();
                        FlagShuffleCards = true;
                    }

                    // Clear the table, set up the UI for playing a game, and deal a new game
                    ClearTable();
                    SetUpGameInPlay();

                    //MessageBox.Show("Cards Count: " + CardsInDeck.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    game.DealNewGame(NumberOfCards);

                    _x1 = deckCard3.Location.X;
                    _y1 = deckCard3.Location.Y;

                    DeckCardPB.Location = new Point(_x1 + 0, _y1);

                    //send over number of cards in initial hand, ie 5 cards
                    for (int i = 0; i <= NumberOfCards; i++)
                    {
                        UpdateUIDealerCards(i);
                        UpdateUIPlayerCards(i);

                        if (i == NumberOfCards)
                        {
                            shuffleButton.Enabled = true;
                        }
                    }

                    //sort cards in player and dealer hands ascending order, then show players cards as face-up
                    SortCards(1);
                    DeckCardPB.Location = deckCard3.Location;

                    //clearTableButton.Enabled = true;
                    //HideHandsBtn.Enabled = false;
                    //ShowHandsBtn.Enabled = false;
                    dealButton.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File is missing or corrupted!" + " " + ex.ToString(), "Error1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
        }

        private void cardClick(object sender, EventArgs e)
        {
            //card click event
            int tnum;
            string tpicbox;

            if (AnimationDone == true)
            {

                WhoWonDiscards = "";

                tpicbox = ((PictureBox)sender).Name.ToString();
                tnum = Convert.ToInt32(((PictureBox)sender).Tag);

                gameOverTextBox.Hide();

                //MessageBox.Show("cardClick " + tnum.ToString() + " " + tpicbox.ToString());

                //load player cards
                List<Card> pcards = game.CurrentPlayer.Hand.Cards;
                UpdateUIPlayerDiscards(tnum);
                P1CardTotal = Convert.ToInt32(pcards[tnum].FaceVal);

                //MessageBox.Show("Player: " + playerCards[tnum].Name.ToString() + " " + playerCards[tnum].Tag.ToString() + " " + pcards[tnum].Suit.ToString() + " " + (int)pcards[tnum].FaceVal + " " + pcards[tnum].FaceVal.ToString() + " " + pcards[tnum].IsCardUp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //load dealer cards
                List<Card> dcards = game.Dealer.Hand.Cards;
                UpdateUIDealerDiscards(tnum);
                P2CardTotal = Convert.ToInt32(dcards[tnum].FaceVal);

                //MessageBox.Show("Dealer: " + dealerCards[tnum].Name.ToString() + " " + dealerCards[tnum].Tag.ToString() + " " + dcards[tnum].Suit.ToString() + " " + (int)dcards[tnum].FaceVal + " " + dcards[tnum].FaceVal.ToString() + " " + dcards[tnum].IsCardUp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //WhoWonDiscards is used in UpdateUIAllDiscards
                GetGameHandResult(ref WhoWonDiscards, P1CardTotal, P2CardTotal);
                //MessageBox.Show("WhoWonDiscards " + WhoWonDiscards.ToString());

                //move cards to discard piles, there is two discard piles 
                //card delay of 1.0 sec
                Delay(1000);
                UpdateUIAllDiscards(1);
                UpdateUIAllDiscards(2);
            }
        }

        /// <summary>
        /// Get the hand result.  This returns an WhoWon value as string
        /// </summary>
        /// <returns></returns>
        private void GetGameHandResult(ref string WhoWon, int P1Total, int P2Total)
        {
            string tWhowon;

            if (P1Total > P2Total)
            {
                //player 1 wins
                tWhowon = "Player1";
                //sends EndResult value in this form code
                EndGame(EndResult.PlayerWin);

            }
            else if (P1Total < P2Total)
            {
                //player 2 wins
                tWhowon = "Player2";
                EndGame(EndResult.DealerWin);
            }
            else
            {
                //tie, push (war)
                tWhowon = "Player1";
                EndGame(EndResult.Push);
            }

            WhoWon = tWhowon;
        }

        /// <summary>
        /// show cards in players hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHandsBtn_Click(object sender, EventArgs e)
        {
            //show cards in hands
            List<Card> dcards = game.Dealer.Hand.Cards;
            //MessageBox.Show("Dealer Cards " + dcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //show the dealer card face
            for (int i = 0; i < dcards.Count; i++)
            {
                dcards[i].IsCardUp = true;
                LoadDealerCard(dealerCards[i], dcards[i]);

                dealerCards[i].Show();
                dealerCards[i].BringToFront();

                //MessageBox.Show("Show Cards " + dcards[i].Suit.ToString() + " " + (int)dcards[i].FaceVal + " " + dcards[i].FaceVal.ToString() + " " + dcards[i].IsCardUp.ToString() + "total= " + temp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// hide cards in players hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideHandsBtn_Click(object sender, EventArgs e)
        {
            //hide cards in hands
            List<Card> dcards = game.Dealer.Hand.Cards;
            //MessageBox.Show("Dealer Cards " + dcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //show the dealer card backs
            for (int i = 0; i < dcards.Count; i++)
            {
                dcards[i].IsCardUp = false;
                LoadDealerCard(dealerCards[i], dcards[i]);

                dealerCards[i].Show();
                dealerCards[i].BringToFront();

                // MessageBox.Show("Show Cards " + dcards[i].Suit.ToString() + " " + dcards[i].FaceVal.ToString() + " " + dcards[i].IsCardUp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SortCards(int cardNum)
       {
            //show cards in hands
            List<Card> dcards = game.Dealer.Hand.Cards;
            //MessageBox.Show("Dealer Cards " + dcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //sort the cards in the dealer hand by desending order
            int tnum1 = dcards.Count;
            for (int i = 1; i < tnum1; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if ((int)dcards[j - 1].FaceVal < (int)dcards[j].FaceVal)
                    {
                        var tempd = dcards[j - 1];
                        dcards[j - 1] = dcards[j];
                        dcards[j] = tempd;
                        j--;
                    }
                    else
                        break;
                }
            }

            //for (int k = 0; k < tnum1; k++)
            //        MessageBox.Show("Show Cards " + dcards[k].Suit.ToString() + " " + (int)dcards[k].FaceVal + " " + dcards[k].FaceVal.ToString() + " " + dcards[k].IsCardUp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //show the dealer card face
            for (int i = 0; i < dcards.Count; i++)
            {
                dcards[i].IsCardUp = false;
                LoadDealerCard(dealerCards[i], dcards[i]);

                dealerCards[i].Show();
                dealerCards[i].BringToFront();

                //MessageBox.Show("Dealer Cards " + dcards[i].Suit.ToString() + " " + (int)dcards[i].FaceVal + " " + dcards[i].FaceVal.ToString() + " " + dcards[i].IsCardUp.ToString() + "total= " + temp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            List<Card> pcards = game.CurrentPlayer.Hand.Cards;
            //MessageBox.Show("Player Cards " + pcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //sort the cards in the player hand by desending order
            int tnum2 = pcards.Count;
            for (int i = 1; i < tnum2; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if ((int)pcards[j - 1].FaceVal < (int)pcards[j].FaceVal)
                    {
                        var tempp = pcards[j - 1];
                        pcards[j - 1] = pcards[j];
                        pcards[j] = tempp;
                        j--;
                    }
                    else
                        break;
                }
            }

            //for (int k = 0; k < tnum2; k++)
            //    MessageBox.Show("Player Cards " + pcards[k].Suit.ToString() + " " + (int)pcards[k].FaceVal + " " + pcards[k].FaceVal.ToString() + " " + pcards[k].IsCardUp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //show the player card face
            for (int i = 0; i < pcards.Count; i++)
            {
                if (playerCards[i] != null)
                {
                    //erase previous game data
                    playerCards[i].Visible = false;
                    //remove the pictureBox Action>Click>Method (cardClick function) from the array
                    playerCards[i].Click -= cardClick;
                    //playerCards[i].Dispose();
                }

                pcards[i].IsCardUp = true;
                LoadCard(playerCards[i], pcards[i]);

                playerCards[i].Show();
                playerCards[i].BringToFront();

                //MessageBox.Show("PlayerCards i, Name, Image, Tag " + i + " " + playerCards[i].Name.ToString() + " " + playerCards[i].Image.ToString() + " " + playerCards[i].Tag.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Player: " + cardNum + " " + playerCards[cardNum].Image.ToString() + " " + playerCards[cardNum].ImageLocation.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show("Show Cards " + pcards[i].Suit.ToString() + " " + pcards[i].FaceVal.ToString() + " " + pcards[i].IsCardUp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShuffleBtn_Click(object sender, EventArgs e)
        {
            //ask to start new game
            // Dialog box with two buttons: yes and no.
            DialogResult result1 = MessageBox.Show("Would you like to start a new game?", "Start New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //MessageBox.Show("result1 " + result1, "Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (result1 == DialogResult.Yes)
            {
                //start new game, not used at this time
                //NewGameStarted = false;
                FlagShuffleCards = false;

                game.CurrentPlayer.Losses = 0;
                game.CurrentPlayer.Wins = 0;
                game.CurrentPlayer.Push = 0;

                // Update the "My Record" values
                winTextBox.Text = game.CurrentPlayer.Wins.ToString();
                lossTextBox.Text = game.CurrentPlayer.Losses.ToString();
                tiesTextBox.Text = game.CurrentPlayer.Push.ToString();

                // Clear the table, set up the UI for playing a game, and deal a new game
                ClearTable();

                //hide who won
                gameOverTextBox.Hide();

                //shuffle deck
                PlaySoundFiles("shuffling_cards");

                //card delay of 1.0 sec
                Delay(500);

                //refers to BasicCardGame.NewCardShuffle()
                game.NewCardShuffle();
                CardsInDeck = MAXCARDS;
                lblCardsInDeck.Text = CardsInDeck.ToString();

                CardsInPlayersHand = 0;
                lblCardsInPlayersHand.Text = CardsInPlayersHand.ToString();

                CardsInDealersHand = 0;
                lblCardsInDealersHand.Text = CardsInDealersHand.ToString();

                if (tFlag)
                {
                    lblNew.Show();
                    lblNew.Text = "New Deck";
                    lblNew.ForeColor = Color.Gold;
                }

            }
            else
            {
                //start new game, not used at this time
                //NewGameStarted = true;
            }
        }

        //animate player and dealer cards

        /// <summary>
        /// Refresh the UI to update the dealer cards
        /// </summary>
        private void UpdateUIDealerCards(int cardNum)
        {
            // Save the original location of the PicBoxDealerCard (card to animate)
            _deckstartPoint = DeckCardPB.Location;

            List<Card> dcards = game.Dealer.Hand.Cards;

            //MessageBox.Show("1DealerCards Count: " + dcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("1Dealer cardNum " + cardNum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //start animation
            AnimationTimerDealer.Start();

            //DealerCard
            DealerCardLocationX = dealerCards[cardNum].Location.X;
            DealerCardLocationY = dealerCards[cardNum].Location.Y;

            //MessageBox.Show("Dealer cardNum and i " + cardNum + " " + i, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            AnimationDone = false;

            if (AnimationDone == false)
            {
                LoadDealerCard(dealerCards[cardNum], dcards[cardNum]);
                AnimateDealerCard(cardNum);
            }

            if (tShowHandTotals)
            {
                dealerTotalLabel.Show();
                // Update the value of the hand
                dealerTotalLabel.Text = game.Dealer.Hand.GetSumOfHand().ToString();
            }

            AnimationTimerDealer.Stop();
            AnimationTimerDealer.Enabled = false;
        }

        /// <summary>
        ///   Calls inherited class for power info, then takes necessary actions.
        /// </summary>
        /// <remarks></remarks>
        private void AnimateDealerCard(int cardIndex)
        {
            CardsInDeck--;
            CardsInDealersHand++;

            lblCardsInDeck.Text = CardsInDeck.ToString();
            lblCardsInDealersHand.Text = CardsInDealersHand.ToString();

            //MessageBox.Show("1Cards Count: " + CardsInDeck.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("Dealer cardNum " + cardIndex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            PlaySoundFiles("card_drop");

            //dealerCards[cardIndex].Hide();
            DeckCardPB.BringToFront();
            DeckCardPB.Location = _deckstartPoint;
            _DealerCardIndex = cardIndex;
            AnimationTimerDealer.Enabled = true;
            while (AnimationTimerDealer.Enabled == true)
                // Wait for animation to finish
                Application.DoEvents();
        }

        /// <summary>
        /// Move card one frame per timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void AnimateDealerCardTimer_Tick(object sender, EventArgs e)
        {
            if (_Increment <= 500)
            {
                // Dealer is dealt the card, need to use as endpoints player card locations.
                _a = DealerCardLocationX;
                _b = DealerCardLocationY;
            }
            _x = (_a - _deckstartPoint.X) * _Increment / 500 + _deckstartPoint.X;
            _y = (_b - _deckstartPoint.Y) * _Increment / 500 + _deckstartPoint.Y;

            //MessageBox.Show("_deckstartPoint x and y " + _deckstartPoint.X + " " + _deckstartPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show("1_x and _y and _Increment " + _x + " " + _y + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            DeckCardPB.Location = new Point(_x, _y);
            DeckCardPB.Show();
            DeckCardPB.BringToFront();

            if (_x >= (_a + 1) && AnimationDone == false)
            {
                //end animation before top of card is reached
                AnimationDone = true;
                //MessageBox.Show("2_x and _a and _Increment " + _x + " " + _a + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (_Increment > 500 || AnimationDone == true)
            {
                AnimationTimerDealer.Enabled = false;
                if (_DealerCardIndex >= 0)
                {
                    dealerCards[_DealerCardIndex].Show();
                    dealerCards[_DealerCardIndex].BringToFront();
                }

                DeckCardPB.Location = _deckstartPoint;
                _Increment = 0;
            }
            //how fast to deal Dealer cards, 75
            _Increment += DealSpeed;
        }

        /// <summary>
        /// Refresh the UI to update the player cards
        /// </summary>
        private void UpdateUIPlayerCards(int cardNum)
        {
            // Save the original location of the PicBoxDealerCard (card to animate)
            _deckstartPoint = DeckCardPB.Location;

            //MessageBox.Show("_deckstartPoint x and y " + _deckstartPoint.X + " " + _deckstartPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            List<Card> pcards = game.CurrentPlayer.Hand.Cards;

            //MessageBox.Show("2PlayerCards Count: " + pcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("2Player cardNum " + cardNum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //start animation
            AnimationTimerPlayer.Start();

            //PlayerCard
            PlayerCardLocationX = playerCards[cardNum].Location.X;
            PlayerCardLocationY = playerCards[cardNum].Location.Y;

            //MessageBox.Show("Player cardNum and i " + cardNum + " " + i, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            AnimationDone = false;

            if (AnimationDone == false)
            {
                //LoadCard(playerCards[cardNum], pcards[cardNum]);
                LoadDealerCard(playerCards[cardNum], pcards[cardNum]);
                AnimatePlayerCard(cardNum);
            }

            if (tShowHandTotals)
            {
                playerTotalLabel.Show();
                // Update the value of the hand
                playerTotalLabel.Text = game.CurrentPlayer.Hand.GetSumOfHand().ToString();
            }
            //MessageBox.Show("Player: " + cardNum + " " + playerCards[cardNum].Name.ToString() + " " + playerCards[cardNum].Tag.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            AnimationTimerPlayer.Stop();
            AnimationTimerPlayer.Enabled = false;
        }

        /// <summary>
        ///   Calls inherited class for power info, then takes necessary actions.
        /// </summary>
        /// <remarks></remarks>
        private void AnimatePlayerCard(int cardIndex)
        {
            CardsInDeck--;
            CardsInPlayersHand++;

            lblCardsInDeck.Text = CardsInDeck.ToString();
            lblCardsInPlayersHand.Text = CardsInPlayersHand.ToString();

            //MessageBox.Show("2Cards Count: " + CardsInDeck.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PlaySoundFiles("card_drop");

            //playerCards[cardIndex].Hide();
            DeckCardPB.BringToFront();
            DeckCardPB.Location = _deckstartPoint;
            _PlayerCardIndex = cardIndex;
            AnimationTimerPlayer.Enabled = true;
            while (AnimationTimerPlayer.Enabled == true)
                // Wait for animation to finish
                Application.DoEvents();
        }

        /// <summary>
        /// Move card one frame per timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void AnimatePlayerCardTimer_Tick(object sender, EventArgs e)
        {
            if (_Increment <= 500)
            {
                // Player is dealt the card, need to use as endpoints player card locations.
                _a = PlayerCardLocationX;
                _b = PlayerCardLocationY;
            }
            _x = (_a - _deckstartPoint.X) * _Increment / 500 + _deckstartPoint.X;
            _y = (_b - _deckstartPoint.Y) * _Increment / 500 + _deckstartPoint.Y;

            //MessageBox.Show("_deckstartPoint x and y " + _deckstartPoint.X + " " + _deckstartPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show("1_x and _y and _Increment " + _x + " " + _y + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            DeckCardPB.Location = new Point(_x, _y);
            DeckCardPB.Show();
            DeckCardPB.BringToFront();

            if (_x >= (_a + 1) && AnimationDone == false)
            {
                //end animation before top of card is reached
                AnimationDone = true;
            }

            if (_Increment > 500 || AnimationDone == true)
            {
                AnimationTimerPlayer.Enabled = false;
                if (_PlayerCardIndex >= 0)
                {
                    playerCards[_PlayerCardIndex].Show();
                    playerCards[_PlayerCardIndex].BringToFront();
                }

                DeckCardPB.Location = _deckstartPoint;
                _Increment = 0;
            }

            //how fast to deal Player cards, 75
            _Increment += DealSpeed;
        }

        //animate player and dealer discards

        /// <summary>
        /// Refresh the UI to update the dealer cards
        /// </summary>
        private void UpdateUIDealerDiscards(int cardNum)
        {

            // Save the original location of the PicBoxDealerCard (card to animate)

            DisCardPB.Location = dealerCards[cardNum].Location;
            DisCardPB.Image = dealerCards[cardNum].Image;

            _startPoint = DisCardPB.Location;

            //MessageBox.Show("_startPoint x and y " + _startPoint.X + " " + _startPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            List<Card> dcards = game.Dealer.Hand.Cards;

            //MessageBox.Show("2PlayerCards Count: " + pcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("2Player cardNum " + cardNum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //start animation
            AnimationTimerDealerDiscard.Start();

            //DealerDiscard
            DealerDiscardLocationX = dealerDiscard1.Location.X;
            DealerDiscardLocationY = dealerDiscard1.Location.Y;

            AnimationDone = false;

            if (AnimationDone == false)
            {
                dcards[cardNum].IsCardUp = true;
                LoadDealerCard(dealerCards[cardNum], dcards[cardNum]);
                AnimateDealerDiscard(cardNum);
            }
            AnimationTimerDealerDiscard.Stop();
            AnimationTimerDealerDiscard.Enabled = false;
            //end animation
        }

        /// <summary>
        ///   Calls inherited class for power info, then takes necessary actions.
        /// </summary>
        /// <remarks></remarks>
        private void AnimateDealerDiscard(int cardIndex)
        {
            //MessageBox.Show("1Cards Count: " + CardsInDeck.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("Dealer cardNum " + cardIndex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            PlaySoundFiles("card_drop");

            dealerCards[cardIndex].Hide();

            DisCardPB.Show();
            DisCardPB.BringToFront();
            DisCardPB.Location = _startPoint;
            _DealerCardIndex = cardIndex;

            AnimationTimerDealerDiscard.Enabled = true;
            while (AnimationTimerDealerDiscard.Enabled == true)
                // Wait for animation to finish
                Application.DoEvents();
        }

        /// <summary>
        /// Move card one frame per timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void AnimateDealerDiscardTimer_Tick(object sender, EventArgs e)
        {
            if (_Increment <= 500)
            {
                // Dealer is dealt the card, need to use as endpoints player card locations.
                _a = DealerDiscardLocationX;
                _b = DealerDiscardLocationY;
            }
            _x = (_a - _startPoint.X) * _Increment / 500 + _startPoint.X;
            _y = (_b - _startPoint.Y) * _Increment / 500 + _startPoint.Y;

            //MessageBox.Show("_startPoint x and y " + _startPoint.X + " " + _startPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show("1_x and _y and _Increment " + _x + " " + _y + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            DisCardPB.Location = new Point(_x, _y);
            DisCardPB.Show();
            DisCardPB.BringToFront();

            if (_y >= (_b + 1) && AnimationDone == false)
            {
                //end animation before top of card is reached
                AnimationDone = true;
            }

            if (_Increment > 500 || AnimationDone == true)
            {
                AnimationTimerDealerDiscard.Enabled = false;
                if (_DealerCardIndex >= 0)
                {
                    dealerDiscard1.Image = dealerCards[_DealerCardIndex].Image;
                    dealerDiscard1.Show();
                    dealerDiscard1.BringToFront();
                }
                DisCardPB.Location = _discardstartPoint;
                DisCardPB.Image = cardBackSkin;
                DisCardPB.Hide();
                _Increment = 0;
            }
            //how fast to deal Dealer cards, 75
            _Increment += DealSpeed;
        }

        /// <summary>
        /// Refresh the UI to update the player cards
        /// </summary>
        private void UpdateUIPlayerDiscards(int cardNum)
        {
            // Save the original location of the PicBoxPlayerCard (card to animate)

            DisCardPB.Location = playerCards[cardNum].Location;
            DisCardPB.Image = playerCards[cardNum].Image;

            //DisCardPB.Show();
            //DisCardPB.BringToFront();

            _startPoint = DisCardPB.Location;

            //MessageBox.Show("_startPoint x and y " + _startPoint.X + " " + _startPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            List<Card> pcards = game.CurrentPlayer.Hand.Cards;

            //MessageBox.Show("2PlayerCards Count: " + pcards.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("2Player cardNum " + cardNum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //start animation
            AnimationTimerPlayerDiscard.Start();

            //PlayerDiscard
            PlayerDiscardLocationX = playerDiscard1.Location.X;
            PlayerDiscardLocationY = playerDiscard1.Location.Y;

            AnimationDone = false;

            if (AnimationDone == false)
            {
                AnimatePlayerDiscard(cardNum);
            }

            AnimationTimerPlayerDiscard.Stop();
            AnimationTimerPlayerDiscard.Enabled = false;
            //end animation
        }

        /// <summary>
        ///   Calls inherited class for power info, then takes necessary actions.
        /// </summary>
        /// <remarks></remarks>
        private void AnimatePlayerDiscard(int cardIndex)
        {
            //MessageBox.Show("2Cards Count: " + CardsInDeck.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PlaySoundFiles("card_drop");

            playerCards[cardIndex].Hide();

            DisCardPB.Show();
            DisCardPB.BringToFront();
            DisCardPB.Location = _startPoint;

            _PlayerCardIndex = cardIndex;

            AnimationTimerPlayerDiscard.Enabled = true;
            while (AnimationTimerPlayerDiscard.Enabled == true)
                // Wait for animation to finish
                Application.DoEvents();
        }

        /// <summary>
        /// Move card one frame per timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void AnimatePlayerDiscardTimer_Tick(object sender, EventArgs e)
        {
            if (_Increment <= 500)
            {
                // Player is dealt the card, need to use as endpoints player card locations.
                _a = PlayerDiscardLocationX;
                _b = PlayerDiscardLocationY;
            }
            _x = (_a - _startPoint.X) * _Increment / 500 + _startPoint.X;
            _y = (_b - _startPoint.Y) * _Increment / 500 + _startPoint.Y;

            //MessageBox.Show("_startPoint x and y " + _startPoint.X + " " + _startPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show("1_x and _y and _Increment " + _x + " " + _y + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            DisCardPB.Location = new Point(_x, _y);
            DisCardPB.Show();
            DisCardPB.BringToFront();

            if (_y <= (_b + 1) && AnimationDone == false)
            {
                //end animation before top of card is reached
                AnimationDone = true;
                //MessageBox.Show("2_x and _a and _Increment " + _x + " " + _a + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show("2_y and _b and _Increment " + _y + " " + _b + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (_Increment > 500 || AnimationDone == true)
            {
                AnimationTimerPlayerDiscard.Enabled = false;
                if (_PlayerCardIndex >= 0)
                {
                    playerDiscard1.Image = playerCards[_PlayerCardIndex].Image;
                    playerDiscard1.Show();
                    playerDiscard1.BringToFront();
                }

                DisCardPB.Location = _discardstartPoint;
                DisCardPB.Image = cardBackSkin;
                DisCardPB.Hide();
                _Increment = 0;
            }
            //how fast to deal Player cards, 75
            _Increment += DealSpeed;
        }

        /// <summary>
        /// Refresh the UI to update the all discards
        /// </summary>
        private void UpdateUIAllDiscards(int cardNum)
        {
            // Save the original location of the PicBoxPlayerCard (card to animate)

            if (cardNum == 1)
            {
                DisCardPB.Location = playerDiscard1.Location;
                DisCardPB.Image = playerDiscard1.Image;

            }
            else if (cardNum == 2)
            {
                DisCardPB.Location = dealerDiscard1.Location;
                DisCardPB.Image = dealerDiscard1.Image;

            }

            if (WhoWonDiscards == "Player1")
            {
                //PlayerDiscard
                PlayerDiscardLocationX = deckCard1.Location.X;
                PlayerDiscardLocationY = deckCard1.Location.Y;
            }
            else if (WhoWonDiscards == "Player2")
            {
                //PlayerDiscard
                PlayerDiscardLocationX = deckCard2.Location.X;
                PlayerDiscardLocationY = deckCard2.Location.Y;
            }

            _startPoint = DisCardPB.Location;

            //start animation
            AnimationTimerAllDiscards.Start();

            AnimationDone = false;

            if (AnimationDone == false)
            {
                AnimateAllDiscards(cardNum);
            }

            AnimationTimerAllDiscards.Stop();
            AnimationTimerAllDiscards.Enabled = false;
            //end animation
        }

        /// <summary>
        ///   Calls inherited class for power info, then takes necessary actions.
        /// </summary>
        /// <remarks></remarks>
        private void AnimateAllDiscards(int cardIndex)
        {
            //MessageBox.Show("2Cards Count: " + CardsInDeck.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PlaySoundFiles("card_drop");

            if (cardIndex == 1)
            {
                playerDiscard1.Hide();
            }
            else if (cardIndex == 2)
            {
                dealerDiscard1.Hide();
            }

            DisCardPB.Show();
            DisCardPB.BringToFront();
            DisCardPB.Location = _startPoint;

            _PlayerCardIndex = cardIndex;

            AnimationTimerAllDiscards.Enabled = true;
            while (AnimationTimerAllDiscards.Enabled == true)
                // Wait for animation to finish
                Application.DoEvents();
        }

        /// <summary>
        /// Move card one frame per timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void AnimateAllDiscardsTimer_Tick(object sender, EventArgs e)
        {
            if (_Increment <= 500)
            {
                // discard pile location, need to use as endpoints player card locations.
                _a = PlayerDiscardLocationX;
                _b = PlayerDiscardLocationY;
            }
            _x = (_a - _startPoint.X) * _Increment / 500 + _startPoint.X;
            _y = (_b - _startPoint.Y) * _Increment / 500 + _startPoint.Y;

            DisCardPB.Location = new Point(_x, _y);
            DisCardPB.Show();
            DisCardPB.BringToFront();

            if (_x >= (_a + 1) && AnimationDone == false)
            {
                //end animation before top of card is reached
                AnimationDone = true;
            }

            if (_Increment > 500 || AnimationDone == true)
            {
                AnimationTimerAllDiscards.Enabled = false;
                if (_PlayerCardIndex >= 0)
                {
                    if (WhoWonDiscards == "Player1")
                    {
                        deckCard1.Image = cardBackSkin;
                        deckCard1.Show();
                        deckCard1.BringToFront();
                    }
                    else if (WhoWonDiscards == "Player2")
                    {
                        deckCard2.Image = cardBackSkin;
                        deckCard2.Show();
                        deckCard2.BringToFront();
                    }
                }
                DisCardPB.Hide();
                DisCardPB.Location = _discardstartPoint;
                DisCardPB.Image = cardBackSkin;
                _Increment = 0;
            }
            //how fast to deal Player cards, 75
            _Increment += DiscardSpeed;
        }

        /// <summary>
        /// Exits the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clear the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearTableBtn_Click(object sender, EventArgs e)
        {
            // Clear the table, set up the UI for playing a game, and deal a new game
            ClearTable();
        }

        #endregion

        #region Game Methods

        /// <summary>
        /// Clear the dealer and player cards
        /// </summary>
        private void ClearTable()
        {
            for (int i = 0; i < 6; i++)
            {
                dealerCards[i].Image = null;
                dealerCards[i].Visible = false;

                playerCards[i].Image = null;
                playerCards[i].Visible = false;
            }

            playerDiscard1.Visible = false;
            dealerDiscard1.Visible = false;

            HideHandsBtn.Enabled = false;
            ShowHandsBtn.Enabled = false;
            clearTableButton.Enabled = false;

            dealButton.Enabled = true;

            deckCard1.Visible = false;
            deckCard2.Visible = false;
        }

        private void Delay(int miliseconds_to_sleep)
        {
            //do we need a delay at this time, 1500 ms = 1.5 sec
            System.Threading.Thread.Sleep(miliseconds_to_sleep);
        }

        // PlaySoundFiles
        private void PlaySoundFiles(string tString)
        {
            //play sound files
            if (NSound == 1)
            {
                //sound files in resources - card_drop, defeat, hooray, shuffling_cards, SoundPlayer player = new SoundPlayer(Properties.Resources.hooray);
                switch (tString)
                {
                    case "shuffling_cards":
                        //if using sound files in resoures
                        //SoundPlayer player1 = new SoundPlayer(Properties.Resources.chord);
                        //player1.Play();
                        //player1.Dispose();

                        // Set location of the .wav file
                        SoundFileLocation = SoundFileFolder + "shuffling_cards.wav";
                        SoundPlayer player1 = new SoundPlayer(SoundFileLocation.ToString());
                        player1.Play();
                        player1.Dispose();
                        break;
                    case "deal":
                        //player2
                        SoundFileLocation = SoundFileFolder + "deal.wav";
                        SoundPlayer player2 = new SoundPlayer(SoundFileLocation.ToString());
                        player2.Play();
                        player2.Dispose();
                        break;
                    case "cardflip":
                        //player3
                        SoundFileLocation = SoundFileFolder + "cardflip.wav";
                        SoundPlayer player3 = new SoundPlayer(SoundFileLocation.ToString());
                        player3.Play();
                        player3.Dispose();
                        break;
                    case "defeat":
                        //player4
                        SoundFileLocation = SoundFileFolder + "defeat.wav";
                        SoundPlayer player4 = new SoundPlayer(SoundFileLocation.ToString());
                        player4.Play();
                        player4.Dispose();
                        break;
                    case "hooray":
                        //player5
                        SoundFileLocation = SoundFileFolder + "hooray.wav";
                        SoundPlayer player5 = new SoundPlayer(SoundFileLocation.ToString());
                        player5.Play();
                        player5.Dispose();
                        break;
                    case "chord":
                        SoundFileLocation = SoundFileFolder + "chord.wav";
                        SoundPlayer player6 = new SoundPlayer(SoundFileLocation.ToString());
                        player6.Play();
                        player6.Dispose();
                        break;
                    case "card_drop":
                        //player7
                        SoundFileLocation = SoundFileFolder + "card_drop.wav";
                        SoundPlayer player7 = new SoundPlayer(SoundFileLocation.ToString());
                        player7.Play();
                        player7.Dispose();
                        break;
                    default:
                        //SoundPlayer player = new SoundPlayer(Properties.Resources.card_drop);
                        //player.Play();
                        //player.Dispose();
                        break;
                }   //end switch
            }   //end if NSound
        }   //end PlaySoundFiles

        /// <summary>
        /// Takes an EndResult value and shows the resulting game ending in the UI
        /// </summary>
        /// <param name="endState"></param>
        private void EndGame(EndResult endState)
        {
            switch (endState)
            {
                case EndResult.PlayerWin:
                    gameOverTextBox.Text = "You Won!";
                    game.PlayerWin();
                    break;
                case EndResult.Push:
                    gameOverTextBox.Text = "Tie!";
                    game.CurrentPlayer.Push += 1;
                    game.CurrentPlayer.Balance += game.CurrentPlayer.Bet;
                    break;
                case EndResult.DealerWin:
                    gameOverTextBox.Text = Properties.Settings.Default.Player2Name + " Won!";
                    game.PlayerLose();
                    break;
                case EndResult.DealerWon:
                    gameOverTextBox.Text = "Dealer Won!";
                    game.PlayerLose();
                    break;
                case EndResult.PlayerWon:
                    gameOverTextBox.Text = "You Won!";
                    game.CurrentPlayer.Balance += (game.CurrentPlayer.Bet * (decimal)2.5);
                    game.CurrentPlayer.Wins += 1;
                    break;
            }
            // Update the "My Record" values
            winTextBox.Text = game.CurrentPlayer.Wins.ToString();
            lossTextBox.Text = game.CurrentPlayer.Losses.ToString();
            tiesTextBox.Text = game.CurrentPlayer.Push.ToString();

            SetUpNewGame();
            gameOverTextBox.Show();

            // Check if the current player is out of money
            if (game.CurrentPlayer.Balance == 0)
            {
                MessageBox.Show("Out of Money.  Please create a new game to play again.");
                this.Close();
            }
        }

        /// <summary>
        /// Takes the card value and loads the corresponding card image from file, adds EventHandler(cardClick)
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="c"></param>
        private void LoadCard(PictureBox pb, Card c)
        {
            try
            {
                StringBuilder image = new StringBuilder();

                switch (c.Suit)
                {
                    case Suit.Diamonds:
                        image.Append("d");
                        break;
                    case Suit.Hearts:
                        image.Append("h");
                        break;
                    case Suit.Spades:
                        image.Append("s");
                        break;
                    case Suit.Clubs:
                        image.Append("c");
                        break;
                }

                switch (c.FaceVal)
                {
                    case FaceValue.Ace:
                        image.Append("1");
                        break;
                    case FaceValue.King:
                        image.Append("k");
                        break;
                    case FaceValue.Queen:
                        image.Append("q");
                        break;
                    case FaceValue.Jack:
                        image.Append("j");
                        break;
                    case FaceValue.Ten:
                        image.Append("10");
                        break;
                    case FaceValue.Nine:
                        image.Append("9");
                        break;
                    case FaceValue.Eight:
                        image.Append("8");
                        break;
                    case FaceValue.Seven:
                        image.Append("7");
                        break;
                    case FaceValue.Six:
                        image.Append("6");
                        break;
                    case FaceValue.Five:
                        image.Append("5");
                        break;
                    case FaceValue.Four:
                        image.Append("4");
                        break;
                    case FaceValue.Three:
                        image.Append("3");
                        break;
                    case FaceValue.Two:
                        image.Append("2");
                        break;
                }

                image.Append(Properties.Settings.Default.CardGameImageExtension);
                string cardGameImagePath = Properties.Settings.Default.CardGameImagePath;
                string cardGameImageSkinPath = Properties.Settings.Default.CardGameImageSkinPath;
                image.Insert(0, cardGameImagePath);
                //check to see if the card should be faced down or up;
                if (!c.IsCardUp)
                    image.Replace(image.ToString(), cardGameImageSkinPath);

                pb.Image = new Bitmap(image.ToString());

                //this is the difference between LoadCard and LoadDealerCard
                //pb.Click += new System.EventHandler(cardClick);
                pb.Click += cardClick;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }

        /// <summary>
        /// Takes the card value and loads the corresponding card image from file
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="c"></param>
        private void LoadDealerCard(PictureBox pb, Card c)
        {
            try
            {
                StringBuilder image = new StringBuilder();

                switch (c.Suit)
                {
                    case Suit.Diamonds:
                        image.Append("d");
                        break;
                    case Suit.Hearts:
                        image.Append("h");
                        break;
                    case Suit.Spades:
                        image.Append("s");
                        break;
                    case Suit.Clubs:
                        image.Append("c");
                        break;
                }

                switch (c.FaceVal)
                {
                    case FaceValue.Ace:
                        image.Append("1");
                        break;
                    case FaceValue.King:
                        image.Append("k");
                        break;
                    case FaceValue.Queen:
                        image.Append("q");
                        break;
                    case FaceValue.Jack:
                        image.Append("j");
                        break;
                    case FaceValue.Ten:
                        image.Append("10");
                        break;
                    case FaceValue.Nine:
                        image.Append("9");
                        break;
                    case FaceValue.Eight:
                        image.Append("8");
                        break;
                    case FaceValue.Seven:
                        image.Append("7");
                        break;
                    case FaceValue.Six:
                        image.Append("6");
                        break;
                    case FaceValue.Five:
                        image.Append("5");
                        break;
                    case FaceValue.Four:
                        image.Append("4");
                        break;
                    case FaceValue.Three:
                        image.Append("3");
                        break;
                    case FaceValue.Two:
                        image.Append("2");
                        break;
                }

                image.Append(Properties.Settings.Default.CardGameImageExtension);
                string cardGameImagePath = Properties.Settings.Default.CardGameImagePath;
                string cardGameImageSkinPath = Properties.Settings.Default.CardGameImageSkinPath;
                image.Insert(0, cardGameImagePath);
                //check to see if the card should be faced down or up;
                if (!c.IsCardUp)
                    image.Replace(image.ToString(), cardGameImageSkinPath);

                pb.Image = new Bitmap(image.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }

        #endregion

        #region Game UI Methods

        /// <summary>
        /// Load the Deck Card Images
        /// </summary>
        private void LoadCardSkinImages()
        {
            try
            {
                // Load the card skin image from file
                Image cardSkin = Image.FromFile(Properties.Settings.Default.CardGameImageSkinPath);
                // Set the three cards on the UI to the card skin image
                deckCard1.Image = cardSkin;
                //deckCard1PictureBox.BackColor = Color.SeaGreen;
                deckCard2.Image = cardSkin;
                //deckCard2PictureBox.BackColor = Color.SeaGreen;
                deckCard3.Image = cardSkin;
                //deckCard3PictureBox.BackColor = Color.SeaGreen;

                DeckCardPB.Image = cardSkin;
                //DeckCardPB.BackColor = Color.SeaGreen;
                DisCardPB.Image = cardSkin;

            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Card skin images are not loading correctly.  Make sure the card skin images are in the correct location.");
            }
            playerCards = new PictureBox[] { playerCard1, playerCard2, playerCard3, playerCard4, playerCard5, playerCard6 };
            dealerCards = new PictureBox[] { dealerCard1, dealerCard2, dealerCard3, dealerCard4, dealerCard5, dealerCard6 };
        }

        /// <summary>
        /// Set up the UI for when the game is in play after the player has clicked the deal game button
        /// </summary>
        private void SetUpGameInPlay()
        {
            clearTableButton.Enabled = true;

            ShowHandsBtn.Enabled = true;
            HideHandsBtn.Enabled = true;
            gameOverTextBox.Hide();

            if (tShowHandTotals)
            {
                //show or hide
                playerTotalLabel.Show();
                //show or hide
                dealerTotalLabel.Show();
            }

            dealButton.Enabled = false;

            if (firstTurn)
                ShowHandsBtn.Enabled = true;
        }

        /// <summary>
        /// Set up the UI for a new game
        /// </summary>
        private void SetUpNewGame()
        {
            //player1
            //photoPictureBox.ImageLocation = Properties.Settings.Default.PlayerImage;
            photoPictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage);
            photoPictureBox.Visible = true;
            playerNameLabel.Text = Properties.Settings.Default.PlayerName;

            //player2   
            //photo2PictureBox.ImageLocation = Properties.Settings.Default.DefaultImage2;
            photo2PictureBox.Image = Image.FromFile(Properties.Settings.Default.DefaultImage2);
            photo2PictureBox.Visible = true;
            player2NameLabel.Text = Properties.Settings.Default.Player2Name;

            dealButton.Enabled = true;
            ShowHandsBtn.Enabled = false;
            HideHandsBtn.Enabled = false;
            clearTableButton.Enabled = false;

            gameOverTextBox.Hide();

            if (tShowHandTotals)
            {
                //show or hide
                playerTotalLabel.Show();
                //show or hide
                dealerTotalLabel.Show();
            }

            //display the ShowHands Button
            firstTurn = true;
            ShowPlayersName();
        }

        /// <summary>
        /// Set the "My Account" value in the UI
        /// </summary>
        private void ShowPlayersName()
        {
            // Update the "My Account" name
            myAccountTextBox.Text = Properties.Settings.Default.PlayerName.ToString();
        }

        #endregion
    }
}