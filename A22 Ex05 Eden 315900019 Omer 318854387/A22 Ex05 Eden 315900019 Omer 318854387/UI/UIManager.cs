using Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public class UIManager
    {
        private uint m_GuessesNumber;
        private const uint k_AmountOfColorsInSequence = 4;
        private int m_CurrentGuessNumber = 0;
        private ChooseGuessesNumberForm m_ChooseGuessesNumberForm = new ChooseGuessesNumberForm();
        private BoardForm m_BoardForm;
        private GameManger m_GameManager;
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
            m_ChooseGuessesNumberForm.ShowDialog();
            if(m_ChooseGuessesNumberForm.DialogResult == DialogResult.OK)
            {
                m_GuessesNumber = m_ChooseGuessesNumberForm.GuessesNumber;
                m_GameManager = new GameManger(m_GuessesNumber, k_AmountOfColorsInSequence);
                m_BoardForm = new BoardForm(k_AmountOfColorsInSequence, m_GuessesNumber, r_ColorOptions, Color.Black);
                m_BoardForm.EnableRowAndDisablePrevRowIfNecessary(m_CurrentGuessNumber);
                m_BoardForm.ShowDialog();
            }
        }

        private List<char> convertColorsToChars(List<Color> i_Colors)
        {
            List<char> guessedChars = i_Colors.ConvertAll(convertColorToChar);
            return guessedChars;
        }

        private char convertColorToChar(Color i_Color)
        {
            return (char)(r_ColorOptions.IndexOf(i_Color) + 'A');
        }

        private List<Color> convertCharsToColors(List<char> i_Chars)
        {
            List<Color> convertedColors = i_Chars.ConvertAll(convertCharToColor);
            return convertedColors;
        }

        private Color convertCharToColor(char i_Char)
        {
            return r_ColorOptions[i_Char - 'A'];
        }
    }
}
