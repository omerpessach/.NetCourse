namespace Engine
{
    public class Guess
    {
        private readonly char[] r_CurrentGuess;

        public Guess(char[] i_GuessFromUser)
        {
            r_CurrentGuess = i_GuessFromUser;
        }

        internal Feedback createFeedbackFromGuess(char[] o_RandomSequenceForComparison)
        {
            return new Feedback(amountOfBulls(o_RandomSequenceForComparison), amountOfCows(o_RandomSequenceForComparison));
        }

        private uint      amountOfBulls(char[] i_RandomSequenceForComparison)
        {
            uint amountOfBulls = 0;

            for (int i = 0; i < r_CurrentGuess.Length; i++)
            {
                if (r_CurrentGuess[i] == i_RandomSequenceForComparison[i])
                {
                    amountOfBulls++;
                }
            }

            return amountOfBulls;
        }

        private uint      amountOfCows(char[] i_RandomSequenceForComparison)
        {
            uint amountOfCows = 0;

            for (int i = 0; i < r_CurrentGuess.Length; i++)
            {
                for (int j = 0; j < i_RandomSequenceForComparison.Length; j++)
                {
                    if ((i != j) && r_CurrentGuess[i] == i_RandomSequenceForComparison[j])
                    {
                        amountOfCows++;
                    }
                }
            }

            return amountOfCows;
        }
    }
}
