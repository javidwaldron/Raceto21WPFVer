using System;
using System.Collections.Generic;
using System.Windows;


namespace Raceto21WPFVer
{
    

    public partial class MainWindow : Window
    {
       
        Game game = new Game();

        public int numberOfPlayers;
        List<Player> players = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            game.Setup(numberOfPlayers);  
        
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

         private void howManyPlayers_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            howManyPlayers.Text = "";
        }

        
        public void enterButtonMain_Click(object sender, RoutedEventArgs e)
        {
            
            //Taking only acceptable answers, limited player count to 2-4

            if (int.TryParse(howManyPlayers.Text, out numberOfPlayers) == false
                  || numberOfPlayers < 0 || numberOfPlayers > 4)
            {

                howManyPlayers.Text = "Please enter a valid number between 2 and 4";
                

            }
            //Removes Question Box and Enter Button 
            else
            {
                AskBox.Text = "There are " + numberOfPlayers + " people playing!";
                numberOfPlayers = int.Parse(howManyPlayers.Text);
                howManyPlayers.Visibility = Visibility.Hidden;
                enterButtonMain.Visibility = Visibility.Hidden;


                for (int i = 0; i < numberOfPlayers; i++)
                {

                    players.Add(new Player());
                }
               
                PlayerNames();



            }
               
        }
        public void PlayerNames()
        {

            switch (players.Count)
            {
                case 2:
                    PlayerBPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementB.Visibility = Visibility.Visible;
                    PlayerDPlacementDeck.Visibility = Visibility.Visible;
                    PlayerNamePlacementD.Visibility = Visibility.Visible;
                    break;
                case 3:
                    PlayerBPlacementDeck.Visibility= Visibility.Visible;
                    PlayerNamePlacementB.Visibility= Visibility.Visible;
                    PlayerCPlacementDeck.Visibility= Visibility.Visible;
                    PlayerNamePlacementC.Visibility= Visibility.Visible;
                    PlayerDPlacementDeck.Visibility= Visibility.Visible;
                    PlayerNamePlacementD.Visibility= Visibility.Visible;
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

        private void MenuItemNewGame_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
