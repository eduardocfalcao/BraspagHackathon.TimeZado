using System;
using System.Collections.Generic;
using Android.Locations;
using Java.Util;

namespace BraspagHackathon.TimeZado.Services
{
    public class MerchantAddressDictionary : Dictionary<Guid, Address>
    {
        public MerchantAddressDictionary()
        {
            this.Add(new Guid("d1eda4d8-908e-4886-a1a5-406645ab7de5"), 
                new Address(new Locale("pt_BR"))
                {
                    CountryCode = "BR",
                    CountryName = "Brazil",
                    FeatureName = "Bardana",
                    Latitude = -22.9091454,
                    Longitude = -43.1735433,
                    PostalCode = "20020-040"
                });

            this.Add(new Guid("afc43697-cdfb-42ef-9ab0-a10b060d299c"),
                new Address(new Locale("pt_BR"))
                {
                    CountryCode = "BR",
                    CountryName = "Brazil",
                    FeatureName = "MISTER PIZZA",
                    Latitude = -22.9093883,
                    Longitude = -43.1714095,
                    PostalCode = "20021-120"
                });

            this.Add(new Guid("cc4526e1-dc79-425c-b0ec-5a1875430ef0"),
                new Address(new Locale("pt_BR"))
                {
                    CountryCode = "BR",
                    CountryName = "Brazil",
                    FeatureName = "Edificio Magnus",
                    Latitude = -22.9099269,
                    Longitude = -43.1716026,
                    PostalCode = "20021-060"
                });

            this.Add(new Guid("fcf8cb06-0d89-400d-b43e-6d67bb5361ab"),
                new Address(new Locale("pt_BR"))
                {
                    CountryCode = "BR",
                    CountryName = "Brazil",
                    FeatureName = "Restaurante da Tia",
                    Latitude = -22.9097943,
                    Longitude = -43.1720156,
                    PostalCode = "20020-200"
                });
        }
    }
}