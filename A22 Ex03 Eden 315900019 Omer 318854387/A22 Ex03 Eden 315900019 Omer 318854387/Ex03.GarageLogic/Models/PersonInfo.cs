using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class PersonInfo
    {
        private readonly string r_FullName;
        private readonly string r_PhoneNumber;

        public PersonInfo(string i_FullName, string i_PhoneNumber)
        {
            r_FullName = i_FullName;
            r_PhoneNumber = i_PhoneNumber;
        }

        public override string ToString()
        {
            return string.Format("");
        }
    }
}
