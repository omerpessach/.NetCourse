using Ex03.GarageLogic.Enums;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Models
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorPossibleOptions m_DoorAmount;

        public Car(Engine i_Engine, List<Tier> i_Tiers)
            : base(i_Engine, i_Tiers)
        {
        }

        public eCarColor CarColor { get => m_CarColor; set => m_CarColor = value; }
        public eDoorPossibleOptions DoorAmount { get => m_DoorAmount; set => m_DoorAmount = value; }

        public override string ToString()
        {
            return string.Format("{0}, Color: {1}, Doors amount: {2}", base.ToString(), nameof(m_CarColor), m_DoorAmount);
        }
    }
}
