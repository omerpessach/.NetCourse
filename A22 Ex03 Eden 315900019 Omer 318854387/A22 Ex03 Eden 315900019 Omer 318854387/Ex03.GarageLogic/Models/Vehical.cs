using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public abstract class Vehicle
    {
        protected readonly string   r_ModelName;
        protected readonly string   r_LicenceID;
        protected float             m_CurrentEnergy;
        protected float             m_MaxEnergyCapacity;
        protected readonly List<Tier> r_Tiers; 

        protected Vehicle(string i_ModelName, string i_LicenceID) //should we use here in prop?
        {
            r_ModelName = i_ModelName;
            r_LicenceID = i_LicenceID;
        }

        public List<Tier> Tiers
        {
            get
            {
                return r_Tiers;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenceID
        {
            get
            {
                return r_LicenceID;
            }
        }
    }
}
