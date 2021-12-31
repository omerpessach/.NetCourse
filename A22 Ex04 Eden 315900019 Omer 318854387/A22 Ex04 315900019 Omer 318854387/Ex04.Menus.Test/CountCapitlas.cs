using Ex04.Menus.Interfaces;
using System;
using System.Text;

namespace Ex04.Menus.Test
{
    internal class CountCapitlas : IActionListner
    {
        public void ReportAction()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Please enter a sentence");
            output.AppendLine(string.Format("There are {0} upper-case letters in the given sentence.", getAmountOfCapitalsInString(Console.ReadLine())));
            output.AppendLine("Press any key to continue.");
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private int getAmountOfCapitalsInString(string i_Sentence)
        {
            int amountOfCapitalLetters = 0;

            foreach (char currentChar in i_Sentence)
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
