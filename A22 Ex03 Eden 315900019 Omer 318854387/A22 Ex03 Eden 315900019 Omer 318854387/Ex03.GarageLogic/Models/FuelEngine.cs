using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxEnergyCapacity, eFuelType i_FuelType)
            : base(i_MaxEnergyCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public void Fuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ValueOutOfRangeException("Wrong fuel type");
            }
            else if (m_CurrentEnergy + i_LitersToAdd > m_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException("Too many liters");
            }
            else
            {
                m_CurrentEnergy += i_LitersToAdd;
                CalculatePercentOfEnergyLeft();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, fuel type: {1}", base.ToString(), r_FuelType);
        }
    }
}
