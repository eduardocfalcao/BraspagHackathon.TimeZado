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
    public class CreditCardCreateResponse
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Token { get; set; }

        public string MaskedValue { get; set; }

        public int CustomerId { get; set; }
    }
}