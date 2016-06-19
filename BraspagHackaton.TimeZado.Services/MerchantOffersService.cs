using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackaton.TimeZado.Services.ApiClient;

namespace BraspagHackaton.TimeZado.Services
{
    public class MerchantOffersService
    {
        private List<Offer> offers;
        private readonly Guid merchantId;

        public MerchantOffersService(Guid merchantId)
        {
            this.merchantId = merchantId;
            this.Initialize();
        }

        private async void Initialize()
        {
            this.offers = await LoadOffersFromApi();
        }

        private async Task<List<Offer>> LoadOffersFromApi()
        {
            var api = new OfferApiClient(new BlackboxApiClient());

            return await api.GetOffersOfMerchant(this.merchantId);
        }

        public List<Offer> GetAll()
        {
            return this.offers;
        }
    }
}