using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public abstract class Vehicle
    {
        private readonly List<Tier> r_Tiers;
        private string              m_ModelName;
        private string              m_LicenseID;
        private Engine              m_Engine;
        protected string[]          m_UniqeMembersToInitInfo;

        protected Vehicle(Engine i_Engine, List<Tier> i_Tiers)
        {
            m_Engine = i_Engine;
            r_Tiers = i_Tiers;
        }

        internal List<Tier> Tiers
        {
            get
            {
                return r_Tiers;
            }
        }

        internal string LicenseID
        {
            get
            {
                return m_LicenseID;
            }
        }

        internal Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public string[] UniqeMembersToInitInfo
        {
            get
            {
                return m_UniqeMembersToInitInfo;
            }
        }

        private string getTiersInfo()
        {
            return r_Tiers[0].ToString();
        }

        public abstract void SetUniqeMembers(List<string> i_UniqeMembers);

        public void InitBasicInfo(string i_LicenseID, string i_ModelName)
        {
            m_LicenseID = i_LicenseID;
            m_ModelName = i_ModelName;
        }

        public void InitTierInfo(string i_Manufacturer, float i_AirToAdd)
        {
            foreach (Tier tier in r_Tiers)
            {
                tier.Blow(i_AirToAdd);
                tier.Manufacturer = i_Manufacturer;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"License ID: {0}
Model name: {1}
Tiers Info: {2}", m_LicenseID, m_ModelName, getTiersInfo());
        }
    }
}
