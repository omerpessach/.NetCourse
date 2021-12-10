using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Round
    {
        private Guess    m_CurrentGuess;
        private Feedback m_CurrentFeedback;

        public Guess    CurrentGuess
        {
            get
            {
                return m_CurrentGuess;
            }
            private set
            {
                m_CurrentGuess = value;
            }
        }
        public Feedback CurrentFeedback
        {
            get
            {
                return m_CurrentFeedback;
            }
            private set
            {
                m_CurrentFeedback = value;
            }
        }

        public Round(Guess i_currentGuss, Feedback i_currentFeedback)
        {
            CurrentFeedback = i_currentFeedback;
            CurrentGuess = i_currentGuss;
        }
    }
}
