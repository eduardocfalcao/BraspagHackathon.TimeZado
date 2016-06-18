using Android.Locations;
using BraspagHackaton.TimeZado.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraspagHackaton.TimeZado.Services
{
    public interface IMerchantAddressService
    {
        Merchant[] GetNearbyMerchants(double latitude, double longitude);
    }
}
