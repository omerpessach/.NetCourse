using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Models;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        public readonly GarageManager r_GarageManger = new GarageManager();
        private eMenuOptions m_CurrentChoice;

        public void RunApp()
        {
            bool exitProgram = false;

            Console.WriteLine("Welecom to our Garage!");
            do
            {
                DisplayMenuToUser();
                m_CurrentChoice = (eMenuOptions)getUserInput();
                switch (m_CurrentChoice)
                {
                    case eMenuOptions.AddNewVehical:
                        AddNewVehical();
                        break;
                    case eMenuOptions.GetLicencesIDsFilterByStatus:
                        GetLicencesIDsFilterByStatus();
                        break;
                    case eMenuOptions.ChangeVehicalStatus:
                        ChangeVehicalStatus();
                        break;
                    case eMenuOptions.FillAirToMax:
                        FillAirToMax();
                        break;
                    case eMenuOptions.FuelCar:
                        FuelCar();
                        break;
                    case eMenuOptions.ChargeCar:
                        ChargeCar();
                        break;
                    case eMenuOptions.GetAllVehicalDetails:
                        GetAllVehicalDetails();
                        break;
                    case eMenuOptions.Exit:
                        exitProgram = true;
                        break;
                }

            }
            while (!exitProgram);
        }
        private void AddNewVehical()
        {
            string licenceID;
            Console.WriteLine("please insert license ID");
            Console.ReadLine();
            licenceID = getValidInput();
            if (!r_GarageManger.isVehicalExsistInGarage(licenceID))
            {
                r_GarageManger.AddNewCar(licenceID, createGarageVehical());
            }

        }

        private GarageVehical createGarageVehical()
        {
            Console.WriteLine("please enter the type of vehical you want from the list");

        }

        private string getOwnerPhoneNumber()
        {
            return "";
        }

        private string getOwnerName()
        {
            return "";
        }

        private string getValidInput()
        {
            Console.WriteLine("please insert license ID");
            Console.ReadLine();

            return "";
        }

        private void GetAllVehicalDetails()
        {
            throw new NotImplementedException();
        }

        private void ChargeCar()
        {
            throw new NotImplementedException();
        }

        private void FuelCar()
        {
            throw new NotImplementedException();
        }

        private void FillAirToMax()
        {
            throw new NotImplementedException();
        }

        private void ChangeVehicalStatus()
        {
            throw new NotImplementedException();
        }

        private void GetLicencesIDsFilterByStatus()
        {
            throw new NotImplementedException();
        }

        public static void DisplayMenuToUser()
        {
            string MenuOptions = string.Format(
                @"Which opartion would you like to execute?
press 1 - add new vehicle to garage
press 2 - show license plates of the vehicles in the garage
press 3 - change vehicle status in the gargage
press 4 - fiil air of tiers to max
press 5 - fule a vehicle
press 6 - charge a vehicle
press 7 - desplay vehicale information
press 8 - exit application");
            Console.WriteLine(MenuOptions);
        }

        public static int getUserInput()
        {
            string userChoiceAsString;
            bool isValidInput = false;
            int amountOfMenuOptions = Enum.GetNames(typeof(eMenuOptions)).Length;
            int userChoiceAsInt = 0;

            do
            {
                Console.WriteLine("please enter your choice");
                userChoiceAsString = Console.ReadLine();
                isValidInput = int.TryParse(userChoiceAsString, out userChoiceAsInt);
                if ((userChoiceAsInt >= 1 && userChoiceAsInt <= amountOfMenuOptions) && isValidInput)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine(@"the input {0} you have entered is invalid", userChoiceAsString);
                }
            }
            while (!isValidInput);

            return userChoiceAsInt;
        }
    }
}
