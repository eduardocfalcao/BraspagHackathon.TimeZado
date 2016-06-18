using Android.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraspagHackathon.TimeZado.Extensions
{
    public static class AddressExtensions
    {
        public static double DistanceInMilesFrom(this Address remoteAddress, Address localAddress)
        {
            return (3959 * Math.Acos(Math.Cos(localAddress.Latitude.ToRadians()) * Math.Cos(remoteAddress.Latitude.ToRadians()) * Math.Cos(remoteAddress.Longitude.ToRadians() - localAddress.Longitude.ToRadians()) + Math.Sin(localAddress.Latitude.ToRadians()) * Math.Sin(remoteAddress.Latitude.ToRadians())));
        }
    }
}
