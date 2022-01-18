using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MastermindUserInterface
{
    public delegate void ButtonGuessClickedEventHandler(int i_RowNumber);

    public partial class BoardForm : Form
    {
        private const int k_Space = 50;
        private const int k_IndentationTab = 10;
        private readonly List<Button> r_ButtonsSecretColors;
        private readonly List<FinishedGuessButton> r_ButtonsFinishedGuess;
        private readonly List<Button[,]> r_ButtonsGuessResult;
        private readonly int r_GuessAmountEachRow;
        private readonly int r_ButtonLength = 40;
        private readonly int r_ButtonWidth = 40;
        private readonly int r_NumberOfGuessesEachRow = 4;
        private readonly int r_FinishGuessButtonsHeight = 30;
        private readonly int r_FinishGuessButtonsWidth = 35;
        private readonly int r_ButtonsGuessResultHeight = 12;
        private readonly int r_ButtonsGuessResultWidtht = 12;
        private GuessButton[,] m_ButtonsGuesses;

        public BoardForm(int i_GuessAmountEachRow, int i_NumberOfGuess, List<Color> i_ColorOptions)
        {
            InitializeComponent();
            r_GuessAmountEachRow = i_GuessAmountEachRow;
            r_ButtonsSecretColors = new List<Button>();
            initializeRowButtonsSecretColors(r_ButtonsSecretColors, i_GuessAmountEachRow, new Size(r_ButtonWidth, r_ButtonLength), Color.Black);
            initializeBoardButtons(i_NumberOfGuess, i_GuessAmountEachRow, i_ColorOptions);

            setButtonInBoard(i_NumberOfGuess, i_GuessAmountEachRow, new Size(r_ButtonWidth, r_ButtonLength));
            r_ButtonsFinishedGuess = new List<FinishedGuessButton>(i_NumberOfGuess);
            initializeFinishedButtonList(r_ButtonsFinishedGuess, i_GuessAmountEachRow, "-->>", new Size(r_FinishGuessButtonsWidth, r_FinishGuessButtonsHeight));
            r_ButtonsGuessResult = new List<Button[,]>(i_NumberOfGuess);

            for (int i = 0; i < i_NumberOfGuess; i++)
            {
                r_ButtonsGuessResult.Add(new Button[i_GuessAmountEachRow / 2, i_GuessAmountEachRow / 2]);
                initializeBoardButtonsResult(r_ButtonsGuessResult[i], i, i_GuessAmountEachRow / 2, i_GuessAmountEachRow / 2, new Size(r_ButtonsGuessResultWidtht, r_ButtonsGuessResultHeight));
            }

            this.Size = generatedFormSize();
        }

        public List<FinishedGuessButton> ButtonsFinishGuess
        {
            get
            {
                return r_ButtonsFinishedGuess;
            }
        }

        public void SetButtonsGuessColor(int i_RowNumber, Color[,] i_SetColor)
        {
            for (int i = 0; i < r_ButtonsGuessResult[i_RowNumber].GetLength(0); i++)
            {
                for (int j = 0; j < r_ButtonsGuessResult[i_RowNumber].GetLength(1); j++)
                {
                    r_ButtonsGuessResult[i_RowNumber][i, j].BackColor = i_SetColor[i, j];
                }
            }
        }

        public void SetButtonsSecretGuessColor(Color[] i_SetBackgroundColor)
        {
            for (int i = 0; i < r_ButtonsSecretColors.Count; i++)
            {
                r_ButtonsSecretColors[i].BackColor = i_SetBackgroundColor[i];
            }
        }

        public void EnableDisableARowInBoard(bool i_EnableOrDisableRow, int i_RowNum)
        {
            for (int i = 0; i < m_ButtonsGuesses.GetLength(1); i++)
            {
                m_ButtonsGuesses[i_RowNum, i].Enabled = i_EnableOrDisableRow;
            }
        }

        public Color[] GetRowInGuessButtonBoard(int i_RowNumber)
        {
            Color[] colorsInRow = new Color[m_ButtonsGuesses.GetLength(1)];

            for (int j = 0; j < m_ButtonsGuesses.GetLength(1); j++)
            {
                colorsInRow[j] = m_ButtonsGuesses[i_RowNumber, j].BackColor;
            }

            return colorsInRow;
        }

        protected override void OnShown(EventArgs i_EventArgs)
        {
            base.OnShown(i_EventArgs);
            EnableDisableARowInBoard(true, 0);
        }

        private Size generatedFormSize()
        {
            int width, length;
            Size newFormSize;
            int lastButtonIndex = m_ButtonsGuesses.GetLength(0);
            length = m_ButtonsGuesses[lastButtonIndex - 1, 0].Top + r_ButtonLength + k_Space;

            width = r_ButtonsGuessResult[0][0, 1].Left + r_ButtonsGuessResultWidtht + 20;

            newFormSize = new Size(width, length);
            return newFormSize;
        }

        private void initializeBoardButtonsResult(Button[,] i_SetBoard, int i_RowNumber, int i_NumOfRows, int i_NumberOfCol, Size i_Size)
        {
            for (int i = 0; i < i_NumOfRows; i++)
            {
                for (int j = 0; j < i_NumberOfCol; j++)
                {
                    i_SetBoard[i, j] = new Button();
                    i_SetBoard[i, j].Enabled = false;
                    i_SetBoard[i, j].Size = i_Size;
                    i_SetBoard[i, j].Top = m_ButtonsGuesses[i_RowNumber, 0].Top + (i_SetBoard[i, j].Size.Height * i);
                    i_SetBoard[i, j].Left = r_ButtonsFinishedGuess[i].Right + (i_SetBoard[i, j].Size.Width * (j + 1));
                    this.Controls.Add(i_SetBoard[i, j]);
                }
            }
        }

        private void initializeBoardButtons(int i_NumOfRows, int i_NumOfCol, List<Color> i_ColorOptions)
        {
            m_ButtonsGuesses = new GuessButton[i_NumOfRows, i_NumOfCol];
            for (int i = 0; i < i_NumOfRows; i++)
            {
                for (int j = 0; j < i_NumOfCol; j++)
                {
                    m_ButtonsGuesses[i, j] = new GuessButton(i_ColorOptions, i);
                }
            }
        }

        private void setButtonInBoard(int i_NumOfRows, int i_NumOfCols, Size i_ButtonsSize)
        {
            int spacing = 0;
            int line = 1;
            int i = 0;

            for (int j = 0; j < i_NumOfRows; j++)
            {
                for (int l = 0; l < i_NumOfCols; l++)
                {
                    m_ButtonsGuesses[j, l].Enabled = false;
                    m_ButtonsGuesses[j, l].Size = i_ButtonsSize;
                    m_ButtonsGuesses[j, l].Top = (k_Space * line) + (k_IndentationTab + 16);
                    m_ButtonsGuesses[j, l].Left = spacing + k_Space - i_ButtonsSize.Width;
                    spacing += k_Space;
                    i++;

                    if (i % i_NumOfCols == 0)
                    {
                        line++;
                        spacing = 0;
                    }

                    m_ButtonsGuesses[j, l].Clicked += new ButtonGuessClickedEventHandler(ButtonsGuess_Clicked);
                    this.Controls.Add(m_ButtonsGuesses[j, l]);
                }
            }
        }

        private void initializeRowButtonsSecretColors(List<Button> i_ListToSet, int i_NumOfButtonsInList, Size i_ButtonsSize, Color i_ButtonsColor)
        {
            int spacing = 0;
            for (int i = 0; i < i_NumOfButtonsInList; i++)
            {
                i_ListToSet.Add(new Button());
                i_ListToSet[i].Enabled = false;
                i_ListToSet[i].Size = i_ButtonsSize;
                i_ListToSet[i].Top = k_IndentationTab;
                i_ListToSet[i].Left = spacing + k_Space - i_ButtonsSize.Width;
                spacing += k_Space;
                i_ListToSet[i].BackColor = i_ButtonsColor;
                this.Controls.Add(i_ListToSet[i]);
            }
        }

        private void ButtonsGuess_Clicked(int i_RowNum)
        {
            int numOfGuessesInARound = 0;

             for (int l = 0; l < r_NumberOfGuessesEachRow; l++)
             {
                if (m_ButtonsGuesses[i_RowNum, l].BackColor != Control.DefaultBackColor)
                {
                        numOfGuessesInARound++;
                }
             }
                   
            if (numOfGuessesInARound == r_GuessAmountEachRow)
            {
                r_ButtonsFinishedGuess[i_RowNum].Enabled = true;
            }
        }

        private void initializeFinishedButtonList(List<FinishedGuessButton> i_ListToSet, int i_GuessAmountEachRow, string I_ButtonsSymbol, Size i_ButtonsSize)
        {
            int spacing = 0;
            for (int i = 0; i < i_ListToSet.Capacity; i++)
            {
                i_ListToSet.Add(new FinishedGuessButton());
                i_ListToSet[i].Enabled = false;
                i_ListToSet[i].Text = I_ButtonsSymbol;
                i_ListToSet[i].Size = i_ButtonsSize;
                i_ListToSet[i].Top = spacing + k_Space + i_ButtonsSize.Height;
                i_ListToSet[i].Left = m_ButtonsGuesses[i, i_GuessAmountEachRow - 1].Right + 5;
                spacing += k_Space;
                this.Controls.Add(i_ListToSet[i]);
            }
        }

        private void BoardForm_Load(object sender, EventArgs e)
        {
        }
    }
}
