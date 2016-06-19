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
    public class MerchantApiClient
    {
        public MerchantApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;
        }

        private readonly BlackboxApiClient _blackboxApiClient;

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public async Task<List<Merchant>> GetAll()
        {
            return await BlackboxApiClient.Get<List<Merchant>>("merchant");
        }
    }
}