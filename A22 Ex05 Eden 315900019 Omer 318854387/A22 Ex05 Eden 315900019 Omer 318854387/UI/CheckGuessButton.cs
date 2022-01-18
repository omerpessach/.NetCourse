using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public class CheckGuessButton : Button
    {
        protected override void OnClick(EventArgs i_EventArgs)
        {
            Enabled = false;
        }
    }
}
