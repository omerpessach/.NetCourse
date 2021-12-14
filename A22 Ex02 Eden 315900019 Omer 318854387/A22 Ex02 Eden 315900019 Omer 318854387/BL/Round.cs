namespace Engine
{
    public class Round
    {
        private readonly Guess    m_CurrentGuess;
        private readonly Feedback m_CurrentFeedback;

        public Round(Guess i_CurrentGuss, Feedback i_CurrentFeedback)
        {
            m_CurrentFeedback = i_CurrentFeedback;
            m_CurrentGuess = i_CurrentGuss;
        }

        public Guess     CurrentGuess
        {
            get
            {
                return m_CurrentGuess;
            }
        }

        public Feedback  CurrentFeedback
        {
            get
            {
                return m_CurrentFeedback;
            }
        }
    }
}
