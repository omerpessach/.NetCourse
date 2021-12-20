using Ex03.GarageLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public sealed class GarageManager
    {
        readonly Dictionary<string, GarageVehical> r_GarageVehicals;

        public GarageManager()
        {
            r_GarageVehicals = new Dictionary<string, GarageVehical>();
        }

        public bool AddNewCar(string i_LicenseID, GarageVehical i_VehicalToAdd)
        {
            bool isReEnteredForRepair = false;

            if(r_GarageVehicals.ContainsKey(i_LicenseID))
            {
                i_VehicalToAdd.CurrentStatus = eVehicalStatus.InRepair;
                isReEnteredForRepair = true;
            }
            else
            {
                r_GarageVehicals.Add(i_LicenseID, i_VehicalToAdd);
            }

            return isReEnteredForRepair; 
        }

        public List<string> GetLicencesIDsFilterByStatus(eVehicalStatus i_FilterStatus)
        {
            List<string> allLicensesIDAfterFilter = new List<string>();

            foreach (KeyValuePair<string, GarageVehical> currentVehical in r_GarageVehicals)
            {
                if (currentVehical.Value.CurrentStatus == i_FilterStatus)
                {
                    allLicensesIDAfterFilter.Add(currentVehical.Key);
                }
            }

            return allLicensesIDAfterFilter;
        }

        public void ChangeVehicalStatus(string i_LicenseID, VehicalStatus i_NewStatus)
        {
            GarageVehical currentVehicalToChange;

            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out currentVehicalToChange))
            {
                throw new FormatException("Vehical not found in our garage");
            }

            currentVehicalToChange.CurrentStatus = i_NewStatus.ChosenStatus;
        }

        public void FillAirToMax(string i_LicenseID)
        {
            GarageVehical currentVehicalToFillAir;

            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out currentVehicalToFillAir))
            {
                throw new FormatException("Vehical not found in our garage");
            }

            foreach (Tier currentTier in currentVehicalToFillAir.CurrentVehicle.Tiers)
            {
                currentTier.Blow(currentTier.MaxAirPressure - currentTier.CurrentAirPressure);
            }
        }

        public void FuelCar(string i_LicenseID, FuelType i_FuelType, float i_AmoutToFuel)
        {
            GarageVehical currentVehicalToFuel;

            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out currentVehicalToFuel))
            {
                throw new FormatException("Vehical not found in our garage");
            }

            currentVehicalToFuel.CurrentVehicle.
        }

// +ChargeCar(string i_LicenseID, float i_MinToCharge): void

//+GetAllVehicalDetails(string i_LicenseID) :string
    }
}
