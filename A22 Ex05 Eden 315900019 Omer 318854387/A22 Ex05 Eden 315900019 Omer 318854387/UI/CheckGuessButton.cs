using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public class CheckGuessButton : Button
    {
        public CheckGuessButton()
        {
            Click += checkGuessButton_Click; ;
        }

        private void checkGuessButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
        }
    }
}
