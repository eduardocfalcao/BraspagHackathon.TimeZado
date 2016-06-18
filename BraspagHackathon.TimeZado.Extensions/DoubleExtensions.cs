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

namespace BraspagHackathon.TimeZado.Extensions
{
    public static class DoubleExtensions
    {
        public static double ToRadians(this double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}