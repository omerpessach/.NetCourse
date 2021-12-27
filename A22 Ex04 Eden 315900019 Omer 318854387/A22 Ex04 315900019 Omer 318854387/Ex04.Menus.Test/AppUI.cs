using System;
using System.Collections.Generic;
using Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class AppUI
    {
        private readonly CountCapitlas       r_CountCapitlasAction = new CountCapitlas();
        private readonly ShowVersion         r_ShowVersionAction = new ShowVersion();
        private readonly ShowDate            r_ShowDateAction = new ShowDate();
        private readonly ShowTime            r_ShowTimeAction = new ShowTime();
        private readonly Delegates.MainMenu  r_DelegateMenu = new Delegates.MainMenu(Delegates.eMenuType.PrimMenu, "**Delegates Main Menu**");
        private readonly Interfaces.MainMenu r_InterfacesMenu = new Interfaces.MainMenu(Interfaces.eMenuType.PrimMenu, "**Interfaces Main Menu**");

        public void  Run()
        {
            initDelgatsMenu();
            initInterfacesMenu();
            r_DelegateMenu.RunMenu();
            r_InterfacesMenu.RunMenu();
        }

        private void initDelgatsMenu()
        {
            Delegates.MainMenu versionAndCapitalsMenu = new Delegates.MainMenu(Delegates.eMenuType.SecondaryMenu, "Version and Capitals");
            Delegates.MenuItem countCapitalsActionItem = new Delegates.MenuItem("Count Capitals");
            Delegates.MenuItem showVersionActionItem = new Delegates.MenuItem("Show version");
            Delegates.MainMenu dateAndTimeMenu = new Delegates.MainMenu(Delegates.eMenuType.SecondaryMenu, "Show Date/Time");
            Delegates.MenuItem showDateActionItem = new Delegates.MenuItem("Show Date");
            Delegates.MenuItem showTimeActionItem = new Delegates.MenuItem("Show Time");

            versionAndCapitalsMenu.AddMenuItemToList(countCapitalsActionItem);
            versionAndCapitalsMenu.AddMenuItemToList(showVersionActionItem);
            dateAndTimeMenu.AddMenuItemToList(showDateActionItem);
            dateAndTimeMenu.AddMenuItemToList(showTimeActionItem);

            countCapitalsActionItem.MenuSelected += r_CountCapitlasAction.ReportAction;
            showVersionActionItem.MenuSelected += r_ShowVersionAction.ReportAction;
            showDateActionItem.MenuSelected += r_ShowDateAction.ReportAction;
            showTimeActionItem.MenuSelected += r_ShowTimeAction.ReportAction;

            r_DelegateMenu.AddMenuItemToList(versionAndCapitalsMenu);
            r_DelegateMenu.AddMenuItemToList(dateAndTimeMenu);
        }

        private void initInterfacesMenu()
        {
            Interfaces.MainMenu versionAndCapitalsMenu = new Interfaces.MainMenu(Interfaces.eMenuType.SecondaryMenu, "Version and Capitals");
            Interfaces.ActionItem countCapitalsActionItem = new Interfaces.ActionItem("Count Capitals");
            Interfaces.ActionItem showVersionActionItem = new Interfaces.ActionItem("Show version");
            Interfaces.MainMenu dateAndTimeMenu = new Interfaces.MainMenu(Interfaces.eMenuType.SecondaryMenu, "Show Date/Time");
            Interfaces.ActionItem showDateActionItem = new Interfaces.ActionItem("Show Date");
            Interfaces.ActionItem showTimeActionItem = new Interfaces.ActionItem("Show Time");
            countCapitalsActionItem.AddListner(r_CountCapitlasAction);
            showVersionActionItem.AddListner(r_ShowVersionAction);
            versionAndCapitalsMenu.AddMenuItemToList(countCapitalsActionItem);
            versionAndCapitalsMenu.AddMenuItemToList(showVersionActionItem);
            showDateActionItem.AddListner(r_ShowDateAction);
            showTimeActionItem.AddListner(r_ShowTimeAction);
            dateAndTimeMenu.AddMenuItemToList(showDateActionItem);
            dateAndTimeMenu.AddMenuItemToList(showTimeActionItem);
            r_InterfacesMenu.AddMenuItemToList(countCapitalsActionItem);
            r_InterfacesMenu.AddMenuItemToList(dateAndTimeMenu);
        }
    }
}
