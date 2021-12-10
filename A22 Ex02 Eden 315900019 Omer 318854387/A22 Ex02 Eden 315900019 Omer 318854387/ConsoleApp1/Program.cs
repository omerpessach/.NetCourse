using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
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
