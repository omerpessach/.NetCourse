﻿using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models.FuelVehicals
{
    public class FuelCar : IFuel
    {
        public eFuelType FuelType => throw new NotImplementedException();

        public float CurrentFuelAmount => throw new NotImplementedException();

        public float MaxFuelAmount => throw new NotImplementedException();

        public void Fuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            throw new NotImplementedException();
        }
    }
}
