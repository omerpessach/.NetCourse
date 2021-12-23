using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Models;

namespace Ex03.GarageLogic
{
    public enum eVehicalType
    {
        FuelCar = 1,
        ElectircCar,
        FuelMotocycle,
        ElectricMotocycle,
        Truck,
    }

    internal static class VehicalFactory
    {
        internal static Vehicle MakeVehicle(eVehicalType i_CurrentVehicalType)
        {
            Vehicle newVehicle = null;

            switch (i_CurrentVehicalType)
            {
                case eVehicalType.FuelCar:
                    {
                        newVehicle = CreateFuelCar();
                        break;
                    }
                case eVehicalType.ElectircCar:
                    {
                        newVehicle = CreateElectircCar();
                        break;
                    }
                case eVehicalType.FuelMotocycle:
                    {
                        newVehicle = CreateFuelMotocycle();
                        break;
                    }
                case eVehicalType.ElectricMotocycle:
                    {
                        newVehicle = CreateElectricMotocycle();
                        break;
                    }
                case eVehicalType.Truck:
                    {
                        newVehicle = CreateTruck();
                        break;
                    }
            }

            return newVehicle;
        }

        private static Car CreateFuelCar()
        {
            FuelEngine engine = new FuelEngine(48, FuelEngine.eFuelType.Octan95);
            return CreateCar(engine);
        }

        private static Car CreateElectircCar()
        {
            ElectricEngine engine = new ElectricEngine(2.6f);
            return CreateCar(engine);
        }

        private static Car CreateCar(Engine i_Engine)
        {
            List<Tier> tiers = new List<Tier>();

            for (int i = 0; i < 4; i++)
            {
                tiers.Add(new Tier(29));
            }

            return new Car(i_Engine, tiers);
        }

        private static Motorcycle CreateFuelMotocycle()
        {
            FuelEngine engine = new FuelEngine(5.8f, FuelEngine.eFuelType.Octan98);
            return CreateMotocycle(engine);
        }

        private static Motorcycle CreateElectricMotocycle()
        {
            ElectricEngine engine = new ElectricEngine(2.3f);
            return CreateMotocycle(engine);
        }

        private static Motorcycle CreateMotocycle(Engine i_Engine)
        {
            List<Tier> tiers = new List<Tier>();

            for (int i = 0; i < 2; i++)
            {
                tiers.Add(new Tier(30));
            }

            return new Motorcycle(i_Engine, tiers);
        }

        private static Truck CreateTruck()
        {
            List<Tier> tiers = new List<Tier>();

            for (int i = 0; i < 16; i++)
            {
                tiers.Add(new Tier(25));
            }

            return new Truck(new FuelEngine(130, FuelEngine.eFuelType.Soler), tiers);
        }
    }
}
