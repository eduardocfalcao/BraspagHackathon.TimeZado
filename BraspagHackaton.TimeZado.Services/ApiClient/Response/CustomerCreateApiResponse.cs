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
    public class CustomerCreateApiResponse
    {

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CreditCardId { get; set; }

        public int AdressId { get; set; }

    }
}