using System;
using System.Windows;

namespace Raceto21WPFVer
{
    

    public partial class MainWindow : Window
    {
       
        Game game = new Game();
        private int numberOfPlayers;
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

        
        public int enterButtonMain_Click(object sender, RoutedEventArgs e)
        {
                

            if (int.TryParse(howManyPlayers.Text, out numberOfPlayers) == false
                  || numberOfPlayers < 0 || numberOfPlayers > 4)
            {

                howManyPlayers.Text = "Please enter a valid number between 2 and 4";
                return numberOfPlayers = 0;

            }
            else
            {
                AskBox.Text = "There are " + numberOfPlayers + " people playing!";
                numberOfPlayers = int.Parse(howManyPlayers.Text);
                howManyPlayers.Visibility = Visibility.Hidden;
                enterButtonMain.Visibility = Visibility.Hidden;
                
                return numberOfPlayers;


            }
           


            
        }

        
        
       
    }
}
