namespace SlotMashineRefactor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int initialCredit = Player.GetInitialCredit();
            Player.InitializeMoney(initialCredit);
            SlotMachineUI.ShowWelcomeMessage();
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
                    SlotMachineUI.ShowGameOverMessage();
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
