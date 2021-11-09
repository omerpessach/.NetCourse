using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex01_1
{
    class Program
    {
        static void Main()
        {
            int num1, num2, num3, num4;
            num1 = GetInputFromUser();
            num2 = GetInputFromUser();
            num3 = GetInputFromUser();
            num4 = GetInputFromUser();
        }

        static int GetInputFromUser()
        {
            Console.WriteLine("Please enter number in a binary format");
            string s = Console.ReadLine();

            while (s.Length == 0 || (!s.Contains("0") || !s.Contains("1")))
            {
                Console.WriteLine("The input isnt in the correct format please try again\n enter number in a binary format");
                s = Console.ReadLine();
            }

            int output = Convert.ToInt32(s, 2);
            return output;
        }
    }
}
