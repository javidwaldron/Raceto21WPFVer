using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raceto21WPFVer
{
   class Player
    {

        public List<Card> cardsInHand = new List<Card>();
        public string name;
        public int score = 0;
        public int bettingMoney;
        public int betAmount;

        public bool isActive = true;
        public bool isBetting = false;
        public bool hasWon = false;
        public bool isBust = false;
        public bool isStaying = false;
        public bool askedAboutBetting = false;
        public bool askedAboutThreeCard = false;
        public bool dealOne = false;
        public bool dealThree = false;
        public bool askedInRound = false;
        public bool isEliminated = false; 
    }
}
