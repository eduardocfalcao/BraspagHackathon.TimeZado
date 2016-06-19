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
using BraspagHackaton.TimeZado.Model;
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Criando botão de compra")]
    public class DeviceCreationActivity : Activity
    {
        private TextView offerDescriptionText;
        private TextView offerQuantityText;
        private TextView offerPriceText;
        private TextView offerMerchantNameText;

        public int offerId;
        public int customerId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DeviceCreation);

            var dataProvider = InMemoryDataProvider.GetDataProvider();

            var configuration = dataProvider.Read<GlobalConfiguration>().FirstOrDefault(x => x.Key == GlobalConfigurationKeys.CostumerId);

            if (configuration == null)
            {
                return;
            }

            this.customerId = int.Parse(configuration.Value);
            this.offerId = int.Parse(Intent.GetStringExtra("OfferId"));

            this.offerDescriptionText.Text = Intent.GetStringExtra("OfferDescription");
            this.offerPriceText.Text = Intent.GetStringExtra("OfferPrice");
            this.offerQuantityText.Text = Intent.GetStringExtra("OfferQuantity");
            this.offerMerchantNameText.Text = Intent.GetStringExtra("MerchantName");
        }
    }
}