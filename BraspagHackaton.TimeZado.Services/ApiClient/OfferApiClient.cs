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
using System.Threading.Tasks;

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class OfferApiClient
    {
        public OfferApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;
        }

        private readonly BlackboxApiClient _blackboxApiClient;

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public async Task<List<Offer>> GetOffersOfMerchant(Guid merchantId)
        {
            var resourceUri = string.Format("offer/merchant/{0}", merchantId);

            return await BlackboxApiClient.Get<List<Offer>>(resourceUri);
        }
    }
}