using BL;
using Ex02.ConsoleUtils;
using System;
using System.Text;

namespace UI
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
        private char[,]      m_Board;

        public Board(uint i_NumberOfGuesses)
        {
            m_Board =           new char[i_NumberOfGuesses, k_NumberOfCharsInRow];
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
                m_Board[i_GuessNumber, startIndex] = i_CurrentGuess.CurrentGuess[startIndex];
            }
        }

        private void addFeedback(Feedback i_CurrentFeedback, int i_GuessNumber)
        {
            int amountOfV = i_CurrentFeedback.AmountOfV;
            int amountOfX = i_CurrentFeedback.AmountOfX;

            for (int i = k_MiddleOfBoard; i < amountOfV + k_MiddleOfBoard; i++)
            {
                m_Board[i_GuessNumber, i] = k_CorrectLocationSign;
            }

            for (int i = k_MiddleOfBoard + amountOfV; i < k_MiddleOfBoard + amountOfV + amountOfX; i++)
            {
                m_Board[i_GuessNumber, i] = k_AlmostCorrectLocationSign;
            }

            for (int i = k_MiddleOfBoard + amountOfV + amountOfX; i < k_EndOfRow; i++)
            {
                m_Board[i_GuessNumber, i] = k_BlankSign;
            }

        }

        private void buildBoard()
        {
            StringBuilder m_GameBuilder = new StringBuilder();

            for (int i = 0; i < m_Board.GetLength(0); i++)
            {
                m_GameBuilder.AppendFormat(
@"| {0} {1} {2} {3} | {4} {5} {6} {7} |
|=========|=========|
",
m_Board[i, 0],
m_Board[i, 1],
m_Board[i, 2],
m_Board[i, 3],
m_Board[i, 4],
m_Board[i, 5],
m_Board[i, 6],
m_Board[i, 7]);
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
