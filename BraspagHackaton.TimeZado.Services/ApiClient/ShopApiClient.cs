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
using System.Threading.Tasks;
using BraspagHackaton.TimeZado.Services.ApiClient.Response;
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class ShopApiClient
    {

        private readonly BlackboxApiClient _blackboxApiClient;

        public ShopApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;
        }
        
        public ShopApiClient()
            :this(new BlackboxApiClient())
        {

        }

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public async Task<CreateShopResponse> Post(CreateShopRequest request)
        {
            return await BlackboxApiClient.Post<CreateShopResponse>("shop", request);
        }
    }
}