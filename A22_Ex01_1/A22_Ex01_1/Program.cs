using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex01_1
{
    class Program
    {
        static void Main()
        {
            Input();
            Input();
            Input();
            Input();
        }

        static int Input()
        {
            string inputRequest = "Please enter number in binary format";
            Console.WriteLine("Please enter number in binary format");
            string userInput = Console.ReadLine();

            while (userInput.Length == 0 && (!userInput.Contains("0") || !userInput.Contains("1")))
            {
                Console.WriteLine($"The correct input is wrong, please try again\n {inputRequest}");
                userInput = Console.ReadLine();
            }

            int convertedNumber = Convert.ToInt32(userInput, 2);
            return convertedNumber;
        }

        static int ConvertStringToDecimelNumber(string i_str2Dec)
        {
            double convertedDecNumber = 0;

            for(int i = 0; i< i_str2Dec.Length; i++)
            {
                if(i_str2Dec[i] ==  '1')
                {
                    convertedDecNumber += Math.Pow(2, 7 - i - 1);
                }
            }
            return (int)convertedDecNumber;
        }

        static bool 
    }
}
