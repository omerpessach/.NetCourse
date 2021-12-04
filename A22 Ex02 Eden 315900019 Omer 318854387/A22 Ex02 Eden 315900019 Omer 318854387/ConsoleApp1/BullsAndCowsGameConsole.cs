using BL;
using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;

namespace ConsoleApp1
{
    public class BullsAndCowsGameConsole
    {
        private const int k_MinNumOfAttempts = 4;
        private const int k_MaxNumOfAttempts = 10;

        private StringBuilder m_GameBuilder;
        private GameManager gameManager = new GameManager(0, "");

        private void CheckIfAnswerIsCorrect()
        {
            gameManager.CheckIfCorrectAnswer();
            Console.WriteLine("");
        }

        private void PrintBoard()
        {
        }

        private void CleanScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }

        private bool IsInputValid(string input)
        {
            return false;
        }

        private void Restart()
        {

        }

        /// <summary>
        /// After 'Q'
        /// </summary>
        private void Exit()
        {

        }
    }
}
