using Ex03.GarageLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models.ElectricVehicals
{
    public class ElectricCar : IElectricity
    {
        public float RemainingBatteryTime => throw new NotImplementedException();

        public float MaxBatteryTime => throw new NotImplementedException();

        public void Charge(float i_AmountOfHoursToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
