using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models.FuelVehicals
{
    public class Truck : Vehicle
    {
        protected readonly bool  r_DoesDriveRefrigeratedContents;
        protected readonly float r_LuggageCapacity;


        public eFuelType FuelType => throw new NotImplementedException();

        public float CurrentFuelAmount => throw new NotImplementedException();

        public float MaxFuelAmount => throw new NotImplementedException();

        public void Fuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            throw new NotImplementedException();
        }
    }
}
