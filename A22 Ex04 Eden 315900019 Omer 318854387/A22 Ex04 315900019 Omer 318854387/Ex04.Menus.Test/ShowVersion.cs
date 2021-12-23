using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowVersion : IActionListner
    {
        public void ReportAction()
        {
            Console.WriteLine("Version: 22.1.4.8930");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
