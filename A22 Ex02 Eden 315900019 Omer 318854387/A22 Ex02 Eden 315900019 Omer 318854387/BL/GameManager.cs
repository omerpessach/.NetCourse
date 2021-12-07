using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class GameManager
    {
        private Round[] m_RoundsOfGame = null;
        private const ushort m_AmountOfLettersInSequence = 4;
        private readonly char[] m_RandomSequenceForComparison;

        public enum eGuessingOption
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
        }

        public char[] RandomSequenceForComparison
        {
            get { return m_RandomSequenceForComparison; }
        }

        public GameManager(uint i_AmountOfRounds)
        {
            m_RoundsOfGame = new Round[i_AmountOfRounds];
            m_RandomSequenceForComparison = createRandomSequence();
        }

        private char[] createRandomSequence() //should it be static?
        {
            Random randomAct = new Random();
            char randomChar;
            char[] tempRandomSequenceForComparison = new char[m_AmountOfLettersInSequence];

            for (int i = 0; i < m_AmountOfLettersInSequence; i++)
            {
                do
                {
                    randomChar = (char)(randomAct.Next(Enum.GetNames(typeof(eGuessingOption)).Length) + 'A');
                }
                while (checkIfExistsInSequence(randomChar, tempRandomSequenceForComparison));

                tempRandomSequenceForComparison[i] = randomChar;
            }

            return tempRandomSequenceForComparison;
        }

        private bool checkIfExistsInSequence(char i_currentCharFromRandom, char[] i_currentSequence)
        {
            bool isLetterExists = false;

            foreach(char currentLetter in i_currentSequence)
            {
                if(i_currentCharFromRandom == currentLetter)
                {
                    isLetterExists = true;
                }
            }

            return isLetterExists;
        }


    }

}
