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
using BraspagHackaton.TimeZado.Services.ApiClient.Response;
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class CreditCardApiClient
    {
        public CreditCardApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;   
        }

        private readonly BlackboxApiClient _blackboxApiClient;

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public CreditCardCreateResponse Create(CreditCard creditCard)
        {
            return BlackboxApiClient.Post<CreditCardCreateResponse>("creditCard", creditCard);           
        }
    }
}