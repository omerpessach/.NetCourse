﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        private readonly List<MenuItem> r_AllMenus;
        private bool                    m_IsMenuEnded;      //exit or back

        public MainMenu(eMenuType i_CurrentMenuType, string i_CurrentTitle) : base(i_CurrentTitle)
        {
            string endItemTitle;

            r_AllMenus = new List<MenuItem>();
            m_IsMenuEnded = false;

            endItemTitle = i_CurrentMenuType == eMenuType.PrimMenu ? "Exit" : "Back";
            ExitItem currentExitItem = new ExitItem(endItemTitle); //exit/ back need to be in place zero at menu
            r_AllMenus.Add(currentExitItem);
        }

        public void addMenuItemToList(MenuItem i_CurremtMenuItem)
        {
            r_AllMenus.Add(i_CurremtMenuItem);
        }
        public void RunMenu()
        {
            string descriptionOfMenu = getDescriptionOfMenu();
            int userInput = 0;

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
                    Console.WriteLine(String.Format("{0}, press any key to continue", exception.Message));
                    Console.ReadKey();
                    continue;
                }
                activateCurrentMenuItem(r_AllMenus[userInput]);
                if (m_IsMenuEnded)
                {
                    m_IsMenuEnded = false;
                    break;
                }
            }
        }

        private void activateCurrentMenuItem(MenuItem i_CurrentItemToBeActivated)
        {
            if (i_CurrentItemToBeActivated is ExitItem)
            {
                m_IsMenuEnded = true;
            }
            else if (i_CurrentItemToBeActivated is MainMenu)
            {
                ((MainMenu)i_CurrentItemToBeActivated).RunMenu();
            }
            else
            {
                ((ActionItem)i_CurrentItemToBeActivated).ActivateWhanActionOccured();
            }
        }

        private int getInputFromUser()
        {
            string inputUserAsString;
            bool isValidInput;
            int userChoice = 0;

            Console.WriteLine("Enter your request: (1 to 2 or press '0' to Exit).");
            inputUserAsString = Console.ReadLine();
            isValidInput = int.TryParse(inputUserAsString, out userChoice);
            if (!isValidInput)
            {
                throw new Exception(string.Format("the Input {0} is not an intger", inputUserAsString));
            }
            else if (userChoice < 0 || userChoice > (r_AllMenus.Count -1))
            {
                throw new Exception(String.Format("the Input {0} is out of range", userChoice));
            }

            return userChoice;
        }

        private string getDescriptionOfMenu()
        {
            StringBuilder descriptionOfMenu = new StringBuilder();
            int optionInMenu = 0;

            descriptionOfMenu.AppendLine(string.Format("**{0}**", CurrentTitle));
            descriptionOfMenu.AppendLine("--------------------------");
            foreach (MenuItem currentItem in r_AllMenus)
            {
                descriptionOfMenu.AppendLine(string.Format("{0} -> {1}", optionInMenu, currentItem.CurrentTitle));
                optionInMenu++;
            }
            descriptionOfMenu.AppendLine("--------------------------");

            return descriptionOfMenu.ToString();
        }
    }
}