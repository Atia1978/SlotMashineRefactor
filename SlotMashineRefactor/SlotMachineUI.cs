using System;

namespace SlotMashineRefactor
{
    public static class SlotMachineUI
    {
        public const string PlayAgainYes = "yes";
        public const string PlayAgainNo = "no";
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

        public static GameMode GetGameMode()
        {
            Console.WriteLine("Select mode:");
            Console.WriteLine($"{(int)GameMode.MiddleHorizontal}.Middle Horizontal");
            Console.WriteLine($"{(int)GameMode.AllHorizontal}. All Horizontal");
            Console.WriteLine($"{(int)GameMode.AllVerticals}. All Verticals");
            Console.WriteLine($"{(int)GameMode.Diagonals}. Diagonals");
            Console.WriteLine($"{(int)GameMode.Jackpot}. Jackpot");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int mode) && Enum.IsDefined(typeof(GameMode),mode))
                {
                    return (GameMode)mode;
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

        public static void DisplayWinnings(int winnings)
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
        public static (int rows, int cols) GetGridDimensions()
        {
            Console.WriteLine("Enter the number of rows:");
            int rows = int.Parse(Console.ReadLine() ?? "3");

            Console.WriteLine("Enter the number of columns:");
            int cols = int.Parse(Console.ReadLine() ?? "3");

            return (rows, cols);
        }

        public static bool PlayAgain()
        {
            Console.Write("Do you want to play again? (yes / no): ");
            string response = Console.ReadLine()?.Trim().ToLower();
            return response == PlayAgainYes;
        }

        public static void ShowGameEnd()
        {
            Console.WriteLine("Game ended. Thank you for playing!");
        }

    }
}
