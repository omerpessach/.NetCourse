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

        public static void HourGlass(int i_StarCount = 5, int i_SpaceFromStart = 0)
        {
            if (i_StarCount > 0)
            {
                PrintLevelHourGlass(i_StarCount, i_SpaceFromStart);
                HourGlass(i_StarCount - 2, i_SpaceFromStart + 1);
                if (i_StarCount > 1)
                {
                    PrintLevelHourGlass(i_StarCount, i_SpaceFromStart);
                }
            }
        }

        public static void PrintLevelHourGlass(int i_StarCount, int i_SpaceFromStart)
        {
            PrintSingleCharNTimesInARow(' ', i_SpaceFromStart);
            PrintSingleCharNTimesInARow('*', i_StarCount);
            PrintSingleCharNTimesInARow(' ', i_SpaceFromStart);
            Console.WriteLine();
        }

        public static void PrintSingleCharNTimesInARow(char i_Sign, int i_TimesToPrint)
        {
            if (i_TimesToPrint > 0)
            {
                Console.Write(i_Sign);
                PrintSingleCharNTimesInARow(i_Sign, i_TimesToPrint - 1);
            }
        }
    }
}
