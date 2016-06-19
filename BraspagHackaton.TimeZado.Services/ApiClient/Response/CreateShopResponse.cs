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

namespace BraspagHackaton.TimeZado.Services.ApiClient.Response
{
    public class CreateShopResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public int Status { get; set; }
    }
}