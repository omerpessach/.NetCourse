using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex01_4
{
    class Program
    {
        public static void Main()
        {
            InputUser();
        }
        private static void InputUser()
        {
            int numberFromTheString = 0;
            bool divisionBy4Result = false;
            bool isNumber = false;
            int amountUppercaseResult = 0;
            string inputRequest = "Please insert a 6-character string.The string should contain only numbers or letters but not combined";
            Console.WriteLine("Please insert a 6-character string.");
            string sixCharacterString = Console.ReadLine();
            while (!IsValidNumber(sixCharacterString, ref numberFromTheString, ref isNumber))
            {
                Console.WriteLine($"the string you entered isn't valid, please try again.\n{inputRequest}");
                sixCharacterString = Console.ReadLine();
            }
            Console.WriteLine(string.Format("Is the string a Palindrome? {0}", PalindromeCheck(sixCharacterString) ? "YES" : "NO"));
            if (isNumber == true)
            {
                DivideByFourCheck(numberFromTheString, ref divisionBy4Result);
                Console.WriteLine(string.Format("Is the number divided By 4? {0}", divisionBy4Result ? "YES" : "NO"));
            }
            else
            {
                AmountOfUppercaseLetters(sixCharacterString, ref amountUppercaseResult);
                Console.WriteLine(string.Format("The Amount of uppercase letters in the sting is: {0}", amountUppercaseResult));
            }
        }
        private static bool IsValidNumber(string i_StringFromUser, ref int io_IntgerFromString, ref bool io_IsNumber )
        {
            bool validString = true;
            if (i_StringFromUser.Length != 6)
            {
                validString = false;
            }
            else if (int.TryParse(i_StringFromUser,out io_IntgerFromString))
            {
                io_IsNumber = true; 
            }
            else
            {
                for (int i = 0; i < i_StringFromUser.Length && validString == true; ++i)
                {
                    if (!((i_StringFromUser[i] >= 'A' && i_StringFromUser[i] <= 'Z') || (i_StringFromUser[i] >= 'a' && i_StringFromUser[i] <= 'z')))
                    {
                        validString = false;
                    }
                }
            }
            return validString;
        }
        private static bool PalindromeCheck(string i_InputString)
        {
            int stringLength = i_InputString.Length;
            if(stringLength == 0)
            {
                return true;
            }

            return IsPalindromeRecursive(i_InputString,0,stringLength-1);
        }
        private static bool IsPalindromeRecursive(string i_InputString, int i_StartPoint, int i_EndPoint)
        {
            if (i_StartPoint == i_EndPoint)
            {
                return true;
            }
            if (i_InputString[i_StartPoint] != i_InputString[i_EndPoint])
            {
                return false;
            }
            if (i_StartPoint < i_EndPoint + 1)
            {
                return IsPalindromeRecursive(i_InputString, i_StartPoint + 1, i_EndPoint - 1);
            }
            return true;
        }
        private static void DivideByFourCheck(int i_NumberFromString, ref bool io_IsDividedByFour)
        {
            
            if(i_NumberFromString % 4 == 0)
            {
                io_IsDividedByFour = true;
            }
        }
        private static void AmountOfUppercaseLetters(string i_InputString, ref int io_AmountOfUpperCaseLetters)
        {
            foreach(char singleChar in i_InputString)
            {
                if(singleChar >= 'A' && singleChar <= 'Z')
                {
                    io_AmountOfUpperCaseLetters++;
                }
            }
        }
    }
}
