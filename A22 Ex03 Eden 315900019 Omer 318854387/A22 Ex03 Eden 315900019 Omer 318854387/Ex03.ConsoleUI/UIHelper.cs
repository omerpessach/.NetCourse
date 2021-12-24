using Ex03.GarageLogic.Exceptions;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex03.ConsoleUI
{
    public static class UIHelper
    {
        private const string k_TryAgainMsg = "Please try again";
        private const string k_RegexAlphaOnly = "^[a-zA-Z]+$";
        private const string k_RegexDigitOnly = "^[0-9]+$";

        public static int        GetUserInputToMenuOption()
        {
            string userChoiceAsString;
            bool isValidInput = false;
            int amountOfMenuOptions = Enum.GetNames(typeof(eMenuOptions)).Length;
            int userChoiceAsInt = 0;

            do
            {
                Console.WriteLine("Please enter your choice");
                userChoiceAsString = Console.ReadLine();
                isValidInput = int.TryParse(userChoiceAsString, out userChoiceAsInt);
                if ((userChoiceAsInt >= 1 && userChoiceAsInt <= amountOfMenuOptions) && isValidInput)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine(string.Format("The input {0} you have entered is invalid", userChoiceAsString));
                }
            }
            while (!isValidInput);

            return userChoiceAsInt;
        }

        public static bool       IsStringValid(string i_Input)
        {
            return !(string.IsNullOrEmpty(i_Input) || i_Input.Replace(" ", "").Length == 0);
        }

        public static string     GetNotEmptyOrWhiteSpacesString(string i_RequestMsg)
        {
            string userInput;

            Console.WriteLine(i_RequestMsg);
            userInput = Console.ReadLine();
            while (!IsStringValid(userInput))
            {
                Console.WriteLine(string.Format(@"The string isnt valid.
{0}", i_RequestMsg));
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        public static float      GetFloatFromUser(string i_RequestMsg)
        {
            float number;
            string userInput;

            Console.WriteLine(i_RequestMsg);
            userInput = Console.ReadLine();
            while (!float.TryParse(userInput, out number) || number < 0)
            {
                Console.WriteLine(string.Format(@"You didnt enter a posstive number
{0}
{1}",k_TryAgainMsg, i_RequestMsg));
                userInput = Console.ReadLine();
            }

            return number;
        }

        public static void       HandleValueOutOfRangeException(ValueOutOfRangeException i_Ex)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(i_Ex.Message);
            output.AppendLine(string.Format("The range is between {0} to {1}", i_Ex.MinValue, i_Ex.MaxValue));
            output.AppendLine(k_TryAgainMsg);
            Console.WriteLine(output);
        }

        public static void       HandleGenericInfoException(Exception i_Ex)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(i_Ex.Message);
            output.AppendLine(k_TryAgainMsg);
            Console.WriteLine(output);
        }

        public static T          GetEnumFromUser<T>(string i_RequestMsg)
        {
            string userInput;
            T returnType;

            Console.WriteLine(i_RequestMsg);
            PrintEnumOptions<T>();
            userInput = Console.ReadLine();
            while (!TryParseStringToEnum<T>(userInput, out returnType))
            {
                Console.WriteLine("Not valid value, Please select number from the list");
                PrintEnumOptions<T>();
                userInput = Console.ReadLine();
            }

            return returnType;
        }

        private static bool      TryParseStringToEnum<T>(string i_Input, out T o_requestedEnum)
        {
            int inputAsInt;
            bool hasSucceed;

            o_requestedEnum = default;
            hasSucceed = int.TryParse(i_Input, out inputAsInt) && Enum.IsDefined(typeof(T), inputAsInt);
            if (hasSucceed)
            {
                o_requestedEnum = (T)Enum.ToObject(typeof(T), inputAsInt);
            }

            return hasSucceed;
        }

        public static void       PrintEnumOptions<T>()
        {
            foreach (string name in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("Enter {1:D} for {0}", name, Enum.Parse(typeof(T), name));
            }
        }

        public static string     GetStringContainsOnlyLetters(string i_GuideMsg)
        {
            string input;

            Console.WriteLine(i_GuideMsg);
            input = Console.ReadLine();

            while (!IsAlpha(input))
            {
                Console.WriteLine(@"Invalid name
{0}",k_TryAgainMsg);
                input = Console.ReadLine();
            }

            return input;
        }

        public static string     GetStringContainsOnlyDigits(string i_GuideMsg)
        {
            string input;

            Console.WriteLine(i_GuideMsg);
            input = Console.ReadLine();

            while (!IsContainsOnlyDigits(input))
            {
                Console.WriteLine(@"Invalid number
{0}",k_TryAgainMsg);
                input = Console.ReadLine();
            }

            return input;
        }

        public static bool       IsAlpha(string i_Input)
        {
            return Regex.IsMatch(i_Input, k_RegexAlphaOnly);
        }

        public static bool       IsContainsOnlyDigits(string i_Input)
        {
            return Regex.IsMatch(i_Input, k_RegexDigitOnly);
        }

        public static bool       DoesWantToGoBackToMenu(string i_SymbolToGoBackToMenu)
        {
            bool doesWannaGoBack = false;

            Console.WriteLine(string.Format(@"To go back to the menu press {0}
to try again enter anything", i_SymbolToGoBackToMenu));
            doesWannaGoBack = Console.ReadLine().Equals(i_SymbolToGoBackToMenu);
            if (doesWannaGoBack)
            {
                Console.Clear();
            }

            return doesWannaGoBack;
        }
    }
}
