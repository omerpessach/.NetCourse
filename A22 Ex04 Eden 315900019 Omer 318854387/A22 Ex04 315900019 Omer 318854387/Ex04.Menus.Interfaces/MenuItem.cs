using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_CurrentTitle;

        public MenuItem(string i_Title)
        {
            CurrentTitle = i_Title;
        }

        public string CurrentTitle
        {
            get
            {
                return m_CurrentTitle;
            }
            set
            {
                m_CurrentTitle = value;
            }
        }
    }
}
