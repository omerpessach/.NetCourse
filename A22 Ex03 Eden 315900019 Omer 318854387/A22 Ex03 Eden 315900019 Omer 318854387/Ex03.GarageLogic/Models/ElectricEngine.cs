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
        }
    }
}
