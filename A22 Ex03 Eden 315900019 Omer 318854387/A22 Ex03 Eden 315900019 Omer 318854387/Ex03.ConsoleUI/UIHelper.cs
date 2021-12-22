using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class UIHelper
    {
        public static int GetUserInputToMenuOption()
        {
            string userChoiceAsString;
            bool isValidInput = false;
            int amountOfMenuOptions = Enum.GetNames(typeof(eMenuOptions)).Length;
            int userChoiceAsInt = 0;

            do
            {
                Console.WriteLine("please enter your choice");
                userChoiceAsString = Console.ReadLine();
                isValidInput = int.TryParse(userChoiceAsString, out userChoiceAsInt);
                if ((userChoiceAsInt >= 1 && userChoiceAsInt <= amountOfMenuOptions) && isValidInput)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine(@"the input {0} you have entered is invalid", userChoiceAsString);
                }
            }
            while (!isValidInput);

            return userChoiceAsInt;
        }
    }
}
