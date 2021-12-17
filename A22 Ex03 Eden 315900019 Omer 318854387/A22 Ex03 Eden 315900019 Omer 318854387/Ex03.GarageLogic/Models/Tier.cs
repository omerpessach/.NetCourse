using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    internal class Tier
    {
        private readonly string r_Manufacturer;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Tier(string i_Manufacturer, float i_MaxAirPressure, float i_currentAirPressure = 0)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_currentAirPressure;
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        public void Blow(float i_AirToAdd)
        {
            if (i_AirToAdd < 0)
            {
                throw new ValueOutOfRangeException("Negative number is not allowed");
            }
            else if (i_AirToAdd + m_CurrentAirPressure > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("The value is too high");
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }
    }
}
