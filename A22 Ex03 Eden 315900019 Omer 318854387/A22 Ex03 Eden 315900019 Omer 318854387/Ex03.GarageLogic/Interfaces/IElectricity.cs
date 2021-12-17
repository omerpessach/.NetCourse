using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Interfaces
{
    internal interface IElectricity
    {
        float RemainingBatteryTime { get; }
        float MaxBatteryTime { get; }
        void Charge(float i_AmountOfHoursToAdd);
    }
}
