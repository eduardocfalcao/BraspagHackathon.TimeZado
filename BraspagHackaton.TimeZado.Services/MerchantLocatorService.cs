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
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado.Services
{
    public class MerchantLocatorService : IMerchantLocatorService
    {
        public List<Merchant> GetNearbyMerchants(double latitude, double longitude, double maxDistanceInMiles = 5)
        {
            throw new NotImplementedException();
        }
    }
}