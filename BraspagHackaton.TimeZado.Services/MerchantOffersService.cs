using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackaton.TimeZado.Services.ApiClient;

namespace BraspagHackaton.TimeZado.Services
{
    public class MerchantOffersService
    {
        private readonly Guid merchantId;

        public MerchantOffersService(Guid merchantId)
        {
            this.merchantId = merchantId;
        }

        public async void LoadOffers(Action<List<Offer>> callback)
        {
            var offers = await LoadOffersFromApi();

            if (callback != null)
            {
                callback.Invoke(offers);
            }
        }

        private async Task<List<Offer>> LoadOffersFromApi()
        {
            var api = new OfferApiClient(new BlackboxApiClient());

            return await api.GetOffersOfMerchant(this.merchantId);
        }
    }
}