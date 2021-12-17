using Ex03.GarageLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class GarageManager
    {
        readonly Dictionary<string, GarageVehical> r_GarageVehicals = new Dictionary<string, GarageVehical>();
    }
}
