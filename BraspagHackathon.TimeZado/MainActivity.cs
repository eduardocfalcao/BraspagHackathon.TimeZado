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

            var dataProvider = InMemoryDataProvider.GetDataProvider();

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.OpenManageCardButton);
            Button nearbyMerchantsButton = FindViewById<Button>(Resource.Id.OpenNearbyMerchantsButton);

            button.Click += OpenManageCardsActivity;
            nearbyMerchantsButton.Click += NearbyMerchantsButton_Click;

            CreateDevicesList(dataProvider);
        }

        private void CreateDevicesList(InMemoryDataProvider dataProvider)
        {
            ListView devicesList = FindViewById<ListView>(Resource.Id.DeviceList);

            var devices = dataProvider.Read<DeviceDisplayData>();

            if (devices != null)
            {
                deviceListAdapter = new DeviceListAdapter(this, devices);
                devicesList.Adapter = deviceListAdapter;
            }

            devicesList.ItemClick += DevicesList_ItemClick;
        }

        protected override void OnResume()
        {
            base.OnResume();

            var dataProvider = InMemoryDataProvider.GetDataProvider();
            CreateDevicesList(dataProvider);
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
                
                AlertDialog successDialog = builder.Create();
                successDialog.SetTitle("Confirmação de compra");
                successDialog.SetIcon(Android.Resource.Drawable.DialogFrame);
                successDialog.SetMessage(message);
                successDialog.SetButton("Ok", (s2, e2) =>
                {
                    successDialog.Dismiss();
                });

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

