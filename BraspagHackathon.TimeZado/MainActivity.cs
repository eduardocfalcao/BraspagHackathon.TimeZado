using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using BraspagHackaton.TimeZado.Model;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackathon.TimeZado.Adpaters;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Time Zado App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.OpenManageCardButton);
            Button nearbyMerchantsButton = FindViewById<Button>(Resource.Id.OpenNearbyMerchantsButton);

            button.Click += OpenManageCardsActivity;
            nearbyMerchantsButton.Click += NearbyMerchantsButton_Click;

            CreateDevicesList();
        }

        private void CreateDevicesList()
        {
            ListView devicesList = FindViewById<ListView>(Resource.Id.DeviceList);

            if (DataHolder.Devices != null)
            {
                var deviceAdapter = new DeviceListAdapter(this, DataHolder.Devices);
                devicesList.Adapter = deviceAdapter;
            }

            devicesList.ItemClick += DevicesList_ItemClick;
        }

        protected override void OnResume()
        {
            base.OnResume();

            CreateDevicesList();
        }

        private void DevicesList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenFirstAccessConfigurationActivity()
        {
            var intent = new Intent(this, typeof(FirstAccessConfigurationActivity));
            StartActivity(intent);
        }

        private void NearbyMerchantsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(NearbyMerchantsActivity));
            StartActivity(intent);
        }

        private void OpenManageCardsActivity(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ManageCardActivity));
            StartActivity(intent);
        }
    }
}

