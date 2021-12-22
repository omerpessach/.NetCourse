using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Models;
using Ex03.GarageLogic.Enums;

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
                m_CurrentChoice = (eMenuOptions)UIHelper.GetUserInputToMenuOption();
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
            licenceID = Console.ReadLine();
            if (!r_GarageManger.isVehicalExsistInGarage(licenceID))
            {
                r_GarageManger.AddNewCar(licenceID, createGarageVehical(licenceID));
            }

        }

        private GarageVehical createGarageVehical(string i_licenceID)
        {
            PersonInfo newOwner;
            eVehicalType chosenVehicalType;

            createNewOwner(out newOwner);
            getVehicalType(out chosenVehicalType);
            VehicalFactory.MakeVehicle(chosenVehicalType, newOwner, i_licenceID, askForMoreDataAccordingToVehicalType(chosenVehicalType));
        }

        private List<string> askForMoreDataAccordingToVehicalType(eVehicalType i_chosenVehicalType)
        {
            List<string> requiredData = new List<string>();
            switch(i_chosenVehicalType)
            {
                case eVehicalType.ElectircCar:
                    
                        break;
                case eVehicalType.FuelCar:
                    break;
                case eVehicalType.FuelMotocycle:
                    break;
                case eVehicalType.ElectricMotocycle:
                    break;
                case eVehicalType.Truck:
                    break;
            }

            return requiredData;
        }
        private static void getVehicalType(out eVehicalType o_ChoseVehicalType)
        {
            string userChoiceForVehicalType = string.Empty;
            int indexVehicalType = 1;
            bool isValidType = false;
            int inputNumber = 0;

            while (!isValidType)
            {
                Console.Clear();
                foreach (string vehicalType in Enum.GetNames(typeof(eVehicalType)))
                {
                    Console.WriteLine("please enter" + indexVehicalType + "for" + vehicalType);
                    indexVehicalType++;
                }
                userChoiceForVehicalType = Console.ReadLine();
                if (int.TryParse(userChoiceForVehicalType, out inputNumber))
                {
                    if (inputNumber >= 1 && inputNumber <= Enum.GetNames(typeof(eVehicalType)).Length)
                    {
                        isValidType = true;
                    }
                    else
                    {
                        Console.WriteLine(@"the number you have enterd: {0}, is out of range", inputNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! please enter intger only!");
                }
            }

            o_ChoseVehicalType = (eVehicalType)Enum.Parse(typeof(eVehicalType), userChoiceForVehicalType);
        }
        private static void createNewOwner(out PersonInfo o_NewOwner)
        {
            string ownerName, phoneNumber;
            Console.WriteLine("Please enter your name: ");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please enter your phone number. Integers Only: ");
            phoneNumber = Console.ReadLine();
            o_NewOwner = new PersonInfo(ownerName, phoneNumber);
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


    }
}
