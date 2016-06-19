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
using BraspagHackathon.TimeZado.Services;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Criando botão de compra")]
    public class DeviceCreationActivity : Activity
    {
        private TextView offerDescriptionText;
        private TextView offerQuantityText;
        private TextView offerPriceText;
        private TextView offerMerchantNameText;

        private Button createDeviceButton;

        public int offerId;
        public int customerId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DeviceCreation);

            this.offerDescriptionText = FindViewById<TextView>(Resource.Id.OfferDescriptionText);
            this.offerQuantityText = FindViewById<TextView>(Resource.Id.OfferQuantityText);
            this.offerPriceText = FindViewById<TextView>(Resource.Id.OfferPriceText);
            this.offerMerchantNameText = FindViewById<TextView>(Resource.Id.OfferMerchantNameText);

            this.createDeviceButton = FindViewById<Button>(Resource.Id.CreateDeviceButton);

            createDeviceButton.Click += CreateDeviceButton_Click;

            var dataProvider = InMemoryDataProvider.GetDataProvider();

            var configuration = dataProvider.Read<GlobalConfiguration>().First(x => x.Key == GlobalConfigurationKeys.CostumerId);

            this.customerId = int.Parse(configuration.Value);
            this.offerId = int.Parse(Intent.GetStringExtra("OfferId"));

            this.offerDescriptionText.Text = Intent.GetStringExtra("OfferDescription");
            this.offerPriceText.Text = string.Format("Preço: {0}", Intent.GetStringExtra("OfferPrice"));
            this.offerQuantityText.Text = string.Format("Quantidade: {0}", Intent.GetStringExtra("OfferQuantity"));
            this.offerMerchantNameText.Text = string.Format("Oferta de {0}", Intent.GetStringExtra("MerchantName"));
        }

        private void CreateDeviceButton_Click(object sender, EventArgs e)
        {
            var service = new DeviceService();

            service.CreateVirtualDevice(device =>
            {
                device.CustomerId = this.customerId;
                device.OfferId = this.offerId;

                service.UpdateVirutalDevice(updatedDevice =>
                {
                    var data = new DeviceDisplayData
                    {
                        Device = updatedDevice,
                        MerchantName = this.offerMerchantNameText.Text,
                        OfferName = this.offerDescriptionText.Text,
                        Price = this.offerPriceText.Text,
                        Quantity = this.offerQuantityText.Text
                    };

                    DataHolder.Devices.Add(data);

                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                },
                device);
            });
        }
    }
}