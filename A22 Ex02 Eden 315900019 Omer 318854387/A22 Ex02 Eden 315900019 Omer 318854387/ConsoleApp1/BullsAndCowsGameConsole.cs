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
        private const ushort k_SequenceLenght = 4;
        private const char k_CorrectLocationSign = 'V';
        private const char k_AlmostCorrectLocationSign = 'X';
        private const char k_HiddenSign = '#';
        private const string k_TypeGuessStatement = "Please type your next guess <{0}> or 'Q' to quit";
        private const string k_PrePrintBoardStatusStatement = "current board status:";
        private const string k_AskForRestartStatement = "Would you like to start a new game? <Y/N>";
        private const string k_WinStatement = "You guessed after {0} steps!";
        private const string k_LostStatement = "No more guesses allowed. You Lost.";
        private const string k_InValidInputNotALetter = "No more guesses allowed. You Lost."; // I should change the text
        private const string k_InValidInputNotANumber = "No more guesses allowed. You Lost.";
        private const string k_InValidInputNubmerOutOfRange = "No more guesses allowed. You Lost.";
        private const string k_InValidInputLetterOutOfRange = "No more guesses allowed. You Lost.";

        private StringBuilder m_GameBuilder;
        private GameManager gameManager = new GameManager(0);

        private void checkIfAnswerIsCorrect()
        {
            gameManager.CheckIfCorrectAnswer();
            Console.WriteLine("");
        }

        private void printBoard()
        {
        }

        private void cleanScreen()
        {
            Screen.Clear();
        }

        private bool isInputValid(string input)
        {
            return false;
        }

        private void restart()
        {

        }

        private void closeConsole()
        {
            Environment.Exit(0);
        }
    }
}
