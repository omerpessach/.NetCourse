using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class GarageVehical
    {
        public enum eVehicalStatus
        {
            InRepair,
            Fixed,
            Paid,
        }

        private readonly Vehicle r_Vehicle;
        private readonly PersonInfo r_Owner;
        private eVehicalStatus m_Status = eVehicalStatus.InRepair;

        public GarageVehical(PersonInfo i_OwnerInfo, Vehicle i_Vehicle)
        {
            r_Owner = i_OwnerInfo;
            r_Vehicle = i_Vehicle;
        }

        public eVehicalStatus Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}
vehicle detailes: {1}
status in garage: {2}", r_Owner.ToString(), Vehicle.ToString(), Status);
        }
    }
}
