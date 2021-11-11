using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex01_1
{
    class Program
    {
        static void Main()
        {
            int numberOfOnesInAllNumbers = 0;
            int numberOfZerosInAllNumbers = 0;
            int countOfNumbersThatPowOfTwo = 0;
            int maxNumber = 0;
            int minNumber = int.MaxValue;

            Input(ref numberOfOnesInAllNumbers, ref numberOfZerosInAllNumbers, ref countOfNumbersThatPowOfTwo, ref maxNumber, ref minNumber);
            Input(ref numberOfOnesInAllNumbers, ref numberOfZerosInAllNumbers, ref countOfNumbersThatPowOfTwo, ref maxNumber, ref minNumber);
            Input(ref numberOfOnesInAllNumbers, ref numberOfZerosInAllNumbers, ref countOfNumbersThatPowOfTwo, ref maxNumber, ref minNumber);
            Input(ref numberOfOnesInAllNumbers, ref numberOfZerosInAllNumbers, ref countOfNumbersThatPowOfTwo, ref maxNumber, ref minNumber);
            double avgOnes = numberOfOnesInAllNumbers / 4;
            double avgZeros = numberOfZerosInAllNumbers / 4;
            Console.WriteLine(string.Format("Avg of ones is {0}", avgOnes));
            Console.WriteLine(string.Format("Avg of zeros is {0}", avgZeros));
            Console.WriteLine(string.Format("Count of numbers that pow of 2 {0}", countOfNumbersThatPowOfTwo));
            Console.WriteLine(string.Format("The max number is {0}", maxNumber));
            Console.WriteLine(string.Format("The min number is {0}", minNumber));
            Console.ReadLine();
        }

        static int Input(ref int numberOfOnesInAllNumbers, ref int numberOfZerosInAllNumbers, ref int countOfNumbersThatPowOfTwo, ref int maxNumber, ref int minNumber)
        {
            string inputRequest = "Please enter number in binary format";
            Console.WriteLine(inputRequest);
            string userInput = Console.ReadLine();

            while (userInput.Length != 8 || (!userInput.Contains("0") || !userInput.Contains("1")))
            {
                Console.WriteLine(string.Format("The input is wrong, please try again\n {0}", inputRequest));
                userInput = Console.ReadLine();
            }

            int numberOfOnes = userInput.Split('1').Length - 1;
            int numberOfZeros = userInput.Split('0').Length - 1;
            numberOfOnesInAllNumbers += numberOfOnes;
            numberOfZerosInAllNumbers += numberOfZeros;

            if (numberOfOnes == 1)
            {
                countOfNumbersThatPowOfTwo++;
            }

            int convertedNumber = ConvertStringToDecimelNumber(userInput);

            if (maxNumber < convertedNumber)
            {
                maxNumber = convertedNumber;
            }

            if (minNumber > convertedNumber)
            {
                minNumber = convertedNumber;
            }

            return convertedNumber;
        }

        static int ConvertStringToDecimelNumber(string i_str2Dec)
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

    }
}
