namespace Engine
{
    public class Round
    {
        private readonly Guess    r_CurrentGuess;
        private readonly Feedback r_CurrentFeedback;

        public Round(Guess i_CurrentGuss, Feedback i_CurrentFeedback)
        {
            r_CurrentFeedback = i_CurrentFeedback;
            r_CurrentGuess = i_CurrentGuss;
        }

        public Guess     CurrentGuess
        {
            get
            {
                return r_CurrentGuess;
            }
        }

        public Feedback  CurrentFeedback
        {
            get
            {
                return r_CurrentFeedback;
            }
        }
    }
}
