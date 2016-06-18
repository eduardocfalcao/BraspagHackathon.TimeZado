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

namespace BraspagHackathon.TimeZado.Services
{
    public class MerchantAddressBookService : IMerchantAddressBookService
    {
        private readonly Dictionary<Guid, Address> addresses;

        public MerchantAddressBookService(ILocatorService locatorService)
        {
            this.addresses = new Dictionary<Guid, Address>();

            this.Initialize();
        }

        public List<Merchant> GetNearbyMerchants(Address localAddress)
        {
            throw new NotImplementedException();                             
        }

        private void Initialize()
        {
            // Inicializa o catálogo de endereços - neste exemplo preencherá com dados padrão em memória
            this.addresses.Add(TimeZadoMerchantCredentials.MerchantIdGuid, TimeZadoMerchantCredentials.MerchantAddress);
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