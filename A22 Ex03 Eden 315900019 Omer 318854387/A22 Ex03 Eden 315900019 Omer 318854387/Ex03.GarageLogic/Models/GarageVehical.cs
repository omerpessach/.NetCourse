using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class GarageVehical
    {
        private readonly Vehicle r_CurrentVehicle;
        private readonly PersonInfo r_Owner;
        private eVehicalStatus m_currentStatus = eVehicalStatus.InRepair;

        public GarageVehical(PersonInfo i_OwnerInfo)
        {
            r_Owner = i_OwnerInfo;
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
            return string.Format(@"{0}, vehicle detailes: {1}, {2}, status in garage: {3}", r_Owner.ToString(), CurrentVehicle.LicenceID, CurrentVehicle.ModelName, CurrentStatus);
        }
    }
}
