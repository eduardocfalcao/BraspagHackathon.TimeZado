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
using Android.Locations;
using System.Threading.Tasks;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Procurar lojas próximas")]
    public class NearbyMerchantsActivity : Activity, ILocationListener
    {
        private Location currentLocation;
        private LocationManager locationManager;
        private TextView locationText;
        private TextView addressText;
        string locationProvider;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NearbyMerchants);

            this.locationText = FindViewById<TextView>(Resource.Id.Location);
            this.addressText = FindViewById<TextView>(Resource.Id.Address);

            InitializeLocationManager();
        }

        private void InitializeLocationManager()
        {
            this.locationManager = (LocationManager)GetSystemService(LocationService);

            var criteria = new Criteria
            {
                Accuracy = Accuracy.Medium
            };

            var providers = this.locationManager.GetProviders(criteria, true);

            if (providers.Any())
            {
                this.locationProvider = providers.First();
            }
            else
            {
                this.locationProvider = string.Empty;
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            // Ao restaurar o aplicativo do segundo plano, reiniciamos o serviço de localização
            this.locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);
        }

        protected override void OnPause()
        {
            base.OnPause();

            // Quando o aplicativo entrar em segundo plano, paramos o serviço de atualização para economizar bateria
            this.locationManager.RemoveUpdates(this);
        }

        public async void OnLocationChanged(Location location)
        {
            this.currentLocation = location;

            if (this.currentLocation == null)
            {
                this.locationText.Text = "Impossível determinar sua localização. Tente novamente depois de um tempo.";
                this.addressText.Text = string.Empty;
            }
            else
            {
                this.locationText.Text = string.Format("{0:f6}, {1:f6}", location.Latitude, location.Longitude);

                var address = await ReverseGeocodeCurrentLocation();

                DisplayAddress(address);
            }
        }

        private void DisplayAddress(Address address)
        {
            if (address != null)
            {
                var deviceAddress = new StringBuilder();

                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }

                this.addressText.Text = deviceAddress.ToString();
            }
        }

        private async Task<Address> ReverseGeocodeCurrentLocation()
        {
            var geocoder = new Geocoder(this);

            var addressList = await geocoder.GetFromLocationAsync(this.currentLocation.Latitude, this.currentLocation.Longitude, 1);

            return addressList.FirstOrDefault();
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
    }
}