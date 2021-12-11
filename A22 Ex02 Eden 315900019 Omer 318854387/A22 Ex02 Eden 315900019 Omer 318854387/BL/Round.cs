namespace BL
{
    public class Round
    {
        private Guess    m_CurrentGuess;
        private Feedback m_CurrentFeedback;

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

        public Round(Guess i_currentGuss, Feedback i_currentFeedback)
        {
            m_CurrentFeedback = i_currentFeedback;
            m_CurrentGuess = i_currentGuss;
        }
    }
}
