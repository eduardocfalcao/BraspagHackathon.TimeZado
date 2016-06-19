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
using BraspagHackathon.TimeZado.Services;

namespace BraspagHackathon.TimeZado.Adpaters
{
    public class MerchantListAdapter : BaseAdapter
    {
        public MerchantListAdapter(Activity context, List<Merchant> merchants)
        {
            this.merchants = merchants;
            this.context = context;
            this.merchantAddressBookService = new MerchantAddressBookService();
        }

        private List<Merchant> merchants;
        private Activity context;
        private MerchantAddressBookService merchantAddressBookService;

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

        public Merchant GetMerchant(int position)
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
            return GetMerchant(position).MerchantId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var merchant = GetMerchant(position);

            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.MerchantsListTemplate, null);
            }
            var address = this.merchantAddressBookService.Get(merchant);

            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Name).Text = merchant.Name;
            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Description).Text = merchant.Description;
            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Site).Text = merchant.SiteUrl;
            convertView.FindViewById<TextView>(Resource.Id.MerchantInfo_Address).Text = string.Concat(address.FeatureName,
                                                                                                      " - ",
                                                                                                      address.Thoroughfare);

            return convertView;
        }
    }
}