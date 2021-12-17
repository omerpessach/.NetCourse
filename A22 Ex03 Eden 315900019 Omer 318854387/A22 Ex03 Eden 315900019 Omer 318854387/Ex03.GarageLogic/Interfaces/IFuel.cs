using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Interfaces
{
    internal interface IFuel
    {
        eFuelType FuelType { get; }
        float CurrentFuelAmount { get; }
        float MaxFuelAmount { get; }
        void Fuel(float i_LitersToAdd, eFuelType i_FuelType);
    }
}
