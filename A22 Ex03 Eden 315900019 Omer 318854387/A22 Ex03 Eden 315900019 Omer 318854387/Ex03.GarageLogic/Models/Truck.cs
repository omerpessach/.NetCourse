﻿using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class Truck : Vehicle
    {
        private bool         m_DoesDriveRefrigeratedContents;
        private float        m_LuggageCapacity;
        private const string k_DoesDriveRefrigeratedContentsInitInfoMsg = "Does drive refrigerated contents? Y/N";
        private const string k_LuggageCapacityInitInfoMsg = "Type luggage capacity";

        public Truck(Engine i_Engine, List<Tier> i_Tiers)
            : base(i_Engine, i_Tiers)
        {
            m_UniqeMembersToInitInfo = new string[] { k_DoesDriveRefrigeratedContentsInitInfoMsg, k_LuggageCapacityInitInfoMsg };
        }

        public override void    SetUniqeMembers(List<string> i_UniqeMembers)
        {
            setDoesDriveRefrigeratedContents(i_UniqeMembers[0]);
            setLuggageCapacity(i_UniqeMembers[1]);
        }

        private void            setDoesDriveRefrigeratedContents(string i_Value)
        {
            if (i_Value.ToUpper().Equals("Y") || i_Value.ToUpper().Equals("N"))
            {
                m_DoesDriveRefrigeratedContents = i_Value.ToUpper().Equals("Y");
            }
            else
            {
                throw new FormatException("Invalid value, the value should be Y or N");
            }
        }

        private void            setLuggageCapacity(string i_Value)
        {
            float valueAsFloat;

            if (float.TryParse(i_Value, out valueAsFloat))
            {
                if (valueAsFloat >= 0)
                {
                    m_LuggageCapacity = valueAsFloat;
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

        public override string  ToString()
        {
            return string.Format(
@"{0}
Does drive refrigerated contents: {1}
Luggage capacity: {2}", base.ToString(), m_DoesDriveRefrigeratedContents, m_LuggageCapacity);
        }
    }
}
