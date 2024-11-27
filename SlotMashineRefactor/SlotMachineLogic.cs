using System;

namespace SlotMashineRefactor
{
    public static class SlotMachineLogic
    {

        private static readonly Random random = new Random();

        {
            int[,] grid = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = random.Next(SlotMachineGewinnElement.MIN_VALUE, SlotMachineGewinnElement.MAX_VALUE);
                }
            }
            return grid;
        }

        public static int CalculateWinnings(int wager, GameMode mode, int[,] grid)
        {
            bool win = mode switch
            {
                GameMode.MiddleHorizontal => CheckRowWin(grid.GetLength(0) / 2, grid),
                GameMode.AllHorizontal => CheckAllRows(grid),
                GameMode.AllVerticals => CheckAllColumns(grid),
                GameMode.Diagonals => CheckDiagonals(grid),
                GameMode.Jackpot => CheckJackpot(grid),
                _ => false
            };

            int multiplier = mode == GameMode.Jackpot ? SlotMachineGewinnElement.JACKPOT_MULTIPLIER : SlotMachineGewinnElement.WINNING_MULTIPLIER;
            return win ? wager * multiplier : 0;
        }
        public static bool CheckRowWin(int row, int[,] grid)
        {
            int first = grid[row, 0];
            if (first == 0)
            {
                return false;
            }

            for (int col = 1; col < grid.GetLength(1); col++)
            {
                if (grid[row, col] != first)
                {

                    return false;
                }
            }
            return true;
        }
        public static bool CheckColumnWin(int col, int[,] grid)
        {
            int first = grid[0, col];
            if (first == 0)
            {
                return false;
            }
            for (int row = 1; row < grid.GetLength(0); row++)
            {
                if (grid[row, col] != first)
        {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckAllRows(int[,] grid)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                if (CheckRowWin(row, grid))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckAllColumns(int[,] grid)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                if (CheckColumnWin(col, grid))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckDiagonals(int[,] grid)
        {
            int size = Math.Min(grid.GetLength(0), grid.GetLength(1));
            int firstPrimary = grid[0, 0];
            bool primaryWin = firstPrimary != 0;

            for (int i = 1; i < size; i++)
        {
                if (grid[i, i] != firstPrimary)
            {
                    primaryWin = false;
                    break;
                }

            }
            int firstSecondary = grid[0, size - 1];
            bool secondaryWin = firstSecondary != 0;
            for (int i = 1; i < size; i++)
                {
                if (grid[i, size - 1 - i] != firstSecondary)
                    {
                    secondaryWin = false;
                    break;
                }
            }

            return primaryWin || secondaryWin;
        }

        private static bool CheckJackpot(int[,] grid)
        {
            int firstElement = grid[0, 0];
            if (firstElement == 0)
        {
                return false;
            }
            foreach (int element in grid)
            {
                if (element != firstElement)
                {
                    return false;
                }
            }
            return true;

        }

    }
}
