using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Models;

namespace Ex03.GarageLogic
{
    internal sealed class VehicalFactory
    {
        public static Vehicle MakeVehicle(eVehicalType i_CurrentVehicalType)
        {
            //Vehicle newVehicle;

            switch(i_CurrentVehicalType)
            {
                case eVehicalType.FuelCar:
                    break;
                case eVehicalType.ElectircCar:
                    break;
                case eVehicalType.FuelMotocycle:
                    break;
                case eVehicalType.ElectricMotocycle:
                    break;
                case eVehicalType.Truck:
                    break;
            }
        }
    }
}
