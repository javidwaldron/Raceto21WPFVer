using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
       
        
        //Bools for visuals
        
        public bool placementAwin = false;
        public bool placementBwin = false;
        public bool placementCwin = false;
        public bool placementDwin = false;
        public bool placementEwin = false;
        
        public bool placementAstay = false;
        public bool placementBstay = false;
        public bool placementCstay = false;
        public bool placementDstay = false;
        public bool placementEstay = false;
       
        public bool placementAbust = false;
        public bool placementBbust = false;
        public bool placementCbust = false;
        public bool placementDbust = false;
        public bool placementEbust = false;
       
        public bool placementApass = false;
        public bool placementBpass = false;
        public bool placementCpass = false;
        public bool placementDpass = false;
        public bool placementEpass = false;



        List<Player> players = new List<Player>();
        List<int> playerScore = new List<int>();
        
        
        

        public MainWindow()
        {
            
         

            InitializeComponent();
            deck.ShowAllCards();

            

            PlayerACardTest.Source = new BitmapImage(new Uri(@"/Images/7C.png", UriKind.Relative));

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

        // Enables player placement visibility and prompts name entering ask boxes+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void PlayerNames()
        {

            switch (numberOfPlayers)
            {
                case 2:
                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerNameBAskBox.Visibility = Visibility.Visible;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    PlayerNameDAskBox.Visibility = Visibility.Visible;

                    

                    PlayerAPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementA.Visibility = Visibility.Hidden;
                    PlayerNameAAskBox.Visibility = Visibility.Hidden;
                    PlayerCPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementC.Visibility = Visibility.Hidden;
                    PlayerNameCAskBox.Visibility = Visibility.Hidden;
                    PlayerEPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementE.Visibility = Visibility.Hidden;
                    PlayerNameEAskBox.Visibility = Visibility.Hidden;

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

                    

                    PlayerAPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementA.Visibility = Visibility.Hidden;
                    PlayerNameAAskBox.Visibility = Visibility.Hidden;
                    PlayerEPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementE.Visibility = Visibility.Hidden;
                    PlayerNameEAskBox.Visibility = Visibility.Hidden;


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


        //For Use When starting a new round, fixes a bug+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void PlayerNamesNewRound()
        {

            switch (numberOfPlayers)
            {
                case 2:
                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Text = players[0].name;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Text = players[1].name;


                    

                    PlayerAPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementA.Visibility = Visibility.Hidden;
                    PlayerNameAAskBox.Visibility = Visibility.Hidden;
                    PlayerCPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementC.Visibility = Visibility.Hidden;
                    PlayerNameCAskBox.Visibility = Visibility.Hidden;
                    PlayerEPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementE.Visibility = Visibility.Hidden;
                    PlayerNameEAskBox.Visibility = Visibility.Hidden;

                    break;

                case 3:

                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Text = players[0].name;
                    PlayerCPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementC.Visibility = Visibility.Visible;
                    PlayerNamePlacementC.Text = players[1].name;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Text = players[2].name;


                    

                    PlayerAPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementA.Visibility = Visibility.Hidden;
                    PlayerNameAAskBox.Visibility = Visibility.Hidden;
                    PlayerEPlacementDeck.Visibility = Visibility.Hidden;
                    PlayerNamePlacementE.Visibility = Visibility.Hidden;
                    PlayerNameEAskBox.Visibility = Visibility.Hidden;


                    break;

                case 4:
                    PlayerAPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementA.Visibility = Visibility.Visible;
                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    PlayerEPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementE.Visibility = Visibility.Visible;
                    
                    break;

            }


        }


        // Move this, this restarts application for new game+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void MenuItemNewGame_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }


        // Allows players to enter name after hitting enter, takes input based on visibility of box, determined by number of players, all lead to ready player button activate once entered names, equal player count+++++++++++++++++

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

        //This assigns the players to each score placement/ player class name. Triggered by ready button.+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

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

        //Triggers the official first start of the game+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
       
        
        
        
        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            AssignPlayers();
            ReadyButton.Visibility = Visibility.Collapsed;
            AskBox.Text = "Ok " + players[0].name + " are you ready for your first card?";
            GameTurn();

        }

        //Using a turn marker in combination of a turn integer to shift the available playing options for each player, creating turns. Called after every stay, pass, 21 or bust.
        //Also checks the score integer, and will declare multiple winners if player score matches the number one spot of the collective score collection.

        private void GameTurn()
        {
            deck.Shuffle();
            StatusImage();
            

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

                playerScore.Sort();
                playerScore.Reverse();
                
                newRoundButton.Visibility = Visibility.Visible;

                AskBox.Text = "Round Over!!!";

                PlacementBcontinue.Visibility = Visibility.Visible;
                PlacementDcontinue.Visibility = Visibility.Visible;

                if (players[0].hasWon == true || players[0].score == playerScore[0] && players[0].isStaying == true)
                {
                    PlayerBWin.Visibility = Visibility.Visible;
                    PlayerBStay.Visibility = Visibility.Collapsed;

                }
                if(players[1].hasWon == true || players[1].score == playerScore[0] && players[1].isStaying == true)
                {
                    PlayerDWin.Visibility = Visibility.Visible;
                    PlayerDStay.Visibility = Visibility.Collapsed;
                }
            


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
             

                playerScore.Sort();
                playerScore.Reverse();

                newRoundButton.Visibility = Visibility.Visible;
               

                AskBox.Text = "Round Over!!!";

                PlacementBcontinue.Visibility = Visibility.Visible;
                PlacementCcontinue.Visibility = Visibility.Visible;
                PlacementDcontinue.Visibility = Visibility.Visible;

                if (players[0].hasWon == true || players[0].score == playerScore[0] && players[0].isStaying == true)
                {
                    PlayerBWin.Visibility = Visibility.Visible;
                    PlayerBStay.Visibility = Visibility.Collapsed;

                }
                if (players[1].hasWon == true || players[1].score == playerScore[0] && players[1].isStaying == true)
                {
                    PlayerCWin.Visibility = Visibility.Visible;
                    PlayerCStay.Visibility = Visibility.Collapsed;
                }
                if(players[2].hasWon == true || players[2].score == playerScore[0] && players[2].isStaying == true)
                {
                    PlayerDWin.Visibility = Visibility.Visible;
                    PlayerDStay.Visibility = Visibility.Collapsed;
                }



                
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


                playerScore.Sort();
                playerScore.Reverse();

                newRoundButton.Visibility = Visibility.Visible;


                AskBox.Text = "Round Over!!!";
               
                PlacementAcontinue.Visibility = Visibility.Visible;
                PlacementBcontinue.Visibility = Visibility.Visible;
                PlacementDcontinue.Visibility = Visibility.Visible;
                PlacementEcontinue.Visibility = Visibility.Visible;


                if (players[0].hasWon == true || players[0].score == playerScore[0] && players[0].isStaying == true)
                {
                    PlayerAWin.Visibility = Visibility.Visible;
                    PlayerAStay.Visibility = Visibility.Collapsed;

                }
                if (players[1].hasWon == true || players[1].score == playerScore[0] && players[1].isStaying == true)
                {
                    PlayerBWin.Visibility = Visibility.Visible;
                    PlayerBStay.Visibility = Visibility.Collapsed;
                }
                if (players[2].hasWon == true || players[2].score == playerScore[0] && players[2].isStaying == true)
                {
                    PlayerDWin.Visibility = Visibility.Visible;
                    PlayerDStay.Visibility = Visibility.Collapsed;
                }
                if (players[3].hasWon == true || players[3].score == playerScore[0] && players[3].isStaying == true )
                {
                    PlayerEWin.Visibility = Visibility.Visible;
                    PlayerEStay.Visibility = Visibility.Collapsed;

                }

            }








        }

        // CALCULATES SCORE IN HAND FOR EACH PLAYER BASED ON CARD VALUE++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
       
        
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


       

        // PLACEMENT A GAMEPLAY BOXES HERE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private void PlayerAHitButton_Click(object sender, RoutedEventArgs e)
        {

          


            if (numberOfPlayers == 4)
            {
                
                Card card = deck.DealTopCard();
                 
                

                players[0].cardsInHand.Add(card);

                

                players[0].score = ScoreHand(players[0]);               
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                AskBox.Text = "Would you like another card, " + players[0].name + " ?";
               
                PlayerAPassButton.Visibility = Visibility.Collapsed;

                // Come back and do visibility of winn, bust stay icons

                if (players[0].score == 21)
                {
                    twentyOneObtained++;
                    players[0].hasWon = true;
                    playerScore.Add(players[0].score);
                    turn++;

                    PlayerAHitButton.Visibility = Visibility.Collapsed;
                    PlayerAStayButton.Visibility = Visibility.Collapsed;
                    PlayerAPassButton.Visibility = Visibility.Collapsed;
                    placementAwin = true;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    GameTurn();


                }
                if (players[0].score > 21)
                {
                    players[0].isActive = false;
                    players[0].isBust = true;
                    busted++;
                    placementAbust = true;
                    turn++;
                    players[0].score = 0;
                    playerScore.Add(players[0].score);

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
                playerScore.Add(players[0].score);
                turn++;
                placementAstay = true;
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
                playerScore.Add(players[0].score);
                turn++;
                GameTurn();
                placementApass = true;

            }

        }






        // PLACENMENT B GAMEPLAY BOXES HERE++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
       
        private void PlayerBHitButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 2)
            {
                Card card = deck.DealTopCard();
                players[0].cardsInHand.Add(card);
                players[0].score = ScoreHand(players[0]);             
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                AskBox.Text = "Would you like another card, " + players[0].name + " ?";
                PlayerBPassButton.Visibility = Visibility.Collapsed;


                if (players[0].score == 21)
                {
                    twentyOneObtained++;
                    players[0].hasWon = true;
                    playerScore.Add(players[0].score);
                    turn++;

                    //Insert Win Visual Here


                    PlayerBHitButton.Visibility = Visibility.Collapsed;
                    PlayerBStayButton.Visibility = Visibility.Collapsed;
                    PlayerBPassButton.Visibility = Visibility.Collapsed;
                    placementBwin = true;
                    Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " + players[0].score + "/21";
                    GameTurn();


                }
                if (players[0].score > 21)
                {
                    players[0].isActive = false;
                    players[0].isBust = true;
                    busted++;
                    placementBbust = true;
                    //Insert Busted Visual Here


                    turn++;
                    players[0].score = 0;
                    playerScore.Add(players[0].score);

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
                    placementBwin = true;
                    playerScore.Add(players[0].score);

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
                    placementBbust = true;

                    // Insert Busted Visual here

                    turn++;
                    players[0].score = 0;
                    playerScore.Add(players[0].score);

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
                AskBox.Text = "Would you like another card, " + players[1].name + " ?";
                PlayerBPassButton.Visibility = Visibility.Collapsed;

                if (players[1].score == 21)
                {
                    twentyOneObtained++;
                    players[1].hasWon = true;
                    turn++;
                    placementBwin = true;
                    playerScore.Add(players[1].score);

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
                    placementBbust = true;

                    turn++;
                    players[1].score = 0;
                    playerScore.Add(players[1].score);

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
                playerScore.Add(players[0].score);
                placementBstay = true;
                GameTurn();
                // Add stay  graphic visibility here

            }
            if (numberOfPlayers == 3)
            {
                players[0].isStaying = true;
                players[0].isActive = false;
                turn++;
                playerScore.Add(players[0].score);
                placementBstay = true;
                GameTurn();
                // Add stay  graphic visibility here

            }
            if (numberOfPlayers == 4)
            {
                players[1].isStaying = true;
                players[1].isActive = false;
                turn++;
                playerScore.Add(players[1].score);
                placementBstay = true;
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
                playerScore.Add(players[0].score);
                turn++;
                placementBpass = true;
                GameTurn();

            }
            if (numberOfPlayers == 3)
            {
                Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " is sitting out this round!";
                players[0].score = 0;
                playerScore.Add(players[0].score);
                turn++;
                placementBpass = true;
                GameTurn();

            }
            if (numberOfPlayers == 4)
            {
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " is sitting out this round!";
                players[1].score = 0;
                playerScore.Add(players[1].score);
                turn++;
                placementBpass = true;
                GameTurn();

            }

        }


        // PLACENMENT C GAMEPLAY BOXES HERE+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private void PlayerCHitButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 3)
            {
                Card card = deck.DealTopCard();
                players[1].cardsInHand.Add(card);
                players[1].score = ScoreHand(players[1]);
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                AskBox.Text = "Would you like another card, " + players[1].name + " ?";
                PlayerCPassButton.Visibility = Visibility.Collapsed;

                if (players[1].score == 21)
                {
                    twentyOneObtained++;
                    players[1].hasWon = true;
                    playerScore.Add(players[1].score);
                    turn++;
                    placementCwin = true;
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
                    placementCbust = true;

                    turn++;
                    players[1].score = 0;
                    playerScore.Add(players[1].score);

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
                playerScore.Add(players[1].score);
                turn++;
                placementCstay = true;
                GameTurn();

            }

        }

        private void PlayerCPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 3)
            {
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " is sitting out this round!";
                players[1].score = 0;
                playerScore.Add(players[1].score);
                turn++;
                placementCpass = true;
                GameTurn();


            }
        }


        // PLACEMENT D GAMEPLAY BOXES HERE+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void PlayerDHitButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 2)
            {
                Card card = deck.DealTopCard();
                players[1].cardsInHand.Add(card);
                players[1].score = ScoreHand(players[1]);
                Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " + players[1].score + "/21";
                AskBox.Text = "Would you like another card, " + players[1].name + " ?";
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                if (players[1].score == 21)
                {
                    twentyOneObtained++;
                    players[1].hasWon = true;
                    turn++;
                    playerScore.Add(players[1].score);
                    placementDwin = true;
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
                    placementDbust = true;
                    
                    turn++;
                    players[1].score = 0;
                    playerScore.Add(players[1].score);




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
                AskBox.Text = "Would you like another card, " + players[2].name + " ?";
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                if (players[2].score == 21)
                {
                    twentyOneObtained++;
                    players[2].hasWon = true;
                    turn++;
                    playerScore.Add(players[2].score);

                    placementDwin = true;


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
                    playerScore.Add(players[2].score);
                    placementDbust = true;

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
                AskBox.Text = "Would you like another card, " + players[2].name + " ?";
                PlayerDPassButton.Visibility = Visibility.Collapsed;

                if (players[2].score == 21)
                {
                    twentyOneObtained++;
                    players[2].hasWon = true;
                    turn++;
                    playerScore.Add(players[2].score);

                    placementDwin = true;


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
                    playerScore.Add(players[2].score);
                    placementDbust = true;

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
                playerScore.Add(players[1].score);
                turn++;
                placementDstay = true;
                GameTurn();

            }
            if(numberOfPlayers == 3)
            {
                players[2].isStaying = true;
                players[2].isActive = false;
                turn++;
                playerScore.Add(players[2].score);
                placementDstay = true;
                GameTurn();
            }
            if(numberOfPlayers == 4)
            {
                players[2].isStaying = true;
                players[2].isActive = false;
                turn++;
                playerScore.Add(players[2].score);
                placementDstay = true;
                GameTurn();

            }


        }

        private void PlayerDPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 3)
            {
                Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " is sitting out this round!";
                players[2].score = 0;
                playerScore.Add(players[2].score);
                turn++;
                placementDpass = true;
                GameTurn();

            }
            if(numberOfPlayers == 4)
            {
                Player_3_Score_and_Holder.Text = "Player 3 " + players[2].name + " is sitting out this round!";
                players[2].score = 0;
                playerScore.Add(players[2].score);
                turn++;
                placementDpass = true;
                GameTurn();

            }

        }

        // PLACEMENT E GAMEPLAY BOXES HERE+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void PlayerEHitButton_Click(object sender, RoutedEventArgs e)
        {
            if(numberOfPlayers == 4)
            {

                Card card = deck.DealTopCard();
                players[3].cardsInHand.Add(card);
                players[3].score = ScoreHand(players[3]);
                Player_4_Score_and_Holder.Text = "Player 4 " + players[3].name + " : score of " + players[3].score + "/21";
                AskBox.Text = "Would you like another card,  " + players[3].name + " ?";
                PlayerEPassButton.Visibility = Visibility.Collapsed;

                if (players[3].score == 21)
                {
                    twentyOneObtained++;
                    players[3].hasWon = true;
                    turn++;
                    placementEwin = true;
                    playerScore.Add(players[3].score);
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
                    playerScore.Add(players[3].score);
                    placementEbust = true;

                    //Insert Busted Visual Here

                    Player_4_Score_and_Holder.Text = "Player 4 " + players[3].name + " has busted!";
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
                playerScore.Add(players[3].score);
                turn++;
                placementEstay = true;
                GameTurn();

            }

        }

        private void PlayerEPassButton_Click(object sender, RoutedEventArgs e)
        {

            if (numberOfPlayers == 4)
            {
                Player_4_Score_and_Holder.Text = "Player 4 " + players[3].name + " is sitting out this round!";
                players[3].score = 0;
                playerScore.Add(players[3].score);
                turn++;
                placementEpass = true;
                GameTurn();

            }



        }
   

        //TRIGGERS FOR THE DIFFERENT IMAGES I MADE TO REFLECT EACH PLAYERS STATUS AT THE END OF A TURN +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void StatusImage()
        {

            if(placementAwin == true)
            {
                PlayerAWin.Visibility = Visibility.Visible;
            }
            if(placementAstay == true)
            {
                PlayerAStay.Visibility = Visibility.Visible;
            }
            if(placementAbust == true)
            {
                PlayerABust.Visibility = Visibility.Visible;
            }
            if(placementApass == true)
            {
                PlayerAPass.Visibility = Visibility.Visible;
            }
            if (placementBwin == true)
            {
                PlayerBWin.Visibility = Visibility.Visible;
            }
            if (placementBstay == true)
            {
                PlayerBStay.Visibility = Visibility.Visible;
            }
            if (placementBbust == true)
            {
                PlayerBBust.Visibility = Visibility.Visible;
            }
            if (placementBpass == true)
            {
                PlayerBPass.Visibility = Visibility.Visible;
            }
            if (placementCwin == true)
            {
                PlayerCWin.Visibility = Visibility.Visible;
            }
            if (placementCstay == true)
            {
                PlayerCStay.Visibility = Visibility.Visible;
            }
            if (placementCbust == true)
            {
                PlayerCBust.Visibility = Visibility.Visible;
            }
            if (placementCpass == true)
            {
                PlayerCPass.Visibility = Visibility.Visible;
            }
            if (placementDwin == true)
            {
                PlayerDWin.Visibility = Visibility.Visible;
            }
            if (placementDstay == true)
            {
                PlayerDStay.Visibility = Visibility.Visible;
            }
            if (placementDbust == true)
            {
                PlayerDBust.Visibility = Visibility.Visible;
            }
            if (placementDpass == true)
            {
                PlayerDPass.Visibility = Visibility.Visible;
            }
            if (placementEwin == true)
            {
                PlayerEWin.Visibility = Visibility.Visible;
            }
            if (placementEstay == true)
            {
                PlayerEStay.Visibility = Visibility.Visible;
            }
            if (placementEbust == true)
            {
                PlayerEBust.Visibility = Visibility.Visible;
            }
            if (placementEpass == true)
            {
                PlayerEPass.Visibility = Visibility.Visible;
            }

        }


        //NEW ROUND MECHANICS, RESETS ALL PLAYER VALUES, RESETS SCORE LIST, ASSIGNS PLAYERS TO SCORE BOXES AND CONTINUES GAME ROUNDS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      
        private void newRoundButton_Click(object sender, RoutedEventArgs e)
        {
            Deck deck = new Deck();


            turn = 0;

         placementAwin = false;
         placementBwin = false;
         placementCwin = false;
         placementDwin = false;
         placementEwin = false;

         placementAstay = false;
         placementBstay = false;
         placementCstay = false;
         placementDstay = false;
         placementEstay = false;

         placementAbust = false;
         placementBbust = false;
         placementCbust = false;
         placementDbust = false;
         placementEbust = false;

         placementApass = false;
         placementBpass = false;
         placementCpass = false;
         placementDpass = false;
         placementEpass = false;

            PlayerAWin.Visibility = Visibility.Hidden;
            PlayerBWin.Visibility = Visibility.Hidden;
            PlayerCWin.Visibility = Visibility.Hidden;  
            PlayerDWin.Visibility = Visibility.Hidden;
            PlayerEWin.Visibility = Visibility.Hidden;

            PlayerABust.Visibility = Visibility.Hidden;
            PlayerBBust.Visibility = Visibility.Hidden;
            PlayerCBust.Visibility = Visibility.Hidden;
            PlayerDBust.Visibility = Visibility.Hidden;
            PlayerEBust.Visibility = Visibility.Hidden;

            PlayerAPass.Visibility = Visibility.Hidden;
            PlayerBPass.Visibility = Visibility.Hidden;
            PlayerCPass.Visibility = Visibility.Hidden;
            PlayerDPass.Visibility = Visibility.Hidden;
            PlayerEPass.Visibility = Visibility.Hidden;

            PlayerAStay.Visibility = Visibility.Hidden;
            PlayerBStay.Visibility = Visibility.Hidden;
            PlayerCStay.Visibility = Visibility.Hidden;
            PlayerDStay.Visibility = Visibility.Hidden;
            PlayerEStay.Visibility = Visibility.Hidden;

            PlacementAcontinue.Visibility = Visibility.Hidden;
            PlacementBcontinue.Visibility = Visibility.Hidden;
            PlacementCcontinue.Visibility = Visibility.Hidden;
            PlacementDcontinue.Visibility = Visibility.Hidden;
            PlacementEcontinue.Visibility = Visibility.Hidden;

            

            foreach (Player player in players)
            {
                player.score = 0;
                player.cardsInHand.Clear();

                player.hasWon = false;
                player.isBust = false;
                player. isStaying = false;

            }

            playerScore.Clear();

            PlayerNamesNewRound();
            AssignPlayers();
          
            AskBox.Text ="" + players[0].name + " is now Player 1, are you ready for your first card?";
            GameTurn();
            newRoundButton.Visibility = Visibility.Hidden;

        }

        // PLAYER REMOVAL SYSTEM FOR AT THE END OF ROUND, BASED ON AMOUNT OF PEOPLE PLAYING AND PLAYER PLACEMENT TO REMOVE AND SHIFT PLAYER NUMBERS++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private void PlacementAcontinue_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 4)
            {
                players.Remove(players[0]);
                numberOfPlayers--;
                

                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";
            }
           else if (numberOfPlayers == 3)
            {
                players.Remove(players[0]);
                numberOfPlayers--;
               

                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";


            }
            else if (numberOfPlayers == 2)
            {
                //insert void reaction here
            }


            PlacementAcontinue.Visibility = Visibility.Hidden;


        }

        private void PlacementBcontinue_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 4)
            {
                players.Remove(players[1]);
                numberOfPlayers--;
                
                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";

            }
           else if(numberOfPlayers == 3)
            {
                players.Remove(players[0]);
                numberOfPlayers--;
                
                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";
            }
            else if(numberOfPlayers == 2)
            {
                // insert void player reaction
       
            }

            PlacementBcontinue.Visibility = Visibility.Hidden;


        }

        private void PlacementCcontinue_Click(object sender, RoutedEventArgs e)
        {
           
            if (numberOfPlayers == 3)
            {
                players.Remove(players[1]);
                numberOfPlayers--;
                

                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";


            }
            else if (numberOfPlayers == 2)
            {
                //insert void reaction here
            }

            PlacementCcontinue.Visibility = Visibility.Hidden;


        }

        private void PlacementDcontinue_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 4)
            {
                players.Remove(players[2]);
                numberOfPlayers--;
                

                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";
            }
           else if (numberOfPlayers == 3)
            {
                players.Remove(players[2]);
                numberOfPlayers--;
                

                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";


            }
            else if (numberOfPlayers == 2)
            {
                //insert void reaction here
            }

            PlacementDcontinue.Visibility = Visibility.Hidden;


        }

        private void PlacementEcontinue_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfPlayers == 4)
            {
                players.Remove(players[3]);
                numberOfPlayers--;
                

                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";
            }
            else if(numberOfPlayers == 3)
            {
                players.Remove(players[2]);
                numberOfPlayers--;
                

                Player_1_Score_and_Holder.Text = "";
                Player_2_Score_and_Holder.Text = "";
                Player_3_Score_and_Holder.Text = "";
                Player_4_Score_and_Holder.Text = "";


            }
           else if (numberOfPlayers == 2)
            {
                //insert void reaction here
            }

            PlacementEcontinue.Visibility = Visibility.Hidden;


        }
  
    
    
    
    
    
    
    
    
    }      
        
}
