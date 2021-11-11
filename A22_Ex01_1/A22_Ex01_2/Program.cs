using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex01_2
{
    public class Program
    {
        static void Main()
        {
            HourGlass();
        }

        public static void HourGlass(int starCount = 5, int spaceFromStart = 0)
        {
            if (starCount > 0)
            {
                PrintLevelHourGlass(starCount, spaceFromStart);

                HourGlass(starCount - 2, spaceFromStart + 1);

                if (starCount > 1)
                {
                    PrintLevelHourGlass(starCount, spaceFromStart);
                }
            }
        }

        public static void PrintLevelHourGlass(int starCount, int spaceFromStart)
        {
            PrintSingleCharNTimesInARow(' ', spaceFromStart);
            PrintSingleCharNTimesInARow('*', starCount);
            PrintSingleCharNTimesInARow(' ', spaceFromStart);
            Console.WriteLine();
        }

        public static void PrintSingleCharNTimesInARow(char sign, int n)
        {
            if (n > 0)
            {
                Console.Write(sign);
                PrintSingleCharNTimesInARow(sign, n - 1);
            }
        }
    }
}
