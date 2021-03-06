using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace UI
{
    public delegate void ButtonCheckGuessClickedDelegate(Color[] i_ColorToCheck);

    public class GuessRow
    {
        private const int                       k_GuessButtonSideLength = 60;
        private const int                       k_CheckButtonHeight = 20;
        private const int                       k_CheckButtonWidth = 40;
        private const int                       k_ResultButtonSideLength = 20;
        private const int                       k_MarginResultButton = 10;
        private const int                       k_MarginGuessButton = 10;
        private const int                       k_TopMarginCheckGuess = 20;
        private const int                       k_RightMarginCheckGuess = 15;
        private const string                    k_CheckGuessSymbol = "-->>";
        private readonly List<GuessButton>      r_GuessButtons;
        private readonly CheckGuessButton       r_ButtonCheckGuess = new CheckGuessButton();
        private readonly Button[,]              r_ButtonsGuessResult;
        private readonly Dictionary<int, Color> r_ChosenColors;
        private int                             m_Width;

        public GuessRow(uint i_AmountOfColorsInSequence, List<Color> i_ColorOptions, Point i_StartLocation, ControlCollection o_Controls)
        {
            r_GuessButtons = new List<GuessButton>((int)i_AmountOfColorsInSequence);
            r_ButtonsGuessResult = new Button[i_AmountOfColorsInSequence / 2, i_AmountOfColorsInSequence / 2];
            r_ChosenColors = new Dictionary<int, Color>((int)i_AmountOfColorsInSequence);

            initGuessButtons(i_ColorOptions, o_Controls);
            initGuessResultButtons(o_Controls);
            initCheckGuessButton(o_Controls);
            arrangeLocationToAllItems(i_StartLocation);
        }

        public event ButtonCheckGuessClickedDelegate ButtonCheckGuessClicked;

        public int     Height
        {
            get => k_GuessButtonSideLength + k_MarginGuessButton;
        }

        public int     Width
        {
            get => m_Width;
        }

        public Color[] ButtonsResultColor
        {
            set
            {
                for (int i = 0, iColorIndex = 0; i < r_ButtonsGuessResult.GetLength(0); i++)
                {
                    for (int j = 0; j < r_ButtonsGuessResult.GetLength(1); j++)
                    {
                        r_ButtonsGuessResult[i, j].BackColor = value[iColorIndex++];
                    }
                }
            }
        }

        public bool    GuessButtonsEnabled
        {
            set
            {
                r_GuessButtons.ForEach(button => button.Enabled = value);
            }
        }

        private void   initCheckGuessButton(ControlCollection o_Controls)
        {
            r_ButtonCheckGuess.Enabled = false;
            r_ButtonCheckGuess.Text = k_CheckGuessSymbol;
            r_ButtonCheckGuess.Size = new Size(k_CheckButtonWidth, k_CheckButtonHeight);
            r_ButtonCheckGuess.Click += checkGuessButton_Click;
            o_Controls.Add(r_ButtonCheckGuess);
        }

        private void   checkGuessButton_Click(object sender, EventArgs e)
        {
            Color[] colors = new Color[r_ChosenColors.Count];

            for (int i = 0; i < r_ChosenColors.Count; i++)
            {
                colors[i] = r_ChosenColors[i];
            }

            ButtonCheckGuessClicked?.Invoke(colors);
        }

        private void   initGuessButtons(List<Color> i_ColorOptions, ControlCollection o_Controls)
        {
            for (int i = 0; i < r_GuessButtons.Capacity; i++)
            {
                GuessButton guessButton = new GuessButton(i, i_ColorOptions);
                guessButton.Size = new Size(k_GuessButtonSideLength, k_GuessButtonSideLength);
                guessButton.Enabled = false;
                guessButton.GuessWasMade += guessButton_GuessWasMade;
                r_GuessButtons.Insert(i,guessButton);
                o_Controls.Add(guessButton);
            }
        }

        private void   initGuessResultButtons(ControlCollection o_Controls)
        {
            for (int i = 0; i < r_ButtonsGuessResult.GetLength(0); i++)
            {
                for (int j = 0; j < r_ButtonsGuessResult.GetLength(1); j++)
                {
                    Button resultButton = new Button();
                    resultButton.Enabled = false;
                    resultButton.Size = new Size(k_ResultButtonSideLength, k_ResultButtonSideLength);
                    r_ButtonsGuessResult[i, j] = resultButton;
                    o_Controls.Add(resultButton);
                }
            }
        }

        private void   arrangeLocationToAllItems(Point i_StartLocation)
        {
            i_StartLocation.Y += k_MarginGuessButton;
            foreach (GuessButton guessButton in r_GuessButtons)
            {
                guessButton.Location = i_StartLocation;
                i_StartLocation.X += guessButton.Width + k_MarginGuessButton;
            }

            i_StartLocation.Y += k_TopMarginCheckGuess;
            r_ButtonCheckGuess.Location = i_StartLocation;
            i_StartLocation.Y -= k_TopMarginCheckGuess;
            i_StartLocation.X += r_ButtonCheckGuess.Width + k_RightMarginCheckGuess;
            for (int i = 0; i < r_ButtonsGuessResult.GetLength(0); i++)
            {
                for (int j = 0; j < r_ButtonsGuessResult.GetLength(1); j++)
                {
                    r_ButtonsGuessResult[i, j].Location = i_StartLocation;
                    i_StartLocation.X += k_MarginResultButton + k_ResultButtonSideLength;
                    m_Width = i_StartLocation.X;
                }

                i_StartLocation.X -= (k_MarginResultButton + k_ResultButtonSideLength) * r_ButtonsGuessResult.GetLength(1);
                i_StartLocation.Y += k_MarginResultButton + k_ResultButtonSideLength;
            }
        }

        private void   guessButton_GuessWasMade(int i_RowIndex, Color i_SelectedColor)
        {
            r_ChosenColors[i_RowIndex] = i_SelectedColor;
            r_ButtonCheckGuess.Enabled = r_GuessButtons.Capacity == r_ChosenColors.Count;
            r_GuessButtons.ForEach(button => button.ColorsToDisable = r_ChosenColors.Values);
        }
    }
}
