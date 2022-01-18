using System;

namespace MastermindLogicUnit
{
    public class LogicUnit
    {
        private const int k_MaxLength = 4;
        private const int k_ValidRangeLetters = 8;
        private const int k_MaxVScore = 4;
        private const int k_MaxXScore = 4;
        private static char[] m_SecretLetters;
        private char[] m_GuessedLetters;


        // $G$ NTT-999 (-5) This kind of field should be readonly.
        private Random m_RandValidLetter = new Random();
        private int m_VScore;
        private int m_XScore;

        public LogicUnit()
        {
            m_SecretLetters = new char[k_MaxLength];
            m_RandValidLetter = new Random();
        }

        public enum eGameState
        {
            PlayerWon,
            PlayerLost,
            InProgress
        }

        public char[] GuessedLetters
        {
            get { return m_GuessedLetters; }
            set { m_GuessedLetters = value; }
        }

        public char[] SecretLetters
        {
            get { return m_SecretLetters; }
        }

        public int VScore
        {
            get { return m_VScore; }
        }

        public int XScore
        {
            get { return m_XScore; }
        }

        public bool IsGameOver()
        {
            bool m = XScore.Equals(k_MaxXScore);
            return m;
        }

        // $G$ NTT-999 (-5) You should have used constants here
        public eGameState FillBoard(char[] i_Results, char[] i_GuessedLetters, int i_NumberOfAttempts, int i_Row)
        {
            eGameState gameState;
            m_GuessedLetters = i_GuessedLetters;
            NumberOfLettersFoundInPosition();
            NumberOfUnitqueLettersFound();
            int start;

            // second add V scores to the board.
            for (start = 0; start < VScore; start++)
            {
                i_Results[start] = 'V';
            }

            // third add X scores to the board
            for (start = VScore; start < VScore + XScore; start++)
            {
                i_Results[start] = 'X';
            }

            // for the rest padding with spaces.
            for (start = VScore + XScore; start < 4; start++)
            {
                i_Results[start] = ' ';
            }

            gameState = getGameState(i_NumberOfAttempts, i_Row);

            return gameState;
        }

        public void GenerateFourSecretLetters()
        {
            for (int i = 0; i < k_MaxLength; i++)
            {
                m_SecretLetters[i] = generateASecretLetter();
            }
        }

        public void NumberOfLettersFoundInPosition()
        {
            m_VScore = 0;

            for (int i = 0; i < m_SecretLetters.Length; i++)
            {
                if (m_GuessedLetters[i] == m_SecretLetters[i])
                {
                    m_VScore++;
                }
            }
        }

        public void NumberOfUnitqueLettersFound()
        {
            m_XScore = 0;

            for (int i = 0; i < m_GuessedLetters.Length; i++)
            {
                for (int j = 0; j < m_SecretLetters.Length; j++)
                {
                    // if the letter was found and it's not in the same position
                    if ((i != j) && (m_GuessedLetters[i] == m_SecretLetters[j]))
                    {
                        m_XScore++;
                    }
                }
            }
        }

        private char generateASecretLetter()
        {
            char randomValidLetter;

            do
            {
                randomValidLetter = (char)(m_RandValidLetter.Next(k_ValidRangeLetters) + 'A');
            }
            while (isUsedLetter(randomValidLetter));

            return randomValidLetter;
        }
       
        private bool isUsedLetter(char i_CheckIfLetterIsUsed)
        {
            bool letterIsUsed = false;

            for (int i = 0; i < m_SecretLetters.Length; i++)
            {
                if(m_SecretLetters[i] == i_CheckIfLetterIsUsed)
                {
                    letterIsUsed = true;
                }
            }

            return letterIsUsed;
        }

        private eGameState getGameState(int i_NumberOfAttempts, int i_Row)
        {
            eGameState gameState;

            if (VScore == k_MaxVScore)
            {
                gameState = eGameState.PlayerWon;
            }
            else if (i_Row == i_NumberOfAttempts - 1)
            {
                gameState = eGameState.PlayerLost;
            }
            else
            {
                gameState = eGameState.InProgress;
            }

            return gameState;
        }
    }
}
