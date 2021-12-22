using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Models;
using Ex03.GarageLogic.Enums;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        private readonly GarageManager r_GarageManger = new GarageManager();
        private const string k_AskForLicenseID = "Please insert license ID";
        private const string k_LicenseIDNotFoundMsg = "Vehical with license ID: {0} not found in our garage";
        private const string k_Done = "Done!";

        public void RunApp()
        {
            bool exitProgram = false;
            eMenuOptions userChoice;

            Console.WriteLine("Welecom to our Garage!");
            do
            {
                displayMenuToUser();
                userChoice = (eMenuOptions)UIHelper.GetUserInputToMenuOption();
                switch (userChoice)
                {
                    case eMenuOptions.AddNewVehical:
                        {
                            AddNewVehical();
                            break;
                        }
                    case eMenuOptions.GetLicencesIDsFilterByStatus:
                        {
                            getLicencesIDsFilterByStatus();
                            break;
                        }
                    case eMenuOptions.ChangeVehicalStatus:
                        {
                            changeVehicalStatus();
                            break;
                        }
                    case eMenuOptions.FillAirToMax:
                        {
                            fillAirToMax();
                            break;
                        }
                    case eMenuOptions.FuelCar:
                        {
                            fuelCar();
                            break;
                        }
                    case eMenuOptions.ChargeCar:
                        {
                            chargeCar();
                            break;
                        }
                    case eMenuOptions.GetAllVehicalDetails:
                        {
                            getAllVehicalDetails();
                            break;
                        }
                    case eMenuOptions.Exit:
                        {
                            exitProgram = true;
                            break;
                        }
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
            switch (i_chosenVehicalType)
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

        private void getAllVehicalDetails()
        {
            string licenseID = GetLicenseIDFromUser();
            Console.WriteLine(r_GarageManger.GetVehicalDetails(licenseID));
        }

        private void chargeCar()
        {
            throw new NotImplementedException();
        }

        private void fuelCar()
        {
            throw new NotImplementedException();
        }

        private void fillAirToMax()
        {
            string licenseID = GetLicenseIDFromUser();
            r_GarageManger.FillAirToMax(licenseID);
            Console.WriteLine(k_Done);
        }

        private void changeVehicalStatus()
        {
            throw new NotImplementedException();
        }

        private void getLicencesIDsFilterByStatus()
        {
            throw new NotImplementedException();
        }

        private void displayMenuToUser()
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

        private string GetLicenseIDFromUser()
        {
            string inputFromUser;
            StringBuilder licenseExsitsAlreadyOutput = new StringBuilder(k_AskForLicenseID);
            licenseExsitsAlreadyOutput.AppendLine(k_AskForLicenseID);

            Console.WriteLine(k_AskForLicenseID);
            inputFromUser = Console.ReadLine();
            while (r_GarageManger.IsLicenseIDExsists(inputFromUser))
            {
                Console.WriteLine(string.Format(licenseExsitsAlreadyOutput.ToString()), inputFromUser);
                inputFromUser = Console.ReadLine();
            }

            return inputFromUser;
        }
    }
}
