using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class UIManager
    {
        private int m_GuessesNumber;
        private ChooseGuessesNumberForm m_ChooseGuessesNumberForm;
        private BoardForm m_BoardForm;

        public void StartGame()
        {
            m_ChooseGuessesNumberForm = new ChooseGuessesNumberForm();
            m_ChooseGuessesNumberForm.ShowDialog();
            if(m_ChooseGuessesNumberForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                m_GuessesNumber = m_ChooseGuessesNumberForm.GuessesNumber;
                m_BoardForm = new BoardForm();
            }
        }
    }
}
