using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        private readonly GarageManager r_GarageManger = new GarageManager();
        private const string           k_AskForLicenseID = "Please insert license ID";
        private const string           k_AskForTierManufacturer = "Please insert tiers' manufacturer";
        private const string           k_RequestMinToCharge = "Enter amount of minutes that tou want to charge";
        private const string           k_RequestLiterToFuel = "Enter amount of liters to fuel";
        private const string           k_AskForTierAirPressure = "Enter tiers' air pressure";
        private const string           k_AskFilterByStatusOrGetAll = "Type 1 to get all license Ids or 2 to get license Ids by status";
        private const string           k_NoWasLicensesFounded = "No licenses was founded";
        private const string           k_Done = "Done!";
        private const string           k_GoBackToMenuSymbol = "Q";

        public void          RunApp()
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
                            addNewVehical();
                            break;
                        }
                    case eMenuOptions.GetLicensesIDsFilterByStatus:
                        {
                            getLicensesIDs();
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
                            getVehicalDetails();
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

        private void         addNewVehical()
        {
            string licenseID;
            Vehicle vehicle;
            PersonInfo personInfo;

            licenseID = UIHelper.GetNotEmptyOrWhiteSpacesString(k_AskForLicenseID);
            if (r_GarageManger.IsLicenseIDExsists(licenseID))
            {
                r_GarageManger.ChangeVehicalStatus(licenseID, eVehicalStatus.InRepair);
                Console.WriteLine("The Vehicle already exsists in the system, status changed to in repair");
            }
            else
            {
                vehicle = makeVehicleAccordingToUser(licenseID);
                personInfo = getPersonInfoFromUser();
                r_GarageManger.InsertNewVehicle(personInfo, vehicle);
                Console.WriteLine("The vehicle successfully added");
            }
        }

        private Vehicle      makeVehicleAccordingToUser(string i_LicenseID)
        {
            string modelName;
            eVehicalType vehicalType;
            Vehicle vehicle;

            vehicalType = getVehicalTypeFromUser();
            vehicle = r_GarageManger.MakeVehicle(vehicalType);
            modelName = UIHelper.GetNotEmptyOrWhiteSpacesString("Enter the vehicle model");
            vehicle.InitBasicInfo(i_LicenseID, modelName);
            initTiersInfo(vehicle);
            initVehicleUniqeMembers(vehicle);

            return vehicle;
        }

        private void         initTiersInfo(Vehicle i_Vehicle)
        {
            bool doesWantToGoBackToMenu = false;
            bool hasSucceed = false;
            string manufacturer = UIHelper.GetNotEmptyOrWhiteSpacesString(k_AskForTierManufacturer);
            float tiersAirPressure;

            do
            {
                tiersAirPressure = UIHelper.GetFloatFromUser(k_AskForTierAirPressure);
                try
                {
                    i_Vehicle.InitTierInfo(manufacturer, tiersAirPressure);
                    hasSucceed = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    UIHelper.HandleValueOutOfRangeException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
                catch (Exception ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }

            } while (!hasSucceed && !doesWantToGoBackToMenu);
        }

        private void         initVehicleUniqeMembers(Vehicle i_Vehicle)
        {
            bool doesWantToGoBackToMenu = false;
            string[] uniqeMembersInfo = i_Vehicle.UniqeMembersToInitInfo;
            int numberOfUniqeMembersInfo = uniqeMembersInfo.Length;
            List<string> inputValues = new List<string>();
            bool hasSucceed = false;

            do
            {
                for (int i = 0; i < numberOfUniqeMembersInfo; i++)
                {
                    Console.WriteLine(uniqeMembersInfo[i]);
                    inputValues.Add(Console.ReadLine());
                }

                try
                {
                    i_Vehicle.SetUniqeMembers(inputValues);
                    hasSucceed = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    inputValues.Clear();
                    UIHelper.HandleValueOutOfRangeException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
                catch (Exception ex)
                {
                    inputValues.Clear();
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
            } while (!hasSucceed && !doesWantToGoBackToMenu);
        }

        private PersonInfo   getPersonInfoFromUser()
        {
            string name = UIHelper.GetStringContainsOnlyLetters("Please enter your name");
            string phoneNumber = UIHelper.GetStringContainsOnlyDigits("Please enter your phone number");

            return new PersonInfo(name, phoneNumber);
        }

        private void         getVehicalDetails()
        {
            bool doesWantToGoBackToMenu = false;
            string licenseID;
            bool isDone = false;

            do
            {
                licenseID = getLicenseIDFromUser();
                try
                {
                    Console.WriteLine(r_GarageManger.GetVehicalDetails(licenseID));
                    isDone = true;
                }
                catch (KeyNotFoundException ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
            } while (!doesWantToGoBackToMenu && !isDone);
        }

        private void         chargeCar()
        {
            string licenseID;
            float inputNumber;
            bool hasSucceed = false;
            bool doesWantToGoBackToMenu = false;

            do
            {
                licenseID = getLicenseIDFromUser();
                inputNumber = UIHelper.GetFloatFromUser(k_RequestMinToCharge);

                try
                {
                    r_GarageManger.Charge(licenseID, inputNumber);
                    hasSucceed = true;
                }
                catch (KeyNotFoundException ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
                catch (ArgumentException ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
                catch (ValueOutOfRangeException ex)
                {
                    ex.MaxValue *= 60f;
                    ex.MinValue *= 60f;
                    UIHelper.HandleValueOutOfRangeException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
            }
            while (!hasSucceed && !doesWantToGoBackToMenu);
        }

        private void         fuelCar()
        {
            string licenseID;
            float inputNumber;
            eFuelType fuelType;
            bool hasSucceed = false;
            bool doesWantToGoBackToMenu = false;

            do
            {
                licenseID = getLicenseIDFromUser();
                inputNumber = UIHelper.GetFloatFromUser(k_RequestLiterToFuel);
                fuelType = UIHelper.GetEnumFromUser<eFuelType>("Select fuel type");
                try
                {
                    r_GarageManger.Fuel(licenseID, fuelType, inputNumber);
                    hasSucceed = true;
                }
                catch (KeyNotFoundException ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
                catch (ArgumentException ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
                catch (ValueOutOfRangeException ex)
                {
                    UIHelper.HandleValueOutOfRangeException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
            }
            while (!hasSucceed && !doesWantToGoBackToMenu);
        }

        private void         fillAirToMax()
        {
            string licenseID;
            bool hasSucceed = false;
            bool doesWantToGoBackToMenu = false;

            do
            {
                licenseID = getLicenseIDFromUser();
                try
                {
                    r_GarageManger.FillAirToMax(licenseID);
                    hasSucceed = true;
                    Console.WriteLine(k_Done);
                }
                catch (KeyNotFoundException ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
            }
            while (!hasSucceed && !doesWantToGoBackToMenu);
        }

        private void         changeVehicalStatus()
        {
            string licenseID;
            eVehicalStatus requestedStatus;
            bool hasSucceed = false;
            bool doesWantToGoBackToMenu = false;

            do
            {
                licenseID = getLicenseIDFromUser();
                requestedStatus = UIHelper.GetEnumFromUser<eVehicalStatus>("Select status");
                try
                {
                    r_GarageManger.ChangeVehicalStatus(licenseID, requestedStatus);
                    hasSucceed = true;
                    Console.WriteLine(k_Done);
                }
                catch (KeyNotFoundException ex)
                {
                    UIHelper.HandleGenericInfoException(ex);
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                }
            }
            while (!hasSucceed && !doesWantToGoBackToMenu);
        }

        private eVehicalType getVehicalTypeFromUser()
        {
            return UIHelper.GetEnumFromUser<eVehicalType>("Select vehical type");
        }

        private void         getLicensesIDs()
        {
            eVehicalStatus requestedStatus;
            StringBuilder licenseIDsOutput = new StringBuilder();
            List<string> licenseIDs;
            float inputNumber;
            bool doesWantToGoBackToMenu = false;

            if (!r_GarageManger.IsGarageContainsVehicles())
            {
                Console.WriteLine(k_NoWasLicensesFounded);
            }
            else
            {
                inputNumber = UIHelper.GetFloatFromUser(k_AskFilterByStatusOrGetAll);
                while (inputNumber != 1 && inputNumber != 2 && !doesWantToGoBackToMenu)
                {
                    doesWantToGoBackToMenu = UIHelper.DoesWantToGoBackToMenu(k_GoBackToMenuSymbol);
                    inputNumber = UIHelper.GetFloatFromUser(k_AskFilterByStatusOrGetAll);
                }

                if (!doesWantToGoBackToMenu)
                {
                    if (inputNumber == 1)
                    {
                        licenseIDs = r_GarageManger.GetLicensesIDs();
                    }
                    else
                    {
                        requestedStatus = UIHelper.GetEnumFromUser<eVehicalStatus>("Select status");
                        licenseIDs = r_GarageManger.GetLicensesIDsByStatus(requestedStatus);
                    }

                    if (licenseIDs.Count == 0)
                    {
                        Console.WriteLine(k_NoWasLicensesFounded);
                    }
                    else
                    {
                        foreach (string licenseId in licenseIDs)
                        {
                            licenseIDsOutput.AppendLine(licenseId);
                        }

                        Console.WriteLine(licenseIDsOutput);
                    }
                }
            }
        }

        private void         displayMenuToUser()
        {
            string MenuOptions = string.Format(
                @"Which opartion would you like to execute?
press 1 - add new vehicle to garage
press 2 - show license plates of the vehicles in the garage
press 3 - change vehicle status in the gargage
press 4 - fiil air of tiers to max
press 5 - fuel a vehicle
press 6 - charge a vehicle
press 7 - desplay vehicale information
press 8 - exit application");

            Console.WriteLine(MenuOptions);
        }

        private string       getLicenseIDFromUser()
        {
            string inputFromUser = UIHelper.GetNotEmptyOrWhiteSpacesString(k_AskForLicenseID);
            return inputFromUser;
        }
    }
}
