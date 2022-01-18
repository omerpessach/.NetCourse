using System;
using System.Windows.Forms;

namespace MastermindUserInterface
{
    public class FinishedGuessButton : Button
    {
        public FinishedGuessButton()
        {
            this.Click += new EventHandler(OnClick);
        }

        public void OnClick(object sender, EventArgs i_EventArgs)
        {
            this.Enabled = false;
        }
    }
}
