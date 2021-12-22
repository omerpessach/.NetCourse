using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    public abstract class Engine
    {
        protected float m_MaxEnergyCapacity;
        protected float m_CurrentEnergy;
        protected float m_PercentOfEnergyLeft = 100;

        protected Engine(float i_MaxEnergyCapacity)
        {
            m_MaxEnergyCapacity = i_MaxEnergyCapacity;
        }

        public void CalculatePercentOfEnergyLeft()
        {
            m_PercentOfEnergyLeft = 100 / (m_MaxEnergyCapacity / m_CurrentEnergy);
        }

        public override string ToString()
        {
            return string.Format("Max energy capacity: {0}, Current energy: {1}, percent of energy left: {2}", m_MaxEnergyCapacity, m_CurrentEnergy, m_PercentOfEnergyLeft);
        }
    }
}
