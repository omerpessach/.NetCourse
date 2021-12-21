using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        public static GarageManager s_GarageManger = new GarageManager();

        public static void StartApp()
        {
            bool exitProgram = false; 

            Console.WriteLine("Welecom to our Garage!");
            do
            {
                DisplayMenuToUser();
                
            }
           
        }

        public static void DisplayMenuToUser()
        {
            string MenuOptions = string.Format(
                @"Which opartion would you like to execute?
press 1 - add new vehicle to garage
press 2 - show license plates of the vehicles in the garage
press 3 - change vehicle status in the gargage
press 4 - blow vehicle tiers to maximum
press 5 - fule a vehicle
press 6 - charge a vehicle
press 7 - desplay vehicale information
press 8 - exit application");
            Console.WriteLine(MenuOptions);
        }

        public static void getUserInput()
        {
            bool isValidInput = true;
            string userChoice;

            do
            {
                Console.WriteLine("please enter your choice");
                userChoice = Console.ReadLine();

            }
        }
    }
}
