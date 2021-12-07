using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Guess
    {
        public const uint k_AmountOfCharForGuess = 4;
        private char[] m_CurrentGuess = new char[k_AmountOfCharForGuess];

        public Guess(char[] i_GuessFromUser)
        {
            m_CurrentGuess = i_GuessFromUser;
        }

        private uint AmountOfBulls(char[] i_RandomSequenceForComparison)
        {
            uint amountOfBulls = 0;

            for (int i = 0; i < k_AmountOfCharForGuess; i++)
            {
                if (m_CurrentGuess[i] == i_RandomSequenceForComparison[i])
                {
                    amountOfBulls++;
                }
            }

            return amountOfBulls;
        }

        private uint AmountOfCows(char[] i_RandomSequenceForComparison)
        {
            uint amountOfCows = 0;

            for (int i = 0; i < k_AmountOfCharForGuess; i++)
            {
                for (int j = 0; j < i_RandomSequenceForComparison.Length; j++)
                {
                    if ((i != j) && m_CurrentGuess[i] == i_RandomSequenceForComparison[j])
                    {
                        amountOfCows++;
                    }
                }
            }

            return amountOfCows;
        }

        public Feedback createFeedbackFromGuess(char[] i_RandomSequenceForComparison)
        {
            return new Feedback(AmountOfBulls(i_RandomSequenceForComparison), AmountOfCows(i_RandomSequenceForComparison));
        }
    }
}
