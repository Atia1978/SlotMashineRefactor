using System;

namespace SlotMashineRefactor
{
    public static class SlotMachineUI
    {
        private const string PLAY_AGAIN_YES = "y";
        private const string PLAY_AGAIN_NO = "n";
        private const int MIN_VALUE = 3;
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
        public static void DisplayGameModes()
        {
            foreach (GameMode mode in Enum.GetValues(typeof(GameMode)))
            {
                Console.WriteLine($"{(int)mode}. {FormatGameMode(mode)}");
            }
        }
        private static string FormatGameMode(GameMode mode)
        {
            return mode.ToString().Replace("MiddleHorizontal", "Middle Horizontal")
                           .Replace("AllVerticals", "All Verticals");
        }

        public static GameMode GetGameMode()
        {
            Console.WriteLine("Select mode:");
            DisplayGameModes();

            while (true)

            {
                int maxMode = Enum.GetValues(typeof(GameMode)).Cast<int>().Max();
                if (int.TryParse(Console.ReadLine(), out int mode) && Enum.IsDefined(typeof(GameMode),mode))
                {
                    return (GameMode)mode;
                }
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {maxMode}");
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
            Console.WriteLine($"Enter the number of rows:");
            int rows = GetvalidDimension();

            Console.WriteLine("Enter the number of columns:");
            int cols = GetvalidDimension();

            return (rows, cols);
        }
        public static int GetvalidDimension()
        {
            while (true)
            {
                String input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"Input is empty. Defaulting to {MIN_VALUE}.");
                   
                    return MIN_VALUE;
                }
                if (int.TryParse(input, out int value) && value > 0)
                {
                    if (value >= MIN_VALUE)
                    {
                        return value;
                    }
                   if (value < MIN_VALUE)
                    {
                        Console.WriteLine($"Value must be at least {MIN_VALUE}. Defaulting to {MIN_VALUE}.");
                        return MIN_VALUE;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number:");

                }
            }
        }

        public static bool PlayAgain()
        {
            Console.Write("Do you want to play again? (Y / N): ");
            string response = Console.ReadLine()?.Trim().ToLower();
            return response == PLAY_AGAIN_YES;
        }

        public static void ShowGameEnd()
        {
            Console.WriteLine("Game ended. Thank you for playing!");
        }
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Slot Machine Game!");
        }

        public static void ShowGameOverMessage()
        {
            Console.WriteLine("You have no money left. Game over!");
        }
    }
}
