using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorPossibleOptions m_DoorAmount;

        public Car(string i_ModelName, string i_LicenceID, Engine i_Engine, eCarColor i_Color, eDoorPossibleOptions i_DoorsAmount)
            : base(i_ModelName, i_LicenceID, i_Engine)
        {
            m_CarColor = i_Color;
            m_DoorAmount = i_DoorsAmount;
        }

        public eCarColor CarColor { get => m_CarColor; set => m_CarColor = value; }
        public eDoorPossibleOptions DoorAmount { get => m_DoorAmount; set => m_DoorAmount = value; }

        public override string ToString()
        {
            return string.Format("{0}, Color: {1}, Doors amount: {2}", base.ToString(), nameof(m_CarColor), m_DoorAmount);
        }
    }
}
