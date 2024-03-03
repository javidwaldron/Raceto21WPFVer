using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace Raceto21WPFVer
{


    public partial class MainWindow : Window
    {

        Game game = new Game();
        Deck deck = new Deck();

        public int numberOfPlayers;
        public int nameenteredcount;
        public int twentyOneObtained;
        public int turn = 0;
        public int busted = 0;
        public bool allPlayersIn = false;

        List<Player> players = new List<Player>();
        public MainWindow()
        {

            InitializeComponent();


        }

        //Exit Menu Button
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        //Wipes the  how many players text once selected
        private void howManyPlayers_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            howManyPlayers.Text = "";
        }

        //Forces a value between 2- 4, once user hits enter key assigns to int number of players 
        private void howManyPlayers_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {



                if (int.TryParse(howManyPlayers.Text, out numberOfPlayers) == false
                      || numberOfPlayers < 0 || numberOfPlayers > 4)
                {

                    howManyPlayers.Text = "Please enter a valid number between 2 and 4";


                }
                //Removes Question Box and Enter Button 
                else
                {
                    AskBox.Text = "Please Input Your Names and Hit Enter";
                    numberOfPlayers = int.Parse(howManyPlayers.Text);
                    howManyPlayers.Visibility = Visibility.Hidden;


                    for (int i = 0; i < numberOfPlayers; i++)
                    {

                        players.Add(new Player());

                    }


                    PlayerNames();



                }

            }

        }

        // Enables player placement visibility and prompts name entering ask boxes
        public void PlayerNames()
        {

            switch (players.Count)
            {
                case 2:
                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerNameBAskBox.Visibility = Visibility.Visible;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    PlayerNameDAskBox.Visibility = Visibility.Visible;
                    break;
                case 3:
                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerNameBAskBox.Visibility = Visibility.Visible;
                    PlayerCPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementC.Visibility = Visibility.Visible;
                    PlayerNameCAskBox.Visibility = Visibility.Visible;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    PlayerNameDAskBox.Visibility = Visibility.Visible;
                    break;
                case 4:
                    PlayerAPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementA.Visibility = Visibility.Visible;
                    PlayerNameAAskBox.Visibility = Visibility.Visible;
                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerNameBAskBox.Visibility = Visibility.Visible;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    PlayerNameDAskBox.Visibility = Visibility.Visible;
                    PlayerEPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementE.Visibility = Visibility.Visible;
                    PlayerNameEAskBox.Visibility = Visibility.Visible;
                    break;

            }


        }
        // Move this, this restarts application for new game
        private void MenuItemNewGame_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }


        // Allows players to enter name after hitting enter, takes input based on visibility of box, determined by number of players

        private void PlayerNameAAskBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerNameAAskBox.Text = "";


        }
        private void PlayerNameAAskBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == System.Windows.Input.Key.Return)
            {
                PlayerNamePlacementA.Text = PlayerNameAAskBox.Text;
                PlayerNameAAskBox.Visibility = Visibility.Hidden;
                nameenteredcount++;

                if (nameenteredcount == numberOfPlayers)
                {
                    ReadyButton.Visibility = Visibility.Visible;
                }


            }

        }
        private void PlayerNameBAskBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerNameBAskBox.Text = "";


        }
        private void PlayerNameBAskBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == System.Windows.Input.Key.Return)
            {
                PlayerNamePlacementB.Text = PlayerNameBAskBox.Text;
                PlayerNameBAskBox.Visibility = Visibility.Hidden;
                nameenteredcount++;

                if (nameenteredcount == numberOfPlayers)
                {
                    ReadyButton.Visibility = Visibility.Visible;
                }


            }


        }
        private void PlayerNameCAskBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerNameCAskBox.Text = "";


        }
        private void PlayerNameCAskBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                PlayerNamePlacementC.Text = PlayerNameCAskBox.Text;
                PlayerNameCAskBox.Visibility = Visibility.Hidden;
                nameenteredcount++;

                if (nameenteredcount == numberOfPlayers)
                {
                    ReadyButton.Visibility = Visibility.Visible;
                }

            }


        }
        private void PlayerNameDAskBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerNameDAskBox.Text = "";


        }
        private void PlayerNameDAskBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                PlayerNamePlacementD.Text = PlayerNameDAskBox.Text;
                PlayerNameDAskBox.Visibility = Visibility.Hidden;
                nameenteredcount++;

                if (nameenteredcount == numberOfPlayers)
                {
                    ReadyButton.Visibility = Visibility.Visible;
                }

            }


        }

        private void PlayerNameEAskBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerNameEAskBox.Text = "";


        }
        private void PlayerNameEAskBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                PlayerNamePlacementE.Text = PlayerNameEAskBox.Text;
                PlayerNameEAskBox.Visibility = Visibility.Hidden;
                nameenteredcount++;

                if (nameenteredcount == numberOfPlayers)
                {
                    ReadyButton.Visibility = Visibility.Visible;
                }


            }

        }

        //This assigns the players to each score placement/ player class name. Triggered by ready button.

        public void AssignPlayers()
        {


            switch (numberOfPlayers)
            {
                case 2:
                    players[0].name = PlayerNamePlacementB.Text;
                    players[1].name = PlayerNamePlacementD.Text;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                    break;

                case 3:
                    players[0].name = PlayerNamePlacementB.Text;
                    players[1].name = PlayerNamePlacementC.Text;
                    players[2].name = PlayerNamePlacementD.Text;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                    Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " : score of " + players[2].score + "/21";

                    break;

                case 4:
                    players[0].name = PlayerNamePlacementA.Text;
                    players[1].name = PlayerNamePlacementB.Text;
                    players[2].name = PlayerNamePlacementD.Text;
                    players[3].name = PlayerNamePlacementE.Text;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                    Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " : score of " + players[2].score + "/21";
                    Player_4_Score_and_Holder.Text = "Player 4 " + players[3].name + " : score of " + players[3].score + "/21";

                    break;

            }



        }

        //Triggers the official placement of each player
        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            AssignPlayers();
            ReadyButton.Visibility = Visibility.Collapsed;
            AskBox.Text = "Ok " + players[0].name + " are you ready for your first card?";
            GameTurn();

        }

        //Using a turn marker in combination of a turn integer to shift the available playing options for each player, creating turns. Called after every stay, pass, 21 or bust

        private void GameTurn()
        {
            deck.Shuffle();
            //Two PLayer Turn & Game Winning Condition

            if (turn == 0 && numberOfPlayers == 2)
            {
                PlayerBHitButton.Visibility = Visibility.Visible;
                PlayerBStayButton.Visibility = Visibility.Visible;
                PlayerBPassButton.Visibility = Visibility.Visible;
            }
            if (turn == 1 && numberOfPlayers == 2)
            {
                AskBox.Text = "Ok " + players[1].name + " are you ready for your first card?";

                PlayerBHitButton.Visibility = Visibility.Collapsed;
                PlayerBStayButton.Visibility = Visibility.Collapsed;
                PlayerBPassButton.Visibility = Visibility.Collapsed;

                PlayerDHitButton.Visibility = Visibility.Visible;
                PlayerDStayButton.Visibility = Visibility.Visible;
                PlayerDPassButton.Visibility = Visibility.Visible;

            }
            if (turn == 2 && numberOfPlayers == 2)
            {
                PlayerDHitButton.Visibility = Visibility.Collapsed;
                PlayerDStayButton.Visibility = Visibility.Collapsed;
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                AskBox.Text = "Round Over!";
                //Insert Victory thing here

            }
            if (turn == 0 && numberOfPlayers == 3)
            {

                PlayerBHitButton.Visibility = Visibility.Visible;
                PlayerBStayButton.Visibility = Visibility.Visible;
                PlayerBPassButton.Visibility = Visibility.Visible;

            }
            if (turn == 1 && numberOfPlayers == 3)
            {

                AskBox.Text = "Ok " + players[1].name + " are you ready for your first card?";

                PlayerBHitButton.Visibility = Visibility.Collapsed;
                PlayerBStayButton.Visibility = Visibility.Collapsed;
                PlayerBPassButton.Visibility = Visibility.Collapsed;

                PlayerCHitButton.Visibility = Visibility.Visible;
                PlayerCStayButton.Visibility = Visibility.Visible;
                PlayerCPassButton.Visibility = Visibility.Visible;

            }
            if (turn == 2 && numberOfPlayers == 3)
            {

                AskBox.Text = "Ok " + players[2].name + " are you ready for your first card?";

                PlayerCHitButton.Visibility = Visibility.Collapsed;
                PlayerCStayButton.Visibility = Visibility.Collapsed;
                PlayerCPassButton.Visibility = Visibility.Collapsed;

                PlayerDHitButton.Visibility = Visibility.Visible;
                PlayerDStayButton.Visibility = Visibility.Visible;
                PlayerDPassButton.Visibility = Visibility.Visible;


            }
            if (turn == 3 && numberOfPlayers == 3)
            {
                PlayerDHitButton.Visibility = Visibility.Collapsed;
                PlayerDStayButton.Visibility = Visibility.Collapsed;
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                AskBox.Text = "Round Over!";
                //Insert Victory Thing here
            }
            if (turn == 0 && numberOfPlayers == 4)
            {
                PlayerAHitButton.Visibility = Visibility.Visible;
                PlayerAStayButton.Visibility = Visibility.Visible;
                PlayerAPassButton.Visibility = Visibility.Visible;
            }
            if (turn == 1 && numberOfPlayers == 4)
            {
                AskBox.Text = "Ok " + players[1].name + " are you ready for your first card?";

                PlayerAHitButton.Visibility = Visibility.Collapsed;
                PlayerAStayButton.Visibility = Visibility.Collapsed;
                PlayerAPassButton.Visibility = Visibility.Collapsed;

                PlayerBHitButton.Visibility = Visibility.Visible;
                PlayerBStayButton.Visibility = Visibility.Visible;
                PlayerBPassButton.Visibility = Visibility.Visible;

            }
            if (turn == 2 && numberOfPlayers == 4)
            {
                AskBox.Text = "Ok " + players[2].name + " are you ready for your first card?";

                PlayerBHitButton.Visibility = Visibility.Collapsed;
                PlayerBStayButton.Visibility = Visibility.Collapsed;
                PlayerBPassButton.Visibility = Visibility.Collapsed;

                PlayerDHitButton.Visibility = Visibility.Visible;
                PlayerDStayButton.Visibility = Visibility.Visible;
                PlayerDPassButton.Visibility = Visibility.Visible;

            }
            if (turn == 3 && numberOfPlayers == 4)
            {

                AskBox.Text = "Ok " + players[3].name + " are you ready for your first card?";

                PlayerDHitButton.Visibility = Visibility.Collapsed;
                PlayerDStayButton.Visibility = Visibility.Collapsed;
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                PlayerEHitButton.Visibility = Visibility.Visible;
                PlayerEStayButton.Visibility = Visibility.Visible;
                PlayerEPassButton.Visibility = Visibility.Visible;

            }
            if (turn == 4 && numberOfPlayers == 4)
            {
                PlayerEHitButton.Visibility = Visibility.Collapsed;
                PlayerEStayButton.Visibility = Visibility.Collapsed;
                PlayerEPassButton.Visibility = Visibility.Collapsed;

                AskBox.Text = "Round Over!";
                //Insert Victory Thing here
            }








        }

        // Copy pasted over from console 21 code
        int ScoreHand(Player player)
        {
            int score = 0;

            foreach (Card card in player.cardsInHand)
            {
                string faceValue = card.ID.Remove(card.ID.Length - 1);
                switch (faceValue)
                {
                    case "K":
                    case "Q":
                    case "J":
                        score = score + 10;
                        break;
                    case "A":
                        score = score + 1;
                        break;
                    default:
                        score = score + int.Parse(faceValue);
                        break;
                }
            }
            return score;
        }





        // PLACEMENT A GAMEPLAY BOXES HERE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        private void PlayerAHitButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 4)
            {
                Card card = deck.DealTopCard();
                players[0].cardsInHand.Add(card);
                players[0].score = ScoreHand(players[0]);
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                AskBox.Text = "Would you like another card," + players[0].name + " ?";
                PlayerAPassButton.Visibility = Visibility.Collapsed;

                // Come back and do visibility of winn, bust stay icons

                if (players[0].score == 21)
                {
                    twentyOneObtained++;
                    players[0].hasWon = true;
                    turn++;

                    PlayerAHitButton.Visibility = Visibility.Collapsed;
                    PlayerAStayButton.Visibility = Visibility.Collapsed;
                    PlayerAPassButton.Visibility = Visibility.Collapsed;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    GameTurn();


                }
                if (players[0].score > 21)
                {
                    players[0].isActive = false;
                    players[0].isBust = true;
                    busted++;

                    turn++;
                    players[0].score = 0;

                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " has busted!";
                    PlayerAHitButton.Visibility = Visibility.Collapsed;
                    PlayerAStayButton.Visibility = Visibility.Collapsed;
                    PlayerAPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();


                }
            }

        }

        private void PlayerAStayButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 4)
            {
                players[0].isStaying = true;
                players[0].isActive = false;
                turn++;
                GameTurn();
                // Add stay  graphic visibility here

            }
        }

        private void PlayerAPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 4)
            {
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " is sitting out this round!";
                players[0].score = 0;
                turn++;
                GameTurn();

            }

        }






        // PLACENMENT B GAMEPLAY BOXES HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void PlayerBHitButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 2)
            {
                Card card = deck.DealTopCard();
                players[0].cardsInHand.Add(card);
                players[0].score = ScoreHand(players[0]);
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                AskBox.Text = "Would you like another card," + players[0].name + " ?";
                PlayerBPassButton.Visibility = Visibility.Collapsed;


                if (players[0].score == 21)
                {
                    twentyOneObtained++;
                    players[0].hasWon = true;
                    turn++;

                    //Insert Win Visual Here


                    PlayerBHitButton.Visibility = Visibility.Collapsed;
                    PlayerBStayButton.Visibility = Visibility.Collapsed;
                    PlayerBPassButton.Visibility = Visibility.Collapsed;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    GameTurn();


                }
                if (players[0].score > 21)
                {
                    players[0].isActive = false;
                    players[0].isBust = true;
                    busted++;

                    //Insert Busted Visual Here


                    turn++;
                    players[0].score = 0;

                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " has busted!";
                    PlayerBHitButton.Visibility = Visibility.Collapsed;
                    PlayerBStayButton.Visibility = Visibility.Collapsed;
                    PlayerBPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();

                }
            }
            else if (numberOfPlayers == 3)
            {
                Card card = deck.DealTopCard();
                players[0].cardsInHand.Add(card);
                players[0].score = ScoreHand(players[0]);
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                AskBox.Text = "Would you like another card," + players[0].name + " ?";
                PlayerBPassButton.Visibility = Visibility.Collapsed;

                if (players[0].score == 21)
                {
                    twentyOneObtained++;
                    players[0].hasWon = true;
                    turn++;

                    //Insert Win Visual Here

                    PlayerBHitButton.Visibility = Visibility.Collapsed;
                    PlayerBStayButton.Visibility = Visibility.Collapsed;
                    PlayerBPassButton.Visibility = Visibility.Collapsed;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    GameTurn();


                }
                if (players[0].score > 21)
                {
                    players[0].isActive = false;
                    players[0].isBust = true;
                    busted++;


                    // Insert Busted Visual here

                    turn++;
                    players[0].score = 0;

                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " has busted!";
                    PlayerBHitButton.Visibility = Visibility.Collapsed;
                    PlayerBStayButton.Visibility = Visibility.Collapsed;
                    PlayerBPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();

                }

            }
            else if (numberOfPlayers == 4)
            {
                Card card = deck.DealTopCard();
                players[1].cardsInHand.Add(card);
                players[1].score = ScoreHand(players[1]);
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                AskBox.Text = "Would you like another card," + players[1].name + " ?";
                PlayerBPassButton.Visibility = Visibility.Collapsed;

                if (players[1].score == 21)
                {
                    twentyOneObtained++;
                    players[1].hasWon = true;
                    turn++;

                    // Insert Victory Visual Here


                    PlayerBHitButton.Visibility = Visibility.Collapsed;
                    PlayerBStayButton.Visibility = Visibility.Collapsed;
                    PlayerBPassButton.Visibility = Visibility.Collapsed;
                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                    GameTurn();


                }
                if (players[1].score > 21)
                {
                    players[1].isActive = false;
                    players[1].isBust = true;
                    busted++;

                    turn++;
                    players[1].score = 0;

                    //Insert Busted Visual Here

                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " has busted!";
                    PlayerBHitButton.Visibility = Visibility.Collapsed;
                    PlayerBStayButton.Visibility = Visibility.Collapsed;
                    PlayerBPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();

                }

            }

        }

        private void PlayerBStayButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 2)
            {
                players[0].isStaying = true;
                players[0].isActive = false;
                turn++;
                GameTurn();
                // Add stay  graphic visibility here

            }
            if (numberOfPlayers == 3)
            {
                players[0].isStaying = true;
                players[0].isActive = false;
                turn++;
                GameTurn();
                // Add stay  graphic visibility here

            }
            if (numberOfPlayers == 4)
            {
                players[1].isStaying = true;
                players[1].isActive = false;
                turn++;
                GameTurn();
                // Add stay  graphic visibility here

            }

        }

        private void PlayerBPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 2)
            {
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " is sitting out this round!";
                players[0].score = 0;
                turn++;
                GameTurn();

            }
            if (numberOfPlayers == 3)
            {
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " is sitting out this round!";
                players[0].score = 0;
                turn++;
                GameTurn();

            }
            if (numberOfPlayers == 4)
            {
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " is sitting out this round!";
                players[1].score = 0;
                turn++;
                GameTurn();

            }

        }


        // PLACENMENT C GAMEPLAY BOXES HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        private void PlayerCHitButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 3)
            {
                Card card = deck.DealTopCard();
                players[1].cardsInHand.Add(card);
                players[1].score = ScoreHand(players[1]);
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                AskBox.Text = "Would you like another card," + players[1].name + " ?";
                PlayerCPassButton.Visibility = Visibility.Collapsed;

                if (players[1].score == 21)
                {
                    twentyOneObtained++;
                    players[1].hasWon = true;
                    turn++;

                    // Insert Victory Visual Here


                    PlayerCHitButton.Visibility = Visibility.Collapsed;
                    PlayerCStayButton.Visibility = Visibility.Collapsed;
                    PlayerCPassButton.Visibility = Visibility.Collapsed;
                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                    GameTurn();


                }
                if (players[1].score > 21)
                {
                    players[1].isActive = false;
                    players[1].isBust = true;
                    busted++;

                    turn++;
                    players[1].score = 0;

                    //Insert Busted Visual Here

                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " has busted!";
                    PlayerCHitButton.Visibility = Visibility.Collapsed;
                    PlayerCStayButton.Visibility = Visibility.Collapsed;
                    PlayerCPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();
                }

            }

        }

        private void PlayerCStayButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 3)
            {
                players[1].isStaying = true;
                players[1].isActive = false;
                turn++;
                GameTurn();

            }

        }

        private void PlayerCPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 3)
            {
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " is sitting out this round!";
                players[1].score = 0;
                turn++;
                GameTurn();


            }
        }


        // PLACEMENT D GAMEPLAY BOXES HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void PlayerDHitButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 2)
            {
                Card card = deck.DealTopCard();
                players[1].cardsInHand.Add(card);
                players[1].score = ScoreHand(players[1]);
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                AskBox.Text = "Would you like another card," + players[1].name + " ?";
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                if (players[1].score == 21)
                {
                    twentyOneObtained++;
                    players[1].hasWon = true;
                    turn++;

                    // Insert Victory Visual Here


                    PlayerDHitButton.Visibility = Visibility.Collapsed;
                    PlayerDStayButton.Visibility = Visibility.Collapsed;
                    PlayerDPassButton.Visibility = Visibility.Collapsed;
                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                    GameTurn();


                }
                if (players[1].score > 21)
                {
                    players[1].isActive = false;
                    players[1].isBust = true;
                    busted++;

                    turn++;
                    players[1].score = 0;

                    //Insert Busted Visual Here

                    Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " has busted!";
                    PlayerDHitButton.Visibility = Visibility.Collapsed;
                    PlayerDStayButton.Visibility = Visibility.Collapsed;
                    PlayerDPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();

                }


            }
            if(numberOfPlayers == 3)
            {

                Card card = deck.DealTopCard();
                players[2].cardsInHand.Add(card);
                players[2].score = ScoreHand(players[2]);
                Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " : score of " + players[2].score + "/21";
                AskBox.Text = "Would you like another card," + players[2].name + " ?";
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                if (players[2].score == 21)
                {
                    twentyOneObtained++;
                    players[2].hasWon = true;
                    turn++;

                    // Insert Victory Visual Here


                    PlayerDHitButton.Visibility = Visibility.Collapsed;
                    PlayerDStayButton.Visibility = Visibility.Collapsed;
                    PlayerDPassButton.Visibility = Visibility.Collapsed;
                    Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " : score of " + players[2].score + "/21";
                    GameTurn();


                }
                if (players[2].score > 21)
                {
                    players[2].isActive = false;
                    players[2].isBust = true;
                    busted++;

                    turn++;
                    players[2].score = 0;

                    //Insert Busted Visual Here

                    Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " has busted!";
                    PlayerDHitButton.Visibility = Visibility.Collapsed;
                    PlayerDStayButton.Visibility = Visibility.Collapsed;
                    PlayerDPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();

                }


            }
            if (numberOfPlayers == 4)
            {

                Card card = deck.DealTopCard();
                players[2].cardsInHand.Add(card);
                players[2].score = ScoreHand(players[2]);
                Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " : score of " + players[2].score + "/21";
                AskBox.Text = "Would you like another card," + players[2].name + " ?";
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                if (players[2].score == 21)
                {
                    twentyOneObtained++;
                    players[2].hasWon = true;
                    turn++;

                    // Insert Victory Visual Here


                    PlayerDHitButton.Visibility = Visibility.Collapsed;
                    PlayerDStayButton.Visibility = Visibility.Collapsed;
                    PlayerDPassButton.Visibility = Visibility.Collapsed;
                    Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " : score of " + players[2].score + "/21";
                    GameTurn();


                }
                if (players[2].score > 21)
                {
                    players[2].isActive = false;
                    players[2].isBust = true;
                    busted++;

                    turn++;
                    players[2].score = 0;

                    //Insert Busted Visual Here

                    Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " has busted!";
                    PlayerDHitButton.Visibility = Visibility.Collapsed;
                    PlayerDStayButton.Visibility = Visibility.Collapsed;
                    PlayerDPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();

                }


            }

        }

        private void PlayerDStayButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 2)
            {
                players[1].isStaying = true;
                players[1].isActive = false;
                turn++;
                GameTurn();

            }
            if(numberOfPlayers == 3)
            {
                players[2].isStaying = true;
                players[2].isActive = false;
                turn++;
                GameTurn();
            }
            if(numberOfPlayers == 4)
            {
                players[3].isStaying = true;
                players[3].isActive = false;
                turn++;
                GameTurn();

            }


        }

        private void PlayerDPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 3)
            {
                Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " is sitting out this round!";
                players[2].score = 0;
                turn++;
                GameTurn();

            }
            if(numberOfPlayers == 4)
            {
                Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " is sitting out this round!";
                players[2].score = 0;
                turn++;
                GameTurn();

            }

        }

        // PLACEMENT E GAMEPLAY BOXES HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void PlayerEHitButton_Click(object sender, RoutedEventArgs e)
        {
            if(numberOfPlayers == 4)
            {

                Card card = deck.DealTopCard();
                players[3].cardsInHand.Add(card);
                players[3].score = ScoreHand(players[2]);
                Player_4_Score_and_Holder.Text = "Player 4 " + players[3].name + " : score of " + players[3].score + "/21";
                AskBox.Text = "Would you like another card," + players[3].name + " ?";
                PlayerEPassButton.Visibility = Visibility.Collapsed;

                if (players[3].score == 21)
                {
                    twentyOneObtained++;
                    players[2].hasWon = true;
                    turn++;

                    // Insert Victory Visual Here


                    PlayerEHitButton.Visibility = Visibility.Collapsed;
                    PlayerEStayButton.Visibility = Visibility.Collapsed;
                    PlayerEPassButton.Visibility = Visibility.Collapsed;
                    Player_4_Score_and_Holder.Text = "Player 4 " + players[3].name + " : score of " + players[3].score + "/21";
                    GameTurn();


                }
                if (players[3].score > 21)
                {
                    players[3].isActive = false;
                    players[3].isBust = true;
                    busted++;

                    turn++;
                    players[3].score = 0;

                    //Insert Busted Visual Here

                    Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " has busted!";
                    PlayerDHitButton.Visibility = Visibility.Collapsed;
                    PlayerDStayButton.Visibility = Visibility.Collapsed;
                    PlayerDPassButton.Visibility = Visibility.Collapsed;
                    GameTurn();

                }
            }



        }

        private void PlayerEStayButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 4)
            {
                players[3].isStaying = true;
                players[3].isActive = false;
                turn++;
                GameTurn();

            }

        }

        private void PlayerEPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 4)
            {
                Player_4_Score_and_Holder.Text = "Player 4 " + players[3].name + " is sitting out this round!";
                players[3].score = 0;
                turn++;
                GameTurn();

            }



        }
   
    
    
    
    
    
    
    
    
    }      
        
}
