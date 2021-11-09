using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex01_1
{
    class Program
    {
        static void Main()
        {
            int numberOfOnes = 0;
            int numberOfZero = 0;
            Input(ref numberOfOnes, ref numberOfZero);
            Input(ref numberOfOnes, ref numberOfZero);
            Input(ref numberOfOnes, ref numberOfZero);
            Input(ref numberOfOnes, ref numberOfZero);
            double avgOnes = numberOfOnes / 4;
            double avgZeros = numberOfZero / 4;
            Console.WriteLine($"avg of ones is {avgOnes}");
            Console.WriteLine($"avg of zeros is {avgZeros}");
        }

        static int Input(ref int numberOfOnes, ref int numberOfZeros)
        {
            string inputRequest = "Please enter number in binary format";
            Console.WriteLine("Please enter number in binary format");
            string userInput = Console.ReadLine();

            while (userInput.Length != 8 || (!userInput.Contains("0") || !userInput.Contains("1")))
            {
                Console.WriteLine($"The correct input is wrong, please try again\n {inputRequest}");
                userInput = Console.ReadLine();
            }

            numberOfOnes += userInput.Split('1').Length - 1;
            numberOfZeros += userInput.Split('0').Length - 1;

            int convertedNumber = Convert.ToInt32(userInput, 2);
            return convertedNumber;
        }
    }
}
