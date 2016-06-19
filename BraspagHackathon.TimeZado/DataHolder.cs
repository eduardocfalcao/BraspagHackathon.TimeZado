using System.Collections.Generic;

using Android.App;
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado
{
    public static class DataHolder
    {
        static DataHolder()
        {
            if (Devices == null)
            {
                Devices = new List<DeviceDisplayData>();
            }
        }

        public static List<DeviceDisplayData> Devices { get; private set; }
    }
}