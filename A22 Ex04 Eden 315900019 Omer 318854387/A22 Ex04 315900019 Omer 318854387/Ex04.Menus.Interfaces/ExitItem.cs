using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class ExitItem : MenuItem //exit Represents an item in the menu - if primMenu : title = exit else title = back
    {
        public ExitItem(string i_CurrentTitle) : base(i_CurrentTitle)
        {
        }
    }

}
