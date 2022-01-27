using Engine.Enums;
using System;

namespace Engine
{
    public class GameManger
    {
        private readonly char[]  r_RandomSequenceForComparison;
        private readonly Round[] r_RoundsOfGame;
        private uint             m_CurrentRound = 0;
        Random                   m_randomAct = new Random();

        public GameManger(uint o_AmountOfRounds, uint o_AmountOfLettersInSequence)
        {
            r_RoundsOfGame = new Round[o_AmountOfRounds];
            r_RandomSequenceForComparison = createRandomSequence(o_AmountOfLettersInSequence);
        }

        public char[]       RandomSequence
        {
            get
            {
                return r_RandomSequenceForComparison;
            }
        }

        public uint         CurrentRound
        {
            get
            {
                return m_CurrentRound;
            }
        }

        public Round        CreateRound(char[] i_CurrentGuessFromUser)
        {
            Guess currentGuess = new Guess(i_CurrentGuessFromUser);
            Round newRound = new Round(currentGuess, currentGuess.createFeedbackFromGuess(r_RandomSequenceForComparison));

            r_RoundsOfGame[CurrentRound] = newRound;
            m_CurrentRound++;
            return newRound;
        }

        private char[]      createRandomSequence(uint i_AmountOfLettersInSequence)
        {
            char[] tempRandomSequenceForComparison = new char[i_AmountOfLettersInSequence];
            char randomChar;

            for (int i = 0; i < i_AmountOfLettersInSequence; i++)
            {
                do
                {
                    randomChar = (char)(m_randomAct.Next(Enum.GetNames(typeof(eGuessingOption)).Length) + 'A');
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
