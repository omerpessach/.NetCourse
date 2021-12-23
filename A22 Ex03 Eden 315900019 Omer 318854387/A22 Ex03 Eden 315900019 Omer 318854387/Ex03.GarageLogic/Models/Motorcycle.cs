using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int          m_EngineVolume;
        private const string k_LicenseTypeInitInfoMsg = "Enter license type: 1 for A, 2 for AA, 3 for A2, 4 for B";
        private const string k_EngineVolumeInitInfoMsg = "Enter engine volume";
        private const string k_LicenseTypeArgumentExceptionMsg = "Invalid value by setting license type";
        private const string k_LicenseTypeFormatExceptionMsg = "Wrong format by setting license type";

        public Motorcycle(Engine i_Engine, List<Tier> i_Tiers)
            : base(i_Engine, i_Tiers)
        {
            m_UniqeMembersToInitInfo = new string[] { k_LicenseTypeInitInfoMsg, k_EngineVolumeInitInfoMsg };
        }

        private void           setLicenseType(string i_Value)
        {
            m_LicenseType = (eLicenseType)GarageHelper.GetEnumValueOtherwiseThrowException<eLicenseType>(i_Value, k_LicenseTypeArgumentExceptionMsg, k_LicenseTypeFormatExceptionMsg);
        }

        private void           setEngineVolume(string i_Value)
        {
            int engineVolume;

            if (int.TryParse(i_Value, out engineVolume))
            {
                if (engineVolume > 0)
                {
                    m_EngineVolume = engineVolume;
                }
                else
                {
                    throw new ArgumentException("The value is negative");
                }
            }
            else
            {
                throw new FormatException("Cannot set engine volume by invalid value");
            }
        }

        public override void   SetUniqeMembers(List<string> i_UniqeMembers)
        {
            setLicenseType(i_UniqeMembers[0]);
            setEngineVolume(i_UniqeMembers[1]);
        }

        public override string ToString()
        {
            return string.Format("{0}, License type: {1}, Engine Volume {2}", base.ToString(), m_LicenseType, m_EngineVolume);
        }
    }
}
