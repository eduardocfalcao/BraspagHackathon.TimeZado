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

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class BlackboxApiClient
    {

        public BlackboxApiClient(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        private readonly string _apiUrl;

        public string ApiUrl { get { return _apiUrl; } }


        public T Post<T>(string resourceUri, object postBody)
        {
            return default(T);
        }

        public void Put<T> (string resourceUri, object putBody)
        {

        }

        public T Get<T>(string resourceUri)
        {
            return default(T);
        }


    }
}