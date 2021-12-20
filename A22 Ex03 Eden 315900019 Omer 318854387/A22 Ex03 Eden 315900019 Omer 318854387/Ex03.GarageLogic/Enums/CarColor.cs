using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Enums
{
    public class CarColor
    {
        private eCarColor m_ChosenCarColor;

        public static CarColor ChoiseColor(int i_colorInputFromUser)
        {
            CarColor currentCarColor = new CarColor();

            switch(i_colorInputFromUser)
            {
                case 1:
                    currentCarColor.m_ChosenCarColor = eCarColor.Red;
                    break;
                case 2:
                    currentCarColor.m_ChosenCarColor = eCarColor.White;
                    break;
                case 3:
                    currentCarColor.m_ChosenCarColor = eCarColor.Black;
                    break;
                case 4:
                    currentCarColor.m_ChosenCarColor = eCarColor.Blue;
                    break;
                default:
                    throw new FormatException("Wrong input. There is no color that fits to this input");
            }

            return currentCarColor;
        }

        public eCarColor ChosenCarColor
        {
            get
            {
                return m_ChosenCarColor;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}", ChosenCarColor);
        }
    }
}
