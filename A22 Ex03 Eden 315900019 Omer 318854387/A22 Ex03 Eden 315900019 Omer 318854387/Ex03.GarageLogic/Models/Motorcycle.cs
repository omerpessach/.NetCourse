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

        public Motorcycle(Engine i_Engine, List<Tier> i_Tiers)
            : base(i_Engine, i_Tiers)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}, Licence type: {1}, Engine Volume {2}", base.ToString(), m_LicenceType, m_EngineVolume);
        }
    }
}
