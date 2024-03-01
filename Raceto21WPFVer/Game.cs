using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Security;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Raceto21WPFVer
{
    public class Game
    {

        public bool gameEnd = false;
        public bool roundEnd = false;
        public bool validPlayernumbers = false;
        Deck deck = new Deck();
        public int gamesplayed = 0;

        List<Player> players = new List<Player>();


        public void Setup()
        {

            //Gets number of players using jay's code/ rebuking if invalid format entered
            gameEnd = false;
            Console.WriteLine("How many players? (Please enter a valid whole number between 2 & 8): ");
            Console.WriteLine();
            string howManyPlayers = Console.ReadLine();
            int numberOfplayers;

            while (int.TryParse(howManyPlayers, out numberOfplayers) == false
                  || numberOfplayers < 1 || numberOfplayers > 8)
            {
                Console.WriteLine("Invalid number of players.");
                Console.Write("How many players?");
                howManyPlayers = Console.ReadLine();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("There are " + numberOfplayers + " playing");
            Console.WriteLine();

            // Getting number of players using int obtained 
            for (int i = 0; i < numberOfplayers; i++)
            {

                players.Add(new Player());
            }

            // Delete this comment when done for testing
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();

            //Getting player names
            foreach (Player player in players)
            {

                //Added + 1 because indexes start at 0
                Console.Write("Ok player " + (players.IndexOf(player) + 1) + " , what is your name? ");
                player.name = Console.ReadLine();

            }

            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");


            //Setting waging, while all players will begin with 100 not revealed or displayed for not betting people
            foreach (Player player in players)
            {
                while (player.askedAboutBetting == false)
                {
                    Console.WriteLine();
                    Console.Write("" + player.name + ", are you interested in placing a wager? Enter (Y) for yes or (N) for no : ");
                    string response = Console.ReadLine();

                    if (response.ToUpper().StartsWith("Y"))
                    {
                        player.bettingMoney = 100;
                        Console.WriteLine("" + player.name + ", is beginning with $" + player.bettingMoney + " of betting money!");
                        Console.WriteLine();
                        player.isBetting = true;
                        player.askedAboutBetting = true;

                    }
                    else if (response.ToUpper().StartsWith("N"))
                    {
                        Console.WriteLine("" + player.name + ", is just playing for fun!");
                        Console.WriteLine();
                        player.isBetting = false;
                        player.askedAboutBetting = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter (Y) for yes or (N) for no");
                    }
                }


            }

        }
        // Essentially where offer a card is, asked if they want to be dealt a card or three in a turn
        public void CoreGame()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            //Shuffle's cards
            deck.Shuffle();

            // Using turn ints to tell when everyone has gone
            int turn = 0;
            int busted = 0;
            int notactive = 0;
            int twentyOneObtained = 0;

            //Creating a list within a list for round by round play
            List<Player> currentPlayers = new List<Player>();
            
            //Creating list to store player scores, adds score if not 21 or over
            List<int> playerScore = new List<int>();

            //While the game isnt over
            while (roundEnd == false)
            {
                // For every player playing in game
                foreach (Player player in players)
                {
                    //To stop it asking players who said no to playing another round
                    if (player.isActive == true && player.isEliminated == false)
                    {
                        //Adding a smaller list of players for individual rounds
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine();
                        //Ask would you like to play
                        Console.Write("" + player.name + ", would you like to be dealt in? Enter (Y) for yes or (N) for no : ");
                        string response = Console.ReadLine();
                        while (player.askedInRound == false)
                        {
                            //If player says yes and wants a card
                            if (response.ToUpper().StartsWith("Y"))
                            {
                                //Adding a smaller list of players for individual rounds
                                currentPlayers.Add(player);
                                player.askedInRound = true;
                                
                                //if betting is true, sets up question of wager, making sure wager does not exceed current wallet
                                if(player.isBetting == true)
                                {
                                    
                                    int betAmount;

                                    Console.Write("How much would you like to bet this round?");
                                    Console.Write(" " + player.name + " has $" + player.bettingMoney + " in cash currently!: $");

                                    string bettingAnswer = Console.ReadLine();

                                    while (int.TryParse(bettingAnswer, out betAmount) == false || betAmount > player.bettingMoney)
                                    {
                                        Console.WriteLine("Invalid amount for bet.");
                                        Console.Write("How much would you like to bet this round? :$");
                                        bettingAnswer = Console.ReadLine();
                                        Console.Write("");
                                    }


                                    // Final Declare of money waged this round
                                    Console.WriteLine() ;
                                    Console.WriteLine("" + player.name + ", is betting $" + betAmount + " this round!");

                                    player.betAmount = betAmount;
                                }


                                // Goes through check to see if they want the one card or three card version
                                while (player.askedAboutThreeCard == false && player.isActive == true)
                                {

                                    Console.Write("Would you like one card or three? Enter (1) to be dealt one card at a time, or (3) for three at a time : ");
                                    string cardamountresponse = Console.ReadLine();

                                    // Sets game for player to be based on individual cards
                                    if (cardamountresponse == "1")
                                    {
                                        player.askedAboutThreeCard = true;

                                        //While player score is under 21 will deal card then keep asking if they want another until no
                                        while (player.score < 21 && player.isActive == true)
                                        {

                                            Console.Write("" + player.name + ", are you ready for a card? Enter (Y) for yes or (N) for no. : ");
                                            string anotherResponse = Console.ReadLine();

                                            //If player takes card is under 21 score and active all the code happens and will repeat until....
                                            if (anotherResponse.ToUpper().StartsWith("Y"))
                                            {
                                                Console.WriteLine();
                                                Card card = deck.DealTopCard();
                                                player.cardsInHand.Add(card);
                                                player.score = ScoreHand(player);
                                                ShowHand(player);
                                                Console.WriteLine();
                                                Console.WriteLine("" + player.name + "'s, score is now " + player.score + "/21.");
                                                

                                            }
                                            //Player syas no, ends turn and adds score to player score index
                                            else if (anotherResponse.ToUpper().StartsWith("N"))
                                            {
                                                player.isStaying = true;
                                                player.isActive = false;
                                                Console.WriteLine();
                                                Console.WriteLine("" + player.name + " is staying with a final score of " + player.score + "/21.");
                                                playerScore.Add(player.score);
                                                turn++;

                                            }
                                            //Reprimand for bad input
                                            else
                                            {
                                                Console.WriteLine("Please Enter either (Y) for yes or (N) for no : ");
                                            }

                                        }
                                        // When player score is equal to 21 they win automatically and the game ends ***Revist has won***
                                        if (player.score == 21)
                                        {
                                            twentyOneObtained++;
                                            player.hasWon = true;                                           
                                            turn++;

                                        }
                                        //If a player busts they lose automatically and turn ends
                                        if (player.score > 21)
                                        {
                                            player.isActive = false;
                                            player.isBust = true;
                                            busted++;
                                            Console.WriteLine();
                                            Console.WriteLine("" + player.name + " has busted, sorry!");
                                            turn++;
                                            player.score = 0;
                                            if (player.isBetting == true)
                                            {
                                                player.bettingMoney = player.bettingMoney - player.betAmount;
                                                Console.WriteLine("" + player.name + " has lost $" + player.betAmount + "in cash! Making their new cash total $" + player.bettingMoney + "");
                                            }
                                        }
                                    }
                                    // Sets game for player to be based on three cards
                                    else if (cardamountresponse == "3")
                                    {
                                        Console.WriteLine();
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Card card = deck.DealTopCard();

                                            player.cardsInHand.Add(card);
                                        }
                                        
                                        player.score = ScoreHand(player);
                                        ShowHand(player);
                                        Console.WriteLine();
                                        Console.WriteLine("" + player.name + "'s, score is now " + player.score + "/21.");
                                        

                                        player.askedAboutThreeCard = true;

                                        if (player.score == 21)
                                        {
                                            twentyOneObtained++;
                                            player.hasWon = true;                                          
                                            turn++;
                                            

                                        }
                                        //If a player busts they lose automatically and turn ends
                                        if (player.score > 21)
                                        {
                                            player.isActive = false;
                                            Console.WriteLine();
                                            Console.WriteLine("" + player.name + " has busted, sorry!");
                                            player.isBust = true;
                                            player.score = 0;
                                            turn++;
                                            busted++;
                                            if (player.isBetting == true)
                                            {
                                                player.bettingMoney = player.bettingMoney - player.betAmount;
                                                Console.WriteLine("" + player.name + " has lost $" + player.betAmount + "in cash! Making their new cash total $" + player.bettingMoney + "");
                                            }
                                        }
                                        //Automatically stays if neither 21 or busting met
                                        else
                                        {
                                            player.isActive = false;
                                            Console.WriteLine();
                                            Console.WriteLine("" + player.name + " is staying with a final score of " + player.score + "/21.");
                                            turn++;
                                            playerScore.Add(player.score);
                                        }

                                    }
                                    //Reprimands to Enter one of the two acceptable options
                                    else
                                    {
                                        player.askedAboutThreeCard = false;
                                        Console.WriteLine("Please Enter either 1 or 3");
                                        cardamountresponse = Console.ReadLine();
                                    }
                                }

                                //Player says no and sits out Round
                            }
                            else if (response.ToUpper().StartsWith("N"))
                            {

                                Console.WriteLine("" + player.name + " , is staying out this round.");
                                turn++;
                                player.askedInRound = true;
                                player.isActive = false;
                                notactive++;

                            }
                            //Reprimand for improper answer
                            else
                            {
                                Console.WriteLine("Please Enter either (Y) for yes or (N) for no");
                                response = Console.ReadLine();

                            }
                        }
                        // If every outcome has happened, adds an int. if it equals the total items in current player list, round ends
                        if (turn == currentPlayers.Count || currentPlayers.Count == 0)
                        {
                            
                            roundEnd = true;
                            
                        }

                    }

                }


            }
            //Round is up due to everyone having gone
            while (roundEnd == true)
            {

                // if everyone backs out immediately asks if you want to do a new game
                if (currentPlayers.Count == 0 || notactive == currentPlayers.Count)
                {
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine();
                    Console.Write("There is no one who wants to continue this round. Start a new game? Enter (Y) for yes or (N) for no : ");
                    string playAgainResponse = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");



                    //Not sure original logic here, think i didnt want deck to get corrupt with same name? Test later
                    if (playAgainResponse.ToUpper().StartsWith("Y"))
                    {
                        gamesplayed++;
                        string deckName = gamesplayed.ToString();
                        Console.WriteLine();
                        players.Clear();
                        roundEnd = false;

                        Setup();
                        CoreGame();


                    }
                    //Trying code to exit program I found online
                    else if (playAgainResponse.ToUpper().StartsWith("N"))
                    {
                        System.Environment.Exit(1);

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a (Y) for yes or (N) for no : ");
                    }
                }

                //Followed tutorials on sorting list, should declare winner first and descending by score
                players.Sort((left,right) =>left.score.CompareTo(right.score));
                players.Reverse();
               
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine();
                
                //Takes the final scores and sorts then ascendingly, then reverses it
                playerScore.Sort();
                playerScore.Reverse();
                
                
               
               // If busted is equal to total number of those currently playing, busted message plays
                if(busted == currentPlayers.Count)
                {
                    Console.WriteLine("Oh no, everyone busted!");
                    Console.WriteLine();
                }
               
                // Checks if someone has won and writes there name, if they havent and no one has one with twentyoneobtained varaible, writes name of person score equal to highest stored scores :)
                foreach (Player player in players)
                {
                    

                        if (player.hasWon && player.isEliminated == false)
                        {
                            Console.WriteLine("Congratulations, " + player.name + " has won this round!");
                            Console.WriteLine();
                            if(player.isBetting)
                        {
                            player.bettingMoney = player.bettingMoney + player.betAmount;
                            Console.WriteLine("" + player.name + " has won $" + player.betAmount + " in cash! Making their new cash total $" + player.bettingMoney + "!!!");

                        }

                    }
                        else if (!player.hasWon && player.isEliminated == false && player.isActive == false)
                        {
                            if (!player.isBust && twentyOneObtained == 0)
                            {
                                if (player.score == playerScore[0])
                                {
                                    Console.WriteLine("" + player.name + ", scored the highest this round, therefore is the winner!");
                                    Console.WriteLine();
                                if(player.isBetting == true)
                                {
                                    player.bettingMoney = player.bettingMoney + player.betAmount;
                                    Console.WriteLine("" + player.name + " has won $" + player.betAmount + " in cash! Making their new cash total $" + player.bettingMoney + "!!!");
                                }

                                }
                            else
                            {
                                Console.Write("");
                            }
                            
                            }
                            
                            if(player.isBetting== true && player.score!= playerScore[0] && !player.isBust && player.isEliminated == false)
                            {
                                player.bettingMoney = player.bettingMoney - player.betAmount;
                                Console.WriteLine();
                                Console.WriteLine("" + player.name + " has lost $" + player.betAmount + " in cash! Making their new cash total $" + player.bettingMoney + "!!!");
                            }
                           if(player.isBetting == true && player.bettingMoney <= 0 && player.isEliminated == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Sorry, " + player.name + ", you're out of cash, so you are out of the game!!!");
                            Console.WriteLine();
                            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                            currentPlayers.Remove(player);
                            player.isEliminated = true;

    }
                        Console.Write("");

                        }
                


                    turn = 0;

                    // Checks to see if playing for fun, if betting and out of money they are out!!!
                    if (!player.isBetting || player.isBetting == true && player.bettingMoney > 0 && player.isEliminated == false)
                    {
                        Console.WriteLine();
                        Console.Write("" + player.name + ", would you like to play another round?  (Y) for yes and (N) for no. : ");
                        string playagain = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");


                        //Do you want to play again, if yes adds back to the current players
                        if (playagain.ToUpper().StartsWith("Y"))
                        {

                            currentPlayers.Add(player);
                            player.isActive = true;
                            player.askedAboutThreeCard = false;
                            player.askedInRound = false;
                            player.isBust = false;
                            player.hasWon = false;

                            player.score = 0;
                            roundEnd = false;
                            player.cardsInHand.Clear();



                        }
                        //If you dont want to play again removes from current players/
                        else if (playagain.ToUpper().StartsWith("N"))
                        {

                            currentPlayers.Remove(player);
                            player.isActive = false;
                        }
                        //Reprimanding bad input
                        else
                        {
                            Console.Write("Please Enter (Y) for yes or (N) for no. : ");
                        }


                    }
                    else if(player.isBetting == true && player.bettingMoney == 0)
                    {
                        currentPlayers.Remove(player);
                    }

                }



                Deck deck = new Deck();
                CoreGame();

            }
            //Lifted from jays original code
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
            //Lifted from jays original code
            void ShowHand(Player player)
            {
                if (player.cardsInHand.Count > 0)
                {
                    Console.Write(player.name + " has: ");
                    foreach (Card card in player.cardsInHand)
                    {
                        Console.Write(card.name + " , ");

                    }


                }

            }






        }
    }
}












