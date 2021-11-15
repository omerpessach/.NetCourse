using System;
using System.Collections.Generic;
using System.Text;

namespace A22_Ex01_2
{
    public class Program
    {
        static void Main()
        {
            PrintHourGlass();
        }

        public static void PrintHourGlass(int i_Height = 5, int i_Level = 0)
        {
            StringBuilder clockBuilder = new StringBuilder();

            PrintHourGlassRecursive(clockBuilder, i_Height, i_Level);
            Console.Write(clockBuilder.ToString());
        }

        private static void PrintHourGlassRecursive(StringBuilder clockBuilder, int i_Height, int i_Level)
        {
            string line = GetLevelHourGlass(i_Height, i_Level++);

            clockBuilder.AppendLine(line);
            if (i_Height > 2)
            {
                PrintHourGlassRecursive(clockBuilder, i_Height - 2, i_Level);
                clockBuilder.AppendLine(line);
            }
        }

        private static string GetLevelHourGlass(int i_Height, int i_Level)
        {
            return PrintSingleCharNTimesInARow(' ', i_Level) + PrintSingleCharNTimesInARow('*', i_Height);
        }

        private static string PrintSingleCharNTimesInARow(char i_Sign, int i_TimesToPrint)
        {
            return new string(i_Sign, i_TimesToPrint);
        }
    }
}
