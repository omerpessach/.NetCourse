using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void SelectedEventHandler();
    public class MenuItem
    {
        public event SelectedEventHandler MenuSelected;

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

        public void OnMenuSelected()
        {
            if(MenuSelected != null)
            {
                MenuSelected.Invoke();
            }
        }
    }
}
