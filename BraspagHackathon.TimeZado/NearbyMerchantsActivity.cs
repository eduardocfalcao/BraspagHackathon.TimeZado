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
using BraspagHackathon.TimeZado.Services;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackathon.TimeZado.Adpaters;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Procurar lojas pr�ximas")]
    public class NearbyMerchantsActivity : Activity, ILocationListener
    {
        private Location currentLocation;
        private LocationManager locationManager;
        private TextView locationText;
        private TextView addressText;
        private string locationProvider;
        private MerchantLocatorService merchantLocatorService;
        private ListView nearbyMerchantsList;
        private MerchantListAdapter merchantAdapter;
        private Address currentAddress;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NearbyMerchants);

            this.locationText = FindViewById<TextView>(Resource.Id.Location);
            this.addressText = FindViewById<TextView>(Resource.Id.Address);
            this.nearbyMerchantsList = FindViewById<ListView>(Resource.Id.NearbyMerchantsList);

            this.merchantLocatorService = new MerchantLocatorService();

            InitializeLocationManager();
            DisplayCurrentLocation();
            FindNearbyMerchants();
        }

        private void DisplayCurrentLocation()
        {
            if (this.currentLocation == null)
            {
                this.locationText.Text = "Procurando minha localiza��o...";
                this.addressText.Text = string.Empty;
            }
            else
            {
                this.locationText.Text = string.Format("{0:f6}, {1:f6}", this.currentLocation.Latitude, this.currentLocation.Longitude);

                this.currentAddress = ReverseGeocodeCurrentLocation();

                this.addressText.Text = FormatAddress(this.currentAddress);
            }
        }

        private void FindNearbyMerchants()
        {
            this.merchantLocatorService.GetNearbyMerchants(merchants =>
            {
                this.merchantAdapter = new MerchantListAdapter(this, merchants);
                this.nearbyMerchantsList.Adapter = this.merchantAdapter;
            },
            this.currentAddress);
        }

        private void InitializeLocationManager()
        {
            this.locationManager = (LocationManager)GetSystemService(LocationService);

            var criteria = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
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

        protected override void OnStart()
        {
            base.OnStart();

            // Procura a localiza��o na inicializa��o do aplicativo
            RequestLocationUpdates();
        }

        private void RequestLocationUpdates()
        {
            if (locationProvider != string.Empty)
            {
                this.locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);
            }
            else
            {
                this.locationText.Text = "Nenhum provedor de localiza��o dispon�vel. Certifique-se de que voc� est� conectado � uma conex�o de boa precis�o, como Wi-fi.";
            }
        }

        private void RemoveLocationUpdates()
        {
            this.locationManager.RemoveUpdates(this);
        }

        protected override void OnResume()
        {
            base.OnResume();

            // Ao restaurar o aplicativo do segundo plano, reiniciamos o servi�o de localiza��o
            RequestLocationUpdates();
        }

        protected override void OnPause()
        {
            base.OnPause();

            // Quando o aplicativo entrar em segundo plano, paramos o servi�o de atualiza��o para economizar bateria
            RemoveLocationUpdates();
        }

        public void OnLocationChanged(Location location)
        {
            this.currentLocation = location;
          
            DisplayCurrentLocation();
        }

        private static string FormatAddress(Address address)
        {
            if (address != null)
            {
                var deviceAddress = new StringBuilder();

                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }

                return deviceAddress.ToString();
            }

            return null;
        }

        private Address ReverseGeocodeCurrentLocation()
        {
            var geocoder = new Geocoder(this);

            var addressList = geocoder.GetFromLocation(this.currentLocation.Latitude, this.currentLocation.Longitude, 10);

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