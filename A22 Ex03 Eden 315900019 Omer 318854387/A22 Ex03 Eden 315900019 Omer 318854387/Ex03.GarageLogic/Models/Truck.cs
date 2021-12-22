using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class Truck : Vehicle
    {
        private readonly bool r_DoesDriveRefrigeratedContents;
        private readonly float r_LuggageCapacity;

        public Truck(Engine i_Engine, List<Tier> i_Tiers)
            : base(i_Engine, i_Tiers)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}, Does drive refrigerated contents: {1}, Luggage capacity: {2}", base.ToString(), r_DoesDriveRefrigeratedContents, r_LuggageCapacity);
        }
    }
}
