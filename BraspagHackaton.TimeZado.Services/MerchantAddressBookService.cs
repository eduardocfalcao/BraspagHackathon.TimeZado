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

            this.Initialize();
        }

        private async void Initialize()
        {
            // Inicializa o catálogo de endereços - neste exemplo preencherá com dados padrão em memória
            this.addresses.Add(TimeZadoMerchantCredentials.MerchantIdGuid, TimeZadoMerchantCredentials.MerchantAddress);

            // Inicializa o cache de lojas - isto poderia ser diferente se pudéssemos buscar na API lojas por endereço físico
            this.merchants = await LoadMerchantsFromApi();
        }

        private async Task<List<Merchant>> LoadMerchantsFromApi()
        {
            var api = new MerchantApiClient(new BlackboxApiClient());

            return await api.GetAll();
        }

        public List<Merchant> GetNearbyMerchants(Address localAddress, double maxDistanceInMiles = 2)
        {
            if (this.merchants != null && this.merchants.Any())
            {
                var nearbyKeys = this.addresses.Where(a => a.Value.DistanceInMilesFrom(localAddress) <= maxDistanceInMiles).Select(a => a.Key);

                return merchants.Where(m => nearbyKeys.Contains(m.MerchantId)).ToList();
            }

            return new List<Merchant>();
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