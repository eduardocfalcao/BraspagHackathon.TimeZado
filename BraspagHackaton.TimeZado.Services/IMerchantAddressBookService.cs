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
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado.Services
{
    public interface IMerchantAddressBookService
    {
        Address Get(Merchant merchant);

        void Set(Address address, Merchant merchant);
    }
}