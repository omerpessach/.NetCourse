using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Enums
{
    public class LicenceType
    {
        private eLicenceType m_currentLicenceType;

        public LicenceType DriverLicenseTypeAnalysis(String i_LicenceTypeInput)
        {
            LicenceType currentLicenceType = new LicenceType();

            switch(i_LicenceTypeInput)
            {
                case "A":
                    currentLicenceType.m_currentLicenceType = eLicenceType.A;
                    break;
                case "B":
                    currentLicenceType.m_currentLicenceType = eLicenceType.B;
                    break;
                case "AA":
                    currentLicenceType.m_currentLicenceType = eLicenceType.AA;
                    break;
                case "A2":
                    currentLicenceType.m_currentLicenceType = eLicenceType.A2;
                    break;
                default:
                    throw new FormatException("Wrong input. no Licence type was found according to this input");
            }

            return currentLicenceType;
        }

        public eLicenceType CurrentLicenceType
        {
            get
            {
                return m_currentLicenceType;
            }
        }
        public override string ToString()
        {
            return string.Format(@"{0}", CurrentLicenceType);
        }
    }
}
