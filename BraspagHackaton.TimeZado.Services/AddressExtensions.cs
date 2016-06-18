using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BraspagHackaton.TimeZado.Services
{
    public static class AddressExtensions
    {

        public static double DistanceInMilesFrom(this Address remoteAddress, Address localAddress)
        {
            return (3959 * Math.Acos(Math.Cos(localAddress.Latitude.ToRadians()) 
                    * Math.Cos(remoteAddress.Latitude.ToRadians()) 
                    * Math.Cos(remoteAddress.Longitude.ToRadians() 
                                - localAddress.Longitude.ToRadians()) 
                                + Math.Sin(localAddress.Latitude.ToRadians()) 
                                * Math.Sin(remoteAddress.Latitude.ToRadians())));
        }
    }
}