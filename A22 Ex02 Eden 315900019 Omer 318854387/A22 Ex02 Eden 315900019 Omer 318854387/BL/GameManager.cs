using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class GameManager
    {
        private Round[]         m_RoundsOfGame = null;
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

        public GameManager(uint i_AmountOfRounds)
        {
            m_RoundsOfGame = new Round[i_AmountOfRounds];
            m_RandomSequenceForComparison = createRandomSequence();
        }

         private static char[] createRandomSequence()
        {
            Random randomAct = new Random();
            Array values = Enum.GetValues(typeof(eGuessingOption)); //it is ok ? should it be a diffrent way?
            char[] tempRandomSequenceForComparison = new char[m_AmountOfLettersInSequence];

            for (int i = 0; i< m_AmountOfLettersInSequence; i++)
            {
                int mIndex = randomAct.Next(0, Enum.GetNames(typeof(eGuessingOption)).Length);
                tempRandomSequenceForComparison[i] = (char)values.GetValue(mIndex);
            }

            return tempRandomSequenceForComparison;
        }
       

        
    }
 
}
