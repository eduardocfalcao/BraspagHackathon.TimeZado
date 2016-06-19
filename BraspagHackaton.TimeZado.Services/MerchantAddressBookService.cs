using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BraspagHackathon.TimeZado.Model.Entities;
using Java.Util;
using BraspagHackathon.TimeZado.Services;
using BraspagHackathon.TimeZado.Extensions;
using BraspagHackaton.TimeZado.Services.ApiClient;
using System.Threading.Tasks;

namespace BraspagHackathon.TimeZado.Services
{
    public class MerchantAddressBookService
    {
        private readonly Dictionary<Guid, Address> addresses;
        private List<Merchant> merchants;

        public MerchantAddressBookService()
        {
            this.addresses = new Dictionary<Guid, Address>();

            Task.Run(this.Initialize).Wait();
        }

        private async Task Initialize()
        {
            // Inicializa o cache de lojas - isto poderia ser diferente se pud�ssemos buscar na API lojas por endere�o f�sico
            this.merchants = await LoadMerchantsFromApi();

            // Inicializa o cat�logo de endere�os - neste exemplo preencher� com dados padr�o em mem�ria
            this.addresses.Add(TimeZadoMerchantCredentials.MerchantIdGuid, TimeZadoMerchantCredentials.MerchantAddress);
        }

        private async Task<List<Merchant>> LoadMerchantsFromApi()
        {
            var api = new MerchantApiClient(new BlackboxApiClient(@"https://braspaglabs.azure-api.net/blackbox/api/v1/"));

            return await api.GetAll();
        }

        public List<Merchant> GetNearbyMerchants(Address localAddress, double maxDistanceInMiles = 2)
        {
            var nearbyKeys = this.addresses.Where(a => a.Value.DistanceInMilesFrom(localAddress) <= maxDistanceInMiles).Select(a => a.Key);

            return merchants.Where(m => nearbyKeys.Contains(m.MerchantId)).ToList();
        }

        public Address Get(Merchant merchant)
        {
            if (!this.addresses.ContainsKey(merchant.MerchantId))
            {
                return null;
            }

            return this.addresses[merchant.MerchantId];
        }

        public void Set(Address address, Merchant merchant)
        {
            this.addresses[merchant.MerchantId] = address;
        }
    }
}