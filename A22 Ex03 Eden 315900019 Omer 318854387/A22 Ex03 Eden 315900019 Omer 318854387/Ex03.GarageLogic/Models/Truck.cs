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
            r_DoesDriveRefrigeratedContents = i_DoesDriveRefrigeratedContents;
            r_LuggageCapacity = i_LuggageCapacity;
        }

        public override string ToString()
        {
            return string.Format("{0}, Does drive refrigerated contents: {1}, Luggage capacity: {2}", base.ToString(), r_DoesDriveRefrigeratedContents, r_LuggageCapacity);
        }
    }
}
