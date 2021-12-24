using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(string message, float i_MinValue, float i_MaxValue) : base(message)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MaxValue { get => m_MaxValue; set => m_MaxValue = value; }
        public float MinValue { get => m_MinValue; set => m_MinValue = value; }
    }
}
