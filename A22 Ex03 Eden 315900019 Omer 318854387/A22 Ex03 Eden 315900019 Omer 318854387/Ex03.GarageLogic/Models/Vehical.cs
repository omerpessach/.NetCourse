using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicenceID;
        protected readonly Engine r_Engine;
        protected readonly List<Tier> r_Tiers;

        protected Vehicle(string i_ModelName, string i_LicenceID, Engine i_Engine)
        {
            r_ModelName = i_ModelName;
            r_LicenceID = i_LicenceID;
            r_Engine = i_Engine;
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
            get => Tiers.Count;
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

        public Engine Engine
        {
            get
            {
                return r_Engine;
            }
        }

        public override string ToString()
        {
            return string.Format("Licence ID: {0}, Model name: {1}", LicenceID, ModelName);
        }
    }
}
