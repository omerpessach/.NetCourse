using Engine;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public class UIManager
    {
        private const uint                       k_AmountOfColorsInSequence = 4;
        private uint                             m_GuessesNumber;
        private int                              m_CurrentGuessNumber = 0;
        private BoardForm                        m_BoardForm;
        private GameManger                       m_GameManager;
        private readonly ChooseGuessesNumberForm r_ChooseGuessesNumberForm = new ChooseGuessesNumberForm();
        private readonly Color                   r_ComputerSequenceButtonsColor = Color.Black;
        private readonly List<Color>             r_ColorOptions = new List<Color>
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

        public void         StartGame()
        {
            r_ChooseGuessesNumberForm.ShowDialog();
            if (r_ChooseGuessesNumberForm.DialogResult == DialogResult.OK)
            {
                m_GuessesNumber = r_ChooseGuessesNumberForm.GuessesNumber;
                m_GameManager = new GameManger(m_GuessesNumber, k_AmountOfColorsInSequence);
                m_BoardForm = new BoardForm(k_AmountOfColorsInSequence, m_GuessesNumber, r_ColorOptions, r_ComputerSequenceButtonsColor);
                m_BoardForm.GuessRows[0].ButtonCheckGuessClicked += uIManager_ButtonCheckGuessClicked;
                m_BoardForm.EnableRowAndDisablePrevRowIfNecessary(m_CurrentGuessNumber);
                m_BoardForm.ShowDialog();
            }
        }

        private void        uIManager_ButtonCheckGuessClicked(Color[] i_ColorToCheck)
        {
            m_BoardForm.GuessRows[m_CurrentGuessNumber].ButtonCheckGuessClicked -= uIManager_ButtonCheckGuessClicked;
            List<Color> colors = new List<Color>(i_ColorToCheck);
            List<char> colorsAsChars = convertColorsToChars(colors);
            Feedback feedback = m_GameManager.CreateRound(colorsAsChars.ToArray()).CurrentFeedback;
            Color[] result = new Color[k_AmountOfColorsInSequence];
            int resultIndex = 0;

            for (int AmountOfV = 0; AmountOfV < feedback.AmountOfV; AmountOfV++, resultIndex++)
            {
                result[resultIndex] = Color.Black;
            }

            for (int AmountOfX = 0; AmountOfX < feedback.AmountOfX; AmountOfX++, resultIndex++)
            {
                result[resultIndex] = Color.Yellow;
            }

            m_BoardForm.GuessRows[m_CurrentGuessNumber].ButtonsResultColor = result;
            m_CurrentGuessNumber++;
            if (m_CurrentGuessNumber != m_GuessesNumber && !hasTheUserWon(feedback))
            {
                m_BoardForm.GuessRows[m_CurrentGuessNumber].ButtonCheckGuessClicked += uIManager_ButtonCheckGuessClicked;
                m_BoardForm.EnableRowAndDisablePrevRowIfNecessary(m_CurrentGuessNumber);
            }
            else
            {
                m_BoardForm.ComputerHiddenButtonColor = convertCharsToColors(m_GameManager.RandomSequence);
                m_BoardForm.DisableRow(m_CurrentGuessNumber-1);
            }
        }

        private bool        hasTheUserWon(Feedback i_Feedback)
        {
            return i_Feedback.AmountOfV == k_AmountOfColorsInSequence;
        }

        private List<char>  convertColorsToChars(List<Color> i_Colors)
        {
            List<char> guessedChars = i_Colors.ConvertAll(convertColorToChar);
            return guessedChars;
        } 

        private char        convertColorToChar(Color i_Color)
        {
            return (char)(r_ColorOptions.IndexOf(i_Color) + 'A');
        }

        private Color[]     convertCharsToColors(char[] i_Chars)
        {
            Color[] convertedColors = new Color[i_Chars.Length];
            
            for(int i = 0; i < i_Chars.Length; i++)
            {
                convertedColors[i] = convertCharToColor(i_Chars[i]);
            }

            return convertedColors;
        }

        private Color       convertCharToColor(char i_Char)
        {
            return r_ColorOptions[i_Char - 'A'];
        }
    }
}