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
using System.Threading.Tasks;

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class CreditCardApiClient
    {
        public CreditCardApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;   
        }
        public CreditCardApiClient()
            : this (new BlackboxApiClient()) 
        {
                
        }

        private readonly BlackboxApiClient _blackboxApiClient;

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public async Task<CreditCardCreateResponse> Create(CreateCreditCardRequest creditCard)
        {
            return await BlackboxApiClient.Post<CreditCardCreateResponse>("creditCard", creditCard);           
        }
    }
}