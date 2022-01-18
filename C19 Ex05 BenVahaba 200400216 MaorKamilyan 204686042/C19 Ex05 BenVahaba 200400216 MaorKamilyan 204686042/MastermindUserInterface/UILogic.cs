namespace MastermindUserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class UILogic
    {
        private const int k_MinNumOfGuesses = 4;
        private const int k_MaxNumOfGuesses = 10;
        private const int k_GuessAmount = 4; // number of guesses in a row.
        private const char k_MinRangeChar = 'A';
        private const char k_MaxRangeChar = 'H';
        private NewGameForm m_StartForm;
        private BoardForm m_BoardForm;
        private MastermindLogicUnit.LogicUnit m_GameLogic;
        private int m_NumberOfGuesses; // number of attemps to win in the game.
        private int m_RowInBoard;
        private List<Color> m_ColorOptions; // options for choosing a background color for the guessed buttons.
        private char[] m_ScoresResults;

        private enum eGameState
        {
            PlayerWon,
            PlayerLost,
            InProgress
        }

        public void Run()
        {
            m_ColorOptions = new List<Color>
                                  {
                                      Color.Magenta,
                                      Color.MediumBlue,
                                      Color.Red,
                                      Color.Yellow,
                                      Color.Lime,
                                      Color.Maroon,
                                      Color.MediumTurquoise,
                                      Color.White
                                  };

            m_GameLogic = new MastermindLogicUnit.LogicUnit();
            m_StartForm = new NewGameForm();
            m_ScoresResults = new char[4];
            startAGame();
        }

        private void startAGame()
        {
            m_StartForm.ShowDialog();

            if (m_StartForm.FormClosedPressingTheStartButton == true)
            {
                m_NumberOfGuesses = m_StartForm.NumberOfChances;
                m_GameLogic.GenerateFourSecretLetters();
                m_BoardForm = new BoardForm(k_GuessAmount, m_NumberOfGuesses, m_ColorOptions);

                foreach (FinishedGuessButton button in m_BoardForm.ButtonsFinishGuess)
                {
                    button.Click += new EventHandler(finishedGuessButton_Clicked);
                }

                m_BoardForm.ShowDialog();
            }
        }

        private void finishedGuessButton_Clicked(object i_Sender, EventArgs i_EventArgs)
        {
            char[] guessedLetters = convertColorArrToCharArr(m_BoardForm.GetRowInGuessButtonBoard(m_RowInBoard));
            eGameState gameState = (eGameState)m_GameLogic.FillBoard(m_ScoresResults, guessedLetters, m_RowInBoard, m_NumberOfGuesses);

            Color[,] colorResults = new Color[k_GuessAmount / 2, k_GuessAmount / 2];
            colorResults = convertScoresCharArrayResultsToColorArrayResults(m_ScoresResults);

            m_BoardForm.SetButtonsGuessColor(m_RowInBoard, colorResults);
            m_BoardForm.EnableDisableARowInBoard(false, m_RowInBoard);
            ++m_RowInBoard;
            if (m_RowInBoard != m_NumberOfGuesses && gameState != eGameState.PlayerWon)
            {
                m_BoardForm.EnableDisableARowInBoard(true, m_RowInBoard);
            }
            else
            {
                m_BoardForm.SetButtonsSecretGuessColor(convertCharArrayToColorsArray(m_GameLogic.SecretLetters));
            }
        }

        private char[] convertColorArrToCharArr(Color[] i_ColorsToArr)
        {
            char[] guessedLetters = new char[i_ColorsToArr.Length];

            for (int i = 0; i < i_ColorsToArr.Length; i++)
            {
                guessedLetters[i] = convertColorToChar(i_ColorsToArr[i]);
            }

            return guessedLetters;
        }

        private char convertColorToChar(Color i_ColorToConvert)
        {
            return (char)(m_ColorOptions.IndexOf(i_ColorToConvert) + 'A');
        }

        private Color[] convertCharArrayToColorsArray(char[] i_CharsToConvert)
        {
            Color[] convertedColors = new Color[i_CharsToConvert.Length];

            for (int i = 0; i < i_CharsToConvert.Length; i++)
            {
                convertedColors[i] = convertCharToColor(i_CharsToConvert[i]);
            }

            return convertedColors;
        }

        private Color convertCharToColor(char i_CharToConvert)
        {
            return m_ColorOptions[i_CharToConvert - 'A'];
        }

        private Color[,] convertScoresCharArrayResultsToColorArrayResults(char[] i_ScoresCharArrayToConvert)
        {
            int matrixResultSize = k_GuessAmount / 2;
            Color[,] colorResults = new Color[matrixResultSize, matrixResultSize];

            int indexOfCharResultArray = 0;

            for (int i = 0; i < matrixResultSize; i++)
            {
                for (int j = 0; j < matrixResultSize; j++)
                {
                    if (indexOfCharResultArray < i_ScoresCharArrayToConvert.Length)
                    {
                        colorResults[i, j] = convertResultCharToColor(i_ScoresCharArrayToConvert[indexOfCharResultArray]);
                        indexOfCharResultArray++;
                    }
                }
            }

            return colorResults;
        }

        // $G$ NTT-999 (-5) You should have used enumeration here
        private Color convertResultCharToColor(char i_ResultsCharToConvert)
        {
            Color resultColor = Color.Empty;

            switch (i_ResultsCharToConvert)
            {
                case 'V':
                    resultColor = Color.Black;
                    break;
                case 'X':
                    resultColor = Color.Yellow;
                    break;
            }

            return resultColor;
        }
    }
}
