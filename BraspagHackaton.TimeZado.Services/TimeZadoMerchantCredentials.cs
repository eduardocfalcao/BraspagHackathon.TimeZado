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
using Java.Util;

namespace BraspagHackathon.TimeZado.Services
{
    public static class MerchantCredentials
    {
        public const string MerchantId = "FCF8CB06-0D89-400D-B43E-6D67BB5361AB";

        public const string MerchantKey = "oEQ9eccdQn390f0UiRaaAKa4qtGwMmLoBE8Bdxvf";

        public static Address MerchantAddress
        {
            get
            {
                return new Address(new Locale("pt_BR"))
                {
                    CountryCode = "BR",
                    CountryName = "Brazil",
                    FeatureName = "Restaurante da Tia",
                    PostalCode = "20020-200",
                    Thoroughfare = "R. Santa Luzia, 405",
                    Phone = "5521980836100",
                    Latitude = -22.9092358,
                    Longitude = -43.171982
                };
            }
        }

        public static Guid MerchantIdGuid
        {
            get
            {
                return Guid.Parse(MerchantId);
            }
        }
    }
}