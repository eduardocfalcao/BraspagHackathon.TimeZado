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
        }
    }
}