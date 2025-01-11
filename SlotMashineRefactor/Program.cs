namespace SlotMashineRefactor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SlotMachineUI.ShowWelcomeMessage();

            SlotMachineUI.ShowGameModesExplanation();
            int playerInitialCredit = SlotMachineUI.GetInitialCredit();

            var player = new Player(playerInitialCredit);


            var (rows, cols) = SlotMachineUI.GetGridDimensions();

            while (player.Money > 0)
            {
                SlotMachineUI.ShowMoney(player.Money);

                int wager = SlotMachineUI.GetWager(player.Money);
                player.DeductWager(wager);

                GameMode gameMode = SlotMachineUI.GetGameMode();

                int[,] grid = SlotMachineLogic.GenerateGrid(rows, cols);
                SlotMachineUI.DisplayGrid(grid);

                int winnings = SlotMachineLogic.CalculateWinnings(wager, gameMode, grid);
                player.AddWinnings(winnings);

                SlotMachineUI.DisplayWinnings(winnings);
                SlotMachineUI.ShowMoney(player.Money);

                if (player.Money <= 0)
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
