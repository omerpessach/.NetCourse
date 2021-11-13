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
            InputUser();
        }
        private static void InputUser()
        {
            string inputRequest = "Please enter a 7 digit positive number.";
            Console.WriteLine("Please enter a 7 digit positive number.");
            string sevenDigitNumber = Console.ReadLine();
            while (!IsValidNumber(sevenDigitNumber))
            {
                Console.WriteLine($"the number you entered isn't valid, please try again.\n{inputRequest}");
                sevenDigitNumber = Console.ReadLine();
            }
            NumberInvestigation(sevenDigitNumber);

        }
        private static bool IsValidNumber(string i_NumberFromUser)
        {
            bool validNumber = true;

            if (i_NumberFromUser.Length != 7)
            {
                validNumber = false;
            }
            else
            {
                for (int i = 0; i < i_NumberFromUser.Length && validNumber == true; ++i)
                {
                    if (i_NumberFromUser[i] < '0' || i_NumberFromUser[i] > '9')
                    {
                        validNumber = false;
                    }
                }
            }

            return validNumber;
        }
        private static void NumberInvestigation(string i_SevenDigitNumber)
        {
            char largestDigit = '0';
            int averageDigitsResult = 0;
            int divisionBy3Result = 0;
            int SmallerThanUnityResult = 0;

            largestDigit = LargestDigitInTheNumber(i_SevenDigitNumber);
            AverageDigits(i_SevenDigitNumber, ref averageDigitsResult);
            AmountOfDigitsDiviedByThree(i_SevenDigitNumber, ref divisionBy3Result);
            AmountOfSmallerDigitsThanUnity(i_SevenDigitNumber, ref SmallerThanUnityResult);
            string investigationResults = string.Format(@"The Largest digit in the number is: {0}.
The average of the current digits is: {1}.
The number of digits which are divided by three is: {2}.
The amount of digits which is smaller then the unity is: {3}.", largestDigit, averageDigitsResult, divisionBy3Result, SmallerThanUnityResult);
            Console.WriteLine(investigationResults);
        }
        private static char LargestDigitInTheNumber(string i_SevenDigitNumber)
        {
            return i_SevenDigitNumber.Max(x => x);
        }
        private static void AverageDigits(string i_SevenDigitNumber, ref int io_AverageaResult)
        {
            int sumOfDigits = 0;

            foreach (char digit in i_SevenDigitNumber)
            {
                sumOfDigits += (int)char.GetNumericValue(digit);
            }

            io_AverageaResult = (sumOfDigits / 7);
        }
        private static void AmountOfDigitsDiviedByThree(string i_SevenDigitNumber, ref int io_AmountOfDivisionResult)
        {
            foreach (char digit in i_SevenDigitNumber)
            {
                if ((int)digit % 3 == 0)
                {
                    io_AmountOfDivisionResult++;
                }
            }
        }
        private static void AmountOfSmallerDigitsThanUnity(string i_SevenDigitNumber, ref int io_SmallerThanUnityResult)
        {
            char unityDigitInNumber = i_SevenDigitNumber[6];

            foreach (char digit in i_SevenDigitNumber)
            {
                if (digit < unityDigitInNumber)
                {
                    io_SmallerThanUnityResult++;
                }
            }
        }
    }
}
