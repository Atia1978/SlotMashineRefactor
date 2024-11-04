using System;

namespace SlotMashineRefactor
{
    public class SlotMachineLogic
    {

        private static readonly Random random = new Random();

        public static int Money { get; private set; } = 100;

        public static void DeductWager(int wager) => Money -= wager;

        public static void AddWinnings(int winnings) => Money += winnings;

        public static int[,] GenerateGrid()

        {
            int[,] grid = new int[SlotMachineGewinnElement.GRID_SIZE, SlotMachineGewinnElement.GRID_SIZE];
            for (int row = 0; row < SlotMachineGewinnElement.GRID_SIZE; row++)
            {
                for (int col = 0; col < SlotMachineGewinnElement.GRID_SIZE; col++)
                {
                    grid[row, col] = random.Next(SlotMachineGewinnElement.MIN_VALUE, SlotMachineGewinnElement.MAX_VALUE);
                }
            }
            return grid;
        }

        public static int CalculateWinnings(int wager, int mode, int[,] grid)
        {
            bool win = mode switch
            {
                1 => IsRowWin(1, grid),
                2 => CheckAllRows(grid),
                3 => CheckAllColumns(grid),
                4 => CheckDiagonals(grid),
                5 => CheckJackpot(grid),
                _ => false
            };

            return win ? wager * (mode == 5 ? SlotMachineGewinnElement.JACKPOT_MULTIPLIER : SlotMachineGewinnElement.WINNING_MULTIPLIER) : 0;
        }

        private static bool IsRowWin(int row, int[,] grid)
        {
            return IsUniform(grid[row, 0], grid[row, 1], grid[row, 2]);
        }

        private static bool CheckAllRows(int[,] grid)
        {
            for (int row = 0; row < SlotMachineGewinnElement.GRID_SIZE; row++)
            {
                if (IsRowWin(row, grid))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckAllColumns(int[,] grid)
        {
            for (int col = 0; col < SlotMachineGewinnElement.GRID_SIZE; col++)
            {
                if (IsUniform(grid[0, col], grid[1, col], grid[2, col]))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckDiagonals(int[,] grid)
        {
            return IsUniform(grid[0, 0], grid[1, 1], grid[2, 2]) || IsUniform(grid[0, 2], grid[1, 1], grid[2, 0]);
        }

        private static bool CheckJackpot(int[,] grid)
        {
            int firstElement = grid[0, 0];
            for (int row = 0; row < SlotMachineGewinnElement.GRID_SIZE; row++)
            {
                for (int col = 0; col < SlotMachineGewinnElement.GRID_SIZE; col++)
                {
                    if (grid[row, col] != firstElement)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsUniform(params int[] values)
        {
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] != values[0])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
