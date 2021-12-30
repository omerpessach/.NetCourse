using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        private readonly List<MenuItem> r_InnerMenus = new List<MenuItem>();
        private bool                    m_IsMenuEnded = false;

        public MainMenu(eMenuType i_MenuType, string i_Title) : base(i_Title)
        {
            string endItemTitle;

            endItemTitle = i_MenuType == eMenuType.PrimMenu ? "Exit" : "Back";
            ExitItem exitOrBackItem = new ExitItem(endItemTitle); // Exit or back need to be in place zero at menu
            r_InnerMenus.Add(exitOrBackItem);
        }

        public void     AddMenuItem(MenuItem i_MenuItem)
        {
            r_InnerMenus.Add(i_MenuItem);
        }

        public void     RunMenu()
        {
            string menuDescription = getMenuDescription();
            int userInput;

            while (!m_IsMenuEnded)
            {
                Console.Clear();
                Console.WriteLine(menuDescription);
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
                if (m_IsMenuEnded)
                {
                    m_IsMenuEnded = false;
                }
            }
        }

        private void    activateMenuItem(MenuItem i_ItemToBeActivated)
        {
            if (i_ItemToBeActivated is ExitItem)
            {
                m_IsMenuEnded = true;
            }
            else if (i_ItemToBeActivated is MainMenu)
            {
                ((MainMenu)i_ItemToBeActivated).RunMenu();
            }
            else
            {
                i_ItemToBeActivated.OnMenuSelected();
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
                throw new FormatException(string.Format("the Input {0} is not an intger", inputUserAsString));
            }
            else if (userChoice < 0 || userChoice > (r_InnerMenus.Count - 1))
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
            foreach (MenuItem menuItem in r_InnerMenus)
            {
                menuDescription.AppendLine(string.Format("{0} -> {1}", optionInMenu, menuItem.Title));
                optionInMenu++;
            }

            menuDescription.AppendLine("--------------------------");
            return menuDescription.ToString();
        }
    }
}
