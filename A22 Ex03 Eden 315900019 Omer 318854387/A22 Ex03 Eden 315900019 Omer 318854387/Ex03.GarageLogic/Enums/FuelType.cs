using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Enums
{
    public class FuelType
    {
        private eFuelType m_currentFuelType;
        public static FuelType ChoiseFuelType(int i_FuelTypeInput)
        {
            FuelType currentFuel = new FuelType();

            switch (i_FuelTypeInput)
            {
                case 1:
                    currentFuel.m_currentFuelType = eFuelType.Octan95;
                    break;
                case 2:
                    currentFuel.m_currentFuelType = eFuelType.Octan96;
                    break;
                case 3:
                    currentFuel.m_currentFuelType = eFuelType.Octan98;
                    break;
                case 4:
                    currentFuel.m_currentFuelType = eFuelType.Soler;
                    break;
                default:
                    throw new FormatException("Wrong input. There is no fuel type that fits to this input");
            }

            return currentFuel;
        }

        public eFuelType CurrentFuelType
        {
            get
            {
                return m_currentFuelType;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}", CurrentFuelType);
        }
    }
}
}
