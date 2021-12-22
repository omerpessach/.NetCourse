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

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
            set
            {
                m_Manufacturer = value;
            }
        }

        public void SetrequiredDataForTier(string i_Manufacturer, float i_CurrentAirPressure)
        {
            if((i_CurrentAirPressure< 0) || (i_CurrentAirPressure > r_MaxAirPressure))
            {
                throw new ValueOutOfRangeException(string.Format(@"the current air pressure {0} isn't valid", i_CurrentAirPressure));
            }
            else
            {
                Manufacturer = i_Manufacturer;
                CurrentAirPressure = i_CurrentAirPressure;
            }
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
    }
}
