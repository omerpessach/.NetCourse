using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException: Exception
    {
        public ValueOutOfRangeException(string message) : base(message)
        {
        }
    }
}
