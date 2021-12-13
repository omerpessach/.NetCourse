using Engine.Enums;
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

        public Round        CreateRound(char[] i_CurrentGuessFromUser)
        {
            Guess currentGuess = new Guess(i_CurrentGuessFromUser);
            Round newRound = new Round(currentGuess, currentGuess.createFeedbackFromGuess(m_RandomSequenceForComparison));

            m_RoundsOfGame[CurrentRound] = newRound;
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

        private bool        checkIfExistsInSequence(char i_CurrentCharFromRandom, char[] i_CurrentSequence)
        {
            bool isLetterExists = false;

            for (int i = 0; i < i_CurrentSequence.Length && !isLetterExists; i++)
            {
                isLetterExists = i_CurrentSequence[i] == i_CurrentCharFromRandom;
            }

            return isLetterExists;
        }
    }
}
