using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity)
        {
        }

        public void Charge(float i_AmountOfHoursToAdd)
        {
            if (m_CurrentEnergy + i_AmountOfHoursToAdd > m_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException("");
            }
            else
            {
                m_CurrentEnergy += i_AmountOfHoursToAdd;
                CalculatePercentOfEnergyLeft();
            }
        }
    }
}
