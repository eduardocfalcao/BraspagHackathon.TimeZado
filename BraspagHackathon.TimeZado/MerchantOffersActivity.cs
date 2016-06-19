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

            var offers = service.GetAll();

            var offersFormatted = offers.Select(o => string.Format("{0} - {1}", o.Label, o.Description)).ToArray();

            var adapter = new ArrayAdapter<string>(this, Resource.Layout.OfferListTemplate, offersFormatted);

            this.offersList.Adapter = adapter;
        }
    }
}