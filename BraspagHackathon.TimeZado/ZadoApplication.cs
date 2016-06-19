using System.Collections.Generic;

using Android.App;
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado
{
    public class ZadoApplication : Application
    {
        public List<DeviceDisplayData> Devices { get; set; }
    }
}