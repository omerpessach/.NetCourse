using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class GarageHelper
    {
        public static int GetEnumValueOtherwiseThrowException<T>(string i_Value, string i_ArgumentExceptionMsg, string i_FormatExceptionMsg)
        {
            int valueAsInt;
            bool isRepresnetAnEnum = false;

            if (int.TryParse(i_Value, out valueAsInt))
            {
                foreach (int value in Enum.GetValues(typeof(T)))
                {
                    if (value == valueAsInt)
                    {
                        isRepresnetAnEnum = true;
                        break;
                    }
                }

                if (!isRepresnetAnEnum)
                {
                    throw new ArgumentException(i_ArgumentExceptionMsg);
                }
            }
            else
            {
                throw new FormatException(i_FormatExceptionMsg);
            }

            return valueAsInt;
        }
    }
}
