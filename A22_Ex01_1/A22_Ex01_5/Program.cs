using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex01_5
{
    class Program
    {
        static void Main()
        {
            GetStaticstics();
        }

        private static void GetStaticstics()
        {
            string recivedNumber = GetInputFromUser();
            NumberInvestigation(recivedNumber);
        }

        private static string GetInputFromUser()
        {
            string inputRequest = "Please enter a 7 digit positive number.";
            string userInput;
            uint userInputUInt;

            Console.WriteLine("Please enter a 7 digit positive number.");
            userInput = Console.ReadLine();
            while (!uint.TryParse(userInput, out userInputUInt) || userInputUInt.ToString().Length != 7)
            {
                Console.WriteLine(string.Format(@"the number you entered isn't valid, please try again.\n{0}", inputRequest));
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static void NumberInvestigation(string i_SevenDigitNumber)
        {
            char largestDigit = '0';
            float averageDigitsResult = 0;
            int divisionBy3Result = 0;
            int smallerThanUnityResult = 0;
            string investigationResults;

            largestDigit = LargestDigitInTheNumber(i_SevenDigitNumber);
            averageDigitsResult = AverageDigits(i_SevenDigitNumber);
            divisionBy3Result = AmountOfDigitsDiviedByThree(i_SevenDigitNumber);
            smallerThanUnityResult = AmountOfSmallerDigitsThanUnity(i_SevenDigitNumber);
            investigationResults = string.Format(@"The Largest digit in the number is: {0}.
The average of the current digits is: {1}.
The number of digits which are divided by three is: {2}.
The amount of digits which is smaller then the unity is: {3}.", largestDigit, averageDigitsResult, divisionBy3Result, smallerThanUnityResult);
            Console.WriteLine(investigationResults);
        }

        private static char LargestDigitInTheNumber(string i_SevenDigitNumber)
        {
            return i_SevenDigitNumber.Max(x => x);
        }

        private static float AverageDigits(string i_SevenDigitNumber)
        {
            return i_SevenDigitNumber.Sum(c => (float)c - (float)'0') / 7;
        }

        private static int AmountOfDigitsDiviedByThree(string i_SevenDigitNumber)
        {
            return i_SevenDigitNumber.Count(c => (int)(c) % 3 == 0);
        }

        private static int AmountOfSmallerDigitsThanUnity(string i_SevenDigitNumber)
        {
            char unityDigitInNumber = i_SevenDigitNumber[6];

            return i_SevenDigitNumber.Count(c => c < unityDigitInNumber);
        }
    }
}
