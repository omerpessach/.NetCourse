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
            int maxNumber = 0;
            int minNumber = int.MaxValue;
            double avgOnes;
            double avgZeros;

            for (int i = 0; i < 4; i++)
            {
                Input(ref numberOfOnesInAllNumbers, ref numberOfZerosInAllNumbers, ref countOfNumbersThatPowOfTwo, ref maxNumber, ref minNumber);
            }

            avgOnes = numberOfOnesInAllNumbers / 4;
            avgZeros = numberOfZerosInAllNumbers / 4;
            Console.WriteLine(string.Format("Avg of ones is {0}", avgOnes));
            Console.WriteLine(string.Format("Avg of zeros is {0} ", avgZeros));
            Console.WriteLine(string.Format("Count of numbers that pow of 2 {0}", countOfNumbersThatPowOfTwo));
            Console.WriteLine(string.Format("The amount of numbers that represent increasing sequence {0}"));
            Console.WriteLine(string.Format("The max number is {0}", maxNumber));
            Console.WriteLine(string.Format("The min number is {0}", minNumber));
        }

        private static int Input(ref int io_NumberOfOnesInAllNumbers, ref int io_NumberOfZerosInAllNumbers, ref int io_CountOfNumbersThatPowOfTwo, ref int io_MaxNumber, ref int io_MinNumber)
        {
            string inputRequest = "Please enter number in binary format";
            string userInput;
            int numberOfOnes;
            int numberOfZeros;
            int convertedNumber;

            Console.WriteLine(inputRequest);
            userInput = Console.ReadLine();
            while (userInput.Length != 8 || (!userInput.Contains("0") || !userInput.Contains("1")))
            {
                Console.WriteLine(string.Format("The input is wrong, please try again\n {0}", inputRequest));
                userInput = Console.ReadLine();
            }

            numberOfOnes = userInput.Split('1').Length - 1;
            numberOfZeros = userInput.Split('0').Length - 1;
            io_NumberOfOnesInAllNumbers += numberOfOnes;
            io_NumberOfZerosInAllNumbers += numberOfZeros;
            if (numberOfOnes == 1)
            {
                io_CountOfNumbersThatPowOfTwo++;
            }

            convertedNumber = ConvertStringToDecimelNumber(userInput);
            if (io_MaxNumber < convertedNumber)
            {
                io_MaxNumber = convertedNumber;
            }

            if (io_MinNumber > convertedNumber)
            {
                io_MinNumber = convertedNumber;
            }

            return convertedNumber;
        }

        private static int ConvertStringToDecimelNumber(string i_str2Dec)
        {
            double convertedDecNumber = 0;

            for (int i = 0; i < i_str2Dec.Length; i++)
            {
                if (i_str2Dec[i] == '1')
                {
                    convertedDecNumber += Math.Pow(2, 7 - i - 1);
                }
            }

            return (int)convertedDecNumber;
        }

        private static bool DoseTheNumberRepresentIncreasingSequence(int i_DecNumber)
        {
            string NumberToString = i_DecNumber.ToString();
            bool IncreasingSequence = true;
            for (int i = 0; i < NumberToString.Length && IncreasingSequence == true; ++i)
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
