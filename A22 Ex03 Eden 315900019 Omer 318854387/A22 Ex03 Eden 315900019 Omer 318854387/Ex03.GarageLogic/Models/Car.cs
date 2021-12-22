using Ex03.GarageLogic.Enums;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Models
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorPossibleOptions m_DoorAmount;

        public Car(string i_ModelName, string i_LicenceID, Engine i_Engine, eCarColor i_Color, eDoorPossibleOptions i_DoorsAmount)
            : base(i_ModelName, i_LicenceID, i_Engine)
        {
            float MaxAirPressureOfTier = 29;

            m_CarColor = i_Color;
            m_DoorAmount = i_DoorsAmount;
            this.NumberOfWheels = 4;
        }

        public eCarColor CarColor { get => m_CarColor; set => m_CarColor = value; }
        public eDoorPossibleOptions DoorAmount { get => m_DoorAmount; set => m_DoorAmount = value; }

        protected override void GetrequiredDataAccorrdingToVehical(ref List<string> io_RequiredData)
        {
            io_RequiredData.Add("Car color: [1 = Red , 2 = White , 3 = Black, 4 = Blue]");
            io_RequiredData.Add("Number of doors: [2 = Min ; 5 = Max]");
        }

        public override void SetEngineInformation(float i_CurrentEngineCapcityLeft)
        {
            float engineMaxCapacity = getMaxEngineCapacity();

            SetEnergyEngineCapacity(i_CurrentEngineCapcityLeft, engineMaxCapacity);
        }

        protected override float getMaxEngineCapacity()
        {
            float MaxEngineCapacity;
            FuelEngine fuelCarEngine = this.Engine as FuelEngine;

            if(fuelCarEngine != null)
            {
                MaxEngineCapacity = 48f; //max capacity of car as fuel engine 
            }
            else
            {
                MaxEngineCapacity = 2.6f; //max capacity of car as elctric engine
            }

            return MaxEngineCapacity;
        }

        public override string ToString()
        {
            return string.Format("{0}, Color: {1}, Doors amount: {2}", base.ToString(), nameof(m_CarColor), m_DoorAmount);
        }
    }
}
