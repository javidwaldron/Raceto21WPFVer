using System.Windows;

namespace Raceto21WPFVer
{
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void enterButtonMain_Click(object sender, RoutedEventArgs e)
        {

        }

        private void howManyPlayers_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            howManyPlayers.Text = "";
        }
    }
}
