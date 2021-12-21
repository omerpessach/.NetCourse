using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class Motorcycle : Vehicle
    {
        private eLicenceType m_LicenceType;
        private int m_EngineVolume;

        public Motorcycle(string i_ModelName, string i_LicenceID, Engine i_Engine, eLicenceType i_LicenceType, int i_EngineVolume)
            : base(i_ModelName, i_LicenceID, i_Engine)
        {
            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
        }

        public override string ToString()
        {
            return string.Format("{0}, Licence type: {1}, Engine Volume {2}", base.ToString(), m_LicenceType, m_EngineVolume);
        }
    }
}
