using System;
using System.Linq;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado.Adpaters
{
    public class DeviceListAdapter : BaseAdapter
    {
        private Activity context;
        private List<DeviceDisplayData> devices;

        public DeviceListAdapter(Activity context, List<DeviceDisplayData> devices)
        {
            this.context = context;
            this.devices = devices;
        }
        
        public override int Count
        {
            get
            {
                return this.devices.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public Guid GetDeviceId(int position)
        {
            return GetDevice(position).Device.Id;
        }

        public DeviceDisplayData GetDevice(int position)
        {
            return this.devices.ElementAt(position);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var deviceDisplayData = GetDevice(position);

            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.DeviceListTemplate, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.DeviceInfo_Description).Text = deviceDisplayData.OfferName;
            convertView.FindViewById<TextView>(Resource.Id.DeviceInfo_MerchantName).Text = deviceDisplayData.MerchantName;
            convertView.FindViewById<TextView>(Resource.Id.DeviceInfo_Price).Text = deviceDisplayData.Price;
            convertView.FindViewById<TextView>(Resource.Id.DeviceInfo_Quantity).Text = deviceDisplayData.Quantity;

            return convertView;
        }
    }
}