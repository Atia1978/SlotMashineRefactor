namespace SlotMashineRefactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Player.InitializeMoney(100);
            Console.WriteLine("Welcome to the Slot Machine Game!");
            var (rows, cols) = SlotMachineUI.GetGridDimensions();

            while (Player.Money > 0)
            {
                SlotMachineUI.ShowMoney(Player.Money);

                int wager = SlotMachineUI.GetWager(Player.Money);
                Player.DeductWager(wager);

                GameMode gameMode = SlotMachineUI.GetGameMode();

                int[,] grid = SlotMachineLogic.GenerateGrid(rows,cols);
                SlotMachineUI.DisplayGrid(grid);

                int winnings = SlotMachineLogic.CalculateWinnings(wager,gameMode,grid);
                Player.AddWinnings(winnings);

                SlotMachineUI.DisplayWinnings(winnings);
                SlotMachineUI.ShowMoney(Player.Money);

                if (Player.Money <= 0)
                {
                    Console.WriteLine("You have no money left. Game over!");
                    break;
                }

                if (!SlotMachineUI.PlayAgain())
                {
                    SlotMachineUI.ShowGameEnd();
                    break;
                }
            }
        }
    }
}
