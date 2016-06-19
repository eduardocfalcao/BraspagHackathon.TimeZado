using System;
using System.Collections.Generic;
using System.Linq;
using Android.Locations;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackathon.TimeZado.Extensions;
using BraspagHackaton.TimeZado.Services.ApiClient;
using System.Threading.Tasks;

namespace BraspagHackathon.TimeZado.Services
{
    public class MerchantLocatorService
    {
        public async void GetNearbyMerchants(Action<List<MerchantGpsData>> callback, Address address, double maxDistanceInMiles = 2)
        {
            var addresses = new MerchantAddressDictionary();
            var merchants = await LoadMerchantsFromApi();

            var nearbyKeys = addresses.Where(a => a.Value.DistanceInMilesFrom(address) <= maxDistanceInMiles).Select(a => a.Key);
            var nearbyMerchants = merchants.Where(m => nearbyKeys.Contains(m.MerchantId));
            var merchantsGpsData = merchants.Select(m => new MerchantGpsData { Merchant = m, Address = addresses[m.MerchantId] });

            if (callback != null)
            {
                callback.Invoke(merchantsGpsData.ToList());
            }
        }

        private async Task<List<Merchant>> LoadMerchantsFromApi()
        {
            var api = new MerchantApiClient(new BlackboxApiClient());

            return await api.GetAll();
        }
    }
}