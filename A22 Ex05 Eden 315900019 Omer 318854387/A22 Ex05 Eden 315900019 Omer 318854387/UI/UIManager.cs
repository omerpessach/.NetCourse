using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public class UIManager
    {
        private int m_GuessesNumber;
        private ChooseGuessesNumberForm m_ChooseGuessesNumberForm;
        private BoardForm m_BoardForm;
        private readonly List<Color> r_ColorOptions = new List<Color>
                                  {
                                      Color.Magenta,
                                      Color.Red,
                                      Color.Lime,
                                      Color.MediumTurquoise,
                                      Color.MediumBlue,
                                      Color.Yellow,
                                      Color.Maroon,
                                      Color.White
                                  };

        public void StartGame()
        {
            m_ChooseGuessesNumberForm = new ChooseGuessesNumberForm();
            m_ChooseGuessesNumberForm.ShowDialog();
            if(m_ChooseGuessesNumberForm.DialogResult == DialogResult.OK)
            {
                m_GuessesNumber = m_ChooseGuessesNumberForm.GuessesNumber;
                m_BoardForm = new BoardForm(r_ColorOptions);
                m_BoardForm.ShowDialog();
            }
        }
    }
}
