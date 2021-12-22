using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string r_LicenceID;
        protected Engine m_Engine;
        protected List<Tier> r_Tiers;

        protected Vehicle(Engine i_Engine, List<Tier> i_Tiers)
        {
            m_Engine = i_Engine;
            r_Tiers = i_Tiers;
        }

        public List<Tier> Tiers
        {
            get
            {
                return r_Tiers;
            }
        }

        public int TiersAmount
        {
            get
            {
                return Tiers.Count;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicenceID
        {
            get
            {
                return r_LicenceID;
            }
            set
            {
                r_LicenceID = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public override string ToString()
        {
            return string.Format("Licence ID: {0}, Model name: {1}", LicenceID, ModelName);
        }
    }
}
