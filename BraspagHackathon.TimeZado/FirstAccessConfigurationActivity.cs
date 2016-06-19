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
using BraspagHackaton.TimeZado.Services.ApiClient;
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;
using BraspagHackaton.TimeZado.Model;
using BraspagHackathon.TimeZado.Model.Entities;
using System.Threading.Tasks;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Gerenciar cartões")]
    public class FirstAccessConfigurationActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FirstAccessConfiguration);

            var createCustomerButton = FindViewById(Resource.Id.CreateCustomerButton);
            createCustomerButton.Click += CreateCustomerButton_Click;
        }

        private async void CreateCustomerButton_Click(object sender, EventArgs e)
        {
            var api = new CustomerApiClient(new BlackboxApiClient("https://braspaglabs.azure-api.net/blackbox/api/v1/"));

            var customerApiRequest = new Customer()
            {
                AddressId = 100,
                CreditCardId = 200,
                FisrtName = FindViewById<EditText>(Resource.Id.FirstName).Text,
                LastName = FindViewById<EditText>(Resource.Id.LastName).Text,
                Email = FindViewById<EditText>(Resource.Id.Email).Text
            };

            var customerResponse = await api.Create(customerApiRequest);

            var dataProvider = InMemoryDataProvider.GetDataProvider();

            var configuration = new GlobalConfiguration()
            {
                Key = GlobalConfigurationKeys.CostumerId,
                Value = customerResponse.Id.ToString()
            };

            dataProvider.Insert(configuration);
        }
    }
}