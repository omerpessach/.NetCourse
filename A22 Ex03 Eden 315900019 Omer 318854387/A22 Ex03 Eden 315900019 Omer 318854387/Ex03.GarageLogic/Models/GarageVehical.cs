using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class GarageVehical
    {
        private readonly string  r_OwnerName;
        private readonly Vehicle r_CurrentVehicle;
        private readonly string  r_PhoneNumberOwner;
        private eVehicalStatus   m_currentStatus;

        public GarageVehical(string i_NameOfOwner, string i_PhoneNumberOwner)
        {
            m_currentStatus = eVehicalStatus.InRepair;
            r_OwnerName = i_NameOfOwner;
            r_PhoneNumberOwner = i_PhoneNumberOwner;
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string PhoneNumberOwner
        {
            get
            {
                return r_PhoneNumberOwner;
            }
        }

        public eVehicalStatus CurrentStatus
        {
            get
            {
                return m_currentStatus;
            }
            set
            {
                m_currentStatus = value; 
            }
        }

        public Vehicle CurrentVehicle
        {
            get
            {
                return r_CurrentVehicle;
            }
        }

        public override string ToString()
        {
            return string.Format(@"Owner name:{0}, owner phone:{1}, vehicle detailes: {2}, {3}, status in garage: {4}", OwnerName, PhoneNumberOwner, CurrentVehicle.LicenceID, CurrentVehicle.ModelName, CurrentStatus);
        }
    }
}
