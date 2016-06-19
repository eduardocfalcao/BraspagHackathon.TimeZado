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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MerchantOffers);

            this.offersList = FindViewById<ListView>(Resource.Id.OffersList);

            this.merchantId = Guid.Parse(Intent.GetStringExtra("MerchantId"));

            DisplayMerchantOffers();
        }

        private void DisplayMerchantOffers()
        {
            var service = new MerchantOffersService(this.merchantId);

            service.LoadOffers(offers =>
            {
                var adapter = new OfferListAdapter(this, offers);

                this.offersList.Adapter = adapter;
            });
        }
    }
}