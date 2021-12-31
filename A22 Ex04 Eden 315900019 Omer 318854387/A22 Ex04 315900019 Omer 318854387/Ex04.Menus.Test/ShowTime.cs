using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowTime : IActionListner
    {
        public void ReportAction()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format("The time now is {0:t}", DateTime.Now));
            output.AppendLine("Press any key to continue.");
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
