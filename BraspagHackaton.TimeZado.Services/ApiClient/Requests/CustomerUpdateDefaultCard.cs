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
    public class CustomerUpdateDefaultCard
    {

        public int CustomerId { get; set; }

        public int CreditCardId { get; set; }

    }
}