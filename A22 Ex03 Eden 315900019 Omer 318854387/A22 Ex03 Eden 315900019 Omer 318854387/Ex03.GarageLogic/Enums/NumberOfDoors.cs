using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Enums
{
    class NumberOfDoors
    {
        private eDoorPossibleOptions m_AmountOfDoorsChosen;

        public static NumberOfDoors AnalysiOfAmountOfDoors(int i_AmountOfDoorsInput)
        {
            NumberOfDoors amountOfDoors = new NumberOfDoors();

            switch (i_AmountOfDoorsInput)
            {
                case 2:
                    amountOfDoors.m_AmountOfDoorsChosen = eDoorPossibleOptions.Two;
                    break;
                case 3:
                    amountOfDoors.m_AmountOfDoorsChosen = eDoorPossibleOptions.Three;
                    break;
                case 4:
                    amountOfDoors.m_AmountOfDoorsChosen = eDoorPossibleOptions.Four;
                    break;
                case 5:
                    amountOfDoors.m_AmountOfDoorsChosen = eDoorPossibleOptions.Five;
                    break;
                default:
                    throw new FormatException("Wrong input. There is no amount of doors that fits to this input");
            }

            return amountOfDoors;
        }

        public eDoorPossibleOptions AmountOfDoorsChosen
        {
            get
            {
                return m_AmountOfDoorsChosen;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}", AmountOfDoorsChosen);
        }
    }
}
