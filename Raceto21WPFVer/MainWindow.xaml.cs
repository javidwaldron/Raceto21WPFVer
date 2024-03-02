using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;


namespace Raceto21WPFVer
{


    public partial class MainWindow : Window
    {

        Game game = new Game();

        public int numberOfPlayers;
        public int nameenteredcount;
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
           
                if(nameenteredcount ==  numberOfPlayers)
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
                        Player_1_Score_and_Holder.Text = "Player 1 " + players[0].name + " : score of " +players[0].score+ "/21";
                        Player_2_Score_and_Holder.Text = "Player 2 " + players[1].name + " : score of " +players[1].score+ "/21";
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
        }
    }
}
