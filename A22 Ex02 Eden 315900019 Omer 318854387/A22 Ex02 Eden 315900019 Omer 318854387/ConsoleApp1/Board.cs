using BL;
using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Board
    {
        private const string k_PrePrintBoardStatusStatement = "Current board status:";
        private const char   k_CorrectLocationSign = 'V';
        private const char   k_AlmostCorrectLocationSign = 'X';
        private const char   k_BlankSign = ' ';
        private const int    k_NumberOfCharsInRow = 8;
        private const int    k_MiddleOfBoard = 4;
        private const int    k_EndOfRow = 8;
        private uint         m_NumberOfGuesses;
        private char[,]      m_BoardGame;

        private uint NumberOfGuesses
        {
            get { return m_NumberOfGuesses; }
            set { m_NumberOfGuesses = value; }
        }

        public Board(uint i_NumberOfGuesses)
        {
            NumberOfGuesses = i_NumberOfGuesses;
            m_BoardGame = new char[i_NumberOfGuesses, k_NumberOfCharsInRow];
            buildBoard();
        }

        public void  PrintBoard()
        {
            cleanScreen();
            Console.WriteLine(k_PrePrintBoardStatusStatement);
            Console.WriteLine(string.Empty);
            buildBoard();
        }

        public void  AddRound(Round i_NewRound, int i_GuessNumber)
        {
            addGuess(i_NewRound.CurrentGuess, i_GuessNumber);
            addFeedback(i_NewRound.CurrentFeedback, i_GuessNumber);
        }

        private void addGuess(Guess i_CurrentGuess, int i_GuessNumber)
        {

            for (int startIndex = 0; startIndex < i_CurrentGuess.CurrentGuess.Length; startIndex++)
            {
                m_BoardGame[i_GuessNumber, startIndex] = i_CurrentGuess.CurrentGuess[startIndex];
            }

        }

        private void addFeedback(Feedback i_CurrentFeedback, int i_GuessNumber)
        {
            int amountOfV = i_CurrentFeedback.AmountOfV;
            int amountOfX = i_CurrentFeedback.AmountOfX;

            for (int i = k_MiddleOfBoard; i < amountOfV + k_MiddleOfBoard; i++)
            {
                m_BoardGame[i_GuessNumber, i] = k_CorrectLocationSign;
            }

            for (int i = k_MiddleOfBoard + amountOfV; i < k_MiddleOfBoard + amountOfV + amountOfX; i++)
            {
                m_BoardGame[i_GuessNumber, i] = k_AlmostCorrectLocationSign;
            }

            for(int i = k_MiddleOfBoard + amountOfV + amountOfX; i< k_EndOfRow; i++)
            {
                m_BoardGame[i_GuessNumber, i] = k_BlankSign;
            }

        }

        private void buildBoard()
        {
            StringBuilder m_GameBuilder = new StringBuilder();

            for (int i = 0; i < m_BoardGame.GetLength(0); i++)
            {
                m_GameBuilder.AppendFormat(
@"| {0} {1} {2} {3} | {4} {5} {6} {7} |
|=========|=========|
",
m_BoardGame[i, 0],
m_BoardGame[i, 1],
m_BoardGame[i, 2],
m_BoardGame[i, 3],
m_BoardGame[i, 4],
m_BoardGame[i, 5],
m_BoardGame[i, 6],
m_BoardGame[i, 7]);
            }

            string printOnScreen = string.Format(
@"|Pins:    |Result:  |
|=========|=========|
| # # # # |         |
|=========|=========|
{0}", m_GameBuilder.ToString());

            Console.WriteLine(printOnScreen);
        } 

        private void cleanScreen()
        {
            Screen.Clear();
        }





    }
}
