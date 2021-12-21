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

            if (r_GarageVehicals.ContainsKey(i_LicenseID))
            {
                i_VehicalToAdd.Status = eVehicalStatus.InRepair;
                isReEnteredForRepair = true;
            }
            else
            {
                r_GarageVehicals.Add(i_LicenseID, i_VehicalToAdd);
            }

            return isReEnteredForRepair;
        }

        public List<string> GetLicencesIDsByStatus(eVehicalStatus i_FilterStatus)
        {
            List<string> allLicensesIDAfterFilter = new List<string>();

            foreach (KeyValuePair<string, GarageVehical> currentVehical in r_GarageVehicals)
            {
                if (currentVehical.Value.Status == i_FilterStatus)
                {
                    allLicensesIDAfterFilter.Add(currentVehical.Key);
                }
            }

            return allLicensesIDAfterFilter;
        }

        public void ChangeVehicalStatus(string i_LicenseID, eVehicalStatus i_NewStatus)
        {
            GarageVehical currentVehicalToChange;

            // Should this part be separate to a new private method and to be called in each method?
            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out currentVehicalToChange)) 
            {
                throw new KeyNotFoundException(string.Format(@"Vehical with license ID: {0} not found in our garage", i_LicenseID));
            }

            currentVehicalToChange.Status = i_NewStatus;
        }

        public void FillAirToMax(string i_LicenseID)
        {
            GarageVehical currentVehicalToFillAir;

            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out currentVehicalToFillAir))
            {
                throw new KeyNotFoundException(string.Format(@"Vehical with license ID: {0} not found in our garage", i_LicenseID));
            }

            foreach (Tier currentTier in currentVehicalToFillAir.Vehicle.Tiers)
            {
                currentTier.BlowToMax();
            }
        }

        public void Fuel(string i_LicenseID, eFuelType i_FuelType, float i_AmoutToFuel)
        {
            GarageVehical currentVehicalToFuel;

            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out currentVehicalToFuel))
            {
                throw new KeyNotFoundException(string.Format(@"Vehical with license ID: {0} not found in our garage", i_LicenseID));
            }

            (currentVehicalToFuel.Vehicle.Engine as FuelEngine).Fuel(i_AmoutToFuel, i_FuelType);
        }

        public void Charge(string i_LicenseID, float i_MinToCharge)
        {
            GarageVehical currentVehical;

            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out currentVehical))
            {
                throw new KeyNotFoundException(string.Format(@"Vehical with license ID: {0} not found in our garage", i_LicenseID));
            }

            (currentVehical.Vehicle.Engine as ElectricEngine).Charge(i_MinToCharge);
        }

        public string GetVehicalDetails(string i_LicenseID)
        {
            GarageVehical vehicalDetails;

            if (!r_GarageVehicals.TryGetValue(i_LicenseID, out vehicalDetails))
            {
                throw new KeyNotFoundException(string.Format(@"Vehical with license ID: {0} not found in our garage", i_LicenseID));
            }

            return vehicalDetails.ToString();
        }
    }
}
