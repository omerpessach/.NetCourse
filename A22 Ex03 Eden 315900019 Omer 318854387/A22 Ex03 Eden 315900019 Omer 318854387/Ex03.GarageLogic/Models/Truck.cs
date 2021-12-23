using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class Truck : Vehicle
    {
        private bool r_DoesDriveRefrigeratedContents;
        private float r_LuggageCapacity;
        private const string k_DoesDriveRefrigeratedContentsInitInfoMsg = "Does drive refrigerated contents? Y/N";
        private const string k_LuggageCapacityInitInfoMsg = "Type luggage capacity";

        public Truck(Engine i_Engine, List<Tier> i_Tiers)
            : base(i_Engine, i_Tiers)
        {
            m_UniqeMembersToInitInfo = new string[] { k_DoesDriveRefrigeratedContentsInitInfoMsg, k_LuggageCapacityInitInfoMsg };
        }

        public override void SetUniqeMembers(List<string> i_UniqeMembers)
        {
            SetDoesDriveRefrigeratedContents(i_UniqeMembers[0]);
            SetLuggageCapacity(i_UniqeMembers[1]);
        }

        private void SetDoesDriveRefrigeratedContents(string i_Value)
        {
            if (i_Value.ToUpper().Equals("Y") || i_Value.ToUpper().Equals("N"))
            {
                r_DoesDriveRefrigeratedContents = i_Value.ToUpper().Equals("Y");
            }
            else
            {
                throw new FormatException("Invalid value, the value should be Y or N");
            }
        }

        private void SetLuggageCapacity(string i_Value)
        {
            float valueAsFloat;

            if (float.TryParse(i_Value, out valueAsFloat))
            {
                if (valueAsFloat >= 0)
                {
                    r_LuggageCapacity = valueAsFloat;
                }
                else
                {
                    throw new ValueOutOfRangeException("The value is lower than 0", 0, float.MaxValue);
                }
            }
            else
            {
                throw new FormatException("The input is not a number");
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Does drive refrigerated contents: {1}
Luggage capacity: {2}", base.ToString(), r_DoesDriveRefrigeratedContents, r_LuggageCapacity);
        }
    }
}
