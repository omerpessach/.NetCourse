using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Enums
{
    public class VehicalStatus
    {
        private eVehicalStatus m_currentStatus;

        public static VehicalStatus ChoiseColor(int i_StatusFromUser)
        {
            VehicalStatus currentStatus = new VehicalStatus();

            switch (i_StatusFromUser)
            {
                case 1:
                    currentStatus.m_currentStatus = eVehicalStatus.Fixed;
                    break;
                case 2:
                    currentStatus.m_currentStatus = eVehicalStatus.InRepair;
                    break;
                case 3:
                    currentStatus.m_currentStatus = eVehicalStatus.Paid;
                    break;
                default:
                    throw new FormatException("Wrong input. There is no status that fits to this input");
            }

            return currentStatus;
        }

        public eVehicalStatus ChosenStatus
        {
            get
            {
                return m_currentStatus;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}", ChosenStatus);
        }
    }
}
