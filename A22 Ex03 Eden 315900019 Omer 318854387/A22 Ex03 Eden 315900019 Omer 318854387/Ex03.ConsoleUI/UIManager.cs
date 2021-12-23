using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Models;
using Ex03.GarageLogic.Enums;
using System.Text;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        private readonly GarageManager r_GarageManger = new GarageManager();
        private const string k_AskForLicenseID = "Please insert license ID";
        private const string k_AskForTierManufacturer = "Please insert tiers' manufacturer";
        private const string k_LicenseIDNotFoundMsg = "Vehical with license ID: {0} not found in our garage";
        private const string k_RequestMinToCharge = "Enter amount of minutes that tou want to charge";
        private const string k_AskForTierAirPressure = "Enter tiers' air pressure";
        private const string k_Done = "Done!";
        private const string k_GoBackToMenuSymbol = "Q";

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
                            addNewVehical();
                            break;
                        }
                    case eMenuOptions.GetLicensesIDsFilterByStatus:
                        {
                            getLicensesIDsFilterByStatus();
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

        private void addNewVehical()
        {
            string licenseID;
            Vehicle vehicle;
            PersonInfo personInfo;

            licenseID = UIHelper.GetNotEmptyOrWhiteSpacesString(k_AskForLicenseID);
            if (r_GarageManger.IsLicenseIDExsists(licenseID))
            {
                r_GarageManger.ChangeVehicalStatus(licenseID, GarageVehical.eVehicalStatus.InRepair);
                Console.WriteLine("The Vehicle already exsists in the system, status changed to in repair");
            }
            else
            {
                vehicle = makeVehicleAccordingToUser(licenseID);
                personInfo = GetPersonInfoFromUser();
                r_GarageManger.InsertNewVehicle(personInfo, vehicle);
                Console.WriteLine("The vehicle successfully added");
            }
        }

        private Vehicle makeVehicleAccordingToUser(string i_LicenseID)
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

        private void initTiersInfo(Vehicle i_Vehicle)
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

        private void initVehicleUniqeMembers(Vehicle i_Vehicle)
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

        private PersonInfo GetPersonInfoFromUser()
        {
            string name = UIHelper.GetStringContainsOnlyLetters("Please enter name");
            string phoneNumber = UIHelper.GetStringContainsOnlyDigits("Please enter phone number");

            return new PersonInfo(name, phoneNumber);
        }

        private void getVehicalDetails()
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

        private void chargeCar()
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

        private void fuelCar()
        {
            string licenseID;
            float inputNumber;
            FuelEngine.eFuelType fuelType;
            bool hasSucceed = false;
            bool doesWantToGoBackToMenu = false;

            do
            {
                licenseID = getLicenseIDFromUser();
                inputNumber = UIHelper.GetFloatFromUser(k_RequestMinToCharge);
                fuelType = UIHelper.GetEnumFromUser<FuelEngine.eFuelType>("Select fuel type");
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

        private void fillAirToMax()
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

        private void changeVehicalStatus()
        {
            string licenseID;
            GarageVehical.eVehicalStatus requestedStatus;
            bool hasSucceed = false;
            bool doesWantToGoBackToMenu = false;

            do
            {
                licenseID = getLicenseIDFromUser();
                requestedStatus = UIHelper.GetEnumFromUser<GarageVehical.eVehicalStatus>("Select status");
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

        private void getLicensesIDsFilterByStatus()
        {
            GarageVehical.eVehicalStatus requestedStatus;

            requestedStatus = UIHelper.GetEnumFromUser<GarageVehical.eVehicalStatus>("Select status");
            r_GarageManger.GetLicensesIDsByStatus(requestedStatus);
        }

        private void displayMenuToUser()
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

        private string getLicenseIDFromUser()
        {
            string inputFromUser = UIHelper.GetNotEmptyOrWhiteSpacesString(k_AskForLicenseID);
            return inputFromUser;
        }
    }
}
