using Android.Locations;
using BraspagHackathon.TimeZado.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraspagHackathon.TimeZado.Services
{
    public interface IMerchantLocatorService
    {
        List<Merchant> GetNearbyMerchants(double latitude, double longitude, double maxDistanceInMiles = 2);
    }
}
