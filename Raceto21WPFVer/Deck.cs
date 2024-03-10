using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; // currently only needed if we use alternate shuffle method

namespace Raceto21WPFVer
{

    public class Deck
    {
        List<Card> cardsForGame = new List<Card>();


        public Deck()
        {
            //Lifted from template, creates an array of card suits, creating an item for every 13 in each four suit
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("...........Please wait, building new deck ..........");
            Console.WriteLine();
            Console.WriteLine();

            string[] suits = { "S", "H", "C", "D" };

            for (int cardVal = 1; cardVal <= 13; cardVal++)
            {
                foreach (string cardSuit in suits)
                {
                    string cardName;
                    string cardLongName;

                    switch (cardVal)
                    {
                        case 1:
                            cardName = "A";
                            cardLongName = "Ace of ";
                            break;
                        case 11:
                            cardName = "J";
                            cardLongName = "Jack of ";
                            break;
                        case 12:
                            cardName = "Q";
                            cardLongName = "Queen of ";
                            break;
                        case 13:
                            cardName = "K";
                            cardLongName = "King of ";
                            break;
                        default:
                            cardName = cardVal.ToString();
                            cardLongName = cardVal.ToString() + " of ";
                            break;
                    }

                    switch (cardSuit)
                    {
                        case "S":
                            cardLongName += "Spades";
                            break;
                        case "H":
                            cardLongName += "Hearts";
                            break;
                        case "C":
                            cardLongName += "Clubs";
                            break;
                        case "D":
                            cardLongName += "Diamonds";
                            break;
                    }
                    cardsForGame.Add(new Card { ID = cardName + cardSuit, name = cardLongName });
                }
            }
        }


        public void Shuffle()
        {
            Console.WriteLine();
            Console.WriteLine("................Shuffling Cards................");
            Console.WriteLine();

            Random rng = new Random();

            // Randomizing the cards in deck
            for (int i = 0; i < cardsForGame.Count; i++)
            {
                Card tmp = cardsForGame[i];
                int swapindex = rng.Next(cardsForGame.Count);
                cardsForGame[i] = cardsForGame[swapindex];
                cardsForGame[swapindex] = tmp;
            }
        }


        //After Index has been jumbled takes card and removes from index and returns value to be plugged into player
        public Card DealTopCard()
        {
            Card card = cardsForGame[cardsForGame.Count - 1];
            cardsForGame.RemoveAt(cardsForGame.Count - 1);
            // Console.WriteLine("I'm giving you " + card);
            return card;
        }

       
       


    }
}

