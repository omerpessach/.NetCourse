using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Validations
    {
        public static bool IsStringContainsLettersOnly(string i_StringToCheck)
        {
            bool isStringContainsLettersOnly = true;

            for (int i = 0; i < i_StringToCheck.Length && isStringContainsLettersOnly; i++)
            {
                isStringContainsLettersOnly = char.IsLetter(i_StringToCheck[i]);
            }

            return isStringContainsLettersOnly;
        }

        public static bool IsStringContainsSpecCharsOnly(string i_StringToCheck, char[] i_SpecChars)
        {
            bool isStringContainsSpecCharsOnly = true;
            string specChars = new string(i_SpecChars);

            for (int i = 0; i < i_StringToCheck.Length && isStringContainsSpecCharsOnly; i++)
            {
                isStringContainsSpecCharsOnly = specChars.Contains(i_StringToCheck[i].ToString());
            }

            return isStringContainsSpecCharsOnly;
        }
    }
}
