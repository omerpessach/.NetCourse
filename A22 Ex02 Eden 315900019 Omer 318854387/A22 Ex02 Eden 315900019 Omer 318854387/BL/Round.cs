using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    class Round
    {
        private Guess m_CurrentGuess = null ;
        private Feedback? m_CurrentFeedback = null;

        public Round(Guess i_currentGuss , Feedback i_currentFeedback)
        {
            m_CurrentFeedback = i_currentFeedback;
            m_CurrentGuess = i_currentGuss;
        }
    }
}
