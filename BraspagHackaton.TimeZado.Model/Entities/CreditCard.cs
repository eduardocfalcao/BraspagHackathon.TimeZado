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
    public class CreditCard
    {

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Token { get; set; }

        public string MaskedValue { get; set; }

        public int CostumerId { get; set; } //campo é necessário mesmo???
    }
}