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
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;
using BraspagHackaton.TimeZado.Services.ApiClient.Response;

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class CustomerApiClient
    {
        public CustomerApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;
        }

        private readonly BlackboxApiClient _blackboxApiClient;

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public async Task<CustomerCreateApiResponse> Create(Customer customer)
        {
            return await BlackboxApiClient.Post<CustomerCreateApiResponse>("customer", customer);
        }
    }
}