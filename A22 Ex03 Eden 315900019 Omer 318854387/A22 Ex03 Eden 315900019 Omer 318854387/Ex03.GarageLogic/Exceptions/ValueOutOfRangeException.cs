using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException: Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(string message) : base(message)
        {
        }
    }
}
