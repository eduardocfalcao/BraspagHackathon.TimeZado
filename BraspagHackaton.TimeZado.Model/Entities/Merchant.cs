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

namespace BraspagHackathon.TimeZado.Model.Entities
{
    public class Merchant
    {
        public Guid MerchantId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string MerchantKey { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SiteUrl { get; set; }

        public string ImageUrl { get; set; }

        public bool IsEnabled { get; set; }
    }
}