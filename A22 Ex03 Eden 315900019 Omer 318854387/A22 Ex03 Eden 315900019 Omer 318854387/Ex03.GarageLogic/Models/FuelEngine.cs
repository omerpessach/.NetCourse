using Ex03.GarageLogic.Enums;
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
            throw new NotImplementedException();
        }
    }
}
