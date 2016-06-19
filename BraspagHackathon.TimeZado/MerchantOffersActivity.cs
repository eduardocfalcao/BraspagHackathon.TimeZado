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
using BraspagHackaton.TimeZado.Services;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackathon.TimeZado.Adpaters;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Ofertas da loja")]
    public class MerchantOffersActivity : Activity
    {
        private ListView offersList;
        private Guid merchantId;
        private string merchantName;
        private OfferListAdapter offerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MerchantOffers);

            this.offersList = FindViewById<ListView>(Resource.Id.OffersList);

            this.merchantId = Guid.Parse(Intent.GetStringExtra("MerchantId"));
            this.merchantName = Intent.GetStringExtra("MerchantName");

            DisplayMerchantOffers();
        }

        private void DisplayMerchantOffers()
        {
            var service = new MerchantOffersService(this.merchantId);

            service.LoadOffers(offers =>
            {
                this.offerAdapter = new OfferListAdapter(this, offers);

                this.offersList.Adapter = offerAdapter;
                this.offersList.ItemClick += OffersList_ItemClick;
            });
        }

        private void OffersList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var selectedOffer = this.offerAdapter.GetOffer(e.Position);

            var intent = new Intent(this, typeof(DeviceCreationActivity));

            intent.PutExtra("OfferId", selectedOffer.Id.ToString());
            intent.PutExtra("OfferDescription", selectedOffer.Label);
            intent.PutExtra("OfferPrice", selectedOffer.Price.ToString("N2"));
            intent.PutExtra("OfferQuantity", selectedOffer.Quantity.ToString("N0"));
            intent.PutExtra("MerchantName", this.merchantName);

            StartActivity(intent);
        }
    }
}