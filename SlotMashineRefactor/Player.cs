using System;

namespace SlotMashineRefactor
{
    public  class Player
    {
        public  int Money { get; private set; }
        public  Player(int StartingMoney)

        {
            if (StartingMoney < 0)
            {
                throw new ArgumentException("Starting money cannot be negative.");

            }

            Money = StartingMoney;
        }
        public  void DeductWager(int wager)
        {
            if (wager > Money)
            {
                throw new InvalidOperationException("Insufficient funds .");

            }

            Money -= wager;
        }

        public  void AddWinnings(int winnings)
        {
            if (winnings < 0)
            {
                throw new ArgumentException("Winnings cannot be negative.");
            }
            Money += winnings;
        }
       
    }
}
