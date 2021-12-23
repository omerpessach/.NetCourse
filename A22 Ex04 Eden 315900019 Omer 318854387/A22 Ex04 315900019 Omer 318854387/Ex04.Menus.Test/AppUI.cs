using System;
using System.Collections.Generic;
using Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class AppUI
    {
        CountCapitlas   m_CountCapitlasAction;
        ShowVersion     m_ShowVersionAction;
        ShowDate        m_ShowDateAction;
        ShowTime        m_ShowTimeAction;

        public AppUI()
        {
            m_CountCapitlasAction = new CountCapitlas();
            m_ShowDateAction = new ShowDate();
            m_ShowTimeAction = new ShowTime();
            m_ShowVersionAction = new ShowVersion();
        }

        public void  Run()
        {
            Delegates.MainMenu delegateMenu;
            createMenuToDelgates(out delegateMenu);
            delegateMenu.RunMenu();

            Interfaces.MainMenu interfacesMenu;
            createMenuToInterfaces(out interfacesMenu);
            interfacesMenu.RunMenu();
        }

        private void createMenuToDelgates(out Delegates.MainMenu o_CurrentMenuToCreate)
        {
            o_CurrentMenuToCreate = new Delegates.MainMenu(Delegates.eMenuType.PrimMenu, "**Delegates Main Menu**");
            Delegates.MainMenu versionAndCapitalsMenu = new Delegates.MainMenu(Delegates.eMenuType.SecondaryMenu, "Version and Capitals");
            Delegates.MenuItem countCapitalsActionItem = new Delegates.MenuItem("Count Capitals");
            Delegates.MenuItem showVersionActionItem = new Delegates.MenuItem("Show version");
            Delegates.MainMenu dateAndTimeMenu = new Delegates.MainMenu(Delegates.eMenuType.SecondaryMenu, "Show Date/Time");
            Delegates.MenuItem showDateActionItem = new Delegates.MenuItem("Show Date");
            Delegates.MenuItem showTimeActionItem = new Delegates.MenuItem("Show Time");

            o_CurrentMenuToCreate.AddMenuItemToList(versionAndCapitalsMenu);
            o_CurrentMenuToCreate.AddMenuItemToList(dateAndTimeMenu);
            versionAndCapitalsMenu.AddMenuItemToList(countCapitalsActionItem);
            versionAndCapitalsMenu.AddMenuItemToList(showVersionActionItem);
            dateAndTimeMenu.AddMenuItemToList(showDateActionItem);
            dateAndTimeMenu.AddMenuItemToList(showTimeActionItem);

            countCapitalsActionItem.MenuSelected += m_CountCapitlasAction.ReportAction;
            showVersionActionItem.MenuSelected += m_ShowVersionAction.ReportAction;
            showDateActionItem.MenuSelected += m_ShowDateAction.ReportAction;
            showTimeActionItem.MenuSelected += m_ShowTimeAction.ReportAction;
        }

        private void createMenuToInterfaces(out Interfaces.MainMenu o_CurrentMenuToCreate)
        {

            o_CurrentMenuToCreate = new Interfaces.MainMenu(Interfaces.eMenuType.PrimMenu, "**Main Menu Interfaces**");
          
            Interfaces.MainMenu versionAndCapitalsMenu = new Interfaces.MainMenu(Interfaces.eMenuType.SecondaryMenu, "Version and Capitals");
            Interfaces.ActionItem countCapitalsActionItem = new Interfaces.ActionItem("Count Capitals");
            countCapitalsActionItem.AddListner(m_CountCapitlasAction);
            Interfaces.ActionItem showVersionActionItem = new Interfaces.ActionItem("Show version");
            showVersionActionItem.AddListner(m_ShowVersionAction);
            versionAndCapitalsMenu.AddMenuItemToList(countCapitalsActionItem);
            versionAndCapitalsMenu.AddMenuItemToList(showVersionActionItem);
            o_CurrentMenuToCreate.AddMenuItemToList(countCapitalsActionItem);
            Interfaces.MainMenu dateAndTimeMenu = new Interfaces.MainMenu(Interfaces.eMenuType.SecondaryMenu, "Show Date/Time");
            Interfaces.ActionItem showDateActionItem = new Interfaces.ActionItem("Show Date");
            showDateActionItem.AddListner(m_ShowDateAction);
            Interfaces.ActionItem showTimeActionItem = new Interfaces.ActionItem("Show Time");
            showTimeActionItem.AddListner(m_ShowTimeAction);
            dateAndTimeMenu.AddMenuItemToList(showDateActionItem);
            dateAndTimeMenu.AddMenuItemToList(showTimeActionItem);
            o_CurrentMenuToCreate.AddMenuItemToList(dateAndTimeMenu);
        }
    }
}
