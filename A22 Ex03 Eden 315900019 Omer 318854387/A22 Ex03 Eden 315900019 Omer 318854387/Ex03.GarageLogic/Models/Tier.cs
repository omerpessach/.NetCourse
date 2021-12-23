using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic.Models
{
    public class Tier
    {
        private readonly float r_MaxAirPressure;
        private string         m_Manufacturer;
        private float          m_CurrentAirPressure;

        public Tier(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string          Manufacturer
        {
            get => m_Manufacturer;
            set => m_Manufacturer = value;
        }

        public void            Blow(float i_AirToAdd)
        {
            if (i_AirToAdd < 0)
            {
                throw new ArgumentException("Negative number is not allowed");
            }
            else if (m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("The value is too high", 0, r_MaxAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public void            BlowToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format("Manufacturer: {0}, r_Max Air Pressure: {1}, Current Air Pressure {2}", m_Manufacturer, r_MaxAirPressure, m_CurrentAirPressure);
        }
    }
}
