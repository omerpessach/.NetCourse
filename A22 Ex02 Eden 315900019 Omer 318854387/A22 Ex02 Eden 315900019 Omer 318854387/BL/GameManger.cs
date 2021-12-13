using System;

namespace Engine
{
    public class GameManger
    {
        private char[]      m_RandomSequenceForComparison;
        private Round[]     m_RoundsOfGame = null;
        private uint        m_CurrentRound = 0;
        private EngineBoard m_EngineBoard;

        public GameManger(uint i_AmountOfRounds, uint i_AmountOfLettersInSequence)
        {
            m_EngineBoard =                 new EngineBoard();
            m_RoundsOfGame =                new Round[i_AmountOfRounds];
            m_RandomSequenceForComparison = createRandomSequence(i_AmountOfLettersInSequence);
        }

        public uint         CurrentRound
        {
            get
            {
                return m_CurrentRound;
            }
        }

        public EngineBoard  EngineBoard
        {
            get
            {
                return m_EngineBoard;
            }
        }

        private Round[]     RoundsOfGame
        {
            get
            {
                return m_RoundsOfGame;
            }
        }

        public Round        CreateRound(char[] i_currentGuessFromUser)
        {
            Guess currentGuess = new Guess(i_currentGuessFromUser);
            Round newRound = new Round(currentGuess, currentGuess.createFeedbackFromGuess(m_RandomSequenceForComparison));

            RoundsOfGame[CurrentRound] = newRound;
            m_CurrentRound++;
            
            return newRound;
        }

        private char[]      createRandomSequence(uint i_AmountOfLettersInSequence)
        {
            Random randomAct = new Random();
            char[] tempRandomSequenceForComparison = new char[i_AmountOfLettersInSequence];
            char randomChar;

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

        private bool        checkIfExistsInSequence(char i_currentCharFromRandom, char[] i_currentSequence)
        {
            bool isLetterExists = false;

            for (int i = 0; i < i_currentSequence.Length && !isLetterExists; i++)
            {
                isLetterExists = i_currentSequence[i] == i_currentCharFromRandom;
            }

            return isLetterExists;
        }
    }
}
