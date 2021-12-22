using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class Truck : Vehicle
    {
        private readonly bool r_DoesDriveRefrigeratedContents;
        private readonly float r_LuggageCapacity;

        public Truck(string i_ModelName, string i_LicenceID, Engine i_Engine, bool i_DoesDriveRefrigeratedContents, float i_LuggageCapacity)
            : base(i_ModelName, i_LicenceID, i_Engine)
        {
            float MaxAirPressureOfTier = 25;

            r_DoesDriveRefrigeratedContents = i_DoesDriveRefrigeratedContents;
            r_LuggageCapacity = i_LuggageCapacity;
            this.NumberOfWheels = 16;
        }

        protected override void GetrequiredDataAccorrdingToVehical(ref List<string> io_RequiredData)
        {
            io_RequiredData.Add("Does drive refrigerated contents? : [Yes = Type 'True' ; No = 'False']");
            io_RequiredData.Add("Cargo volume:");
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
            MaxEngineCapacity = 130f; //max capacity of car as fuel engine 

            return MaxEngineCapacity;
        }


        public override string ToString()
        {
            return string.Format("{0}, Does drive refrigerated contents: {1}, Luggage capacity: {2}", base.ToString(), r_DoesDriveRefrigeratedContents, r_LuggageCapacity);
        }
    }
}
