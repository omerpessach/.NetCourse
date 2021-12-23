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

        private void           calculatePercentOfEnergyLeft()
        {
            m_PercentOfEnergyLeft = 100 / (m_MaxEnergyCapacity / m_CurrentEnergy);
        }

        protected void         AddEnergy(float i_Energy)
        {
            if (m_CurrentEnergy + i_Energy > m_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException("Too many energy", 0, m_MaxEnergyCapacity);
            }
            else
            {
                m_CurrentEnergy += i_Energy;
                calculatePercentOfEnergyLeft();
            }
        }

        public override string ToString()
        {
            return string.Format("Max energy capacity: {0}, Current energy: {1}, percent of energy left: {2}", m_MaxEnergyCapacity, m_CurrentEnergy, m_PercentOfEnergyLeft);
        }
    }
}
