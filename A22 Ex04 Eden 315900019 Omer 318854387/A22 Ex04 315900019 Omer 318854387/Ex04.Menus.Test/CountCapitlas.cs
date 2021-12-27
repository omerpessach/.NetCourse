using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CountCapitlas : IActionListner
    {
        public void ReportAction()
        {
            Console.WriteLine("please enter a sentence");
            Console.WriteLine(string.Format("There are {0} upper-case letters in the given sentence.", amountOfCapitalsInString(Console.ReadLine())));
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private int amountOfCapitalsInString(string i_CurrentSentence)
        {
            int amountOfCapitalLetters = 0;

            foreach (char currentChar in i_CurrentSentence)
            {
                if (char.IsUpper(currentChar))
                {
                    amountOfCapitalLetters++;
                }

            }

            return amountOfCapitalLetters;
        }
    }
}
