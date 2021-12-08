using BL;
using Ex02.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Board
    {
        private const string k_CorrectLocationSign = "V";
        private const string k_AlmostCorrectLocationSign = "X";
        private const string k_HiddenSign = " # ";
        private const string k_PrePrintBoardStatusStatement = "Current board status:";

        private StringBuilder m_IntroGameBuilder = new StringBuilder();
        private StringBuilder m_GameBuilder = new StringBuilder();
        private uint m_NumberOfGuesses;

        private uint NumberOfGuesses
        {
            get { return m_NumberOfGuesses; }
            set { m_NumberOfGuesses = value; }
        }

        public Board(uint i_NumberOfGuesses)
        {
            NumberOfGuesses = i_NumberOfGuesses;
            buildBoard();
        }

        public void PrintBoard()
        {
            cleanScreen();
            StringBuilder board = new StringBuilder(m_IntroGameBuilder.ToString());
            board.AppendLine(m_GameBuilder.ToString());
            Console.WriteLine(board);
        }

        public void AddRound(Round i_NewRound)
        {
            addGuess(i_NewRound.CurrentGuess);
            addFeedback(i_NewRound.CurrentFeedback);
        }

        private void addGuess(Guess i_CurrentGuess)
        {
            int startIndex = m_GameBuilder.ToString().IndexOf("         ");
            string guessConsoleFormat = " ";
            foreach (char item in i_CurrentGuess.CurrentGuess)
            {
                guessConsoleFormat += string.Format("{0} ", item);
            }

            m_GameBuilder.Replace("         ", guessConsoleFormat, startIndex, 9);
        }

        private void addFeedback(Feedback i_CurrentFeedback)
        {
            int startIndex = m_GameBuilder.ToString().IndexOf("       ");
            StringBuilder correctLocationSigns = new StringBuilder();
            StringBuilder almostCorrectLocationSigns = new StringBuilder();
            StringBuilder feedbackResult = new StringBuilder();

            for (int i = 0; i < i_CurrentFeedback.AmountOfV; i++)
            {
                correctLocationSigns.Append(string.Format("{0} ", k_CorrectLocationSign));
            }

            for (int i = 0; i < i_CurrentFeedback.AmountOfX; i++)
            {
                almostCorrectLocationSigns.Append(string.Format("{0} ", k_AlmostCorrectLocationSign));
            }

            int amountOfSpacedToAddInTheEnd = 7 - (i_CurrentFeedback.AmountOfV + i_CurrentFeedback.AmountOfX) * 2;

            feedbackResult.Append(correctLocationSigns);
            feedbackResult.Append(almostCorrectLocationSigns);
            if (amountOfSpacedToAddInTheEnd < 0)
            {
                feedbackResult.Remove(feedbackResult.Length - 1, 1);
            }
            else
            {
                feedbackResult.Append(' ', amountOfSpacedToAddInTheEnd);
            }

            m_GameBuilder.Replace("       ", feedbackResult.ToString(), startIndex, 7);
        }

        private void buildBoard()
        {
            m_IntroGameBuilder.AppendLine(k_PrePrintBoardStatusStatement);
            m_IntroGameBuilder.AppendLine("|Pins:    |Result:|");
            m_IntroGameBuilder.AppendLine("|=========|=======|");
            m_IntroGameBuilder.AppendLine("| # # # # |       |");
            m_IntroGameBuilder.AppendLine("|=========|=======|");
            for (int i = 0; i < NumberOfGuesses; i++)
            {
                m_GameBuilder.AppendLine("|         |       |");
                m_GameBuilder.AppendLine("|=========|=======|");
            }
        }

        private void cleanScreen()
        {
            Screen.Clear();
        }
    }
}
