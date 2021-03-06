using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        private readonly List<MenuItem> r_InnerMenus = new List<MenuItem>();
        private bool                    m_IsMenuEnded = false;      // Exit or back flag

        public MainMenu(eMenuType i_MenuType, string i_Title) : base(i_Title)
        {
            string endItemTitle;

            endItemTitle = i_MenuType == eMenuType.PrimMenu ? "Exit" : "Back";
            ExitItem currentExitItem = new ExitItem(endItemTitle); // Exit or back need to be in place zero at menu
            r_InnerMenus.Add(currentExitItem);
        }

        public void     AddMenuItem(MenuItem i_MenuItem)
        {
            r_InnerMenus.Add(i_MenuItem);
        }

        public void     RunMenu()
        {
            string descriptionOfMenu = getMenuDescription();
            int userInput;

            while (!m_IsMenuEnded)
            {
                Console.Clear();
                Console.WriteLine(descriptionOfMenu);
                try
                {
                    userInput = getInputFromUser();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(string.Format("{0}, press any key to continue", exception.Message));
                    Console.ReadKey();
                    continue;
                }

                activateMenuItem(r_InnerMenus[userInput]);
            }

            m_IsMenuEnded = false;
        }

        private void    activateMenuItem(MenuItem i_ItemToBeActivated)
        {
            m_IsMenuEnded = i_ItemToBeActivated is ExitItem;

            if (!m_IsMenuEnded)
            {
                if (i_ItemToBeActivated is MainMenu)
                {
                    ((MainMenu)i_ItemToBeActivated).RunMenu();
                }
                else
                {
                    ((ActionItem)i_ItemToBeActivated).ActivateWhanActionOccured();
                }
            }
        }

        private int     getInputFromUser()
        {
            string inputUserAsString;
            int userChoice;

            Console.WriteLine("Enter your request: (1 to 2 or press '0' to Exit).");
            inputUserAsString = Console.ReadLine();
            if (!int.TryParse(inputUserAsString, out userChoice))
            {
                throw new Exception(string.Format("the Input {0} is not an intger", inputUserAsString));
            }
            else if (userChoice < 0 || userChoice > r_InnerMenus.Count -1)
            {
                throw new Exception(string.Format("the Input {0} is out of range", userChoice));
            }

            return userChoice;
        }

        private string  getMenuDescription()
        {
            StringBuilder menuDescription = new StringBuilder();
            int optionInMenu = 0;

            menuDescription.AppendLine(string.Format("**{0}**", Title));
            menuDescription.AppendLine("--------------------------");
            foreach (MenuItem currentItem in r_InnerMenus)
            {
                menuDescription.AppendLine(string.Format("{0} -> {1}", optionInMenu, currentItem.Title));
                optionInMenu++;
            }

            menuDescription.AppendLine("--------------------------");
            return menuDescription.ToString();
        }
    }
}
