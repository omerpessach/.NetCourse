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
            Console.WriteLine(string.Format("The time now is {0}", DateTime.Now));
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
