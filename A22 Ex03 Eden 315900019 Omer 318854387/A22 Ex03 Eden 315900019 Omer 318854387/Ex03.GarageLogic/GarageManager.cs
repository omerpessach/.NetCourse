using Ex03.GarageLogic.Models;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class GarageManager
    {
        private readonly Dictionary<string, GarageVehical> r_GarageVehicals = new Dictionary<string, GarageVehical>();
        private const string                               k_ArgumentExceptionEngineIsntFuelMsg = "The engine isnt a fuel one.";
        private const string                               k_ArgumentExceptionEngineIsntElectricMsg = "The engine isnt a electic one.";
        private const string                               k_LicenseNotFoundExceptionMsg = "Vehical with license ID: {0} not found in our garage";

        public Vehicle MakeVehicle(eVehicalType i_VehicalType)
        {
            return VehicalFactory.MakeVehicle(i_VehicalType);
        }

        public void InsertNewVehicle(PersonInfo i_OwnerInfo, Vehicle i_Vehicle)
        {
            GarageVehical newGarageVehical = new GarageVehical(i_OwnerInfo, i_Vehicle);

            r_GarageVehicals.Add(i_Vehicle.LicenseID, newGarageVehical);
        }

        public List<string> GetLicensesIDsByStatus(GarageVehical.eVehicalStatus i_FilterStatus)
        {
            List<string> allLicensesIDAfterFilter = new List<string>();

            foreach (KeyValuePair<string, GarageVehical> vehical in r_GarageVehicals)
            {
                if (vehical.Value.Status == i_FilterStatus)
                {
                    allLicensesIDAfterFilter.Add(vehical.Key);
                }
            }

            return allLicensesIDAfterFilter;
        }

        public void ChangeVehicalStatus(string i_LicenseID, GarageVehical.eVehicalStatus i_NewStatus)
        {
            throwExceptionIfLicenseIDNotFound(i_LicenseID);
            r_GarageVehicals[i_LicenseID].Status = i_NewStatus;
        }

        public void FillAirToMax(string i_LicenseID)
        {
            throwExceptionIfLicenseIDNotFound(i_LicenseID);
            foreach (Tier currentTier in r_GarageVehicals[i_LicenseID].Vehicle.Tiers)
            {
                currentTier.BlowToMax();
            }
        }

        public void Fuel(string i_LicenseID, FuelEngine.eFuelType i_FuelType, float i_AmoutToFuel)
        {
            throwExceptionIfLicenseIDNotFound(i_LicenseID);
            Engine currentEngine = r_GarageVehicals[i_LicenseID].Vehicle.Engine;

            if (currentEngine is FuelEngine)
            {
                (currentEngine as FuelEngine).Fuel(i_AmoutToFuel, i_FuelType);
            }
            else
            {
                throw new ArgumentException(k_ArgumentExceptionEngineIsntFuelMsg);
            }
        }

        public void Charge(string i_LicenseID, float i_MinToCharge)
        {
            throwExceptionIfLicenseIDNotFound(i_LicenseID);
            Engine currentEngine = r_GarageVehicals[i_LicenseID].Vehicle.Engine;

            if (currentEngine is ElectricEngine)
            {
                (currentEngine as ElectricEngine).Charge(i_MinToCharge / 60);
            }
            else
            {
                throw new ArgumentException(k_ArgumentExceptionEngineIsntElectricMsg);
            }
        }

        public string GetVehicalDetails(string i_LicenseID)
        {
            throwExceptionIfLicenseIDNotFound(i_LicenseID);
            return r_GarageVehicals[i_LicenseID].ToString();
        }

        public bool IsLicenseIDExsists(string i_LicenseID)
        {
            return r_GarageVehicals.ContainsKey(i_LicenseID);
        }

        private void throwExceptionIfLicenseIDNotFound(string i_LicenseID)
        {
            if (!IsLicenseIDExsists(i_LicenseID))
            {
                throw new KeyNotFoundException(string.Format(k_LicenseNotFoundExceptionMsg, i_LicenseID));
            }
        }
    }
}