using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    internal abstract class Car : Vehicle
    {
        protected eCarColor      m_CarColor;
        protected eDoorPossibleOptions m_DoorAmount;

        public Car()
        {

        }

    }
}
