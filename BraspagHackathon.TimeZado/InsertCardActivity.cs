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
using RequestCreditCard = BraspagHackaton.TimeZado.Services.ApiClient.Requests.CreateCreditCardRequest;
using BraspagHackaton.TimeZado.Model;
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Inserir Cartão de crédito")]
    public class InsertCardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.InsertCardWindow);

            var button = FindViewById<Button>(Resource.Id.InsertCardButton);

            button.Click += InsertCard;
        }

        private async void InsertCard(object sender, EventArgs e)
        {
            var apiClient = new CreditCardApiClient();
            var dataProvider = InMemoryDataProvider.GetDataProvider();

            var customerId = int.Parse(dataProvider.Read<GlobalConfiguration>()
                                          .Single(x => x.Key == GlobalConfigurationKeys.CostumerId)
                                          .Value);

            var creditCard = new RequestCreditCard()
            {
                Holder = FindViewById<EditText>(Resource.Id.Holder).Text,
                Number = FindViewById<EditText>(Resource.Id.CardNumber).Text,
                Cvv = FindViewById<EditText>(Resource.Id.Cvv).Text,
                ValidThru = FindViewById<EditText>(Resource.Id.ValidThru).Text,
                CustomerId = customerId
            };

            var creditCardResponse = await apiClient.Create(creditCard);

            var creditCardModel = new CreditCard()
            {
                CreatedOn = creditCardResponse.CreatedOn,
                CostumerId = creditCardResponse.CustomerId,
                Id = creditCardResponse.Id,
                MaskedValue = creditCardResponse.MaskedValue,
                Token = creditCardResponse.Token
            };

            dataProvider.Insert(creditCardModel);
        }
    }
}