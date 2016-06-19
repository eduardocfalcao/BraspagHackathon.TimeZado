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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class BlackboxApiClient
    {
        public BlackboxApiClient()
            :this("https://braspaglabs.azure-api.net/blackbox/api/v1/")
        { }

        public BlackboxApiClient(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        private readonly string _apiUrl;

        public string ApiUrl { get { return _apiUrl; } }

        public async Task Post(string resourceUri, object postBody)
        {
            var uri = ApiUrl + resourceUri;
            var httpContent = new StringContent(JsonConvert.SerializeObject(postBody),
                                                Encoding.UTF8,
                                                "application/json");

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uri, httpContent);

            response.EnsureSuccessStatusCode();            
        }


        public async Task<T> Post<T>(string resourceUri, object postBody)
        {
            var uri = ApiUrl + resourceUri;
            var httpContent = new StringContent(JsonConvert.SerializeObject(postBody), 
                                                Encoding.UTF8, 
                                                "application/json");

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uri, httpContent);



            response.EnsureSuccessStatusCode();
            var resultContentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(resultContentString);
        }

        public void Put<T> (string resourceUri, object putBody)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>(string resourceUri)
        {
            var uri = ApiUrl + resourceUri;
           
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();
            var resultContentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(resultContentString);
        }


    }
}