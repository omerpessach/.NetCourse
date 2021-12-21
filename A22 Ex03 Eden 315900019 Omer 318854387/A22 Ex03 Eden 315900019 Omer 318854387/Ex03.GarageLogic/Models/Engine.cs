using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public abstract class Engine
    {
        public float m_CurrentEnergy;
        public readonly float m_MaxEnergyCapacity;

        protected Engine(float i_MaxEnergyCapacity)
        {
            m_MaxEnergyCapacity = i_MaxEnergyCapacity;
        }
    }
}
