using Ex03.GarageLogic.Models;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    internal static class VehicalFactory
    {
        internal static Vehicle      MakeVehicle(eVehicalType i_CurrentVehicalType)
        {
            Vehicle newVehicle = null;

            switch (i_CurrentVehicalType)
            {
                case eVehicalType.FuelCar:
                    {
                        newVehicle = createFuelCar();
                        break;
                    }
                case eVehicalType.ElectircCar:
                    {
                        newVehicle = createElectircCar();
                        break;
                    }
                case eVehicalType.FuelMotocycle:
                    {
                        newVehicle = createFuelMotocycle();
                        break;
                    }
                case eVehicalType.ElectricMotocycle:
                    {
                        newVehicle = createElectricMotocycle();
                        break;
                    }
                case eVehicalType.Truck:
                    {
                        newVehicle = createTruck();
                        break;
                    }
            }

            return newVehicle;
        }

        private static Car           createFuelCar()
        {
            FuelEngine engine = new FuelEngine(48,eFuelType.Octan95);

            return createCar(engine);
        }

        private static Car           createElectircCar()
        {
            ElectricEngine engine = new ElectricEngine(2.6f);

            return createCar(engine);
        }

        private static Car           createCar(Engine i_Engine)
        {
            List<Tier> tiers = new List<Tier>();

            for (int i = 0; i < 4; i++)
            {
                tiers.Add(new Tier(29));
            }

            return new Car(i_Engine, tiers);
        }

        private static Motorcycle    createFuelMotocycle()
        {
            FuelEngine engine = new FuelEngine(5.8f,eFuelType.Octan98);

            return createMotocycle(engine);
        }

        private static Motorcycle    createElectricMotocycle()
        {
            ElectricEngine engine = new ElectricEngine(2.3f);

            return createMotocycle(engine);
        }

        private static Motorcycle    createMotocycle(Engine i_Engine)
        {
            List<Tier> tiers = new List<Tier>();

            for (int i = 0; i < 2; i++)
            {
                tiers.Add(new Tier(30));
            }

            return new Motorcycle(i_Engine, tiers);
        }

        private static Truck         createTruck()
        {
            List<Tier> tiers = new List<Tier>();

            for (int i = 0; i < 16; i++)
            {
                tiers.Add(new Tier(25));
            }

            return new Truck(new FuelEngine(130, eFuelType.Soler), tiers);
        }
    }
}
