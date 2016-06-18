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

namespace BraspagHackaton.TimeZado.Services.ApiClient.Requests
{
    public class CreditCard
    {
        public string Holder { get; set; }

        public string CardNumer { get; set; }

        public string ValidThru { get; set; }

        public string Cvv { get; set; }

        public int CostumerId { get; set; }
    }
}