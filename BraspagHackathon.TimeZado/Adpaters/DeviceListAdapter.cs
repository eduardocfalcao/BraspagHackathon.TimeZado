using System;
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
                throw new NotImplementedException();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }
    }
}