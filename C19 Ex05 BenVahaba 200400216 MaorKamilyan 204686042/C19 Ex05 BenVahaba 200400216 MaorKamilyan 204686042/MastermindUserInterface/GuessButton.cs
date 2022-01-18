using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MastermindUserInterface
{
    public class GuessButton : Button
    {
        private readonly PickAColorForm r_PickAColor;
        private readonly int r_ButtonRowNum;

        public GuessButton(List<Color> i_Colors, int i_ButtonRowNum)
        {
            r_PickAColor = new PickAColorForm(i_Colors);
            r_ButtonRowNum = i_ButtonRowNum;
            this.Click += new EventHandler(OnClick);
        }

        public event ButtonGuessClickedEventHandler Clicked;

        public void OnClick(object sender, EventArgs i_EventArgs)
        {
            r_PickAColor.ShowDialog();
            if (r_PickAColor.UserChoseAColor)
            {
                this.BackColor = r_PickAColor.ColorChosenByUser;
                if (this.Clicked != null)
                {
                    Clicked.Invoke(r_ButtonRowNum);
                }
            }
        }
    }
}
