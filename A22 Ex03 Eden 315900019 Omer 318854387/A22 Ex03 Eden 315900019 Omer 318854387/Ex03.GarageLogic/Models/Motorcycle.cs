using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class Motorcycle : Vehicle
    {
        private eLicenceType m_LicenceType;
        private int m_EngineVolume;

        public Motorcycle(string i_ModelName, string i_LicenceID, Engine i_Engine, eLicenceType i_LicenceType, int i_EngineVolume)
            : base(i_ModelName, i_LicenceID, i_Engine)
        {
            float MaxAirPressureOfTier = 30;

            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
            this.NumberOfWheels = 2;  
        }

        protected override void GetrequiredDataAccorrdingToVehical(ref List<string> io_RequiredData)
        {
            io_RequiredData.Add("Motorcycle license type: [1 = A, 2 = A2, 3 = AA, 4 = B]");
            io_RequiredData.Add("Engine size:");
        }

        public override void SetEngineInformation(float i_CurrentEngineCapcityLeft)
        {
            float engineMaxCapacity = getMaxEngineCapacity();

            SetEnergyEngineCapacity(i_CurrentEngineCapcityLeft, engineMaxCapacity);
        }

        protected override float getMaxEngineCapacity()
        {
            float MaxEngineCapacity;
            FuelEngine fuelMotorcycleEngine = this.Engine as FuelEngine;

            if (fuelMotorcycleEngine != null)
            {
                MaxEngineCapacity = 5.8f; //max capacity of car as fuel engine 
            }
            else
            {
                MaxEngineCapacity = 2.3f; //max capacity of car as elctric engine
            }

            return MaxEngineCapacity;
        }


        public override string ToString()
        {
            return string.Format("{0}, Licence type: {1}, Engine Volume {2}", base.ToString(), m_LicenceType, m_EngineVolume);
        }
    }
}
