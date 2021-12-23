using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Models
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorPossibleOptions m_DoorAmount;
        private const string k_CarColorInitInfoMsg = "Enter car's color: 1 for Red, 2 for White, 3 for Black, 4 for Blue";
        private const string k_DoorAmountInitInfoMsg = "Enter amount of doors between 2 to 5 (2,3,4,5)";
        private const string k_DoorAmountArgumentExceptionMsg = "Invalid value by setting door amount";
        private const string k_CarColorArgumentExceptionMsg = "Invalid value by setting car color";
        private const string k_DoorAmountFormatExceptionMsg = "Wrong format by setting door amount";
        private const string k_CarColorFormatExceptionMsg = "Wrong format by setting car color";

        public Car(Engine i_Engine, List<Tier> i_Tiers)
            : base(i_Engine, i_Tiers)
        {
            m_UniqeMembersToInitInfo = new string[] { k_DoorAmountInitInfoMsg, k_CarColorInitInfoMsg };
        }

        public override void SetUniqeMembers(List<string> i_UniqeMembers)
        {
            SetDoorAmount(i_UniqeMembers[0]);
            SetCarColor(i_UniqeMembers[1]);
        }

        private void SetCarColor(string i_Value)
        {
            m_CarColor = (eCarColor)getEnumValueOtherwiseThrowException<eCarColor>(i_Value, k_CarColorArgumentExceptionMsg, k_CarColorFormatExceptionMsg);
        }

        private void SetDoorAmount(string i_Value)
        {
            m_DoorAmount = (eDoorPossibleOptions)getEnumValueOtherwiseThrowException<eDoorPossibleOptions>(i_Value, k_DoorAmountArgumentExceptionMsg, k_DoorAmountFormatExceptionMsg);
        }

        private int getEnumValueOtherwiseThrowException<T>(string i_Value, string i_ArgumentExceptionMsg, string i_FormatExceptionMsg)
        {
            int valueAsInt;
            bool isRepresnetAnEnum = false;

            if (int.TryParse(i_Value, out valueAsInt))
            {
                foreach (int doorOption in Enum.GetValues(typeof(T)))
                {
                    if (doorOption == valueAsInt)
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

        public override string ToString()
        {
            return string.Format("{0}, Color: {1}, Doors amount: {2}", base.ToString(), nameof(m_CarColor), m_DoorAmount);
        }
    }
}
