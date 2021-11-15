using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex01_1
{
    class Program
    {
        static void Main()
        {
            AnalyzeBinaryNumbers();
        }

        private static void AnalyzeBinaryNumbers()
        {
            int numberOfOnesInAllNumbers = 0;
            int numberOfZerosInAllNumbers = 0;
            int countOfNumbersThatPowOfTwo = 0;
            int maxNumber;
            int minNumber;
            double avgOnes;
            double avgZeros;
            string numberAAsString;
            string numberBAsString;
            string numberCAsString;
            string numberDAsString;
            int numberA;
            int numberB;
            int numberC;
            int numberD;
            int countOfIncreasingSequencesNumbers;

            numberAAsString = InputNumberFromUser();
            numberBAsString = InputNumberFromUser();
            numberCAsString = InputNumberFromUser();
            numberDAsString = InputNumberFromUser();

            numberOfOnesInAllNumbers = GetNumberOfSignalInAllNumbers('1', numberAAsString, numberBAsString, numberCAsString, numberDAsString);
            numberOfZerosInAllNumbers = GetNumberOfSignalInAllNumbers('0', numberAAsString, numberBAsString, numberCAsString, numberDAsString);
            avgOnes = numberOfOnesInAllNumbers / 4;
            avgZeros = numberOfZerosInAllNumbers / 4;
            countOfNumbersThatPowOfTwo = CountOfNumbersThatPowOfTwo(numberAAsString, numberBAsString, numberCAsString, numberDAsString);
            numberA = ConvertStringToDecimelNumber(numberAAsString);
            numberB = ConvertStringToDecimelNumber(numberBAsString);
            numberC = ConvertStringToDecimelNumber(numberCAsString);
            numberD = ConvertStringToDecimelNumber(numberDAsString);
            minNumber = GetMinNumberFromArray(numberA, numberB, numberC, numberD);
            maxNumber = GetMaxNumberFromArray(numberA, numberB, numberC, numberD);
            countOfIncreasingSequencesNumbers = CountOfIncreasingSequencesNumbers(numberA, numberB, numberC, numberD);
            Console.WriteLine(string.Format("Avg of ones is {0}", avgOnes));
            Console.WriteLine(string.Format("Avg of zeros is {0}", avgZeros));
            Console.WriteLine(string.Format("Count of numbers that pow of 2 {0}", countOfNumbersThatPowOfTwo));
            Console.WriteLine(string.Format("The max number is {0}", maxNumber));
            Console.WriteLine(string.Format("The min number is {0}", minNumber));
            Console.WriteLine(string.Format("Count of increasing sequences numbers is {0}", countOfIncreasingSequencesNumbers));
        }

        private static string InputNumberFromUser()
        {
            string inputRequest = "Please enter number in binary format";
            string userInput;

            Console.WriteLine(inputRequest);
            userInput = Console.ReadLine();
            while ((userInput.Length != 8 || (!userInput.Contains("0") || !userInput.Contains("1"))) && (userInput != "11111111") && (userInput != "00000000"))
            {
                Console.WriteLine(string.Format("The input is wrong, please try again\n {0}", inputRequest));
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static int GetNumberOfSignalInAllNumbers(char i_Signal, params string[] i_DecNumbers)
        {
            int numberOfSignal = 0;

            foreach (string item in i_DecNumbers)
            {
                numberOfSignal += GetNumberOfSignalInSingleNumber(i_Signal, item);
            }

            return numberOfSignal;
        }

        private static int GetNumberOfSignalInSingleNumber(char i_Signal, string i_DecNumber)
        {
            return i_DecNumber.Split(i_Signal).Length - 1;
        }

        private static int CountOfNumbersThatPowOfTwo(params string[] i_DecNumbers)
        {
            int countOfNumbersThatPowOfTwo = 0;

            foreach (string item in i_DecNumbers)
            {
                if (GetNumberOfSignalInSingleNumber('1', item) == 1)
                {
                    countOfNumbersThatPowOfTwo++;
                }
            }

            return countOfNumbersThatPowOfTwo;
        }

        private static int GetMinNumberFromArray(params int[] i_DecNumbers)
        {
            int min = int.MaxValue;

            foreach (int item in i_DecNumbers)
            {
                if (item < min)
                {
                    min = item;
                }
            }

            return min;
        }

        private static int GetMaxNumberFromArray(params int[] i_DecNumbers)
        {
            int max = int.MinValue;

            foreach (int item in i_DecNumbers)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        private static int ConvertStringToDecimelNumber(string i_str2Dec)
        {
            double convertedDecNumber = 0;

            for (int i = 0; i < i_str2Dec.Length; ++i)
            {
                if (i_str2Dec[i] == '1')
                {
                    convertedDecNumber += Math.Pow(2, 8 - i - 1);
                }
            }

            return (int)convertedDecNumber;
        }

        private static bool DoseTheNumberRepresentIncreasingSequence(int i_DecNumber)
        {
            string NumberToString = i_DecNumber.ToString();
            bool IncreasingSequence = true;
            for (int i = 0; i < (NumberToString.Length - 1) && IncreasingSequence == true; ++i)
            {
                if ((int)NumberToString[i] >= (int)NumberToString[i + 1])
                {
                    IncreasingSequence = false;
                }
            }
            return IncreasingSequence;
        }

        private static int CountOfIncreasingSequencesNumbers(params int[] i_DecNumbers)
        {
            int AmountOfIncreasingSequencesNumbers = 0;

            foreach (int DecNumber in i_DecNumbers)
            {
                if (DoseTheNumberRepresentIncreasingSequence(DecNumber) == true)
                {
                    AmountOfIncreasingSequencesNumbers++;
                }
            }

            return AmountOfIncreasingSequencesNumbers;
        }
    }
}