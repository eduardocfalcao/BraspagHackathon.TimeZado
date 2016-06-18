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

namespace BraspagHackathon.TimeZado.Model
{
    public class MerchantCredentials
    {
        public const string MerchantId = "FCF8CB06-0D89-400D-B43E-6D67BB5361AB";

        public const string MerchantKey = "oEQ9eccdQn390f0UiRaaAKa4qtGwMmLoBE8Bdxvf";

        public static Guid MerchantIdGuid { get { return Guid.Parse(MerchantId); } }
    }
}