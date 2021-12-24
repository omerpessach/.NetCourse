using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic.Models
{
    public class Tier
    {
        private readonly float r_MaxAirPressure;
        private string         m_Manufacturer;
        private float          m_CurrentAirPressure;
        private const string   k_BlowArgumentExceptionMsg = "Negative number is not allowed";
        private const string   k_BlowValueOutOfRangeExceptionMsg = "The value is too high";

        public Tier(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string          Manufacturer
        {
            set => m_Manufacturer = value;
        }

        public void            Blow(float i_AirToAdd)
        {
            if (i_AirToAdd < 0)
            {
                throw new ArgumentException(k_BlowArgumentExceptionMsg);
            }
            else if (m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(k_BlowValueOutOfRangeExceptionMsg, 0, r_MaxAirPressure);
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
            return string.Format(
@"Manufacturer: {0},
Max Air Pressure: {1},
Current Air Pressure {2}", m_Manufacturer, r_MaxAirPressure, m_CurrentAirPressure);
        }
    }
}
