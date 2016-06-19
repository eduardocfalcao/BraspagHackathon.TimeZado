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
using Java.Lang;
using BraspagHackathon.TimeZado.Model.Entities;
using Java.Net;
using Android.Graphics;

namespace BraspagHackathon.TimeZado.Adpaters
{
    public class OfferListAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Offer> offers;

        public OfferListAdapter(Activity context, List<Offer> offers)
        {
            this.context = context;
            this.offers = offers;
        }

        public override int Count
        {
            get
            {
                return offers.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return GetOffer(position).Id;
        }

        public Offer GetOffer(int position)
        {
            return offers.ElementAt(position);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().PermitAll().Build();
            StrictMode.SetThreadPolicy(policy);

            var offer = GetOffer(position);

            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.OfferListTemplate, null);
            }
            URL url = new URL(offer.ImageUrl);
            Bitmap bmp = BitmapFactory.DecodeStream(url.OpenConnection().InputStream);

            convertView.FindViewById<TextView>(Resource.Id.OfferInfo_Name).Text = offer.Label;
            convertView.FindViewById<ImageView>(Resource.Id.OfferInfo_Image).SetImageBitmap(bmp);
            convertView.FindViewById<TextView>(Resource.Id.OfferInfo_Description).Text = offer.Description;
            convertView.FindViewById<TextView>(Resource.Id.OfferInfo_Price).Text = offer.Price.ToString();

            return convertView;
        }
    }
}