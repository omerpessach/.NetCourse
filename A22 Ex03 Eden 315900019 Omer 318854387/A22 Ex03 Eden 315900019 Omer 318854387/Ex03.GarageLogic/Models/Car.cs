using Ex03.GarageLogic.Enums;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Models
{
    public class Car : Vehicle
    {
        private eCarColor            m_CarColor;
        private eDoorPossibleOption m_DoorAmount;
        private const string         k_CarColorInitInfoMsg = "Enter car's color: 1 for Red, 2 for White, 3 for Black, 4 for Blue";
        private const string         k_DoorAmountInitInfoMsg = "Enter amount of doors between 2 to 5 (2,3,4,5)";
        private const string         k_DoorAmountArgumentExceptionMsg = "Invalid value by setting door amount";
        private const string         k_CarColorArgumentExceptionMsg = "Invalid value by setting car color";
        private const string         k_DoorAmountFormatExceptionMsg = "Wrong format by setting door amount";
        private const string         k_CarColorFormatExceptionMsg = "Wrong format by setting car color";

        public Car(Engine i_Engine, List<Tier> i_Tiers): base(i_Engine, i_Tiers)
        {
            m_UniqeMembersToInitInfo = new string[] { k_DoorAmountInitInfoMsg, k_CarColorInitInfoMsg };
        }

        private void            setCarColor(string i_Value)
        {
            m_CarColor = (eCarColor)GarageHelper.GetEnumValueOtherwiseThrowException<eCarColor>(i_Value, k_CarColorArgumentExceptionMsg, k_CarColorFormatExceptionMsg);
        }

        private void            setDoorAmount(string i_Value)
        {
            m_DoorAmount = (eDoorPossibleOption)GarageHelper.GetEnumValueOtherwiseThrowException<eDoorPossibleOption>(i_Value, k_DoorAmountArgumentExceptionMsg, k_DoorAmountFormatExceptionMsg);
        }

        public override void    SetUniqeMembers(List<string> i_UniqeMembers)
        {
            setDoorAmount(i_UniqeMembers[0]);
            setCarColor(i_UniqeMembers[1]);
        }

        public override string  ToString()
        {
            return string.Format(@"{0}
Color: {1}
Doors amount: {2}", base.ToString(), m_CarColor, m_DoorAmount);
        }
    }
}
