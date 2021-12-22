using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    internal abstract class Motorcycle : Vehicle
    {
        protected eLicenceType m_LicenceType;
        protected int         m_EngineVolume;

    }
}
