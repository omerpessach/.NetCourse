﻿namespace Engine
{
    public class EngineBoard
    {
        private const char  k_CorrectLocationSign = 'V';
        private const char  k_AlmostCorrectLocationSign = 'X';
        private const char  k_BlankSign = ' ';
        private const int   k_MiddleOfBoard = 4;
        private const int   k_EndOfRow = 8;

        public void  AddRound(Round i_NewRound, int i_GuessNumber, char[,] i_MatrixBoard)
        {
            addGuess(i_NewRound.CurrentGuess, i_GuessNumber, i_MatrixBoard);
            addFeedback(i_NewRound.CurrentFeedback, i_GuessNumber, i_MatrixBoard);
        }

        private void addGuess(Guess i_CurrentGuess, int i_GuessNumber, char[,] i_MatrixBoard)
        {
            for (int startIndex = 0; startIndex < i_CurrentGuess.CurrentGuess.Length; startIndex++)
            {
                i_MatrixBoard[i_GuessNumber, startIndex] = i_CurrentGuess.CurrentGuess[startIndex];
            }
        }

        private void addFeedback(Feedback i_CurrentFeedback, int i_GuessNumber, char[,] i_MatrixBoard)
        {
            int amountOfV = i_CurrentFeedback.AmountOfV;
            int amountOfX = i_CurrentFeedback.AmountOfX;

            for (int i = k_MiddleOfBoard; i < amountOfV + k_MiddleOfBoard; i++)
            {
                i_MatrixBoard[i_GuessNumber, i] = k_CorrectLocationSign;
            }

            for (int i = k_MiddleOfBoard + amountOfV; i < k_MiddleOfBoard + amountOfV + amountOfX; i++)
            {
                i_MatrixBoard[i_GuessNumber, i] = k_AlmostCorrectLocationSign;
            }

            for (int i = k_MiddleOfBoard + amountOfV + amountOfX; i < k_EndOfRow; i++)
            {
                i_MatrixBoard[i_GuessNumber, i] = k_BlankSign;
            }
        }
    }
}
