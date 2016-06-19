using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackathon.TimeZado.Services;

namespace BraspagHackathon.TimeZado.Adpaters
{
    public class MerchantListAdapter : BaseAdapter
    {
        public MerchantListAdapter(Activity context, List<MerchantGpsData> merchantsGpsData)
        {
            this.merchants = merchantsGpsData;
            this.context = context;
        }

        private List<MerchantGpsData> merchants;
        private Activity context;

        public override int Count
        {
            get
            {
                return this.merchants.Count;
            }
        }

        /// <summary>
        /// Nao usar esse metodo. Usar o GetMerchant.
        /// </summary>
        public override Java.Lang.Object GetItem(int position)
        {
            return null; 
        }

        public MerchantGpsData GetMerchantGpsData(int position)
        {
            return this.merchants.ElementAt(position);
        }

        /// <summary>
        /// Nao usar esse metodo. Usar o GetMerchantId.
        /// </summary>
        public override long GetItemId(int position)
        {
            return 0;
        }

        public Guid GetMerchantId(int position)
        {
            return GetMerchantGpsData(position).Merchant.MerchantId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var merchantGpsData = GetMerchantGpsData(position);

            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.MerchantsListTemplate, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Name).Text = merchantGpsData.Merchant.Name;
            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Description).Text = merchantGpsData.Merchant.Description;
            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Site).Text = merchantGpsData.Merchant.SiteUrl;
            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Address).Text = string.Concat(merchantGpsData.Address.FeatureName, " - ", merchantGpsData.Address.Thoroughfare);

            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Distance).Text = 
                string.Concat("Distância aproximada (em mêtros): "+ ConvertKilometersToMeters(merchantGpsData.DistanceInKilometers));

            return convertView;
        }

        public string ConvertKilometersToMeters(double km)
        {
            return (km * 1000).ToString("N2");
        }
    }
}