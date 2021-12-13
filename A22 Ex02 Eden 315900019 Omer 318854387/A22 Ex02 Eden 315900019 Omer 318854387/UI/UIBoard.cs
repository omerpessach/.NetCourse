using Ex02.ConsoleUtils;
using System;
using System.Text;

namespace UI
{
    public class UIBoard
    {
        private const uint      k_NumberOfCharsInRow = 8;
        private const string    k_PrePrintBoardStatusStatement = "Current board status:";
        private char[,]         m_MatrixBoard;

        public UIBoard(uint i_GuessesNumber)
        {
            m_MatrixBoard = new char[i_GuessesNumber, k_NumberOfCharsInRow];
            buildBoard();
        }

        public char[,]  MatrixBoard
        {
            get
            {
                return m_MatrixBoard;
            }
        }

        public void     PrintBoard()
        {
            cleanScreen();
            Console.WriteLine(k_PrePrintBoardStatusStatement);
            Console.WriteLine(string.Empty);
            buildBoard();
        }

        private void    buildBoard()
        {
            StringBuilder m_GameBuilder = new StringBuilder();

            for (int i = 0; i < m_MatrixBoard.GetLength(0); i++)
            {
                m_GameBuilder.AppendFormat(
@"| {0} {1} {2} {3} | {4} {5} {6} {7} |
|=========|=========|
",
m_MatrixBoard[i, 0],
m_MatrixBoard[i, 1],
m_MatrixBoard[i, 2],
m_MatrixBoard[i, 3],
m_MatrixBoard[i, 4],
m_MatrixBoard[i, 5],
m_MatrixBoard[i, 6],
m_MatrixBoard[i, 7]);
            }

            string printOnScreen = string.Format(
@"|Pins:    |Result:  |
|=========|=========|
| # # # # |         |
|=========|=========|
{0}", m_GameBuilder.ToString());

            Console.WriteLine(printOnScreen);
        }

        private void    cleanScreen()
        {
            Screen.Clear();
        }
    }
}
