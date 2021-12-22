using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    public class Tier
    {
        private readonly float r_MaxAirPressure;
        private string m_Manufacturer;
        private float m_CurrentAirPressure;

        public Tier(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void Blow(float i_AirToAdd)
        {
            if (i_AirToAdd < 0)
            {
                throw new ValueOutOfRangeException("Negative number is not allowed");
            }
            else if (m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("The value is too high");
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public void BlowToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format("Manufacturer: {0}, r_Max Air Pressure: {1}, Current Air Pressure {2}", m_Manufacturer, r_MaxAirPressure, m_CurrentAirPressure);
        }
    }
}
