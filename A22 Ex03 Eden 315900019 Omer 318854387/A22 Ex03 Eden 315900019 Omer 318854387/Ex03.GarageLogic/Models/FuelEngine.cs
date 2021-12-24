using Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic.Models
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private const string       k_ArgumentExceptionFuel = "Wrong fuel type";

        public FuelEngine(float i_MaxEnergyCapacity, eFuelType i_FuelType)
            : base(i_MaxEnergyCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public void            Fuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(k_ArgumentExceptionFuel);
            }
            else
            {
                AddEnergy(i_LitersToAdd);
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}
fuel type: {1}", base.ToString(), r_FuelType);
        }
    }
}
