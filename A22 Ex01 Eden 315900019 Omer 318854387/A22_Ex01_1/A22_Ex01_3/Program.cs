using System;
using System.Collections.Generic;
using System.Text;
using Ex2 = A22_Ex01_2;

namespace A22_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            PrintHourGlass();
        }

        private static void PrintHourGlass()
        {
            int inputFromUserAsUInt;

            inputFromUserAsUInt = GetInputFromUser();
            Ex2.Program.PrintHourGlass(inputFromUserAsUInt);
        }

        private static int GetInputFromUser()
        {
            int userInputAsNumber;
            string inputRequest = "Please enter the height of the hour Glass";
            string userInput;

            Console.WriteLine(inputRequest);
            userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out userInputAsNumber) || userInputAsNumber < 0)
            {
                Console.WriteLine(string.Format("The input is wrong, please try again\n {0}", inputRequest));
                userInput = Console.ReadLine();
            }

            return userInputAsNumber;
        }
    }
}