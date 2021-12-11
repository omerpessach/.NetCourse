namespace UI
{
    public class Program
    {
        public static void  Main(string[] args)
        {
            startGame();
        }

        private static void startGame()
        {
            BullsAndCowsGameConsole gameConsole = new BullsAndCowsGameConsole();
            gameConsole.StartNewGame();
        }
    }
}
