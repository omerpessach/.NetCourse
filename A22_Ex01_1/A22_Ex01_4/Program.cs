using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            AnalyzeString();
        }

        private static void AnalyzeString()
        {
            int numberFromTheString = 0;
            bool divisionBy4Result = false;
            bool isNumber = false;
            int amountUppercaseResult = 0;
            string inputRequest = "Please insert a 6-character string.The string should contain only numbers or letters but not combined";
            string sixCharacterString;

            Console.WriteLine("Please insert a 6-character string.");
            sixCharacterString = Console.ReadLine();
            while (!IsValidNumber(sixCharacterString, ref numberFromTheString, ref isNumber))
            {
                Console.WriteLine(string.Format("the string you entered isn't valid, please try again.\n{0}", inputRequest));
                sixCharacterString = Console.ReadLine();
            }

            Console.WriteLine(string.Format("Is the string a Palindrome? {0}", IsPalindrome(sixCharacterString) ? "YES" : "NO"));
            if (isNumber)
            {
                divisionBy4Result = DivideByFourCheck(numberFromTheString);
                Console.WriteLine(string.Format("Is the number divided By 4? {0}", divisionBy4Result ? "YES" : "NO"));
            }
            else
            {
                amountUppercaseResult = AmountOfUppercaseLetters(sixCharacterString);
                Console.WriteLine(string.Format("The Amount of uppercase letters in the sting is: {0}", amountUppercaseResult));
            }
        }

        private static bool IsValidNumber(string i_StringFromUser, ref int io_IntgerFromString, ref bool io_IsNumber)
        {
            bool isValidString = i_StringFromUser.Length == 6;

            io_IsNumber = int.TryParse(i_StringFromUser, out io_IntgerFromString);
            if (isValidString && !io_IsNumber)
            {
                isValidString = i_StringFromUser.All(c => ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')));
            }

            return isValidString;
        }

        private static bool IsPalindrome(string i_InputString, int i_StartPoint = 0, int i_EndPoint = 5)
        {
            bool isTheInputPalindrome = false;

            if (!i_InputString.Any())
            {
                isTheInputPalindrome = false;
            }
            else if (i_StartPoint - i_EndPoint == 1)
            {
                isTheInputPalindrome = true;
            }
            else
            {
                if (i_InputString[i_StartPoint] == i_InputString[i_EndPoint])
                {
                    isTheInputPalindrome = IsPalindrome(i_InputString, i_StartPoint + 1, i_EndPoint - 1);
                }
                else
                {
                    isTheInputPalindrome = false;
                }
            }

            return isTheInputPalindrome;
        }

        private static bool DivideByFourCheck(int i_NumberFromString)
        {
            return i_NumberFromString % 4 == 0;
        }

        private static int AmountOfUppercaseLetters(string i_InputString)
        {
            return i_InputString.Count(c => c >= 'A' && c <= 'Z');
        }
    }
}
