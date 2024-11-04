namespace SlotMashineRefactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Console.WriteLine("Welcome to the Slot Machine Game!");

            while (SlotMachineLogic.Money > 0)
            {
                SlotMachineUI.ShowMoney(SlotMachineLogic.Money);

                int wager = SlotMachineUI.GetWager(SlotMachineLogic.Money);
                SlotMachineLogic.DeductWager(wager);

                int gameMode = SlotMachineUI.GetGameMode();

                int[,] grid = SlotMachineLogic.GenerateGrid();
                SlotMachineUI.DisplayGrid(grid);

                int winnings = SlotMachineLogic.CalculateWinnings(wager, gameMode,grid);
                SlotMachineLogic.AddWinnings(winnings);

                SlotMachineUI.ShowWinnings(winnings);
                SlotMachineUI.ShowMoney(SlotMachineLogic.Money);

                if (!SlotMachineUI.PlayAgain())
                {
                    SlotMachineUI.ShowGameEnd();
                    break;
                }
            }
        }
    }
}
