namespace BasicCard
{
    partial class BasicCardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicCardForm));
            this.myAccountLabel = new System.Windows.Forms.Label();
            this.myAccountTextBox = new System.Windows.Forms.TextBox();
            this.deckCard3 = new System.Windows.Forms.PictureBox();
            this.deckCard2 = new System.Windows.Forms.PictureBox();
            this.deckCard1 = new System.Windows.Forms.PictureBox();
            this.gameOverTextBox = new System.Windows.Forms.TextBox();
            this.dealerCard6 = new System.Windows.Forms.PictureBox();
            this.dealerCard5 = new System.Windows.Forms.PictureBox();
            this.dealerCard4 = new System.Windows.Forms.PictureBox();
            this.dealerCard3 = new System.Windows.Forms.PictureBox();
            this.dealerCard2 = new System.Windows.Forms.PictureBox();
            this.dealerCard1 = new System.Windows.Forms.PictureBox();
            this.tiesTextBox = new System.Windows.Forms.TextBox();
            this.tiesLabel = new System.Windows.Forms.Label();
            this.lossTextBox = new System.Windows.Forms.TextBox();
            this.lossesLabel = new System.Windows.Forms.Label();
            this.winsLabel = new System.Windows.Forms.Label();
            this.winTextBox = new System.Windows.Forms.TextBox();
            this.endGameButton = new System.Windows.Forms.Button();
            this.clearTableButton = new System.Windows.Forms.Button();
            this.dealButton = new System.Windows.Forms.Button();
            this.HideHandsBtn = new System.Windows.Forms.Button();
            this.playerCard1 = new System.Windows.Forms.PictureBox();
            this.playerCard2 = new System.Windows.Forms.PictureBox();
            this.playerCard3 = new System.Windows.Forms.PictureBox();
            this.playerCard4 = new System.Windows.Forms.PictureBox();
            this.playerCard5 = new System.Windows.Forms.PictureBox();
            this.playerCard6 = new System.Windows.Forms.PictureBox();
            this.playerTotalLabel = new System.Windows.Forms.Label();
            this.ShowHandsBtn = new System.Windows.Forms.Button();
            this.recordPanel = new System.Windows.Forms.Panel();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.AnimationTimerPlayer = new System.Windows.Forms.Timer(this.components);
            this.DeckCardPB = new System.Windows.Forms.PictureBox();
            this.AnimationTimerDealer = new System.Windows.Forms.Timer(this.components);
            this.dealerTotalLabel = new System.Windows.Forms.Label();
            this.lblCardsInDeck = new System.Windows.Forms.Label();
            this.lblCardsInPlayersHand = new System.Windows.Forms.Label();
            this.lblCardsInDealersHand = new System.Windows.Forms.Label();
            this.lblDeck = new System.Windows.Forms.Label();
            this.lblDealer = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.photo2PictureBox = new System.Windows.Forms.PictureBox();
            this.player2NameLabel = new System.Windows.Forms.Label();
            this.playerDiscard1 = new System.Windows.Forms.PictureBox();
            this.dealerDiscard1 = new System.Windows.Forms.PictureBox();
            this.AnimationTimerDealerDiscard = new System.Windows.Forms.Timer(this.components);
            this.AnimationTimerPlayerDiscard = new System.Windows.Forms.Timer(this.components);
            this.DisCardPB = new System.Windows.Forms.PictureBox();
            this.AnimationTimerAllDiscards = new System.Windows.Forms.Timer(this.components);
            this.shuffleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deckCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard6)).BeginInit();
            this.recordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCardPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerDiscard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerDiscard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisCardPB)).BeginInit();
            this.SuspendLayout();
            // 
            // myAccountLabel
            // 
            this.myAccountLabel.AutoSize = true;
            this.myAccountLabel.BackColor = System.Drawing.Color.Transparent;
            this.myAccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myAccountLabel.ForeColor = System.Drawing.Color.Gold;
            this.myAccountLabel.Location = new System.Drawing.Point(142, 10);
            this.myAccountLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.myAccountLabel.Name = "myAccountLabel";
            this.myAccountLabel.Size = new System.Drawing.Size(75, 20);
            this.myAccountLabel.TabIndex = 6;
            this.myAccountLabel.Text = "Account";
            // 
            // myAccountTextBox
            // 
            this.myAccountTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.myAccountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myAccountTextBox.ForeColor = System.Drawing.Color.Orange;
            this.myAccountTextBox.Location = new System.Drawing.Point(138, 34);
            this.myAccountTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.myAccountTextBox.Multiline = true;
            this.myAccountTextBox.Name = "myAccountTextBox";
            this.myAccountTextBox.ReadOnly = true;
            this.myAccountTextBox.Size = new System.Drawing.Size(82, 28);
            this.myAccountTextBox.TabIndex = 1;
            this.myAccountTextBox.Text = "2000";
            this.myAccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // deckCard3
            // 
            this.deckCard3.BackColor = System.Drawing.Color.Transparent;
            this.deckCard3.Location = new System.Drawing.Point(65, 355);
            this.deckCard3.Name = "deckCard3";
            this.deckCard3.Size = new System.Drawing.Size(75, 105);
            this.deckCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deckCard3.TabIndex = 8;
            this.deckCard3.TabStop = false;
            // 
            // deckCard2
            // 
            this.deckCard2.BackColor = System.Drawing.Color.Transparent;
            this.deckCard2.Location = new System.Drawing.Point(547, 150);
            this.deckCard2.Name = "deckCard2";
            this.deckCard2.Size = new System.Drawing.Size(75, 105);
            this.deckCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deckCard2.TabIndex = 7;
            this.deckCard2.TabStop = false;
            // 
            // deckCard1
            // 
            this.deckCard1.BackColor = System.Drawing.Color.Transparent;
            this.deckCard1.Location = new System.Drawing.Point(547, 537);
            this.deckCard1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.deckCard1.Name = "deckCard1";
            this.deckCard1.Size = new System.Drawing.Size(75, 105);
            this.deckCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deckCard1.TabIndex = 6;
            this.deckCard1.TabStop = false;
            // 
            // gameOverTextBox
            // 
            this.gameOverTextBox.BackColor = System.Drawing.Color.Black;
            this.gameOverTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameOverTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.gameOverTextBox.Location = new System.Drawing.Point(253, 740);
            this.gameOverTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.gameOverTextBox.Multiline = true;
            this.gameOverTextBox.Name = "gameOverTextBox";
            this.gameOverTextBox.ReadOnly = true;
            this.gameOverTextBox.Size = new System.Drawing.Size(223, 30);
            this.gameOverTextBox.TabIndex = 5;
            this.gameOverTextBox.Text = "Who Won";
            this.gameOverTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dealerCard6
            // 
            this.dealerCard6.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard6.Location = new System.Drawing.Point(392, 225);
            this.dealerCard6.Margin = new System.Windows.Forms.Padding(1, 1, 3, 3);
            this.dealerCard6.Name = "dealerCard6";
            this.dealerCard6.Size = new System.Drawing.Size(75, 105);
            this.dealerCard6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerCard6.TabIndex = 14;
            this.dealerCard6.TabStop = false;
            this.dealerCard6.Tag = "5";
            this.dealerCard6.Visible = false;
            // 
            // dealerCard5
            // 
            this.dealerCard5.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard5.Location = new System.Drawing.Point(370, 225);
            this.dealerCard5.Name = "dealerCard5";
            this.dealerCard5.Size = new System.Drawing.Size(75, 105);
            this.dealerCard5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerCard5.TabIndex = 13;
            this.dealerCard5.TabStop = false;
            this.dealerCard5.Tag = "4";
            this.dealerCard5.Visible = false;
            // 
            // dealerCard4
            // 
            this.dealerCard4.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard4.Location = new System.Drawing.Point(348, 225);
            this.dealerCard4.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.dealerCard4.Name = "dealerCard4";
            this.dealerCard4.Size = new System.Drawing.Size(75, 105);
            this.dealerCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerCard4.TabIndex = 12;
            this.dealerCard4.TabStop = false;
            this.dealerCard4.Tag = "3";
            this.dealerCard4.Visible = false;
            // 
            // dealerCard3
            // 
            this.dealerCard3.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard3.Location = new System.Drawing.Point(326, 225);
            this.dealerCard3.Name = "dealerCard3";
            this.dealerCard3.Size = new System.Drawing.Size(75, 105);
            this.dealerCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerCard3.TabIndex = 11;
            this.dealerCard3.TabStop = false;
            this.dealerCard3.Tag = "2";
            this.dealerCard3.Visible = false;
            // 
            // dealerCard2
            // 
            this.dealerCard2.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard2.Location = new System.Drawing.Point(304, 225);
            this.dealerCard2.Name = "dealerCard2";
            this.dealerCard2.Size = new System.Drawing.Size(75, 105);
            this.dealerCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerCard2.TabIndex = 10;
            this.dealerCard2.TabStop = false;
            this.dealerCard2.Tag = "1";
            this.dealerCard2.Visible = false;
            // 
            // dealerCard1
            // 
            this.dealerCard1.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard1.Location = new System.Drawing.Point(282, 225);
            this.dealerCard1.Name = "dealerCard1";
            this.dealerCard1.Size = new System.Drawing.Size(75, 105);
            this.dealerCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerCard1.TabIndex = 9;
            this.dealerCard1.TabStop = false;
            this.dealerCard1.Tag = "0";
            this.dealerCard1.Visible = false;
            // 
            // tiesTextBox
            // 
            this.tiesTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.tiesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiesTextBox.ForeColor = System.Drawing.Color.DarkOrange;
            this.tiesTextBox.Location = new System.Drawing.Point(529, 33);
            this.tiesTextBox.Multiline = true;
            this.tiesTextBox.Name = "tiesTextBox";
            this.tiesTextBox.ReadOnly = true;
            this.tiesTextBox.Size = new System.Drawing.Size(32, 28);
            this.tiesTextBox.TabIndex = 4;
            this.tiesTextBox.Text = "0";
            this.tiesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tiesLabel
            // 
            this.tiesLabel.AutoSize = true;
            this.tiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiesLabel.ForeColor = System.Drawing.Color.Gold;
            this.tiesLabel.Location = new System.Drawing.Point(526, 10);
            this.tiesLabel.Name = "tiesLabel";
            this.tiesLabel.Size = new System.Drawing.Size(42, 20);
            this.tiesLabel.TabIndex = 4;
            this.tiesLabel.Text = "Ties";
            // 
            // lossTextBox
            // 
            this.lossTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.lossTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lossTextBox.ForeColor = System.Drawing.Color.DarkOrange;
            this.lossTextBox.Location = new System.Drawing.Point(420, 33);
            this.lossTextBox.Multiline = true;
            this.lossTextBox.Name = "lossTextBox";
            this.lossTextBox.ReadOnly = true;
            this.lossTextBox.Size = new System.Drawing.Size(32, 28);
            this.lossTextBox.TabIndex = 3;
            this.lossTextBox.Text = "0";
            this.lossTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lossesLabel
            // 
            this.lossesLabel.AutoSize = true;
            this.lossesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lossesLabel.ForeColor = System.Drawing.Color.Gold;
            this.lossesLabel.Location = new System.Drawing.Point(408, 10);
            this.lossesLabel.Name = "lossesLabel";
            this.lossesLabel.Size = new System.Drawing.Size(66, 20);
            this.lossesLabel.TabIndex = 2;
            this.lossesLabel.Text = "Losses";
            // 
            // winsLabel
            // 
            this.winsLabel.AutoSize = true;
            this.winsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winsLabel.ForeColor = System.Drawing.Color.Gold;
            this.winsLabel.Location = new System.Drawing.Point(295, 10);
            this.winsLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.winsLabel.Name = "winsLabel";
            this.winsLabel.Size = new System.Drawing.Size(48, 20);
            this.winsLabel.TabIndex = 1;
            this.winsLabel.Text = "Wins";
            // 
            // winTextBox
            // 
            this.winTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.winTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winTextBox.ForeColor = System.Drawing.Color.DarkOrange;
            this.winTextBox.Location = new System.Drawing.Point(302, 34);
            this.winTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.winTextBox.Multiline = true;
            this.winTextBox.Name = "winTextBox";
            this.winTextBox.ReadOnly = true;
            this.winTextBox.Size = new System.Drawing.Size(32, 28);
            this.winTextBox.TabIndex = 2;
            this.winTextBox.Text = "0";
            this.winTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // endGameButton
            // 
            this.endGameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.endGameButton.BackColor = System.Drawing.Color.Transparent;
            this.endGameButton.BackgroundImage = global::BasicCard.Properties.Resources.ButtonRound1;
            this.endGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.endGameButton.FlatAppearance.BorderSize = 0;
            this.endGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.endGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.endGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGameButton.Location = new System.Drawing.Point(592, 804);
            this.endGameButton.Name = "endGameButton";
            this.endGameButton.Size = new System.Drawing.Size(123, 39);
            this.endGameButton.TabIndex = 15;
            this.endGameButton.Text = "End Game";
            this.endGameButton.UseVisualStyleBackColor = false;
            this.endGameButton.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // clearTableButton
            // 
            this.clearTableButton.BackColor = System.Drawing.Color.Transparent;
            this.clearTableButton.BackgroundImage = global::BasicCard.Properties.Resources.ButtonRound1;
            this.clearTableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearTableButton.FlatAppearance.BorderSize = 0;
            this.clearTableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.clearTableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.clearTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTableButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearTableButton.Location = new System.Drawing.Point(307, 804);
            this.clearTableButton.Name = "clearTableButton";
            this.clearTableButton.Size = new System.Drawing.Size(123, 39);
            this.clearTableButton.TabIndex = 13;
            this.clearTableButton.Text = "Clear Table";
            this.clearTableButton.UseVisualStyleBackColor = false;
            this.clearTableButton.Click += new System.EventHandler(this.ClearTableBtn_Click);
            // 
            // dealButton
            // 
            this.dealButton.AutoSize = true;
            this.dealButton.BackColor = System.Drawing.Color.Transparent;
            this.dealButton.BackgroundImage = global::BasicCard.Properties.Resources.ButtonSquare2;
            this.dealButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dealButton.FlatAppearance.BorderSize = 0;
            this.dealButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dealButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dealButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dealButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dealButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dealButton.Location = new System.Drawing.Point(592, 728);
            this.dealButton.Name = "dealButton";
            this.dealButton.Size = new System.Drawing.Size(115, 30);
            this.dealButton.TabIndex = 14;
            this.dealButton.Text = "Deal";
            this.dealButton.UseVisualStyleBackColor = false;
            this.dealButton.Click += new System.EventHandler(this.DealBtn_Click);
            // 
            // HideHandsBtn
            // 
            this.HideHandsBtn.BackColor = System.Drawing.Color.Transparent;
            this.HideHandsBtn.BackgroundImage = global::BasicCard.Properties.Resources.ButtonRound1;
            this.HideHandsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HideHandsBtn.FlatAppearance.BorderSize = 0;
            this.HideHandsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HideHandsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HideHandsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideHandsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideHandsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HideHandsBtn.Location = new System.Drawing.Point(167, 804);
            this.HideHandsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.HideHandsBtn.Name = "HideHandsBtn";
            this.HideHandsBtn.Size = new System.Drawing.Size(123, 39);
            this.HideHandsBtn.TabIndex = 12;
            this.HideHandsBtn.Text = "Hide Hands";
            this.HideHandsBtn.UseVisualStyleBackColor = false;
            this.HideHandsBtn.Click += new System.EventHandler(this.HideHandsBtn_Click);
            // 
            // playerCard1
            // 
            this.playerCard1.BackColor = System.Drawing.Color.Transparent;
            this.playerCard1.Location = new System.Drawing.Point(282, 486);
            this.playerCard1.Name = "playerCard1";
            this.playerCard1.Size = new System.Drawing.Size(75, 105);
            this.playerCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard1.TabIndex = 0;
            this.playerCard1.TabStop = false;
            this.playerCard1.Tag = "0";
            this.playerCard1.Visible = false;
            // 
            // playerCard2
            // 
            this.playerCard2.BackColor = System.Drawing.Color.Transparent;
            this.playerCard2.Location = new System.Drawing.Point(304, 486);
            this.playerCard2.Name = "playerCard2";
            this.playerCard2.Size = new System.Drawing.Size(75, 105);
            this.playerCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard2.TabIndex = 1;
            this.playerCard2.TabStop = false;
            this.playerCard2.Tag = "1";
            this.playerCard2.Visible = false;
            // 
            // playerCard3
            // 
            this.playerCard3.BackColor = System.Drawing.Color.Transparent;
            this.playerCard3.Location = new System.Drawing.Point(326, 486);
            this.playerCard3.Name = "playerCard3";
            this.playerCard3.Size = new System.Drawing.Size(75, 105);
            this.playerCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard3.TabIndex = 2;
            this.playerCard3.TabStop = false;
            this.playerCard3.Tag = "2";
            this.playerCard3.Visible = false;
            // 
            // playerCard4
            // 
            this.playerCard4.BackColor = System.Drawing.Color.Transparent;
            this.playerCard4.Location = new System.Drawing.Point(348, 486);
            this.playerCard4.Name = "playerCard4";
            this.playerCard4.Size = new System.Drawing.Size(75, 105);
            this.playerCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard4.TabIndex = 3;
            this.playerCard4.TabStop = false;
            this.playerCard4.Tag = "3";
            this.playerCard4.Visible = false;
            // 
            // playerCard5
            // 
            this.playerCard5.BackColor = System.Drawing.Color.Transparent;
            this.playerCard5.Location = new System.Drawing.Point(370, 486);
            this.playerCard5.Name = "playerCard5";
            this.playerCard5.Size = new System.Drawing.Size(75, 105);
            this.playerCard5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard5.TabIndex = 4;
            this.playerCard5.TabStop = false;
            this.playerCard5.Tag = "4";
            this.playerCard5.Visible = false;
            // 
            // playerCard6
            // 
            this.playerCard6.BackColor = System.Drawing.Color.Transparent;
            this.playerCard6.Location = new System.Drawing.Point(392, 486);
            this.playerCard6.Name = "playerCard6";
            this.playerCard6.Size = new System.Drawing.Size(75, 105);
            this.playerCard6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard6.TabIndex = 5;
            this.playerCard6.TabStop = false;
            this.playerCard6.Tag = "5";
            this.playerCard6.Visible = false;
            // 
            // playerTotalLabel
            // 
            this.playerTotalLabel.AutoSize = true;
            this.playerTotalLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTotalLabel.ForeColor = System.Drawing.Color.White;
            this.playerTotalLabel.Location = new System.Drawing.Point(262, 486);
            this.playerTotalLabel.Name = "playerTotalLabel";
            this.playerTotalLabel.Size = new System.Drawing.Size(14, 15);
            this.playerTotalLabel.TabIndex = 6;
            this.playerTotalLabel.Text = "0";
            // 
            // ShowHandsBtn
            // 
            this.ShowHandsBtn.BackColor = System.Drawing.Color.Transparent;
            this.ShowHandsBtn.BackgroundImage = global::BasicCard.Properties.Resources.ButtonRound1;
            this.ShowHandsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShowHandsBtn.FlatAppearance.BorderSize = 0;
            this.ShowHandsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ShowHandsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ShowHandsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowHandsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowHandsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ShowHandsBtn.Location = new System.Drawing.Point(25, 804);
            this.ShowHandsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ShowHandsBtn.Name = "ShowHandsBtn";
            this.ShowHandsBtn.Size = new System.Drawing.Size(123, 39);
            this.ShowHandsBtn.TabIndex = 11;
            this.ShowHandsBtn.Text = "Show Hands";
            this.ShowHandsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ShowHandsBtn.UseVisualStyleBackColor = false;
            this.ShowHandsBtn.Click += new System.EventHandler(this.ShowHandsBtn_Click);
            // 
            // recordPanel
            // 
            this.recordPanel.BackColor = System.Drawing.Color.Transparent;
            this.recordPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.recordPanel.Controls.Add(this.lossesLabel);
            this.recordPanel.Controls.Add(this.tiesLabel);
            this.recordPanel.Controls.Add(this.winsLabel);
            this.recordPanel.Controls.Add(this.winTextBox);
            this.recordPanel.Controls.Add(this.tiesTextBox);
            this.recordPanel.Controls.Add(this.lossTextBox);
            this.recordPanel.Controls.Add(this.myAccountLabel);
            this.recordPanel.Controls.Add(this.myAccountTextBox);
            this.recordPanel.Location = new System.Drawing.Point(5, 18);
            this.recordPanel.Name = "recordPanel";
            this.recordPanel.Size = new System.Drawing.Size(699, 77);
            this.recordPanel.TabIndex = 24;
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.playerNameLabel.Location = new System.Drawing.Point(250, 635);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(74, 23);
            this.playerNameLabel.TabIndex = 26;
            this.playerNameLabel.Text = "Player 1";
            this.playerNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.photoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.photoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("photoPictureBox.Image")));
            this.photoPictureBox.ImageLocation = "";
            this.photoPictureBox.Location = new System.Drawing.Point(325, 606);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(90, 90);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoPictureBox.TabIndex = 17;
            this.photoPictureBox.TabStop = false;
            // 
            // AnimationTimerPlayer
            // 
            this.AnimationTimerPlayer.Interval = 50;
            // 
            // DeckCardPB
            // 
            this.DeckCardPB.BackColor = System.Drawing.Color.Transparent;
            this.DeckCardPB.Location = new System.Drawing.Point(640, 150);
            this.DeckCardPB.Name = "DeckCardPB";
            this.DeckCardPB.Size = new System.Drawing.Size(75, 105);
            this.DeckCardPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeckCardPB.TabIndex = 28;
            this.DeckCardPB.TabStop = false;
            this.DeckCardPB.Visible = false;
            // 
            // AnimationTimerDealer
            // 
            this.AnimationTimerDealer.Interval = 50;
            // 
            // dealerTotalLabel
            // 
            this.dealerTotalLabel.AutoSize = true;
            this.dealerTotalLabel.BackColor = System.Drawing.Color.Transparent;
            this.dealerTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dealerTotalLabel.ForeColor = System.Drawing.Color.White;
            this.dealerTotalLabel.Location = new System.Drawing.Point(264, 219);
            this.dealerTotalLabel.Name = "dealerTotalLabel";
            this.dealerTotalLabel.Size = new System.Drawing.Size(14, 15);
            this.dealerTotalLabel.TabIndex = 29;
            this.dealerTotalLabel.Text = "0";
            // 
            // lblCardsInDeck
            // 
            this.lblCardsInDeck.BackColor = System.Drawing.Color.Transparent;
            this.lblCardsInDeck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardsInDeck.ForeColor = System.Drawing.Color.White;
            this.lblCardsInDeck.Location = new System.Drawing.Point(56, 680);
            this.lblCardsInDeck.Name = "lblCardsInDeck";
            this.lblCardsInDeck.Size = new System.Drawing.Size(50, 15);
            this.lblCardsInDeck.TabIndex = 30;
            this.lblCardsInDeck.Text = "lblCardsInDeck";
            // 
            // lblCardsInPlayersHand
            // 
            this.lblCardsInPlayersHand.BackColor = System.Drawing.Color.Transparent;
            this.lblCardsInPlayersHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardsInPlayersHand.ForeColor = System.Drawing.Color.White;
            this.lblCardsInPlayersHand.Location = new System.Drawing.Point(56, 727);
            this.lblCardsInPlayersHand.Name = "lblCardsInPlayersHand";
            this.lblCardsInPlayersHand.Size = new System.Drawing.Size(50, 15);
            this.lblCardsInPlayersHand.TabIndex = 31;
            this.lblCardsInPlayersHand.Text = "lblCardsInPlayersHand";
            // 
            // lblCardsInDealersHand
            // 
            this.lblCardsInDealersHand.BackColor = System.Drawing.Color.Transparent;
            this.lblCardsInDealersHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardsInDealersHand.ForeColor = System.Drawing.Color.White;
            this.lblCardsInDealersHand.Location = new System.Drawing.Point(56, 704);
            this.lblCardsInDealersHand.Name = "lblCardsInDealersHand";
            this.lblCardsInDealersHand.Size = new System.Drawing.Size(50, 15);
            this.lblCardsInDealersHand.TabIndex = 32;
            this.lblCardsInDealersHand.Text = "lblCardsInDealersHand";
            // 
            // lblDeck
            // 
            this.lblDeck.AutoSize = true;
            this.lblDeck.BackColor = System.Drawing.Color.Transparent;
            this.lblDeck.ForeColor = System.Drawing.Color.White;
            this.lblDeck.Location = new System.Drawing.Point(11, 681);
            this.lblDeck.Name = "lblDeck";
            this.lblDeck.Size = new System.Drawing.Size(36, 13);
            this.lblDeck.TabIndex = 33;
            this.lblDeck.Text = "Deck:";
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.BackColor = System.Drawing.Color.Transparent;
            this.lblDealer.ForeColor = System.Drawing.Color.White;
            this.lblDealer.Location = new System.Drawing.Point(11, 705);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(41, 13);
            this.lblDealer.TabIndex = 34;
            this.lblDealer.Text = "Dealer:";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer.ForeColor = System.Drawing.Color.White;
            this.lblPlayer.Location = new System.Drawing.Point(11, 728);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(39, 13);
            this.lblPlayer.TabIndex = 35;
            this.lblPlayer.Text = "Player:";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.BackColor = System.Drawing.Color.Transparent;
            this.lblNew.ForeColor = System.Drawing.Color.White;
            this.lblNew.Location = new System.Drawing.Point(11, 653);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(39, 13);
            this.lblNew.TabIndex = 36;
            this.lblNew.Text = "lblNew";
            // 
            // photo2PictureBox
            // 
            this.photo2PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photo2PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.photo2PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.photo2PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("photo2PictureBox.Image")));
            this.photo2PictureBox.ImageLocation = "";
            this.photo2PictureBox.Location = new System.Drawing.Point(325, 115);
            this.photo2PictureBox.Name = "photo2PictureBox";
            this.photo2PictureBox.Size = new System.Drawing.Size(90, 90);
            this.photo2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photo2PictureBox.TabIndex = 37;
            this.photo2PictureBox.TabStop = false;
            // 
            // player2NameLabel
            // 
            this.player2NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2NameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.player2NameLabel.Location = new System.Drawing.Point(250, 154);
            this.player2NameLabel.Name = "player2NameLabel";
            this.player2NameLabel.Size = new System.Drawing.Size(74, 23);
            this.player2NameLabel.TabIndex = 38;
            this.player2NameLabel.Text = "Player 2";
            this.player2NameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // playerDiscard1
            // 
            this.playerDiscard1.BackColor = System.Drawing.Color.Transparent;
            this.playerDiscard1.Location = new System.Drawing.Point(295, 355);
            this.playerDiscard1.Name = "playerDiscard1";
            this.playerDiscard1.Size = new System.Drawing.Size(75, 105);
            this.playerDiscard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerDiscard1.TabIndex = 39;
            this.playerDiscard1.TabStop = false;
            this.playerDiscard1.Tag = "0";
            this.playerDiscard1.Visible = false;
            // 
            // dealerDiscard1
            // 
            this.dealerDiscard1.BackColor = System.Drawing.Color.Transparent;
            this.dealerDiscard1.Location = new System.Drawing.Point(375, 355);
            this.dealerDiscard1.Name = "dealerDiscard1";
            this.dealerDiscard1.Size = new System.Drawing.Size(75, 105);
            this.dealerDiscard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerDiscard1.TabIndex = 40;
            this.dealerDiscard1.TabStop = false;
            this.dealerDiscard1.Tag = "0";
            this.dealerDiscard1.Visible = false;
            // 
            // AnimationTimerDealerDiscard
            // 
            this.AnimationTimerDealerDiscard.Interval = 50;
            // 
            // AnimationTimerPlayerDiscard
            // 
            this.AnimationTimerPlayerDiscard.Interval = 50;
            // 
            // DisCardPB
            // 
            this.DisCardPB.BackColor = System.Drawing.Color.Transparent;
            this.DisCardPB.Location = new System.Drawing.Point(650, 150);
            this.DisCardPB.Name = "DisCardPB";
            this.DisCardPB.Size = new System.Drawing.Size(75, 105);
            this.DisCardPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DisCardPB.TabIndex = 41;
            this.DisCardPB.TabStop = false;
            this.DisCardPB.Visible = false;
            // 
            // AnimationTimerAllDiscards
            // 
            this.AnimationTimerAllDiscards.Interval = 50;
            // 
            // shuffleButton
            // 
            this.shuffleButton.BackColor = System.Drawing.Color.Transparent;
            this.shuffleButton.BackgroundImage = global::BasicCard.Properties.Resources.ButtonRound1;
            this.shuffleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shuffleButton.FlatAppearance.BorderSize = 0;
            this.shuffleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.shuffleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.shuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shuffleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shuffleButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.shuffleButton.Location = new System.Drawing.Point(450, 804);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(123, 39);
            this.shuffleButton.TabIndex = 42;
            this.shuffleButton.Text = "New Game";
            this.shuffleButton.UseVisualStyleBackColor = false;
            this.shuffleButton.Click += new System.EventHandler(this.ShuffleBtn_Click);
            // 
            // BasicCardForm
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::BasicCard.Properties.Resources.BackgroundGrnBlk;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(744, 861);
            this.Controls.Add(this.shuffleButton);
            this.Controls.Add(this.DisCardPB);
            this.Controls.Add(this.dealerDiscard1);
            this.Controls.Add(this.playerDiscard1);
            this.Controls.Add(this.player2NameLabel);
            this.Controls.Add(this.photo2PictureBox);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblDealer);
            this.Controls.Add(this.lblDeck);
            this.Controls.Add(this.lblCardsInDealersHand);
            this.Controls.Add(this.lblCardsInPlayersHand);
            this.Controls.Add(this.lblCardsInDeck);
            this.Controls.Add(this.dealerTotalLabel);
            this.Controls.Add(this.DeckCardPB);
            this.Controls.Add(this.recordPanel);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.playerCard6);
            this.Controls.Add(this.playerCard5);
            this.Controls.Add(this.dealerCard6);
            this.Controls.Add(this.dealerCard5);
            this.Controls.Add(this.gameOverTextBox);
            this.Controls.Add(this.dealerCard4);
            this.Controls.Add(this.dealerCard3);
            this.Controls.Add(this.photoPictureBox);
            this.Controls.Add(this.endGameButton);
            this.Controls.Add(this.playerTotalLabel);
            this.Controls.Add(this.dealButton);
            this.Controls.Add(this.clearTableButton);
            this.Controls.Add(this.HideHandsBtn);
            this.Controls.Add(this.ShowHandsBtn);
            this.Controls.Add(this.playerCard4);
            this.Controls.Add(this.playerCard3);
            this.Controls.Add(this.playerCard2);
            this.Controls.Add(this.playerCard1);
            this.Controls.Add(this.deckCard3);
            this.Controls.Add(this.deckCard2);
            this.Controls.Add(this.deckCard1);
            this.Controls.Add(this.dealerCard2);
            this.Controls.Add(this.dealerCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BasicCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Game";
            this.Load += new System.EventHandler(this.BasicCardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deckCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard6)).EndInit();
            this.recordPanel.ResumeLayout(false);
            this.recordPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCardPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerDiscard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerDiscard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisCardPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox myAccountTextBox;
        private System.Windows.Forms.TextBox winTextBox;
        private System.Windows.Forms.Button HideHandsBtn;
        private System.Windows.Forms.Button dealButton;
        private System.Windows.Forms.Button clearTableButton;
        private System.Windows.Forms.Label myAccountLabel;
        private System.Windows.Forms.TextBox gameOverTextBox;
        private System.Windows.Forms.Label winsLabel;
        private System.Windows.Forms.Label lossesLabel;
        private System.Windows.Forms.TextBox lossTextBox;
        private System.Windows.Forms.Label tiesLabel;
        private System.Windows.Forms.TextBox tiesTextBox;
        private System.Windows.Forms.PictureBox deckCard1;
        private System.Windows.Forms.PictureBox deckCard2;
        private System.Windows.Forms.PictureBox deckCard3;
        private System.Windows.Forms.PictureBox dealerCard6;
        private System.Windows.Forms.PictureBox dealerCard5;
        private System.Windows.Forms.PictureBox dealerCard4;
        private System.Windows.Forms.PictureBox dealerCard3;
        private System.Windows.Forms.PictureBox dealerCard2;
        private System.Windows.Forms.PictureBox dealerCard1;
        private System.Windows.Forms.Button endGameButton;
        private System.Windows.Forms.PictureBox playerCard1;
        private System.Windows.Forms.PictureBox playerCard2;
        private System.Windows.Forms.PictureBox playerCard3;
        private System.Windows.Forms.PictureBox playerCard4;
        private System.Windows.Forms.PictureBox playerCard5;
        private System.Windows.Forms.PictureBox playerCard6;
        private System.Windows.Forms.Label playerTotalLabel;
        private System.Windows.Forms.Button ShowHandsBtn;
        private System.Windows.Forms.Panel recordPanel;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Timer AnimationTimerPlayer;
        private System.Windows.Forms.PictureBox DeckCardPB;
        internal System.Windows.Forms.Timer AnimationTimerDealer;
        private System.Windows.Forms.Label dealerTotalLabel;
        private System.Windows.Forms.Label lblCardsInDeck;
        private System.Windows.Forms.Label lblCardsInPlayersHand;
        private System.Windows.Forms.Label lblCardsInDealersHand;
        private System.Windows.Forms.Label lblDeck;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.PictureBox photo2PictureBox;
        private System.Windows.Forms.Label player2NameLabel;
        private System.Windows.Forms.PictureBox playerDiscard1;
        private System.Windows.Forms.PictureBox dealerDiscard1;
        private System.Windows.Forms.Timer AnimationTimerDealerDiscard;
        private System.Windows.Forms.Timer AnimationTimerPlayerDiscard;
        private System.Windows.Forms.PictureBox DisCardPB;
        private System.Windows.Forms.Timer AnimationTimerAllDiscards;
        private System.Windows.Forms.Button shuffleButton;
    }
}