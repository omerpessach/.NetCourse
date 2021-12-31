using Ex04.Menus.Interfaces;
using eMenuTypeDelegate = Ex04.Menus.Delegates.eMenuType;
using eMenuTypeInterface = Ex04.Menus.Interfaces.eMenuType;
using MainMenuDelegate = Ex04.Menus.Delegates.MainMenu;
using MainMenuInterface = Ex04.Menus.Interfaces.MainMenu;
using MenuItemDelegate = Ex04.Menus.Delegates.MenuItem;

namespace Ex04.Menus.Test
{
    public class AppUI
    {
        private readonly CountCapitlas       r_CountCapitlasAction = new CountCapitlas();
        private readonly ShowVersion         r_ShowVersionAction = new ShowVersion();
        private readonly ShowDate            r_ShowDateAction = new ShowDate();
        private readonly ShowTime            r_ShowTimeAction = new ShowTime();
        private readonly MainMenuDelegate    r_DelegatesMenu = new MainMenuDelegate(eMenuTypeDelegate.PrimMenu, "**Delegates Main Menu**");
        private readonly MainMenuInterface   r_InterfacesMenu = new MainMenuInterface(eMenuTypeInterface.PrimMenu, "**Interfaces Main Menu**");

        public void  Run()
        {
            initDelgatsMenu();
            initInterfacesMenu();
            r_DelegatesMenu.RunMenu();
            r_InterfacesMenu.RunMenu();
        }

        private void initDelgatsMenu()
        {
            MainMenuDelegate versionAndCapitalsMenu = new MainMenuDelegate(eMenuTypeDelegate.SecondaryMenu, "Version and Capitals");
            MenuItemDelegate countCapitalsActionItem = new MenuItemDelegate("Count Capitals");
            MenuItemDelegate showVersionActionItem = new MenuItemDelegate("Show version");
            MainMenuDelegate dateAndTimeMenu = new MainMenuDelegate(eMenuTypeDelegate.SecondaryMenu, "Show Date/Time");
            MenuItemDelegate showDateActionItem = new MenuItemDelegate("Show Date");
            MenuItemDelegate showTimeActionItem = new MenuItemDelegate("Show Time");

            versionAndCapitalsMenu.AddMenuItem(countCapitalsActionItem);
            versionAndCapitalsMenu.AddMenuItem(showVersionActionItem);
            dateAndTimeMenu.AddMenuItem(showDateActionItem);
            dateAndTimeMenu.AddMenuItem(showTimeActionItem);
            r_DelegatesMenu.AddMenuItem(versionAndCapitalsMenu);
            r_DelegatesMenu.AddMenuItem(dateAndTimeMenu);

            countCapitalsActionItem.MenuSelected += r_CountCapitlasAction.ReportAction;
            showVersionActionItem.MenuSelected += r_ShowVersionAction.ReportAction;
            showDateActionItem.MenuSelected += r_ShowDateAction.ReportAction;
            showTimeActionItem.MenuSelected += r_ShowTimeAction.ReportAction;

        }

        private void initInterfacesMenu()
        {
            MainMenuInterface versionAndCapitalsMenu = new MainMenuInterface(eMenuTypeInterface.SecondaryMenu, "Version and Capitals");
            ActionItem countCapitalsActionItem = new ActionItem("Count Capitals");
            ActionItem showVersionActionItem = new ActionItem("Show version");
            MainMenuInterface dateAndTimeMenu = new MainMenuInterface(eMenuTypeInterface.SecondaryMenu, "Show Date/Time");
            ActionItem showDateActionItem = new ActionItem("Show Date");
            ActionItem showTimeActionItem = new ActionItem("Show Time");
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
