using System;

namespace SlotMashineRefactor
{
    public static class SlotMachineUI
    {
        public static void ShowMoney(int money)
        {
            Console.WriteLine($"You have ${money}.");
        }

        public static int GetWager(int currentMoney)
        {
            while (true)
            {
                Console.Write("Enter your wager: $");
                if (int.TryParse(Console.ReadLine(), out int wager) && wager > 0 && wager <= currentMoney)
                {
                    return wager;
                }
                Console.WriteLine("Invalid wager. Please enter a valid amount.");
            }
        }

        public static int GetGameMode()
        {
            Console.WriteLine("Select mode:");
            Console.WriteLine("1. Middle Horizontal");
            Console.WriteLine("2. All Horizontal");
            Console.WriteLine("3. All Verticals");
            Console.WriteLine("4. Diagonals");
            Console.WriteLine("5. Jackpot");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int mode) && mode >= 1 && mode <= 5)
                {
                    return mode;
                }
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }

        public static void DisplayGrid(int[,] grid)
        {
            Console.WriteLine("Current grid:");
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    Console.Write(grid[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ShowWinnings(int winnings)
        {
            if (winnings > 0)
            {
                Console.WriteLine($"Congratulations! You won ${winnings}!");
            }
            else
            {
                Console.WriteLine("Sorry, you didn't win this time.");
            }
        }

        public static bool PlayAgain()
        {
            Console.Write("Do you want to play again? (yes / no): ");
            string response = Console.ReadLine()?.Trim().ToLower();
            return response == "yes";
        }

        public static void ShowGameEnd()
        {
            Console.WriteLine("Game ended. Thank you for playing!");
        }

    }
}
