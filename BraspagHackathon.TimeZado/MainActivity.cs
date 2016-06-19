using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using BraspagHackaton.TimeZado.Model;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackathon.TimeZado.Adpaters;
using BraspagHackaton.TimeZado.Services.ApiClient;
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Time Zado App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private DeviceListAdapter deviceListAdapter;

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
                deviceListAdapter = new DeviceListAdapter(this, DataHolder.Devices);
                devicesList.Adapter = deviceListAdapter;
            }

            devicesList.ItemClick += DevicesList_ItemClick;
        }

        protected override void OnResume()
        {
            base.OnResume();

            CreateDevicesList();
        }

        private void DevicesList_ItemClick(object sender, AdapterView.ItemClickEventArgs args)
        {
            var shopApiClient = new ShopApiClient();
            var deviceDisplayData = deviceListAdapter.GetDevice(args.Position);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Confirmar compra");
            alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alertDialog.SetMessage(string.Format("Deseja efetivar a compra do produto {0} ?", deviceDisplayData.OfferName));
            alertDialog.SetButton("Confirmar", async (s, e) =>
            {
                alertDialog.Hide();
                var request = new CreateShopRequest()
                {
                    DeviceId = deviceDisplayData.Device.Id
                };

                var result = await shopApiClient.Post(request);
                string message;

                if (result.Success)
                    message = "Compra efetuada com sucesso.";
                else
                    message = "Aconteceu um erro ao tentar efetivar a compra.";

                var t = Toast.MakeText(this, message, ToastLength.Short);
                t.Show();

                alertDialog.Cancel();
                alertDialog.Dismiss();
            });

            alertDialog.SetButton2("Cancelar", (s, e) =>
            {
                alertDialog.Dismiss();
            });

            alertDialog.Show();
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

