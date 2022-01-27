using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class BoardForm : Form
    {
        private const int            k_ComputerButtonMargin = 10;
        private const int            k_ComputerButtonSideLength = 60;
        private const int            k_TopMarginGuessButtons = 40;
        private const int            k_ComputerButtonSideLengthWithMargin = k_ComputerButtonMargin + k_ComputerButtonSideLength;
        private const int            k_TopFormMargin = 70;
        private const int            k_LeftFormMargin = 40;
        private readonly Button[]    r_ButtonsComputerSequence;
        private readonly GuessRow[]  r_Guesses;
        private readonly Size        r_ComputerButtonSize = new Size(k_ComputerButtonSideLength, k_ComputerButtonSideLength);

        public BoardForm(uint i_AmountOfColorsInSequence, uint i_GuessesNumber, List<Color> i_ColorOptions, Color i_ComputerSequenceButtonsColor)
        {
            InitializeComponent();
            Point relevantStartLocation = new Point(k_ComputerButtonMargin, k_ComputerButtonMargin);
            r_ButtonsComputerSequence = new Button[i_AmountOfColorsInSequence];
            r_Guesses = new GuessRow[i_GuessesNumber];

            initButtonsComputerSequence(i_ComputerSequenceButtonsColor, ref relevantStartLocation);
            initGuessButtons(i_AmountOfColorsInSequence, i_ColorOptions, relevantStartLocation);
            int heightOfTheForm = (int)(relevantStartLocation.Y + SystemInformation.CaptionHeight + (r_Guesses[i_GuessesNumber - 1].Height * i_GuessesNumber) + k_TopFormMargin);
            Size = new Size(r_Guesses[i_GuessesNumber - 1].Width + k_LeftFormMargin, heightOfTheForm);
        }

        public GuessRow[] GuessRows
        {
            get => r_Guesses;
        }

        public Color[]    ComputerHiddenButtonColor
        {
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    r_ButtonsComputerSequence[i].BackColor = value[i];
                }
            }
        }

        private void      initButtonsComputerSequence(Color i_ComputerSequenceButtonsColor, ref Point io_RelevantStartLocation)
        {
            for (int i = 0; i < r_ButtonsComputerSequence.Length; i++)
            {
                Button buttonComputerHiddenColor = new Button();

                buttonComputerHiddenColor.BackColor = i_ComputerSequenceButtonsColor;
                buttonComputerHiddenColor.Enabled = false;
                buttonComputerHiddenColor.Size = r_ComputerButtonSize;
                buttonComputerHiddenColor.Location = io_RelevantStartLocation;
                r_ButtonsComputerSequence[i] = buttonComputerHiddenColor;
                io_RelevantStartLocation.X += k_ComputerButtonSideLengthWithMargin;
                Controls.Add(buttonComputerHiddenColor);
            }

            io_RelevantStartLocation = new Point(k_ComputerButtonMargin, k_ComputerButtonSideLength + k_ComputerButtonMargin);
        }

        private void      initGuessButtons(uint i_AmountOfColorsInSequence, List<Color> i_ColorOptions, Point i_RelevantStartLocation)
        {
            i_RelevantStartLocation.Y += k_TopMarginGuessButtons;
            for (int i = 0; i < r_Guesses.Length; i++)
            {
                GuessRow guessRow = new GuessRow(i_AmountOfColorsInSequence, i_ColorOptions, i_RelevantStartLocation, Controls);
                i_RelevantStartLocation.Y += guessRow.Height;
                r_Guesses[i] = guessRow;
            }
        }

        public void       EnableRowAndDisablePrevRowIfNecessary(int i_RowIndexToEnable)
        {
            r_Guesses[i_RowIndexToEnable].GuessButtonsEnabled = true;
            if (i_RowIndexToEnable > 0)
            {
                DisableRow(i_RowIndexToEnable - 1);
            }
        }

        public void       DisableRow(int i_RowIndexToDisable)
        {
            r_Guesses[i_RowIndexToDisable].GuessButtonsEnabled = false;
        }

        private void BoardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
