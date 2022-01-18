using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MastermindUserInterface
{
    public partial class PickAColorForm : Form
    {
        private readonly int r_ColorButtonwidth = 30;
        private readonly int r_ColorButtonheight = 30;
        private readonly int r_SpaceBetweenButtons = 15;
        private List<Button> m_CollorButton;
        private Color m_ChosenColor;
        private bool v_UserChoseAColor = false;

        public PickAColorForm(List<Color> i_ColorOptions)
        {
            InitializeComponent();
            m_CollorButton = new List<Button>(i_ColorOptions.Count);
            for(int i = 0; i < i_ColorOptions.Count; i++)
            {
                m_CollorButton.Add(new Button());
                m_CollorButton[i].Size = new Size(r_ColorButtonwidth, r_ColorButtonheight);

                if(i % 2 == 0)
                {
                    m_CollorButton[i].Top = r_SpaceBetweenButtons;
                    m_CollorButton[i].Left = (r_SpaceBetweenButtons * ((i / 2) + 1)) + (r_ColorButtonwidth * (i / 2));
                }
                else
                {
                    m_CollorButton[i].Top = (r_SpaceBetweenButtons * 2) + r_ColorButtonheight;
                    m_CollorButton[i].Left = (((i + 1) / 2) * r_SpaceBetweenButtons) + (((i - 1) / 2) * r_ColorButtonwidth);
                }

                m_CollorButton[i].BackColor = i_ColorOptions[i];
                this.Controls.Add(m_CollorButton[i]);
                m_CollorButton[i].Click += new EventHandler(colorButtonClicked);
            }

            Size newFormSize = generatedFormSize(m_CollorButton.Count, r_ColorButtonheight, r_ColorButtonwidth, r_SpaceBetweenButtons);
            this.Size = newFormSize;
        }

        public Color ColorChosenByUser
        {
            get { return m_ChosenColor; }
        }

        public bool UserChoseAColor
        {
            get { return v_UserChoseAColor; }
        }

        // $G$ CSS-013 (-5) Bad input variable name (should be in the form of i_PascalCased)
        private Size generatedFormSize(int i_NumberOfButtons, int i_ButtonHeight, int i_ButtonWidth, int i_r_SpaceBetweenButtons)
        {
            int height;
            int width;
            int numberOfButtonsInARow;
            Size calculatedSize;
            height = (2 * i_ButtonHeight) + (3 * i_r_SpaceBetweenButtons) + 40;
            if(i_NumberOfButtons % 2 == 0)
            {
                numberOfButtonsInARow = i_NumberOfButtons / 2;
            }
            else
            {
                numberOfButtonsInARow = (i_NumberOfButtons / 2) + 1;
            }

            width = (numberOfButtonsInARow * i_ButtonWidth) + (i_r_SpaceBetweenButtons * (numberOfButtonsInARow + 2));
            calculatedSize = new Size(width, height);
            return calculatedSize;
        }

        private void colorButtonClicked(object i_Sender, EventArgs i_EventArgs)
        {
            m_ChosenColor = (i_Sender as Button).BackColor;
            v_UserChoseAColor = true;
            this.Close();
        }
        
        private void PickAColorForm_Load(object sender, EventArgs e)
        {
        }
    }
}
