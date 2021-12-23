using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowDate : IActionListner
    {
        public void ReportAction()
        {
            Console.WriteLine(string.Format("The day today is {0}", DateTime.Now.Date.ToShortDateString()));
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
