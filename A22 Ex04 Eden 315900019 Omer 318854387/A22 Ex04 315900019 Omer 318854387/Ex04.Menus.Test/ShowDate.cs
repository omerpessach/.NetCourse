using Ex04.Menus.Interfaces;
using System;
using System.Text;

namespace Ex04.Menus.Test
{
    internal class ShowDate : IActionListner
    {
        public void ReportAction()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format("The day today is {0}", DateTime.Now.Date.ToShortDateString()));
            output.AppendLine("Press any key to continue.");
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
