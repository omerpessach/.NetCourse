using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
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

    public class GameManger
    {
        private char[]  m_RandomSequenceForComparison;
        private Round[] m_RoundsOfGame = null;
        private uint    m_CurrentRound = 0;

        public GameManger(uint i_AmountOfRounds, uint i_AmountOfLettersInSequence)
        {
            m_RoundsOfGame = new Round[i_AmountOfRounds];
            m_RandomSequenceForComparison = createRandomSequence(i_AmountOfLettersInSequence);
        }

        private Round[] RoundsOfGame
        {
            get { return m_RoundsOfGame; }
        }

        public uint     CurrentRound
        {
            get
            {
                return m_CurrentRound;
            }
            private set
            {
                m_CurrentRound = value;
            }
        }

        private char[]  createRandomSequence(uint i_AmountOfLettersInSequence) //should it be static?
        {
            Random randomAct = new Random();
            char   randomChar;
            char[] tempRandomSequenceForComparison = new char[i_AmountOfLettersInSequence];

            for (int i = 0; i < i_AmountOfLettersInSequence; i++)
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

        private bool    checkIfExistsInSequence(char i_currentCharFromRandom, char[] i_currentSequence)
        {
            bool isLetterExists = false;

            foreach (char currentLetter in i_currentSequence)
            {
                if (i_currentCharFromRandom == currentLetter)
                {
                    isLetterExists = true;
                }
            }

            return isLetterExists;
        }

        public Round    CreateRound(char[] i_currentGuessFromUser)
        {
            Guess currentGuess = new Guess(i_currentGuessFromUser);
            Round newRound = new Round(currentGuess, currentGuess.createFeedbackFromGuess(m_RandomSequenceForComparison));

            CurrentRound++;
            RoundsOfGame[CurrentRound] = newRound;
            return newRound;
        }

    }
}
