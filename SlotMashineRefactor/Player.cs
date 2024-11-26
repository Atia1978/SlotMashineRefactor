using System;

namespace SlotMashineRefactor
{
    public static class Player
    {
        public static int Money { get; private set; }
        public static void InitializeMoney(int StartingMoney)

        {
            if (StartingMoney < 0)
            {
                throw new ArgumentException("Starting money cannot be negative.");

            }

            Money = StartingMoney;
        }
        public static void DeductWager(int wager)
        {
            if (wager > Money)
            {
                throw new InvalidOperationException("Insufficient funds .");

            }

            Money -= wager;
        }

        public static void AddWinnings(int winnings)
        {
            if (winnings > 0)
            {
                throw new ArgumentException("Winnings cannot be negative.");
            }
            Money += winnings;
        }
    }
}
